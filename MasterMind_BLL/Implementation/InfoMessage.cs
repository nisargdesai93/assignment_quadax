using MasterMind_BLL.Enum;
using MasterMind_BLL.Model;
using System;

namespace MasterMind_BLL.Implementation
{
    public class InfoMessage : IInfoMessage
    {
        public void PrintInformationalMessage(long messageId, int attemptCount = 0, string randomNumber = "")
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
                        "Once you see randomly generated masked number on your screen, the game will start and you will be asked to enter a four digit " + "\n" +
                        "number. For every correct digit at correct position, a plus (+) sign will appear. For every correct digit a minus (-) sign will " + "\n" +
                        "appear. You will be given "+attemptCount+" attempts to win the game where you need to anticipate all four digits at correct position." + "\n");
                    Console.WriteLine();
                    break;

                case MessageType.PlayerConfirmation:
                    Console.WriteLine("Are you ready to play ?  Press Y/y to start playing. Press E/e to exit.");
                    break;

                case MessageType.Abort:
                    Console.WriteLine("Press any key to abort the game.");
                    Console.WriteLine();
                    break;


                case MessageType.PrintMaskedRandomNumber:
                    Console.WriteLine("Random numbers generated is:  * * * *");
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
            if (result.NumberOfPositonalDigitMatch > 0)
            {
                for (int i = 0; i < result.NumberOfPositonalDigitMatch; i++)
                {
                    Console.Write(" + ");
                }
            }

            if (result.NumberOfDigitMatch > 0)
            {
                for (int i = 0; i < result.NumberOfDigitMatch; i++)
                {
                    Console.Write(" - ");
                }
            }
            Console.WriteLine();
        }

        public void PrintFinalResult(long allowedAttempt, long attemptMade, int randomNumber)
        {
            Console.WriteLine("__________________________________________________________________");
            Console.WriteLine("Random number was: " + randomNumber);
            Console.WriteLine("Allowed attempt: " + allowedAttempt + "\t Attempt:" + attemptMade);
        }

    }
}
