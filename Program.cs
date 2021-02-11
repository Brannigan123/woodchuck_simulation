using System;

namespace woodchuck
{
    class Program
    {
        private readonly Random Rand = new Random();

        public void ShowBanner()
        {
            string banner = @"
***************** ACME Industries Rodent Sciences Division *****************
*                                                                          *
*                WOODCHUCK WOOD CHUCKING SIMULATION v. 1.1                 * 
*                                                                          *
*                One row per woodchuck, one column per day                 * 
*                                                                          *
*                        Includes Bonus Features!!                         *
****************************************************************************
            ";

            Console.WriteLine(banner);
        }

        public void Run(int runIndex=0)
        {
            int columnWidth = 6;

            bool inputIsValid = true;

            int numWoodchucks;
            int numDays;

            // Read number of woodchucks
            do
            {
                if (inputIsValid) inputIsValid = false;
                else Console.Write("Invalid input, please try again.\n");
                Console.Write("Enter number of woodchucks for this simulation (1 - 100):   ");
            } while ((!int.TryParse(Console.ReadLine(), out numWoodchucks)) || numWoodchucks < 1 || numWoodchucks > 100);

            // Read number of days
            inputIsValid = true;
            do
            {
                if (inputIsValid) inputIsValid = false;
                else Console.Write("Invalid input, please try again.\n");
                Console.Write("Enter number of days for this simulation (1 - 10):          ");
            } while ((!int.TryParse(Console.ReadLine(), out numDays)) || numDays < 1 || numDays > 10);
         
            // Create array for storing simulation data
            int[,] data = new int[numWoodchucks, numDays];

            // Write column headers, starting with a header
            Console.WriteLine();
            Console.WriteLine($"SIMULATION {runIndex + 1}: {numWoodchucks} woodchucks over {numDays} days");
            Console.WriteLine();
            Console.Write(new string(' ', columnWidth));
            for (int col = 1; col <= data.GetLength(1); col++)
            {
                Console.Write($"{col}".PadLeft(columnWidth));
            }
            Console.Write(" ");
            Console.Write("Avg".PadLeft(columnWidth - 1));
            Console.Write(" ");
            Console.WriteLine("Tot".PadLeft(columnWidth - 1));

            // Write column header underlines
            Console.Write(new string(' ', columnWidth));
            for (int col = 0; col < data.GetLength(1); col++)
            {
                Console.Write(" _____");
            }
            Console.Write(" ");
            Console.Write("_____");
            Console.Write(" ");
            Console.WriteLine("_____");

            for (int row = 0; row < data.GetLength(0); row++)
            {
                // Write row header
                Console.Write($"{row + 1} |".PadLeft(columnWidth));

                int rowSum = 0;

                // Store and write row data
                for (int col = 0; col < data.GetLength(1); col++)
                {
                    data[row, col] = Rand.Next(1, 50);
                    Console.Write($"{data[row, col]}".PadLeft(columnWidth));
                    rowSum += data[row, col];
                }

                // Write sum and average
                Console.Write(" ");
                Console.Write($"{Math.Round((double) rowSum / data.GetLength(1), 1):F1}".PadLeft(columnWidth - 1));
                Console.Write(" ");
                Console.WriteLine($"{rowSum}".PadLeft(columnWidth - 1));
 
            }

            // Calculate column sums
            int[] colSums = new int[data.GetLength(1)];
            for (int col = 0; col < data.GetLength(1); col++)
            {
                int colSum = 0;
                for (int row = 0; row < data.GetLength(0); row++)
                {
                    colSum += data[row, col];
                }
                colSums[col] = colSum;
            }

            // Write seperators
            Console.Write(new string(' ', columnWidth));
            for (int col = 0; col < data.GetLength(1); col++)
            {
                Console.Write(" _____");
            }
            Console.WriteLine();


            // Calculate Total
            int total = 0;
            foreach(int value in data){
                total += value;
            }

            // Write average row title
            Console.Write("Tot |".PadLeft(columnWidth));
            // Write Averages
             for (int col = 0; col < data.GetLength(1); col++)
            {
                 Console.Write($"{colSums[col]}".PadLeft(columnWidth));
            }
            Console.WriteLine();

            // Write total row title
            Console.Write("Avg |".PadLeft(columnWidth));
            // Write sums
            for (int col = 0; col < data.GetLength(1); col++)
            {
                 Console.Write($"{Math.Round((double) colSums[col] / data.GetLength(0), 1):F1}".PadLeft(columnWidth));
            }
            Console.WriteLine();

            // Write total and average of all the items
            Console.WriteLine();
            Console.WriteLine($"Total wood chucked: {total}");
            Console.WriteLine(
                $"Average woodchuck chuckage: {Math.Round((double) total / (data.GetLength(0) * data.GetLength(1)), 1):F1}");

            Console.Write("\nTo run another simulation, type \"Y\": ");
            ConsoleKey response = Console.ReadKey(false).Key;
            if(response == ConsoleKey.Y)
            {
                Console.WriteLine();
                Run(runIndex + 1);
            }
            else
            {
                Console.Write("\nPress any key to end program...");
                Console.ReadKey();
            }
        }

        public static void Main()
        {
            Program simulation = new Program();
            simulation.ShowBanner();
            simulation.Run();
        }
    }
}