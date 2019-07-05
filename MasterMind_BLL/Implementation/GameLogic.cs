using MasterMind_BLL.Enum;
using MasterMind_BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MasterMind_BLL.Implementation
{
    public class GameLogic : IGameLogic
    {
        public long GenerateRandomNumber()
        {
            int i = 0;
            var random = new Random();

            int[] allowedDigits = { 1, 2, 3, 4, 5, 6 };
            var output = new StringBuilder();

            do
            {
                int num = random.Next(allowedDigits.Length);
                output.Append(allowedDigits[num]);
                i++;
            }
            while (i < 4);

            return Convert.ToInt64(output.ToString());
        }

        public bool ValidateInput(string input)
        {
            int number = 0;
            var flag = true;
            var allowedCharacter = new int[6] { 1, 2, 3, 4, 5, 6 };

            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Input is not a number");
                flag = false;
            }

            else if (input.Length != 4)
            {
                Console.WriteLine("Number must contain only 4 digit");
                flag = false;
            }

            else
            {
                var userInputDigits = GetDigitsFromNumber(Convert.ToInt32(input));

                if (!allowedCharacter.Contains(userInputDigits[Digits.Thousand.ToString()]) || !allowedCharacter.Contains(userInputDigits[Digits.Hundred.ToString()])
                    || !allowedCharacter.Contains(userInputDigits[Digits.Ten.ToString()]) || !allowedCharacter.Contains(userInputDigits[Digits.Zero.ToString()]))
                {
                    Console.WriteLine("All digits must be between 1 to 6");
                    flag = false;
                }
            }

            return flag;
        }

        public Result VerifyInput(Dictionary<string, int> randomNumberDigits, Dictionary<string, int> userInputDigits)
        {
            var result = new Result();
            var keysToExclued = new List<string>();
            KeyValuePair<string, int> positionalMatch = new KeyValuePair<string, int>();

            if (randomNumberDigits.Values.SequenceEqual(userInputDigits.Values))
            {
                result.IsExactMatch = true;
            }

            else
            {
                //Preference will be given to to the condition where digit matches the position as well.
                foreach (var userInputDigit in userInputDigits)
                {
                    positionalMatch = randomNumberDigits.Where(x => x.Key == userInputDigit.Key
                                            && x.Value == userInputDigit.Value
                                            && !keysToExclued.Contains(x.Key)).FirstOrDefault();

                    if (positionalMatch.Key != null)
                    {
                        result.NumberOfPositonalDigitMatch++;
                        keysToExclued.Add(positionalMatch.Key);
                        continue;
                    }
                }

                foreach (var userInputDigit in userInputDigits)
                {

                    var digitMatch = randomNumberDigits.Where(x => x.Value == userInputDigit.Value && !keysToExclued.Contains(x.Key)).FirstOrDefault();
                    // count for digit match will be updated only if positional match doesn't exist
                    if (digitMatch.Key != null)
                    {
                        result.NumberOfDigitMatch++;
                        keysToExclued.Add(digitMatch.Key);
                    }
                }
            }
            return result;
        }

        public Dictionary<string, int> GetDigitsFromNumber(int number)
        {
            var digits = new Dictionary<string, int>();

            int thousand = number / (int)Digits.Thousand;
            int hundred = (number - (thousand * (int)Digits.Thousand)) / (int)Digits.Hundred;
            int ten = (number - (thousand * (int)Digits.Thousand) - (hundred * (int)Digits.Hundred)) / (int)Digits.Ten;
            int zeros = (number - (thousand * (int)Digits.Thousand) - (hundred * (int)Digits.Hundred) - (ten * (int)Digits.Ten));

            digits.Add(Digits.Thousand.ToString(), thousand);
            digits.Add(Digits.Hundred.ToString(), hundred);
            digits.Add(Digits.Ten.ToString(), ten);
            digits.Add(Digits.Zero.ToString(), zeros);

            return digits;
        }

        public long validateUserPermission(char input)
        {
            long flag = (long)ControlCommands.WaitForInput;

            if (Convert.ToString(input).ToLower() == "y")
                return (long)ControlCommands.StartGame;

            if (Convert.ToString(input).ToLower() == "e")
                return (long)ControlCommands.Exit;

            return flag;

        }
    }
}
