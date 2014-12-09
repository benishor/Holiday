using System;

namespace Holiday
{
    public class MessageTemplate : Template
    {
        public string Subject = "";

        public MessageTemplate(string template)
            : base(template)
        {
        }

        public void SetEmployeeName(string employeeName)
        {
            SetParameter("EmployeeName", employeeName);
        }

        public void SetManagerName(string managerName)
        {
            SetParameter("ManagerName", managerName);
        }

        public void SetStartDate(DateTime start)
        {
            SetParameter("Start", start.ToShortDateString());
        }

        public void SetEndDate(DateTime end)
        {
            SetParameter("End", end.ToShortDateString());
        }
    }
}