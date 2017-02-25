using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemAcquistionAPI {
	class ItemRecipe {
		public Dictionary<Item,int> requiredItems = new Dictionary<Item,int>();
		public Item createdItem;
		public int numberOfItemsCreated = 1;

		public ItemRecipe(Item c) {
			createdItem = c;
		}
		
		public void addItem(Item i, int r) {
			requiredItems.Add(i, r);
		}		
	}
}
