using MasterMind_BLL.Model;
using System.Collections.Generic;

namespace MasterMind_BLL
{
    public interface IGameLogic
    {
        long validateUserPermission(char input);
        long GenerateRandomNumber();
        bool ValidateInput(string input);
        Result VerifyInput(Dictionary<string, int>randomNumberDigits, Dictionary<string, int>userInputDigits);
        Dictionary<string, int> GetDigitsFromNumber(int number);
    }
}
