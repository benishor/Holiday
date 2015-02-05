using System.Net.Mail;

namespace Holiday
{
    public class MailChannel : IChannel
    {
        public void Send(Message message)
        {
            var mailMessage = new MailMessage(message.From, message.To, message.Subject, message.Body);
            mailMessage.CC.Add(message.CC);
            var smtpClient = new SmtpClient("host");
            smtpClient.Send(mailMessage);
        }
    }
}