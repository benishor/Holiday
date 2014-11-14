using System.Net.Mail;

namespace Holiday
{
    public class MailChannel : IChannel
    {
        public void Send(string from, string to, string cc, string subject, string body)
        {
            var mailMessage = new MailMessage(from, to, subject, body);
            mailMessage.CC.Add(cc);
            var smtpClient = new SmtpClient("host");
            smtpClient.Send(mailMessage);
        }

    }
}