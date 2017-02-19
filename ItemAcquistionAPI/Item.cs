using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemAcquistionAPI {
	public class Item {
		public String name;
		public int count;
		public List<Item> requiredItems = new List<Item>();
		public String comment;

		public List<Item> getAllItems() {
			List<Item> allItems = this.getItems();
			for (int i = 0; i < allItems.Count; i++) {
				Item tmpItem = allItems[i];
				allItems.RemoveAt(i);
				for(int g = 0; g< allItems.Count; g++) {
					if(tmpItem.name == allItems[g].name) {
						tmpItem.count = +allItems[g].count;
						allItems.RemoveAt(g);
					}
				}
				allItems.Add(tmpItem);
			}
			return allItems;
		}

		private List<Item> getItems() {
			List<Item> allItems = new List<Item>();
			for (int i = 0; i < requiredItems.Count; i++) {
				allItems.Add(requiredItems[i]);
				allItems.AddRange(requiredItems[i].getItems());
			}

			return allItems;
		}

		public String toString() {
			return name;
		}
	}
}
