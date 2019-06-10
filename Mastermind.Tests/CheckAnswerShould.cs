using Mastermind.App;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mastermind.Tests
{
    [TestFixture]
    public class CheckAnswerShould
    {
        [TestCase]
        public void ReturnCorrectOutcomeGivenCorrectGuess()
        {
            int[] answer = new int[4] { 1, 2, 3, 4 };
            int[] guess = answer;

            var gameRound = new GameRound(answer);
            var outcome = gameRound.CheckAnswer(guess);

            outcome.ShouldBe(GameAnswers.CorrectGuess);
        }

        [TestCase]
        public void ReturnAllBlankOutcomeGivenAllIncorrectGuesses()
        {
            int[] answer = new int[4] { 1, 2, 3, 4 };
            int[] guess = new int[4] { 5, 6, 5, 6 };

            var gameRound = new GameRound(answer);
            var outcome = gameRound.CheckAnswer(guess);
            var expected = string.Concat(Enumerable.Repeat(GameAnswers.WrongNumber, 4));

            outcome.ShouldBe(expected);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 4,3,2,1 }) ]
        [TestCase(new int[] { 2, 4, 1, 6 }, new int[] { 6,2,4,1 }) ]
        public void ReturnAllMinusGivenAllCorrectNumbersInWrongPlaces(int[] guess, int[] answer)
        {
            var gameRound = new GameRound(answer);
            var outcome = gameRound.CheckAnswer(guess);
            var expected = string.Concat(Enumerable.Repeat(GameAnswers.CorrectNumberWrongPlace,4));

            outcome.ShouldBe(expected);
        }

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 1, 3, 2, 4 }, "+--+")]
        [TestCase(new int[] { 2, 4, 1, 6 }, new int[] { 6, 4, 1, 2 }, "-++-")]
        [TestCase(new int[] { 3, 5, 1, 4 }, new int[] { 3, 4, 1, 5 }, "+-+-")]
        [TestCase(new int[] { 3, 4, 5, 6 }, new int[] { 2, 4, 5, 6 }, " +++")]
        public void ReturnMixedOutcomeGivenSomeCorrectAndSomeIncorrect(int[] guess, int[] answer, string expected)
        {
            var gameRound = new GameRound(answer);
            var outcome = gameRound.CheckAnswer(guess);
            
            outcome.ShouldBe(expected);
        }
    }
}
