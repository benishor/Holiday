using Holiday;

namespace HolidayTests
{
    public class TestChannel : IChannel
    {
        private string lastFrom;
        private string lastTo;
        private string lastCC;

        public void Send(string from, string to, string cc, string subject, string body)
        {
            lastFrom = from;
            lastTo = to;
            lastCC = cc;
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