using Mastermind.App;
using NUnit.Framework;
using Shouldly;

namespace Mastermind.Tests
{
    [TestFixture]
    public class GenerateAnswerShould
    {
        [TestCase]
        public void Return4DigitsLong()
        {
            var answer = GameAnswers.GenerateRandomAnswer();
            answer.Length.ShouldBe(4);
        }

        [TestCase]
        public void Return4DigitsBetween1And6()
        {
            var answer = GameAnswers.GenerateRandomAnswer();
            answer.Length.ShouldBe(4);
            foreach(var d in answer)
            {
                d.ShouldBeInRange(1, 6);
            }
        }
    }
}
