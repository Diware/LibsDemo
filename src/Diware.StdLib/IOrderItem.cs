using System;
using System.Collections.Generic;
using System.Text;

namespace Diware.SL
{
	public interface IOrderItem
	{
		string ItemName { get; }

		bool Descending { get; }
	}
}
