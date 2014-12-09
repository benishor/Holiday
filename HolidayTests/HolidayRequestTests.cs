using System;
using Holiday;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class HolidayRequestTests
    {
        private HolidayRequest request;
        private TestChannel testChannel;
        private readonly Employee employee = new Employee {Name= "Csaba Trucza", Email = "csaba.trucza@iquestgroup.com"};
        private readonly Employee manager = new Employee {Name= "Andrei Doibani", Email = "andrei.doibani@iquestgroup.com"};

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
            Assert.AreEqual(employee.Email, testChannel.LastFrom);
            Assert.AreEqual(manager.Email, testChannel.LastTo);
            Assert.AreEqual(Employee.HR().Email, testChannel.LastCC);
            Assert.AreEqual(Template.submissionMessageSubject, testChannel.LastSubject);
        }

        [Test]
        public void approved_request_sends_message()
        {
            CreateHolidayRequest();

            request.Approve();
            Assert.AreEqual(manager.Email, testChannel.LastFrom);
            Assert.AreEqual(Employee.HR().Email, testChannel.LastTo);
            Assert.AreEqual(employee.Email, testChannel.LastCC);
            Assert.AreEqual("Cerere de concediu aprobata", testChannel.LastSubject);
        }

        [Test]
        public void rejected_request_sends_message()
        {
            CreateHolidayRequest();

            request.Reject();

            Assert.AreEqual(manager.Email, testChannel.LastFrom);
            Assert.AreEqual(employee.Email, testChannel.LastTo);
            Assert.AreEqual(Employee.HR().Email, testChannel.LastCC);
            Assert.AreEqual("Cerere de concediu rejectata", testChannel.LastSubject);
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
