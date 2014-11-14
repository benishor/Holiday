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
        public void submitted_request_sends_message()
        {
            CreateHolidayRequest();

            var lastMessage = testChannel.GetLastMessage();
            Assert.AreEqual(employee, lastMessage.From);
            Assert.AreEqual(manager, lastMessage.To);
            Assert.AreEqual("New holiday request", lastMessage.Subject);

            var expectedBody =
                string.Format(
                    "Subsemnatul {0}, angajat iQuest va rog a-mi aproba cererea de concediu de odihna pe perioada {1} - {2}.",
                    employee, new DateTime(2014, 11, 11).ToShortDateString(), new DateTime(2014, 11, 12).ToShortDateString());
            Assert.AreEqual(expectedBody, lastMessage.Body);
        }

        [Test]
        public void approved_request_sends_message()
        {
            CreateHolidayRequest();

            request.Approve();

            var lastMessage = testChannel.GetLastMessage();
            Assert.AreEqual(manager, lastMessage.From );
            Assert.AreEqual("hr", lastMessage.To);
            Assert.AreEqual("Holiday request approved", lastMessage.Subject);

            var expectedBody = string.Format("Subsemnatul {0} aprob cererea de concediu de odihna pe perioada {1} - {2} pentru {3}.",
                manager, new DateTime(2014, 11, 11).ToShortDateString(), new DateTime(2014, 11, 12).ToShortDateString(), employee);
            Assert.AreEqual(expectedBody, lastMessage.Body);
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
