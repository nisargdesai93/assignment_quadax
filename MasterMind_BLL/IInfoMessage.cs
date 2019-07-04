using MasterMind_BLL.Model;

namespace MasterMind_BLL
{
    public interface IInfoMessage
    {
        void PrintInformationalMessage(long messageId, int attemptCount = 0, bool maskRandomNumber = false, string randomNumber = "");

        void PrintIndividualResult(Result result);
    }
}
