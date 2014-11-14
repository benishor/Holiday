using System.Net.Mail;

namespace Holiday
{
    public class MailChannel : IChannel
    {
        public void Send(Message message)
        {
            var smtpClient = new SmtpClient("host");
            smtpClient.Send(new MailMessage(
                message.From,
                message.To,
                "",
                ""
                ));
        }

    }
}