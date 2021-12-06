using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using xa = Xunit.Assert;

namespace Diware.SL.UnitTests.EntityT
{
	public class GetHashCodeTestsWithSpecificClasses
	{

		[Fact]
		public void DifferentId_Int()
		{
			JustTestBaseDiffersInId<int>(1, 2);
		}


		[Fact]
		public void SameId_Int()
		{
			JustTestBaseSameId<int>(1);
		}


		private void JustTestBaseDiffersInId<T>(T id1, T id2)
		{
			var a = new JustEntity<T>();
			a.MyId = id1;
			a.Payload = 100;

			var b = new JustEntity<T>();
			b.MyId = id2;
			b.Payload = 100;

			int hashA = a.GetHashCode();
			int hashB = b.GetHashCode();

			xa.NotEqual(hashA, hashB);
		}


		private void JustTestBaseSameId<T>(T id)
		{
			var a = new JustEntity<T>();
			a.MyId = id;
			a.Payload = 100;

			var b = new JustEntity<T>();
			b.MyId = id;
			b.Payload = 200;

			int hashA = a.GetHashCode();
			int hashB = b.GetHashCode();

			xa.Equal(hashA, hashB);
		}
	}
}
