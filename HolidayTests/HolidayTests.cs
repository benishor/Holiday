using System;
using System.ComponentModel;
using Holiday;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class HolidayTests
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
            Assert.IsTrue(testChannel.LastMessageFrom(employee.Email));
            Assert.IsTrue(testChannel.LastMessageTo(manager.Email));
            Assert.IsTrue(testChannel.LastMessageCC(Employee.HR().Email));
        }

        [Test]
        public void approved_request_sends_message()
        {
            CreateHolidayRequest();

            request.Approve();
            Assert.IsTrue(testChannel.LastMessageFrom(manager.Email));
            Assert.IsTrue(testChannel.LastMessageTo(Employee.HR().Email));
            Assert.IsTrue(testChannel.LastMessageCC(employee.Email));
        }

        [Test]
        public void rejected_request_sends_message()
        {
            CreateHolidayRequest();

            request.Reject();
            Assert.IsTrue(testChannel.LastMessageFrom(manager.Email));
            Assert.IsTrue(testChannel.LastMessageTo(employee.Email));
            Assert.IsTrue(testChannel.LastMessageCC(Employee.HR().Email));
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
