using System;
using System.Linq;

namespace Mastermind.App
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Mastermind");
            var game = new Game();

            bool readyToStart = false;
            while (!readyToStart)
            {
                foreach (var opt in GameOption.GetAllOrdered())
                {
                    Console.WriteLine($"Enter {opt.Key} to {opt.Description}");
                }
                var cmd = Console.ReadKey();
                if (IsKeyEqual(cmd.KeyChar, GameOption.Quit.Key)) return;
                if (IsKeyEqual(cmd.KeyChar, GameOption.Help.Key))
                {
                    game.PrintRules();
                };
                readyToStart = IsKeyEqual(cmd.KeyChar, GameOption.Start.Key);
            }

            bool userWantsToPlay = true;
            while (userWantsToPlay)
            {
                bool isWinner = game.Play();
                string nextGameMessage = isWinner ?
                                            "Play again and try to beat you best number of attempts?" :
                                            "Give it another go with a new code?  I think you have this!";
                Console.WriteLine($"{Environment.NewLine}{nextGameMessage}");
                Console.WriteLine($"Press any key to {GameOption.Start.Description}, ({GameOption.Quit.Key}) to {GameOption.Quit.Description}");

                userWantsToPlay = !IsKeyEqual(Console.ReadKey().KeyChar, GameOption.Quit.Key);
            }
        }

        private static bool IsKeyEqual(char keyChar, string value)
        {
            return value.Equals(keyChar.ToString(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
