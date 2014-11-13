using System;
using Holiday;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class HolidayTests
    {
        private HolidayRequest request;
        private TestChannel testChannel;
        private const string employee = "csaba.trucza@iquestgroup.com";
        private const string manager = "andrei.doibani@iquestgroup.com";

        [SetUp]
        public void SetUp()
        {
            testChannel = new TestChannel();
            ChannelLocator.Channel = testChannel;
        }

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

            Assert.AreEqual(employee, testChannel.GetLastSentMail().From);
            Assert.AreEqual(manager, testChannel.GetLastSentMail().To);
        }

        [Test]
        public void approved_request_sends_mail()
        {
            CreateHolidayRequest();

            request.Approve();

            Assert.AreEqual(manager, testChannel.GetLastSentMail().From );
            Assert.AreEqual("hr", testChannel.GetLastSentMail().To);
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
}
