namespace Holiday
{
    public class Employee
    {
        public string Name;
        public string Email;

        private static readonly Employee hr = new Employee {Name = "HR - Holidays", Email = "hr@company.com"};

        public static Employee HR()
        {
            return hr;
        }
    }
}