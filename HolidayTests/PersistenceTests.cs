using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var manager = new Employee();
            var dal = new DAL();

            var request = dal.CreateNewRequest(me, manager, DateTime.Now, DateTime.Now);
            var myRequests = dal.GetAllRequest(me).ToList();
            
            Assert.AreEqual(1, myRequests.Count());
            CollectionAssert.Contains(myRequests, request);

            //dal.GetRequestsWaitingForApproval(me);
            //dal.GetAllRequests(me);
            //dal.GetRequestsByStatus(pending);
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

        public IEnumerable<HolidayRequest> GetAllRequest(Employee me)
        {
            return requests;
        }
    }
}
