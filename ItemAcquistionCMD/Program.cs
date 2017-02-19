using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemAcquistionCMD {
	class Program {
		static void Main(string[] args) {
			ItemAcquistionAPI.Item ia = new ItemAcquistionAPI.Item();
			ia.name = "a";
			ia.numberRequired = 1;

			ItemAcquistionAPI.Item ia1 = new ItemAcquistionAPI.Item();
			ia1.name = "a1";
			ia1.numberRequired = 1;

			ItemAcquistionAPI.Item ia2 = new ItemAcquistionAPI.Item();
			ia2.name = "a2";
			ia2.numberRequired = 1;

			ItemAcquistionAPI.Item ia3 = new ItemAcquistionAPI.Item();
			ia3.name = "a3";
			ia3.numberRequired = 1;

			ItemAcquistionAPI.Item ia31 = new ItemAcquistionAPI.Item();
			ia31.name = "a3-1";
			ia31.numberRequired = 1;

			ItemAcquistionAPI.Item ia11 = new ItemAcquistionAPI.Item();
			ia11.name = "a3-1";
			ia11.numberRequired = 1;

			ia.requiredItems.Add(ia1);
			ia.requiredItems.Add(ia2);
			ia.requiredItems.Add(ia3);
			ia3.requiredItems.Add(ia31);
			ia1.requiredItems.Add(ia11);

			Console.WriteLine(ia.getAllItems().ToString());
			Console.Read();
		}
	}
}
