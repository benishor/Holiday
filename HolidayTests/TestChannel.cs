using Holiday;

namespace HolidayTests
{
    public class TestChannel : IChannel
    {
        public string LastFrom;
        public string LastTo;
        public string LastCC;

        public void Send(string from, string to, string cc, string subject, string body)
        {
            LastFrom = from;
            LastTo = to;
            LastCC = cc;
        }
    }
}