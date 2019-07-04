using MasterMind_BLL.Model;

namespace MasterMind_BLL
{
    public interface IInfoMessage
    {
        void PrintInformationalMessage(long messageId, int attemptCount = 0, string randomNumber = "");

        void PrintIndividualResult(Result result);

        void PrintFinalResult(long allowedAttempt, long attemptMade, int randomNumber);
    }
}
