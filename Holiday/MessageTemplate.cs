namespace Holiday
{
    public class MessageTemplate : Template
    {
        public string Subject = "";

        public MessageTemplate(string template, string employeeName, string managerName, string start, string end)
            : base(template)
        {
            SetParameter("EmployeeName", employeeName);
            SetParameter("ManagerName", managerName);
            SetParameter("Start", start);
            SetParameter("End", end);
        }
    }
}