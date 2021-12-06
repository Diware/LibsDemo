using System;
using System.Collections.Generic;
using System.Text;

namespace Diware.SL
{
	public class OrderItem
		: IOrderItem
	{
		private readonly string itemName;
		private readonly bool isDescending;


		public OrderItem(
			string itemName,
			bool isDescending)
		{
			this.itemName = itemName;
			this.isDescending = isDescending;
		}


		public OrderItem(string itemName) : this(itemName, false) { }


		string IOrderItem.ItemName => itemName;

		bool IOrderItem.Descending => isDescending;
	}
}
