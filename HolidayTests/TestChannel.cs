using Holiday;

namespace HolidayTests
{
    public class TestChannel : IChannel
    {
        private string lastFrom;
        private string lastTo;

        public void Send(string from, string to, string subject, string body)
        {
            lastFrom = from;
            lastTo = to;
        }

        public bool LastMessageFrom(string from)
        {
            return lastFrom == from;
        }

        public bool LastMessageTo(string to)
        {
            return lastTo == to;
        }
    }
}