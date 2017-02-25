using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemAcquistionCMD {
	class Program {
		static void Main(string[] args) {

			for (;;){
				Console.WriteLine("What would you like to do?");
				string selection = Console.ReadLine().ToLower();
				if (selection == "exit")
					exit();
				if (selection == "add")
					add();
				if(selection == "query")
					query();
				if (selection == "modify")
					modify();
				if(selection == "inital")
					inital();
				if (selection == "load")
					load();
				if (selection == "save")
					save();
				if (selection == "view")
					view();
			}
		}

		private static void view() {
			Console.WriteLine("What item would you like to view?");
			string selection = Console.ReadLine().ToLower();
			Console.Write(ItemAcquistionAPI.ItemAcquistionAPI.viewRequiredItems(selection));
		}

		private static void save() {
			throw new NotImplementedException();
		}

		private static void load() {
			throw new NotImplementedException();
		}

		private static void inital() {
			ItemAcquistionAPI.ItemAcquistionAPI.createItem("Iron Ignot", "Created in a Furance");
			ItemAcquistionAPI.ItemAcquistionAPI.createItem("Iron Ore", "Mined with a Stone Pickaxe");
			ItemAcquistionAPI.ItemAcquistionAPI.createItem("Stick");
			ItemAcquistionAPI.ItemAcquistionAPI.createItem("Wood Planks");
			ItemAcquistionAPI.ItemAcquistionAPI.createItem("Wood");
			ItemAcquistionAPI.ItemAcquistionAPI.createItem("Iron Sword");
			ItemAcquistionAPI.ItemAcquistionAPI.addRecipe("Iron Sword", 1, new KeyValuePair<string, int>[] {
				new KeyValuePair<string, int>("Iron Ignot", 2),
				new KeyValuePair<string, int>("Stick", 1)
			});
			ItemAcquistionAPI.ItemAcquistionAPI.addRecipe("Iron Ignot", 1, new KeyValuePair<string, int>[] {
				new KeyValuePair<string, int>("Iron Ore", 2)
			});
			ItemAcquistionAPI.ItemAcquistionAPI.addRecipe("Stick", 4, new KeyValuePair<string, int>[] {
				new KeyValuePair<string, int>("Wood Planks", 2)
			});
			ItemAcquistionAPI.ItemAcquistionAPI.addRecipe("Wood Planks", 4, new KeyValuePair<string, int>[] {
				new KeyValuePair<string, int>("Wood", 1)
			});
		}

		private static void modify() {
			throw new NotImplementedException();
		}

		private static void query() {
			throw new NotImplementedException();
		}

		private static void add() {
			throw new NotImplementedException();
		}

		private static void exit() {
			Environment.Exit(0);
		}
	}
}
