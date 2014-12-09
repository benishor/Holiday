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
        private readonly DateTime start = new DateTime(2014, 11, 11);
        private readonly DateTime end = new DateTime(2014, 11, 12);

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

            Assert.AreEqual(SubmissionMessageTemplate.submissionMessageSubject, testChannel.LastSubject);

            string expectedBody = SubmissionMessageTemplate.submissionMessageBody;
            expectedBody = expectedBody.Replace("{EmployeeName}", employee.Name);
            expectedBody = expectedBody.Replace("{Start}", start.ToShortDateString());
            expectedBody = expectedBody.Replace("{End}", end.ToShortDateString());
            Assert.AreEqual(expectedBody, testChannel.LastBody);
        }

        [Test]
        public void approved_request_sends_message()
        {
            CreateHolidayRequest();

            request.Approve();

            Assert.AreEqual(manager.Email, testChannel.LastFrom);
            Assert.AreEqual(Employee.HR().Email, testChannel.LastTo);
            Assert.AreEqual(employee.Email, testChannel.LastCC);

            Assert.AreEqual(ApprovalMessageTemplate.approvalMessageSubject, testChannel.LastSubject);

            string expectedBody = ApprovalMessageTemplate.approvalMessageBody;
            expectedBody = expectedBody.Replace("{EmployeeName}", employee.Name);
            expectedBody = expectedBody.Replace("{Start}", start.ToShortDateString());
            expectedBody = expectedBody.Replace("{End}", end.ToShortDateString());
            expectedBody = expectedBody.Replace("{ManagerName}", manager.Name);

            Assert.AreEqual(expectedBody, testChannel.LastBody);

        }

        [Test]
        public void rejected_request_sends_message()
        {
            CreateHolidayRequest();

            request.Reject();

            Assert.AreEqual(manager.Email, testChannel.LastFrom);
            Assert.AreEqual(employee.Email, testChannel.LastTo);
            Assert.AreEqual(Employee.HR().Email, testChannel.LastCC);

            Assert.AreEqual(RejectionMessageTemplate.rejectionMessageSubject, testChannel.LastSubject);

            string expectedBody = RejectionMessageTemplate.rejectionMessageBody;
            expectedBody = expectedBody.Replace("{EmployeeName}", employee.Name);
            expectedBody = expectedBody.Replace("{Start}", start.ToShortDateString());
            expectedBody = expectedBody.Replace("{End}", end.ToShortDateString());
            expectedBody = expectedBody.Replace("{ManagerName}", manager.Name);

            Assert.AreEqual(expectedBody, testChannel.LastBody);
        }

        private void CreateHolidayRequest()
        {
            request = new HolidayRequest(
                employee,
                manager,
                start,
                end,
                "vacation");            
        }
    }
}
