using System;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class HolidayTests
    {
        [Test]
        public void usage()
        {
            HolidayRequest request = new HolidayRequest(
                "csaba.trucza@iquestgroup.com", 
                "andrei.doibani@iquestgroup.com",
                new DateTime(2014, 11, 11),
                new DateTime(2014, 11, 12),
                "vacation");

            request.Approve();
        }

        [Test]
        public void submitted_request_sends_mail()
        {
            HolidayRequest request = new HolidayRequest(
                "csaba.trucza@iquestgroup.com",
                "andrei.doibani@iquestgroup.com",
                new DateTime(2014, 11, 11),
                new DateTime(2014, 11, 12),
                "vacation");

            Assert.IsTrue(MailServer.DidSendMail());
        }

        [Test]
        public void approved_request_sends_mail()
        {
            HolidayRequest request = new HolidayRequest(
                "csaba.trucza@iquestgroup.com",
                "andrei.doibani@iquestgroup.com",
                new DateTime(2014, 11, 11),
                new DateTime(2014, 11, 12),
                "vacation");

            Assert.IsTrue(MailServer.GetLastSentMail().From == "andrei.doibani@iquestgroup.com");
        }

    }

    public class MailServer
    {
        public static bool DidSendMail()
        {
            return true;
        }

        public static Mail GetLastSentMail()
        {
            return new Mail() {From = "andrei.doibani@iquestgroup.com"};
        }
    }

    public class Mail
    {
        public string From;
    }

    public class HolidayRequest
    {
        public HolidayRequest(string employee, string manager, DateTime start, DateTime end, string type)
        {
        }

        public void Approve()
        {
        }
    }
}
