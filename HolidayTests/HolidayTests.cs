using System;
using System.Management.Instrumentation;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class HolidayTests
    {
        [Test]
        public void usage()
        {
            var request = CreateHolidayRequest();

            request.Approve();
        }

        [Test]
        public void submitted_request_sends_mail()
        {
            var request = CreateHolidayRequest();

            Assert.IsTrue(MailServer.GetLastSentMail().From == "csaba.trucza@iquestgroup.com");
        }

        [Test]
        public void approved_request_sends_mail()
        {
            var request = CreateHolidayRequest();

            request.Approve();

            Assert.IsTrue(MailServer.GetLastSentMail().From == "andrei.doibani@iquestgroup.com");
        }

        private static HolidayRequest CreateHolidayRequest()
        {
            HolidayRequest request = new HolidayRequest(
                "csaba.trucza@iquestgroup.com",
                "andrei.doibani@iquestgroup.com",
                new DateTime(2014, 11, 11),
                new DateTime(2014, 11, 12),
                "vacation");
            return request;
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
            Mail mail = new Mail {From =from};
            MailServer.Send(mail);
        }

        public void Approve()
        {
            SendMail(manager, "hr");
        }
    }
}
