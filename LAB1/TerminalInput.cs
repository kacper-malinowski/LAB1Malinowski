using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1Malinowski {
    public class TerminalInput {
        public int itemAmount;
        public int seed;
        public int maxWeight;
        public TerminalInput downloadInput() {
            TerminalInput input = new TerminalInput();

            Console.WriteLine("Enter the amount of items");
            input.itemAmount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the seed");
            input.seed = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the knapsack capacity");
            input.maxWeight = Convert.ToInt32(Console.ReadLine());

            return input;
        }
    }
}
