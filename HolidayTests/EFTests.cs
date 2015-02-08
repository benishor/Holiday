using System;
using System.Linq;
using Holiday;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class EFTests
    {
        [SetUp]
        public void SetUp()
        {
            ChannelLocator.Channel = new TestChannel();
        }

        [TearDown]
        public void TearDown()
        {
            ChannelLocator.Channel = null;
        }

        [Test]
        public void smoke_test()
        {
            EFStorage storage = new EFStorage();
            storage.Add(new Employee());
            storage.Add(new HolidayRequest(new Employee(), new Employee(), DateTime.Now, DateTime.Now));
            var employees = storage.GetStorageFor<Employee>().ToList();
            var holidayRequests = storage.GetStorageFor<HolidayRequest>().ToList();
        }

        [Test]
        public void usage_test()
        {
            {
                var dal = new DAL(new EFStorage());
                var employee = new Employee();
                dal.AddEmployee(employee);
                var manager = new Employee();
                dal.AddEmployee(manager);

                var request = new HolidayRequest(employee, manager, DateTime.Now, DateTime.Now);
                dal.AddRequest(request);

                dal.ApproveRequest(request);
                dal.RejectRequest(request);
                
            }

            // What we want:
            {
                var dal = new DAL(new EFStorage());

                var employee = new Employee();
                dal.AddEmployee(employee);
                var manager = new Employee();
                dal.AddEmployee(manager);

                var request = new HolidayRequest(employee, manager, DateTime.Now, DateTime.Now);
                dal.AddRequest(request);

                request.Approve();
                request.Reject();
                
            }
        }

        [Test]
        public void new_employee_is_saved()
        {
            var dal = new DAL(new EFStorage());
            var employee = new Employee();
            employee.Email = "employee@company.com";
            employee.Name = "John Doe";
            dal.AddEmployee(employee);
            var savedEmployee = dal.GetEmployeeByID(employee.ID);
            Assert.IsNotNull(savedEmployee);
            Assert.AreEqual(employee, savedEmployee);

            // Just for good measure, load the employee from another context
            var anotherDal = new DAL(new EFStorage());
            var copyOfEmployee = anotherDal.GetEmployeeByID(employee.ID);
            Assert.IsNotNull(copyOfEmployee);
            Assert.AreEqual(employee.Name, copyOfEmployee.Name);
            Assert.AreEqual(employee.Email, copyOfEmployee.Email);
        }

        [Test]
        public void new_request_is_saved()
        {
            var dal = new DAL(new EFStorage());

            var employee = new Employee {Name = "Employee", Email = "employee@company.com"};
            dal.AddEmployee(employee);
            var manager = new Employee {Name = "Manager", Email = "manager@company.com"};
            dal.AddEmployee(manager);

            var request = new HolidayRequest(employee, manager, DateTime.Now, DateTime.Now);
            dal.AddRequest(request);
            var savedRequest = dal.GetRequestByID(request.ID);
            Assert.AreEqual(request, savedRequest);
            
            var anotherDal = new DAL(new EFStorage());
            var copyOfRequest = anotherDal.GetRequestByID(request.ID);
            Assert.AreEqual(request.employee.Name, copyOfRequest.employee.Name);
            Assert.AreEqual(request.manager.Name, copyOfRequest.manager.Name);
        }
    }
}
