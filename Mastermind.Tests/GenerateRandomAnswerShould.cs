using Mastermind.App;
using NUnit.Framework;
using Shouldly;
using System.Linq;

namespace Mastermind.Tests
{
    [TestFixture]
    public class GenerateRandomAnswerShould
    {
        [TestCase]
        public void ReturnAllUniqueDigitsGivenEasyModeAndTenCalls()
        {
            for(int i = 0; i < 361; i++) //using 6*5*4*3 probability to make sure more than all combinations are used
            {
                var result = GameAnswers.GenerateRandomAnswer();
                var length = result.Length;

                System.Diagnostics.Debug.WriteLine(string.Join("-", result));

                result.AsEnumerable().Distinct().Count().ShouldBe(length);
            }
            System.Diagnostics.Debug.WriteLine("This is to set a breakpoint to check the result log");
        }
    }
}
