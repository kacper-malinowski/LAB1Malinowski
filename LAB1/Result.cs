using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1Malinowski {
    public class Result {
        public List<Item> stolenItems;
        public int maxWeight;
        public int totalValue = 0;
        public int totalWeight = 0;


        public Result() {
            stolenItems = new List<Item>(); // Inicjalizacja listy
        }

        public Result(int var) {
            stolenItems = new List<Item>();
            maxWeight = var;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Stolen items:");
            foreach (var item in stolenItems) {
                sb.AppendLine("ID: " + item.ID + " Value: " + item.value + " Weight: " + item.weight);
            }
            sb.AppendLine("Total value: " + totalValue + " Total weight: " + totalWeight + " Max weight: " + maxWeight);
            return sb.ToString();
        }
    }
}