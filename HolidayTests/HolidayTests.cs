using System;
using NUnit.Framework;

namespace HolidayTests
{
    [TestFixture]
    public class HolidayTests
    {
        [Test]
        public void usage()
        {
            HolidayRequest request = new HolidayRequest(
                "csaba.trucza@iquestgroup.com", 
                "andrei.doibani@iquestgroup.com",
                new DateTime(2014, 11, 11),
                new DateTime(2014, 11, 12),
                "vacation");

            request.Approve();
        }

    }

    public class HolidayRequest
    {
        public HolidayRequest(string employee, string manager, DateTime start, DateTime end, string type)
        {
        }

        public void Approve()
        {
        }
    }
}
