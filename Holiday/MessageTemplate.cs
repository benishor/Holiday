using System;

namespace Holiday
{
    public class MessageTemplate : Template
    {
        public string Subject = "";

        public MessageTemplate(string template, string employeeName, string managerName, string start, string end)
            : base(template)
        {
            //SetEmployeeName(employeeName);
            //SetManagerName(managerName);
            //SetStartDate(start);
            //SetEndDate(end);
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