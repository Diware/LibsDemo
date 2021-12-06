using Diware.SL;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using xa = Xunit.Assert;

namespace Diware.SL.UnitTests.EntityT
{
	public class EqualsTestsWithSpecificClasses
	{

		[Fact]
		public void JustInt()
		{
			JustTestBase<int>(1, 2);
		}


		[Fact]
		public void JustString()
		{
			JustTestBase<string>("1", "2");
		}


		private void JustTestBase<T>(T id1, T id2)
		{
			var a = new JustEntity<T>();
			a.MyId = id1;
			a.Payload = 100;

			var b = new JustEntity<T>();
			b.MyId = id2;
			b.Payload = 100;

			xa.False(a.Equals(b));
		}

	}

}
