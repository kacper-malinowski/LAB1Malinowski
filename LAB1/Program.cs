namespace LAB1Malinowski
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Problem problem = new Problem();
            TerminalInput input = new TerminalInput();
            Result knapsack = new Result();
            input = input.downloadInput();
            knapsack = problem.Solve(input);
            Console.WriteLine(knapsack);
        }
    }
}
