﻿using System;
using System.Collections.Generic;
using System.Linq;
using Holiday;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class PersistenceTests
    {
        [Test]
        public void usage()
        {
            var dal = new DAL();
            var request = dal.CreateNewRequest(new Employee(), new Employee(), DateTime.Now, DateTime.Now);
            request.Approve();
            dal.UpdateRequest(request);
            request.Reject();
            dal.UpdateRequest(request);
        }

        [Test]
        public void new_requests_are_saved()
        {
            var me = new Employee();
            var dal = new DAL();

            var request = dal.CreateNewRequest(me, new Employee(), DateTime.Now, DateTime.Now);
            var myRequests = dal.GetAllRequest(me).ToList();
            
            Assert.AreEqual(1, myRequests.Count());
            CollectionAssert.Contains(myRequests, request);
        }

        [Test]
        public void my_requests_are_not_mixed_with_others()
        {
            var aUser = new Employee();
            var dal = new DAL();
            var request = dal.CreateNewRequest(aUser, new Employee(), DateTime.Now, DateTime.Now);

            var anotherUser = new Employee();
            var anotherUsersRequests = dal.GetAllRequest(anotherUser).ToList();

            CollectionAssert.IsEmpty(anotherUsersRequests);
        }

        [Test]
        public void can_get_requests_pending_approval()
        {
            var employee = new Employee();
            var dal = new DAL();
            var manager = new Employee();
            var request = dal.CreateNewRequest(employee, manager, DateTime.Now, DateTime.Now);
            var requestsWaitingApproval = dal.GetRequestsWaitingApproval(manager);
            CollectionAssert.Contains(requestsWaitingApproval, request);
        }

        [Test]
        public void approved_requests_are_not_pending()
        {
            var employee = new Employee();
            var dal = new DAL();
            var manager = new Employee();
            var request = dal.CreateNewRequest(employee, manager, DateTime.Now, DateTime.Now);
            request.Approve();

            var requestsWaitingApproval = dal.GetRequestsWaitingApproval(manager);
            CollectionAssert.IsEmpty(requestsWaitingApproval);
        }

        [Test]
        public void rejected_requests_are_not_pending()
        {
            var employee = new Employee();
            var dal = new DAL();
            var manager = new Employee();
            var request = dal.CreateNewRequest(employee, manager, DateTime.Now, DateTime.Now);
            request.Reject();

            var requestsWaitingApproval = dal.GetRequestsWaitingApproval(manager);
            CollectionAssert.IsEmpty(requestsWaitingApproval);
        }
    }

    public class DAL
    {
        private readonly ICollection<HolidayRequest> requests = new List<HolidayRequest>();

        public HolidayRequest CreateNewRequest(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            var newRequest = new HolidayRequest(employee, manager, start, end);
            requests.Add(newRequest);
            return newRequest;
        }

        public void UpdateRequest(HolidayRequest request)
        {
        }

        public IEnumerable<HolidayRequest> GetAllRequest(Employee employee)
        {
            return requests.Where(r=>r.WasSubmittedBy(employee));
        }

        public IEnumerable<HolidayRequest> GetRequestsWaitingApproval(Employee manager)
        {
            return requests.Where(r => r.IsWaitingApprovalBy(manager));
        }
    }
}
