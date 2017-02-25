using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemAcquistionCMD {
	class Program {
		static void Main(string[] args) {


			ItemAcquistionAPI.ItemAcquistionAPI.createItem("Iron Ignot", "Created in a Furance");
			ItemAcquistionAPI.ItemAcquistionAPI.createItem("Iron Ore","Mined with a Stone Pickaxe");
			ItemAcquistionAPI.ItemAcquistionAPI.createItem("Stick");
			ItemAcquistionAPI.ItemAcquistionAPI.createItem("Wood Planks");
			ItemAcquistionAPI.ItemAcquistionAPI.createItem("Wood");
			ItemAcquistionAPI.ItemAcquistionAPI.createItem("Iron Sword");
			ItemAcquistionAPI.ItemAcquistionAPI.addRecipe("Iron Sword",1, new KeyValuePair < string, int >[] {
				new KeyValuePair<string, int>("Iron Ignot", 2),
				new KeyValuePair<string, int>("Stick", 1)
			});
			ItemAcquistionAPI.ItemAcquistionAPI.addRecipe("Iron Ignot",1, new KeyValuePair<string, int>[] {
				new KeyValuePair<string, int>("Iron Ore", 2)
			});
			ItemAcquistionAPI.ItemAcquistionAPI.addRecipe("Stick",4, new KeyValuePair<string, int>[] {
				new KeyValuePair<string, int>("Wood Planks", 2)
			});
			ItemAcquistionAPI.ItemAcquistionAPI.addRecipe("Wood Planks",4, new KeyValuePair<string, int>[] {
				new KeyValuePair<string, int>("Wood", 1)
			});

			Console.ReadKey();
		}
	}
}
