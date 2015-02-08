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
    }
}
