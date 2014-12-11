using System;

namespace Holiday
{
    public interface IHolidayRequestView
    {
        void SetEmployee(Employee employee);
        void SetManager(Employee manager);
        void SetStart(DateTime start);
        void SetEnd(DateTime end);
    }
}