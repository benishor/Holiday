namespace Holiday
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        private static readonly Employee hr = new Employee {Name = "HR - Holidays", Email = "hr@company.com"};

        public static Employee HR()
        {
            return hr;
        }
    }
}