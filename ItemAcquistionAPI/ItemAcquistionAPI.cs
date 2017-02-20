using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemAcquistionAPI {
	public static class ItemAcquistionAPI {

		private static Dictionary<Item,ItemRecipe> allItems = new Dictionary<Item, ItemRecipe>();

		/// <summary>
		/// Adds a new item
		/// </summary>
		/// <param name="name">The name of the item to add</param>
		/// <param name="comment">The comment for the item</param>
		/// <returns></returns>
		public static ReturnCode createItem(String name, string comment = "") {
			//check if name already exists
			Item newItem = new Item(name, comment);
			if (allItems.ContainsKey(newItem))
				return ReturnCode.ERROR_ITEM_ALREADY_EXISTS;
			allItems.Add(newItem,null);
			if (allItems.ContainsKey(newItem))
				return ReturnCode.SUCCESS;
			return ReturnCode.ERROR;
		}

		public static ReturnCode addRecipe(Item itemToAddRecipeTo, bool overrideExisting =false, params RecipeIngredient[] ri) {
			if (!allItems.ContainsKey(itemToAddRecipeTo))
				return ReturnCode.ERROR_NO_ITEM_FOUND;
			if (allItems[itemToAddRecipeTo] != null && overrideExisting == false)
				return ReturnCode.ERROR_ITEM_ALREADY_HAS_RECIPE;
			ItemRecipe ir = new ItemRecipe(itemToAddRecipeTo);
			for(int i = 0; i < ri.Length; i++) {
				Item foundItem = null;
				for(int x = 0; x < allItems.Count; x++) {
					if(allItems.ElementAt(x).Key.name == ri[i].name) {
						foundItem = allItems.ElementAt(x).Key;
						break;
					}
				}
				if (foundItem == null)
					return ReturnCode.ERROR_NO_ITEM_FOUND;

				ir.addItem(foundItem, ri[i].quantity);
			}
			allItems[itemToAddRecipeTo] = ir;
			if (allItems[itemToAddRecipeTo] != null)
				return ReturnCode.SUCCESS;
			return ReturnCode.ERROR;
		}
	}
}
