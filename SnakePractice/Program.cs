using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberGame
{
    class Program
    {

        static void Main(string[] args)
        {
            Random rng = new Random();
            bool playAgain;
            int wins = 0;
            do
            {
                playAgain = false;

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Lets play a number guessing game!");
                Console.WriteLine();
                Console.WriteLine("Please choose a difficulty: Easy, Normal, Hard?");
                int numberOfTries = GetDifficulty(Console.ReadLine());

                Console.WriteLine("Please input a number, the random number will be between 0 and the number you input!");
                int usernumber = int.Parse(Console.ReadLine());

                int secretNumber = rng.Next(usernumber + 1);

                Console.WriteLine("Please guess the secret number!");
                int userguess = int.Parse(Console.ReadLine());

                numberOfTries--;


                while (userguess != secretNumber && numberOfTries != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You are incorrect! \nTry again");
                    Console.WriteLine();
                    Console.Write($"You have {numberOfTries} tries left.");
                    Console.WriteLine();
                    numberOfTries--;
                    if (userguess < secretNumber)
                    {
                        SayHigher();
                    }
                    if (userguess > secretNumber)
                    {
                        SayLower();
                    }
                    userguess = int.Parse(Console.ReadLine());
                }

                GameOver(userguess, secretNumber, numberOfTries);
                wins += Scoreboard(userguess, secretNumber);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"You've won {wins} games!");
                Console.Write("Would you like to play again? Y/N: ");
                string userResponse = Console.ReadLine();
                if (userResponse.ToLower() == "y")
                {
                    playAgain = true;
                    Console.Clear();
                }

            } while (playAgain);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Thanks for playing! Press enter to exit!");
            Console.ReadLine();
        }

        public static int Scoreboard(int guess, int secretNumber)
        {            
            if (guess == secretNumber)
            {
                return 1;
            }

            return 0;
        }

        public static void SayHigher()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("The secret number is higher");
        }

        public static void SayLower()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("The secret number is lower");
        }

        public static void GameOver(int guess, int secretNumber, int numberOfTries)
        {
            if (numberOfTries == 0 && guess != secretNumber)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;              
                Console.WriteLine("Oh no, you lost!");
            }

            if (guess == secretNumber)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Correct!");
            }
        }

        public static int GetDifficulty(string difficulty)
        {
            int numberOfTries = 0;
            switch (difficulty.ToLower())
            {
                case "easy":
                    numberOfTries = 7;
                    break;
                case "normal":
                    numberOfTries = 5;
                    break;
                case "hard":
                    numberOfTries = 3;
                    break;
                default:
                    numberOfTries = 5;
                    break;
            }

            return numberOfTries;
        }
    }
}
