// C# Scenario-Based Snack Game
// This is a simple "choose your own adventure" game where the player makes decisions to find a snack.

using System;
using System.Collections.Generic; // Required for List
using System.Threading; // Required for Thread.Sleep

namespace SnackAdventure
{
    class Program
    {
        static List<string> choiceHistory = new List<string>();

        static void Main(string[] args)
        {
            Console.Title = "Snack Adventure!"; // Sets the console window title
            bool playAgain = true;

            while (playAgain)
            {
                choiceHistory.Clear(); // Clear history for a new game
                PlayGame();

                Console.WriteLine("\n------------------------------------------");
                Console.Write("Do you want to go on another snack adventure? (yes/no): ");
                string playAgainInput = Console.ReadLine().Trim().ToLower();
                playAgain = (playAgainInput == "yes" || playAgainInput == "y");
                Console.Clear();
            }

            Console.WriteLine("\nThanks for playing Snack Adventure! Come back when you're hungry again.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void PlayGame()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("~~~ Welcome to Snack Adventure! ~~~");
            Console.ResetColor();
            TypeLine("You're sitting at your desk, and a familiar feeling rumbles in your stomach...");
            TypeLine("You're hungry! Time to find a snack.");
            RecordChoice("Game Started: Feeling hungry.");

            FirstChoice();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- Your Snack Adventure Summary ---");
            foreach (string choice in choiceHistory)
            {
                Console.WriteLine(choice);
            }
            Console.ResetColor();
        }

        static void FirstChoice()
        {
            TypeLine("\nWhere do you decide to look for a snack?");
            Console.WriteLine("  A) Head to the Kitchen Pantry.");
            Console.WriteLine("  B) Check out the Refrigerator.");
            Console.WriteLine("  C) Try your luck with the Vending Machine downstairs.");

            char choice = GetValidChoice(new char[] { 'A', 'B', 'C' });

            switch (choice)
            {
                case 'A':
                    RecordChoice("Decided to check the Kitchen Pantry.");
                    InThePantry();
                    break;
                case 'B':
                    RecordChoice("Decided to check the Refrigerator.");
                    InTheRefrigerator();
                    break;
                case 'C':
                    RecordChoice("Decided to try the Vending Machine.");
                    AtTheVendingMachine();
                    break;
            }
        }

        static void InThePantry()
        {
            TypeLine("\nYou open the pantry. It's filled with various options.");
            Console.WriteLine("What catches your eye?");
            Console.WriteLine("  A) A bag of crunchy Potato Chips.");
            Console.WriteLine("  B) A sleeve of sweet Chocolate Chip Cookies.");
            Console.WriteLine("  C) A lone, shiny Red Apple.");

            char choice = GetValidChoice(new char[] { 'A', 'B', 'C' });

            Console.ForegroundColor = ConsoleColor.Yellow;
            switch (choice)
            {
                case 'A':
                    RecordChoice("Chose Potato Chips from the pantry.");
                    TypeLine("\nYou grab the chips! The salty crunch is immediately satisfying.");
                    TypeLine("Outcome: A classic, quick fix for your hunger. Maybe drink some water too!");
                    break;
                case 'B':
                    RecordChoice("Chose Chocolate Chip Cookies from the pantry.");
                    TypeLine("\nCookies it is! The sweet, chocolatey goodness melts in your mouth.");
                    TypeLine("Outcome: A delightful sugar rush! Perfect for a treat.");
                    break;
                case 'C':
                    RecordChoice("Chose a Red Apple from the pantry.");
                    TypeLine("\nAn apple! You take a crisp bite. It's refreshing and healthy.");
                    TypeLine("Outcome: A wise and wholesome choice. Your body thanks you!");
                    break;
            }
            Console.ResetColor();
        }

        static void InTheRefrigerator()
        {
            TypeLine("\nYou open the refrigerator. The cool air hits your face.");
            Console.WriteLine("What do you go for?");
            Console.WriteLine("  A) A cup of creamy Yogurt.");
            Console.WriteLine("  B) That leftover slice of Pizza from last night.");
            Console.WriteLine("  C) Some crunchy Baby Carrots with Hummus.");

            char choice = GetValidChoice(new char[] { 'A', 'B', 'C' });

            Console.ForegroundColor = ConsoleColor.Green;
            switch (choice)
            {
                case 'A':
                    RecordChoice("Chose Yogurt from the refrigerator.");
                    TypeLine("\nYogurt! Cool, creamy, and just the right amount of tang.");
                    TypeLine("Outcome: A light and refreshing snack. Good for the gut!");
                    break;
                case 'B':
                    RecordChoice("Chose Leftover Pizza from the refrigerator.");
                    TypeLine("\nLeftover pizza! Even cold, it's a champion of snacks.");
                    TypeLine("Outcome: A truly satisfying, albeit a bit heavy, snack. No regrets!");
                    break;
                case 'C':
                    RecordChoice("Chose Carrots and Hummus from the refrigerator.");
                    TypeLine("\nCarrots and hummus! The crunch of the carrots and the smoothness of the hummus is a great combo.");
                    TypeLine("Outcome: Healthy, tasty, and provides good energy. Excellent choice!");
                    break;
            }
            Console.ResetColor();
        }

        static void AtTheVendingMachine()
        {
            TypeLine("\nYou head down to the vending machine. You peer through the glass...");
            // Let's add a small sub-choice here for fun
            TypeLine("You find a dollar in your pocket. What kind of snack are you in the mood for?");
            Console.WriteLine("  A) Something sweet (like a Candy Bar).");
            Console.WriteLine("  B) Something salty (like Pretzels or Chips).");

            char moodChoice = GetValidChoice(new char[] { 'A', 'B' });
            string snackChosen = "";

            Console.ForegroundColor = ConsoleColor.Magenta;
            if (moodChoice == 'A')
            {
                RecordChoice("At vending machine, chose something sweet.");
                snackChosen = "a chocolate bar";
                TypeLine($"\nYou insert your dollar and select {snackChosen}. The machine whirs and drops your treat.");
                TypeLine($"Outcome: A quick sugar hit from the {snackChosen}! Sometimes, that's just what you need.");
            }
            else // MoodChoice == 'B'
            {
                RecordChoice("At vending machine, chose something salty.");
                snackChosen = "a bag of pretzels"; // Could randomize this more if desired
                TypeLine($"\nYou insert your dollar and punch in the code for {snackChosen}. It clunks into the tray.");
                TypeLine($"Outcome: The {snackChosen} provide a satisfying salty crunch. A reliable vending machine pick!");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Gets a valid character choice from the user.
        /// </summary>
        /// <param name="validOptions">An array of valid uppercase characters.</param>
        /// <returns>The valid uppercase character chosen by the user.</returns>
        static char GetValidChoice(char[] validOptions)
        {
            Console.Write("Enter your choice (A, B, C...): ");
            while (true)
            {
                string input = Console.ReadLine().Trim().ToUpper();
                if (input.Length == 1 && Array.Exists(validOptions, option => option == input[0]))
                {
                    return input[0];
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Invalid choice. Please enter one of ({string.Join(", ", validOptions)}): ");
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Simulates typing text line by line for a better reading experience.
        /// </summary>
        /// <param name="message">The message to type out.</param>
        /// <param name="delay">Delay in milliseconds between characters. Default is 20ms.</param>
        static void TypeLine(string message, int delay = 20)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delay); // Small delay to simulate typing
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Records a choice or event in the game's history.
        /// </summary>
        /// <param name="logEntry">The string to add to the history.</param>
        static void RecordChoice(string logEntry)
        {
            choiceHistory.Add($" - {logEntry}");
        }
    }
}

