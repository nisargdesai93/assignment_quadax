using MasterMind_BLL.Enum;
using MasterMind_BLL.Model;
using System;

namespace MasterMind_BLL.Implementation
{
    public class InfoMessage : IInfoMessage
    {
        public void PrintInformationalMessage(long messageId, int attemptCount = 0, bool maskRandomNumber = false, string randomNumber = "")
        {
            var message = (MessageType)messageId;

            switch (message)
            {
                case MessageType.WelcomeMessage:
                    Console.WriteLine("Welcome to the game of Mastermind");
                    Console.WriteLine();
                    break;


                case MessageType.Instructions:
                    Console.WriteLine("INSTRUCTIONS: You will be given a random number four digit number, all digits between 1 to 6 (i.e 2343 or 4563)." + "\n" +
                        "Once you see four astrics on your screen, you will be asked to enter a four digit number. " + "\n" +
                        "For every correct digit a minus sign will appear. " +
                        "For every correct digit at correct position a plus sign will appear." + "\n" +
                        "To win the game you need to anticipate all four digits at correct position.");
                    Console.WriteLine();
                    break;

                case MessageType.PlayerConfirmation:
                    Console.WriteLine("Are you ready to play ?  Press Y/y to start playing. Press A/a to abort.");
                    break;

                case MessageType.Abort:
                    Console.WriteLine("Press any key to abort the game.");
                    Console.WriteLine();
                    break;


                case MessageType.GenerateRandomNumber:
                    if (maskRandomNumber)
                        Console.WriteLine("Random numbers generated is:  * * * *");
                    else
                        Console.WriteLine("Random number generated is: " + randomNumber);

                    Console.WriteLine();
                    break;

                case MessageType.Attempt:
                    Console.Write("Attempt " + attemptCount + " :");
                    break;

                case MessageType.Won:
                    Console.WriteLine("CONGRATULATIONS ! YOU ARE A REAL MASTERMIND !");
                    break;

                case MessageType.Lost:
                    Console.WriteLine("OOOPS. YOU LOST");
                    break;

                case MessageType.Retry:
                    Console.WriteLine("Would you like to play again ? Press Y/y to start again. Press E/e to exit");
                    break;

                case MessageType.InvalidInput:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;

            }
        }

        public void PrintIndividualResult(Result result)
        {
            if (result.NumberOfDigitMatch > 0)
            {
                for (int i = 0; i < result.NumberOfDigitMatch; i++)
                {
                    Console.Write(" - ");
                }
            }
            if (result.NumberOfPositonalDigitMatch > 0)
            {
                for (int i = 0; i < result.NumberOfPositonalDigitMatch; i++)
                {
                    Console.Write(" + ");
                }
            }

            Console.WriteLine();
        }
    }
}
