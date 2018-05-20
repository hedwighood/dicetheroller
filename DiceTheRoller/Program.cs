using System;

namespace DiceTheRoller
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Dice: the Roller");
            Console.WriteLine("What version of the roller would you like to use today?");
            DisplayHelpOptions();
            string input = "";
            string mode = "hunter";
            int rollNumber = 0;
            input = Console.ReadLine();
            while (input != "q")
            {
                if (input == "h")
                    DisplayHelpOptions();
                else if (input == "hunter")
                {
                    mode = input;
                    Console.WriteLine($"Setting mode to {input}");
                }
                else if (int.TryParse(input, out rollNumber) && rollNumber > 0)
                    RollDice(rollNumber, mode);
                else
                    Console.WriteLine("Invalid input!");
                Console.WriteLine("What would you like to do next? (press h for options)");
                input = Console.ReadLine();
            }
            Console.WriteLine("Now quitting- press enter to close the console window");
            Console.ReadLine();
        }

        public static void DisplayHelpOptions()
        {
            Console.WriteLine("Options include:\nhunter for d10 only with sum of successes and reroll of 10s\ninteger for that number of dice rolled\nh for help\nq to quit");
        }

        public static void RollDice(int numOfRolls, string version)
        {
            if (version == "hunter")
            {
                Console.WriteLine("Your rolls are:");
                int successes = 0;
                int fails = 0;
                int critFails =0;
                for (int i = 1; i <= numOfRolls; i++)
                {
                    int result = Roll(10);
                    if (result >= 8)
                        successes++;
                    else
                        fails++;
                    Console.WriteLine(result);
                    if (result == 1)
                        critFails++;
                    if (result == 10)
                    {
                        Console.WriteLine("Extra roll for a crit success:");
                        result = Roll(10);
                        if (result >= 8)
                            successes++;
                        else
                            fails++;
                        Console.WriteLine(result);
                    }
                }
                Console.WriteLine($"You have {successes} successes and {fails} failures from that roll. {critFails} critical fails leaves you with {successes - critFails} successes.");
                if (successes - critFails >= 5)
                    Console.WriteLine("That's a critical success!");
            }
        }

        public static int Roll(int sides)
        {
            Random r = new Random();
            return r.Next(1, sides + 1);
        }
    }
}