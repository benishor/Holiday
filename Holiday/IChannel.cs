namespace Holiday
{
    public interface IChannel
    {
        void Send(string from, string to, string cc, string subject, string body);
    }
}