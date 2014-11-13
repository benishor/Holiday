using System.Net.Mail;

namespace Holiday
{
    public class MailChannel : IChannel
    {
        public void Send(Message message)
        {
            SmtpClient c = new SmtpClient("host");
            c.Send(new MailMessage(
                message.From,
                message.To,
                "",
                ""
                ));
        }

    }
}