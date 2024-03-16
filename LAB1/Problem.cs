namespace LAB1Malinowski {
    public class Problem {
        public List<Item> items;
        IEnumerable<Item> ordered;
        Result knapsack;

        public void GenerateItems(int itemAmount, int seed) {
            items = new List<Item>();
            Random random = new Random(seed);
            for (int i = 0; i < itemAmount; i++) {
                Item item = new Item();
                item.ID = i;
                item.weight = random.Next(1, 10);
                item.value = random.Next(1, 10);
                item.effectiveValue = (float)item.value / (float)item.weight;
                items.Add(item);
            }
        }

        public void sortItems() {
            ordered = items.OrderByDescending(item => item.effectiveValue);
        }

        public Result stealItems(int maxWeight) {
            knapsack = new Result(maxWeight);
            foreach (Item item in ordered) {
                if(knapsack.totalWeight == knapsack.maxWeight) {break; }
                if (knapsack.totalWeight + item.weight <= knapsack.maxWeight) {
                    knapsack.stolenItems.Add(item);
                    knapsack.totalWeight += item.weight;
                    knapsack.totalValue += item.value;
                }
            }
            return knapsack;
        }

        public void ViewItems()
        {
            Console.WriteLine("All items: ");
            foreach (Item item in items)
            {
                Console.WriteLine("ID: " + item.ID + " Value: " + item.value + " Weight: " + item.weight);
            }
        }

        public Result Solve(TerminalInput input) {
            Result knapsack = new Result();
            GenerateItems(input.itemAmount, input.seed);
            sortItems();
            knapsack = stealItems(input.maxWeight);
            return knapsack;
        }

    }
}

