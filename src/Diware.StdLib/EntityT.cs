using System;

namespace Diware.SL
{
	public abstract class Entity<TId>
		: Entity<TId, Entity<TId>>
	{ }


	public abstract class Entity<TId, T>
		: IEntity<TId, T> where T : Entity<TId, T>
	{

		/// <summary>
		/// A reference to self as to an instance of <see cref="IEntity{TId, TEntity}"/>.
		/// </summary>
		protected IEntity<TId, T> _IEntity;

		/// <summary>
		/// Initializes a new instance of the <see cref="Entity{TId, T}"/> class.
		/// </summary>
		protected Entity()
		{
			_IEntity = this;
		}


		TId IEntity<TId>.Id { get; set; }

		
		/// <summary>
		/// Equalses the specified other.
		/// </summary>
		/// <param name="other">The other.</param>
		/// <returns></returns>
		bool IEquatable<T>.Equals(T other) => Equals(other);


		/// <inheritdoc cref="Helpers.SetString(string)" />
		protected string SetString(string value) => Helpers.SetString(value);


		/// <inheritdoc cref="Helpers.SetString(string, int)" />
		protected string SetString(string value, int maxLength)
			=> Helpers.SetString(value, maxLength);


		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode()
		{
			return _IEntity.Id?.GetHashCode() ?? 0;
		}


		/// <summary>
		/// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
		/// <returns>
		///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			if (obj is Entity<TId, T> other)
			{
				return this == other;
			}

			return false;
		}


		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="a">a.</param>
		/// <param name="b">The b.</param>
		/// <returns>
		/// The result of the operator.
		/// </returns>
		public static bool operator ==(Entity<TId, T> a, Entity<TId, T> b)
		{
			if (ReferenceEquals(a, b)) return true;
			if (ReferenceEquals(a, null) 
				|| ReferenceEquals(b, null)) return false;

			return Equals(a._IEntity.Id, b._IEntity.Id);
		}


		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="a">a.</param>
		/// <param name="b">The b.</param>
		/// <returns>
		/// The result of the operator.
		/// </returns>
		public static bool operator !=(Entity<TId, T> a, Entity<TId, T> b)
		{
			return !(a == b);
		}

	}
}
