using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemAcquistionAPI {
	public class Item: IEquatable<Item> {
		public String name = "";
		public int numberRequired;
		public int numberHave= 0;
		public List<Item> requiredItems = new List<Item>();
		public String comment = "";

		public Item(String n, String c ="") {
			name = n;
			comment = c;
		}

		/// <summary>
		/// Finds and combines the number of items required for this one
		/// </summary>
		/// <returns>returns a list of items that are required for this item</returns>
		public List<Item> getAllItems() {
			List<Item> allItems = this.getItems();
			sortByName(allItems);
			for (int i = 0; i < allItems.Count; i++) {
				Item tmpItem = allItems[i];
				allItems.RemoveAt(i);
				for(int g = 0; g< allItems.Count; g++) {
					if(tmpItem.name == allItems[g].name) {
						tmpItem.numberRequired = tmpItem.numberRequired + allItems[g].numberRequired;
						allItems.RemoveAt(g);
					}
				}
				allItems.Add(tmpItem);
			}
			sortByTrulyRequired(allItems);
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
			return name + " required: " + numberRequired + " have: " + numberHave;
		}
		private void sortByName(List<Item> listToSort) {
			listToSort.Sort(delegate (Item x, Item y) {
				return x.name.CompareTo(y.name);
			});
		}
		private void sortByNumberRequired(List<Item> listToSort) {
			listToSort.Sort(delegate (Item x, Item y) {
				return x.numberRequired.CompareTo(y.numberRequired);
			});
		}
		private void sortByTrulyRequired(List<Item> listToSort) {
			listToSort.Sort(delegate (Item x, Item y) {
				int a = x.numberRequired - x.numberHave;
				int b = y.numberRequired - y.numberHave;
				return b.CompareTo(a);
			});
		} 

		public bool Equals(Item otherItem) {
			return false;
		}
		public override bool Equals(object obj) {
			if (obj == null) return false;
			Item objAsItem = obj as Item;
			if (objAsItem == null) return false;
			else return Equals(objAsItem);
		}
		public override int GetHashCode() {
			return name.GetHashCode();
		}
	}
}
