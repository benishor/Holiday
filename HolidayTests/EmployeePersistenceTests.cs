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
    public class EmployeePersistenceTests
    {
        [Test]
        public void usage()
        {
            var dal = new DAL();
            var employee = new Employee();
            dal.AddEmployee(employee);
        }
    }
}
