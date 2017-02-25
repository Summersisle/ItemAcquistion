using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemAcquistionAPI {
	public static class ItemAcquistionAPI {
		private static System.Globalization.TextInfo ti = System.Globalization.CultureInfo.CurrentCulture.TextInfo;
		private static Dictionary<Item,ItemRecipe> allItems = new Dictionary<Item, ItemRecipe>();

		/// <summary>
		/// Adds a new item
		/// </summary>
		/// <param name="name">The name of the item to add</param>
		/// <param name="comment">The comment for the item</param>
		/// <returns></returns>
		public static ReturnCode createItem(String iName, string comment = "") {
			Item itemToAdd = null;
			String itemToAddName = returnProperName(iName);
			for (int x = 0; x < allItems.Count; x++) {
				if (allItems.ElementAt(x).Key.name == itemToAddName) {
					itemToAdd = allItems.ElementAt(x).Key;
					break;
				}
			}
			if (itemToAdd != null)
				return ReturnCode.ERROR_ITEM_ALREADY_EXISTS;
			itemToAdd = new Item(itemToAddName, comment);
			allItems.Add(itemToAdd, null);
			if (allItems.ContainsKey(itemToAdd))
				return ReturnCode.SUCCESS;
			return ReturnCode.ERROR;
		}

		public static string viewRequiredItems(string selection) {
			String itemToViewName = returnProperName(selection);
			Item itemToView = findItem(itemToViewName);
			String output = "";
			output += "Item Name: " + itemToView.name + Environment.NewLine;
			output += "Comment: " + itemToView.comment + Environment.NewLine;
			output += "Recipe requires these items" + Environment.NewLine;
			int counter = 1;
			foreach (var recipe in allItems[itemToView].requiredItems) {
				output += "Item" + counter + ": " + recipe.Key.name +" Number Required: " + recipe.Value + Environment.NewLine;
			}
			return output;
		}

		public static ReturnCode addRecipe(String iName, int nOfItemsCreated, params KeyValuePair<String, int>[] recipeIng) {
			String itemToAddRecipeToName = returnProperName(iName);
			Item itemToAddRecipeTo = findItem(itemToAddRecipeToName);
			if (itemToAddRecipeTo == null)
				return ReturnCode.ERROR_NO_ITEM_FOUND;
			if (allItems[itemToAddRecipeTo] != null)
				return ReturnCode.ERROR_ITEM_ALREADY_HAS_RECIPE;

			ItemRecipe ir = new ItemRecipe(itemToAddRecipeTo);
			foreach (var recipeName in recipeIng) {
				Item tmpItem = findItem(recipeName.Key);
				if (tmpItem == null)
					return ReturnCode.ERROR_NO_ITEM_FOUND;
				ir.addItem(tmpItem, recipeName.Value);
			}
			allItems[itemToAddRecipeTo] = ir;
			allItems[itemToAddRecipeTo].numberOfItemsCreated = nOfItemsCreated;
			if (allItems[itemToAddRecipeTo] != null)
				return ReturnCode.SUCCESS;
			return ReturnCode.ERROR;
		}

		public static void getAllItems() {

		}

		private static Item findItem(String nameOfItemToFind) {
			Item foundItem = null;
			for (int x = 0; x < allItems.Count; x++) {
				if (allItems.ElementAt(x).Key.name == nameOfItemToFind) {
					foundItem = allItems.ElementAt(x).Key;
					break;
				}
			}
			return foundItem;
		}
		private static string returnProperName(string name) {
			return ti.ToTitleCase(name);
		}
	}
}
