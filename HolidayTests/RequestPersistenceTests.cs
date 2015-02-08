using System;
using System.Linq;
using Holiday;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class RequestPersistenceTests
    {
        private DAL dal;
        [SetUp]
        public void SetUp()
        {
            ChannelLocator.Channel = new TestChannel();
            dal = new DAL(new Storage());
        }

        [TearDown]
        public void TearDown()
        {
            ChannelLocator.Channel = null;
            dal = null;
        }

        [Test]
        public void usage()
        {
            var request = new HolidayRequest(new Employee(), new Employee(), DateTime.Now, DateTime.Now);
            dal.AddRequest(request);
            request.Approve(); // maybe dal.ApproveRequest()
            request.Reject(); // maybe dal.RejectRequest()
        }

        [Test]
        public void new_requests_are_saved()
        {
            var me = new Employee();
            var request = new HolidayRequest(me, new Employee(), DateTime.Now, DateTime.Now);
            dal.AddRequest(request);
            var myRequests = dal.GetAllRequest(me).ToList();
            
            Assert.AreEqual(1, myRequests.Count());
            CollectionAssert.Contains(myRequests, request);
        }

        [Test]
        public void my_requests_are_not_mixed_with_others()
        {
            var aUser = new Employee();
            var request = new HolidayRequest(aUser, new Employee(), DateTime.Now, DateTime.Now);
            dal.AddRequest(request);
            var anotherUser = new Employee();
            var anotherUsersRequests = dal.GetAllRequest(anotherUser).ToList();

            CollectionAssert.IsEmpty(anotherUsersRequests);
        }

        [Test]
        public void can_get_requests_pending_approval()
        {
            var employee = new Employee();
            var manager = new Employee();
            var request = new HolidayRequest(employee, manager, DateTime.Now, DateTime.Now);
            dal.AddRequest(request);
            var requestsWaitingApproval = dal.GetRequestsWaitingApproval(manager);
            CollectionAssert.Contains(requestsWaitingApproval, request);
        }

        [Test]
        public void approved_requests_are_not_pending()
        {
            var employee = new Employee();
            var manager = new Employee();
            var request = new HolidayRequest(employee, manager, DateTime.Now, DateTime.Now);
            dal.AddRequest(request);
            request.Approve();

            var requestsWaitingApproval = dal.GetRequestsWaitingApproval(manager);
            CollectionAssert.IsEmpty(requestsWaitingApproval);
        }

        [Test]
        public void rejected_requests_are_not_pending()
        {
            var employee = new Employee();
            var manager = new Employee();
            var request = new HolidayRequest(employee, manager, DateTime.Now, DateTime.Now);
            dal.AddRequest(request);
            request.Reject();

            var requestsWaitingApproval = dal.GetRequestsWaitingApproval(manager);
            CollectionAssert.IsEmpty(requestsWaitingApproval);
        }
    }
}
