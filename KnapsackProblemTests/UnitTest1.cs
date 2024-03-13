using LAB1Malinowski;

namespace KnapsackProblemTests {
    [TestClass]
    public class UnitTest1 {
        [TestMethod]
        public void CommonInstance() {
            Problem problem = new Problem();
            TerminalInput input = new TerminalInput();
            Result result = new Result();
            input.itemAmount = 20;
            input.maxWeight = 30;
            input.seed = 1;
            problem.GenerateItems(input.itemAmount, input.seed);
            problem.ViewItems();
            problem.sortItems();
            result = problem.stealItems(input.maxWeight);
            Assert.IsTrue(result.stolenItems.Any());
        }

        [TestMethod]
        public void EmptyInstance() {
            Problem problem = new Problem();
            TerminalInput input = new TerminalInput();
            Result result = new Result();
            input.itemAmount = 0;
            input.maxWeight = 30;
            input.seed = 1;
            problem.GenerateItems(input.itemAmount, input.seed);
            problem.ViewItems();
            problem.sortItems();
            result = problem.stealItems(input.maxWeight);
            Assert.IsTrue(!result.stolenItems.Any());
        }

        [TestMethod]
        public void DoesTheItemOrderMatter() {
            Problem problem = new Problem();
            problem.items = new List<Item>();

            Problem problem2 = new Problem();
            problem2.items = new List<Item>();

            TerminalInput input = new TerminalInput();
            Result result = new Result();
            Result result2 = new Result();
            input.maxWeight = 8;


            //For maxWeight = 8, 3 items will fit for total value of 18
            problem.items.AddRange(new List<Item>
            {
                new Item { ID = 4, weight = 4, value = 8, effectiveValue = 2 },
                new Item { ID = 1, weight = 1, value = 6, effectiveValue = 6 },
                new Item { ID = 0, weight = 2, value = 4, effectiveValue = 2 },
                new Item { ID = 3, weight = 2, value = 1, effectiveValue = (float) 0.5 },
                new Item { ID = 2, weight = 2, value = 2, effectiveValue = 1 }, 
            });

            problem.ViewItems();
            problem.sortItems();
            result = problem.stealItems(input.maxWeight);

            problem2.items.AddRange(new List<Item>
            {
                new Item { ID = 0, weight = 2, value = 4, effectiveValue = 2 },
                new Item { ID = 1, weight = 1, value = 6, effectiveValue = 6 },
                new Item { ID = 2, weight = 2, value = 2, effectiveValue = 1 },
                new Item { ID = 3, weight = 2, value = 1, effectiveValue = (float) 0.5 },
                new Item { ID = 4, weight = 4, value = 8, effectiveValue = 2 }
            });
            problem2.ViewItems();
            problem2.sortItems();
            result2 = problem.stealItems(input.maxWeight);

            Assert.AreEqual(result.totalValue, result2.totalValue);
        }

        [TestMethod]
        public void CustomInstance() {
            Problem problem = new Problem();
            problem.items = new List<Item>();
            TerminalInput input = new TerminalInput();
            Result result = new Result();
            input.maxWeight = 8;


            //For maxWeight = 8, 3 items will fit for total value of 18
            problem.items.AddRange(new List<Item>
            {
                new Item { ID = 0, weight = 2, value = 4, effectiveValue = 2 },
                new Item { ID = 1, weight = 1, value = 6, effectiveValue = 6 },
                new Item { ID = 2, weight = 2, value = 2, effectiveValue = 1 },
                new Item { ID = 3, weight = 2, value = 1, effectiveValue = (float) 0.5 },
                new Item { ID = 4, weight = 4, value = 8, effectiveValue = 2 }
            });

            problem.ViewItems();
            problem.sortItems();
            result = problem.stealItems(input.maxWeight);

            Assert.AreEqual(result.totalValue, 18);
        }

        [TestMethod]
        public void NoSpaceInBackpack() {
            Problem problem = new Problem();
            TerminalInput input = new TerminalInput() { itemAmount = 10, maxWeight = 0, seed = 5 };
            Result knapsack = new Result();
            knapsack = problem.Solve(input);
            Assert.AreEqual(knapsack.stolenItems.Count(), 0);
        }

        [TestMethod]
        public void NegativeAmountOfItems() {
            Problem problem = new Problem();
            TerminalInput input = new TerminalInput() { itemAmount = -50, maxWeight = 0, seed = 5 };
            Result knapsack = new Result();
            knapsack = problem.Solve(input);
            Assert.AreEqual(knapsack.stolenItems.Count(), 0);
        }

        [TestMethod]
        public void NoItemsFitBackpack() {
            Problem problem = new Problem();
            Result knapsack = new Result();
            problem.items = new List<Item>();
            TerminalInput input = new TerminalInput();
            Result result = new Result();
            input.maxWeight = 10;

            problem.items.AddRange(new List<Item>
            {
                new Item { ID = 0, weight = 30, value = 4, effectiveValue = (float) 0.133 },
                new Item { ID = 1, weight = 11, value = 6, effectiveValue = (float) 0.545 },
                new Item { ID = 2, weight = 15, value = 2, effectiveValue = (float) 0.133 },
                new Item { ID = 3, weight = 23, value = 1, effectiveValue = (float) 0.043 },
                new Item { ID = 4, weight = 40, value = 8, effectiveValue = (float) 0.2 }
            });

            problem.ViewItems();
            problem.sortItems();
            result = problem.stealItems(input.maxWeight);

            Assert.AreEqual(knapsack.stolenItems.Count(), 0);
        }

        [TestMethod]
        public void BackpackTooLarge() {
            Problem problem = new Problem();
            Result knapsack = new Result();
            problem.items = new List<Item>();
            TerminalInput input = new TerminalInput() { itemAmount = 20, maxWeight = 50, seed = 5 };

            problem.items.AddRange(new List<Item>
            {
                new Item { ID = 0, weight = 1, value = 4, effectiveValue = (float) 4 },
                new Item { ID = 1, weight = 1, value = 6, effectiveValue = (float) 6 },
                new Item { ID = 2, weight = 1, value = 2, effectiveValue = (float) 2 },
                new Item { ID = 3, weight = 1, value = 1, effectiveValue = (float) 1 },
                new Item { ID = 4, weight = 1, value = 8, effectiveValue = (float) 8 },
                new Item { ID = 5, weight = 1, value = 4, effectiveValue = (float) 4 },
                new Item { ID = 6, weight = 1, value = 6, effectiveValue = (float) 6 },
                new Item { ID = 7, weight = 1, value = 2, effectiveValue = (float) 2 },
                new Item { ID = 8, weight = 1, value = 1, effectiveValue = (float) 1 },
                new Item { ID = 9, weight = 1, value = 8, effectiveValue = (float) 8 },

            });

            problem.sortItems();
            knapsack = problem.stealItems(input.maxWeight);

            Assert.IsTrue(knapsack.stolenItems.Count() == 10 && knapsack.totalWeight < knapsack.maxWeight);
        }

    }
}