using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mastermind.App
{
    public class GameRound
    {
        private readonly int[] _answer;

        public GameRound(int[] answer = null)
        {
            _answer = (answer ?? GameAnswers.GenerateRandomAnswer());
            Debug.WriteLine(string.Join("-",_answer));
        }
        
        public string CheckAnswer(int[] guess)
        {
            if (string.Join("",guess) == string.Join("", _answer)) return GameAnswers.CorrectGuess;

            var result = new string[GameAnswers.ANSWER_LENGTH];
            var answerList = _answer.AsEnumerable();
            for(int i = 0; i < GameAnswers.ANSWER_LENGTH; i++)
            {
                if (guess[i] == _answer[i])
                {
                    result[i] = GameAnswers.CorrectNumberAndPlace;
                }
                else
                {
                    result[i] = (answerList.Contains(guess[i])) ? 
                                    GameAnswers.CorrectNumberWrongPlace :
                                    GameAnswers.WrongNumber;
                }
            }

            return string.Join("",result);
        }

        public bool TryToParseGuess(string guess, out int[] result)
        {
            result = new int[GameAnswers.ANSWER_LENGTH];
            if (guess.Length != GameAnswers.ANSWER_LENGTH) return false;

            bool isValid = false;

            string pattern = "[1-6]{" + GameAnswers.ANSWER_LENGTH + "}";
            var regEx = new Regex(pattern);
            if (regEx.IsMatch(guess))
            {
                isValid = true;
                for (int i = 0; i < GameAnswers.ANSWER_LENGTH; i++)
                {
                    result[i] = (int)char.GetNumericValue(guess[i]);
                }
            }
            return isValid;
        }
    }
}
