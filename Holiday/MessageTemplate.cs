namespace Holiday
{
    public class MessageTemplate : Template
    {
        public MessageTemplate(string employeeName, string managerName, string start, string end)
        {
            SetParameter("EmployeeName", employeeName);
            SetParameter("ManagerName", managerName);
            SetParameter("Start", start);
            SetParameter("End", end);
        }
    }
}