using System;
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
        public void collection_usage()
        {
            //Employee me = new Employee(); // me
            //var dal = new DAL();

            //dal.GetRequestsWaitingForApproval(me);
            //dal.GetAllRequests(me);
            //dal.GetRequestsByStatus(pending);
        }
    }

    public class DAL
    {
        public HolidayRequest CreateNewRequest(Employee employee, Employee manager, DateTime start, DateTime end)
        {
            return new HolidayRequest(employee, manager, start, end);
        }

        public void UpdateRequest(HolidayRequest request)
        {
        }
    }
}
