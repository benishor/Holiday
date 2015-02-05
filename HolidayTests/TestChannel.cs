using Holiday;

namespace HolidayTests
{
    public class TestChannel : IChannel
    {
        private string lastFrom;
        private string lastTo;
        private string lastCC;

        public void Send(Message message)
        {
            lastFrom = message.From;
            lastTo = message.To;
            lastCC = message.CC;
        }

        public bool LastMessageFrom(string from)
        {
            return lastFrom == from;
        }

        public bool LastMessageTo(string to)
        {
            return lastTo == to;
        }

        public bool LastMessageCC(string cc)
        {
            return lastCC == cc;
        }
    }
}