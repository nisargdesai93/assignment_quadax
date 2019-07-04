﻿using MasterMind_BLL;
using MasterMind_BLL.Enum;
using MasterMind_BLL.Implementation;
using MasterMind_BLL.Model;
using System;

namespace MasterMind_UI
{
    class Program
    {
        public static void Main(string[] args)
        {
            int loop = 1;
            var result = new Result();

            IGameLogic gameLogic = new GameLogic();
            IInfoMessage infoMessage = new InfoMessage();


            //Print introductory messages.
            infoMessage.PrintInformationalMessage((long)MessageType.WelcomeMessage);
            infoMessage.PrintInformationalMessage((long)MessageType.Instructions);

            infoMessage.PrintInformationalMessage((long)MessageType.PlayerConfirmation);

            long userConfirmation = (long)ControlCommands.WaitForInput;

            // The loop will ensure that the user either starts the game or abort it.
            do
            {
                userConfirmation = gameLogic.validateUserPermission(Console.ReadKey().KeyChar);

                if (userConfirmation == (long)ControlCommands.Exit)
                    return;
                else if (userConfirmation != (long)ControlCommands.StartGame)
                    infoMessage.PrintInformationalMessage((long)MessageType.InvalidInput);

            } while (userConfirmation != (long)ControlCommands.StartGame);

        Play:
            var randomNumber = gameLogic.GenerateRandomNumber();

            var randomNumberDigits = gameLogic.GetDigitsFromNumber((int)randomNumber);

            infoMessage.PrintInformationalMessage((long)MessageType.GenerateRandomNumber, 0, true, "");

            do
            {
                infoMessage.PrintInformationalMessage((long)MessageType.Attempt, loop, false, "");

                var input = Console.ReadLine();

                if (!gameLogic.ValidateInput(input))
                    continue;

                var userInputDigits = gameLogic.GetDigitsFromNumber(Convert.ToInt32(input));

                result = gameLogic.VerifyInput(randomNumberDigits, userInputDigits);

                if (result.IsExactMatch)
                {
                    infoMessage.PrintInformationalMessage((long)MessageType.Won);
                    break;
                }

                infoMessage.PrintIndividualResult(result);

                loop++;
            }
            while (loop <= 10);

            //User has used all the chances. Hence, a message will be displayed to show he has lost.
            if (loop >= 10)
            {
                infoMessage.PrintInformationalMessage((long)MessageType.Lost);
            }

            //Ask user if he/she would like to play the game again.
            infoMessage.PrintInformationalMessage((long)MessageType.Retry);

            userConfirmation = gameLogic.validateUserPermission(Console.ReadKey().KeyChar);

            if (userConfirmation == (long)ControlCommands.Exit)
                return;

            else if (userConfirmation == (long)ControlCommands.StartGame)
            {
                loop = 1;
                goto Play;
            }
        }
    }
}