using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using xa = Xunit.Assert;

namespace Diware.SL.UnitTests.ValueObjectT
{
	public class EqualsTestsWithSpecificClasses
	{

		[Fact]
		public void JustInt()
		{
			var a1 = new JustInt();
			var a2 = new JustInt();

			a1.P = 12;
			a2.P = 12;

			a1.F = 12;
			a2.F = 12;

			xa.Equal(a1, a2);
		}


		[Fact]
		public void StringsArray()
		{
			var a1 = new StringsArray();
			var a2 = new StringsArray();

			a1.P = new string[] { "a", "b", "c" };
			a2.P = new string[] { "a", "b", "c" };

			a1.F = new string[] { "a", "b", "c" };
			a2.F = new string[] { "a", "b", "c" };

			xa.Equal(a1, a2);
		}


		[Fact]
		public void StringsList()
		{
			var a1 = new StringsList();
			var a2 = new StringsList();

			a1.P = new List<string>() { "a", "b", "c" };
			a2.P = new List<string>() { "a", "b", "c" };

			a1.F = new List<string>() { "a", "b", "c" };
			a2.F = new List<string>() { "a", "b", "c" };

			xa.Equal(a1, a2);
		}


		[Fact]
		public void IntsArray()
		{
			var a1 = new IntsArray();
			var a2 = new IntsArray();

			a1.P = new int[] { 1, 2, 3 };
			a2.P = new int[] { 1, 2, 3 };

			a1.F = new int[] { 1, 2, 3 };
			a2.F = new int[] { 1, 2, 3 };

			xa.Equal(a1, a2);
		}


		[Fact]
		public void IntsList()
		{
			var a1 = new IntsList();
			var a2 = new IntsList();

			a1.P = new List<int>() { 1, 2, 3 };
			a2.P = new List<int>() { 1, 2, 3 };

			a1.F = new List<int>() { 1, 2, 3 };
			a2.F = new List<int>() { 1, 2, 3 };

			xa.Equal(a1, a2);
		}


		[Fact]
		public void MixedArray()
		{
			var a1 = new MixedArray();
			var a2 = new MixedArray();

			a1.P = new object[] { "a", 1, "c" };
			a2.P = new object[] { "a", 1, "c" };

			a1.F = new object[] { "a", 1, "c" };
			a2.F = new object[] { "a", 1, "c" };

			xa.Equal(a1, a2);
		}


		[Fact]
		public void MixedList()
		{
			var a1 = new MixedList();
			var a2 = new MixedList();

			a1.P = new List<object>() { "a", 1, "c" };
			a2.P = new List<object>() { "a", 1, "c" };

			a1.F = new List<object>() { "a", 1, "c" };
			a2.F = new List<object>() { "a", 1, "c" };

			xa.Equal(a1, a2);
		}


		[Fact]
		public void MixedMultiLevel()
		{
			var a1 = new MixedArray();
			var a2 = new MixedArray();

			a1.P = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z"
					}
				}
			};
			a2.P = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z"
					}
				}
			};

			a1.F = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z"
					}
				}
			};
			a2.F = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z"
					}
				}
			};

			xa.Equal(a1, a2);
		}


		[Fact]
		public void MixedMultiLevelDifferent()
		{
			var a1 = new MixedArray();
			var a2 = new MixedArray();

			a1.P = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z1"
					}
				}
			};
			a2.P = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z2"
					}
				}
			};

			a1.F = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z1"
					}
				}
			};
			a2.F = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z2"
					}
				}
			};

			xa.NotEqual(a1, a2);
		}

		[Fact]
		public void MixedMultiLevelDifferentProperty()
		{
			var a1 = new MixedArray();
			var a2 = new MixedArray();

			a1.P = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z1"
					}
				}
			};
			a2.P = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z2"
					}
				}
			};

			a1.F = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z"
					}
				}
			};
			a2.F = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z"
					}
				}
			};

			xa.NotEqual(a1, a2);
		}


		[Fact]
		public void MixedMultiLevelDifferentField()
		{
			var a1 = new MixedArray();
			var a2 = new MixedArray();

			a1.P = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z"
					}
				}
			};
			a2.P = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z"
					}
				}
			};

			a1.F = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z1"
					}
				}
			};
			a2.F = new object[] {
				"a",
				1,
				"c",
				new object[] {
					100,
					200,
					300,
					new List<string>() {
						"x",
						"y",
						"z2"
					}
				}
			};

			xa.NotEqual(a1, a2);
		}
	}

	class JustInt : ValueObject<JustInt>
	{
		public int F;
		public int P { get; set; }
	}

	class StringsArray : ValueObject<StringsArray>
	{
		public string[] F;
		public string[] P { get; set; }
	}

	class StringsList : ValueObject<StringsList>
	{
		public List<string> F;
		public List<string> P { get; set; }
	}

	class IntsArray : ValueObject<IntsArray>
	{
		public int[] F;
		public int[] P { get; set; }
	}

	class IntsList : ValueObject<IntsList>
	{
		public List<int> F;
		public List<int> P { get; set; }
	}

	class MixedArray : ValueObject<MixedArray>
	{
		public object[] F;
		public object[] P { get; set; }
	}

	class MixedList : ValueObject<MixedList>
	{
		public List<object> F;
		public List<object> P { get; set; }
	}
}
