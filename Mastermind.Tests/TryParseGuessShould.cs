using Mastermind.App;
using NUnit.Framework;
using Shouldly;

namespace Mastermind.Tests
{
    [TestFixture]
    public class TryParseGuessShould
    {
        private readonly GameRound _game = new GameRound();

        [TestCase("1234", new int[] { 1,2,3,4 })]
        [TestCase("4256", new int[] { 4,2,5,6 })]
        [TestCase("5321", new int[] { 5,3,2,1 })]
        public void ReturnTrueIfGiven4DigitsBetween1And6(string guess, int[] expected)
        {
            var isValid = _game.TryToParseGuess(guess, out int[] result);
            isValid.ShouldBeTrue();
            for(int i = 0; i < 4; i++)
            {
                result[i].ShouldBe(expected[i]);
            }
        }

        [TestCase]
        public void ReturnFalseIfGivenEmptyString()
        {
            var guess = string.Empty;
            var isValid = _game.TryToParseGuess(guess, out int[] result);
            isValid.ShouldBeFalse();
        }

        [TestCase]
        public void ReturnFalseIfGivenMoreThan4Digits()
        {
            var guess = "12345";
            var isValid = _game.TryToParseGuess(guess, out int[] result);
            isValid.ShouldBeFalse();
        }

        [TestCase("123T")]
        [TestCase("123*")]
        [TestCase(" 234")]
        public void ReturnFalseIfGivenNonDigit(string guess)
        {
            var isValid = _game.TryToParseGuess(guess, out int[] result);
            isValid.ShouldBeFalse();
        }

        [TestCase("1237")]
        [TestCase("2468")]
        [TestCase("0246")]
        public void ReturnFalseIfGivenDigitOutOfRange(string guess)
        {
            var isValid = _game.TryToParseGuess(guess, out int[] result);
            isValid.ShouldBeFalse();
        }
    }
}
