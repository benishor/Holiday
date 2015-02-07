using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class EmployeePersistenceTests
    {
        [Test]
        public void usage()
        {
            var dal = new DAL();
            var employee = dal.CreateNewEmployee();
        }
    }
}
