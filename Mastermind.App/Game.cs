using System;

namespace Mastermind.App
{
    public class Game
    {
        private const int NUMBER_OF_CHANCES = 10;
        
        public void PrintRules()
        {
            Console.WriteLine("");
            Console.WriteLine("Game Play:");
            Console.WriteLine("----------");
            Console.WriteLine($"> The Mastermind will generate a {GameAnswers.ANSWER_LENGTH} digit code using the numbers 1 through 6");
            Console.WriteLine($"> You shall try to guess the code by inputting {GameAnswers.ANSWER_LENGTH} numbers and press the Enter key");
            Console.WriteLine("> If you did not guess the code an outcome sequence will help you get closer");
            Console.WriteLine(">> Each number correctly guess in the correct position will be represented with a '+'");
            Console.WriteLine(">> A number correctly in the code, but guessed in the incorrect position will be denoted with a '-'");
            Console.WriteLine(">> An incorrect number will be denoted with a ' '");
            Console.WriteLine("----------");
            Console.WriteLine("> You will have 10 tries to crack the code, Good Luck!");
            Console.WriteLine("");
        }

        public bool Play()
        {
            var gameRound = new GameRound(GameAnswers.GenerateRandomAnswer());

            Console.WriteLine($"{Environment.NewLine}Here We Go! Take your best guess");

            for (int i = 0; i < NUMBER_OF_CHANCES; i++)
            {
                if (i > 0)
                {
                    Console.Write($"{Environment.NewLine}Guess #{i + 1}: ");
                }
                var guess = Console.ReadLine();
                bool isValidGuess = gameRound.TryToParseGuess(guess, out int[] result);
                if (isValidGuess)
                {
                    var isSuccess = CheckGuessOutcome(gameRound, result);
                    if (isSuccess) return true;
                }
                else
                {
                    HandleInvalidGuess();
                }
            }

            return false;
        }

        private bool CheckGuessOutcome(GameRound gameRound, int[] guess)
        {
            var outcome = gameRound.CheckAnswer(guess);
            if (outcome.Equals(GameAnswers.CorrectGuess))
            {
                Console.WriteLine("Congratulations you guessed the correct answer!");
                return true;
            }
            else
            {
                Console.WriteLine(outcome);
                return false;
            }
        }

        private void HandleInvalidGuess()
        {
            Console.WriteLine("Not a valid guess, that will cost you a turn.");
            Console.WriteLine("Do you want to read the rules? (Y) to read, or any key to guess again.");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                PrintRules();
                Console.WriteLine("Press any key to guess again");
                Console.ReadKey();
            }            
        }
    }
}
