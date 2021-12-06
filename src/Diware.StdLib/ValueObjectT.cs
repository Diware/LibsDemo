using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace Diware.SL
{

	public abstract class ValueObject<T>
		: IValueObject<T> where T : ValueObject<T>
	{

		#region GetHashCode
		/// <summary>
		/// Since value objects are immutable, this variable is used to store a value
		/// of hash, which is calculated once.
		/// </summary>
		protected int? _hashCode;

		/// <summary>
		/// This function performs real hash calculation.
		/// </summary>
		/// <returns></returns>
		protected virtual int GetHashCodeOnce()
		{
			int rv;

			var props = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
				.Select(o => o.GetValue(this));
			var fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)
				.Select(o => o.GetValue(this));

			unchecked
			{
				rv = props
					.Select(item => item?.GetHashCode() ?? 0)
					.Aggregate(17, (total, nextCode) => total * 23 + nextCode);

				if (props.Count() == 0) rv = 17;
				rv = fields
					.Select(item => item?.GetHashCode() ?? 0)
					.Aggregate(rv, (total, nextCode) => total * 23 + nextCode);
			}

			return rv;
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			if (!_hashCode.HasValue)
			{
				_hashCode = GetHashCodeOnce();
			}

			return _hashCode.Value;
		}
		#endregion


		public override bool Equals(object obj)
		{
			if (ReferenceEquals(obj, null)) return false;

			T other = obj as T;

			return Equals(other);
		}


		public virtual bool Equals(T other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(other, this)) return true;

			Type t = GetType();
			Type otherType = other.GetType();

			if (t != otherType) return false;

			FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public);
			foreach (FieldInfo field in fields)
			{
				object value1 = field.GetValue(other);
				object value2 = field.GetValue(this);

				if (!CompareValues(value1, value2)) return false;
			}

			PropertyInfo[] props = t.GetProperties(BindingFlags.Instance | BindingFlags.Public);
			foreach (PropertyInfo prop in props)
			{
				object value1 = prop.GetValue(other);
				object value2 = prop.GetValue(this);

				if (!CompareValues(value1, value2)) return false;

			}

			return true;
		}


		protected bool CompareValues(object value1, object value2)
		{
			if (value1 == null && value2 == null) return true;
			if (value1 == null && value2 != null
				|| value1 != null && value2 == null) return false;
			// by now we know value1 and value2 are not nulls

			if (value1 is IEnumerable ien1)
			{
				var ien2 = value2 as IEnumerable;
				int count = CountIEnumerable(ien1);

				// return false immediately if ienumerables differ in length
				if (count != CountIEnumerable(ien2, count)) return false;

				var en1 = ien1.GetEnumerator();
				var en2 = ien2.GetEnumerator();

				while (en1.MoveNext())
				{
					en2.MoveNext();
					if (!CompareValues(en1.Current, en2.Current)) return false;
				}
			}
			else
			{
				// return false ONLY if values are different
				if (!value1.Equals(value2)) return false;
			}

			return true;
		}


		public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
		{
            if (ReferenceEquals(x, null))
            {
                return ReferenceEquals(y, null);
            }

            return x.Equals(y);
		}


		public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
		{
			return !(x == y);
		}


		/// <summary>
		/// Calculates numeber of items in <see cref="IEnumerable"/>.
		/// </summary>
		/// <param name="ienumerable"></param>
		/// <returns></returns>
		protected int CountIEnumerable(IEnumerable ienumerable)
		{
			return CountIEnumerable(ienumerable, int.MaxValue);
		}

		protected int CountIEnumerable(IEnumerable ienumerable, int stopCountingAfter)
		{
			int rv = 0;

			/*
			 * Here is the optimization trick:
			 * since this function is used mainly to count items of 
			 * several IEnumerable's and compare those counts to be the same
			 * it is worth to loop-count every non-first IEnumerable until 
			 * its size becomes larger than the size of first IEnumerable.
			 * 
			 * Example: first IEnumerable has size 3, second has real size 100.
			 * Calculation of second will use MoveNext until counter reaches 3+1=4.
			 * 
			 * P.S. if stopCountingAfter is int.MaxValue - there is no point to check
			 * rv <= stopCountingAfter on each loop: run the loop without the check
			 * 
			 */

			var en = ienumerable.GetEnumerator();
			if (stopCountingAfter == int.MaxValue)
			{
				while (en.MoveNext()) rv++;
			}
			else
			{
				while (rv <= stopCountingAfter && en.MoveNext()) rv++;
			}

			return rv;
		}


		protected string SetString(string value) => Helpers.SetString(value);
	}

}
