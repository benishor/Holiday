using System;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class HolidayTests
    {
        private HolidayRequest request;
        private const string employee = "csaba.trucza@iquestgroup.com";
        private const string manager = "andrei.doibani@iquestgroup.com";

        [Test]
        public void usage()
        {
            CreateHolidayRequest();
            request.Approve();
        }

        [Test]
        public void submitted_request_sends_mail()
        {
            CreateHolidayRequest();

            Assert.AreEqual(employee, MailServer.GetLastSentMail().From);
            Assert.AreEqual(manager, MailServer.GetLastSentMail().To);
        }

        [Test]
        public void approved_request_sends_mail()
        {
            CreateHolidayRequest();

            request.Approve();

            Assert.AreEqual(manager, MailServer.GetLastSentMail().From );
            Assert.AreEqual("hr", MailServer.GetLastSentMail().To);
        }

        private void CreateHolidayRequest()
        {
            request = new HolidayRequest(
                employee,
                manager,
                new DateTime(2014, 11, 11),
                new DateTime(2014, 11, 12),
                "vacation");            
        }
    }

    public class MailServer
    {
        private static Mail lastSentMail;

        public static Mail GetLastSentMail()
        {
            return lastSentMail;
        }

        public static void Send(Mail mail)
        {
            lastSentMail = mail;
        }
    }

    public class Mail
    {
        public string From;
        public string To;
    }

    public class HolidayRequest
    {
        private readonly string employee;
        private readonly string manager;

        public HolidayRequest(string employee, string manager, DateTime start, DateTime end, string type)
        {
            this.employee = employee;
            this.manager = manager;
            Submit();
        }

        private void Submit()
        {
            SendMail(employee, manager);
        }

        private void SendMail(string from, string to)
        {
            Mail mail = new Mail {From = from, To = to};
            MailServer.Send(mail);
        }

        public void Approve()
        {
            SendMail(manager, "hr");
        }
    }
}
