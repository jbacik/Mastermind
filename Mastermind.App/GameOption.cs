using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind.App
{
    public sealed class GameOption
    {
        public static GameOption Start = new GameOption("S", "Start a new Game", 1);
        public static GameOption Help = new GameOption("H", "Read how to play the game", 2);
        public static GameOption Quit = new GameOption("Q", "Quit the game", 3);

        public string Key;
        public string Description;
        public int Order;

        public GameOption(string key, string description, int order)
        {
            this.Key = key;
            this.Description = description;
            this.Order = order;
        }

        public static IEnumerable<GameOption> GetAllOrdered()
        {
            return new [] { Start, Help, Quit }.OrderBy(o => o.Order);
        }
    }
}
