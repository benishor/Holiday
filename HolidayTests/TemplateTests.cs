using System.Collections.Generic;
using NUnit.Framework;

namespace HolidayTests
{
    
    [TestFixture]
    public class TemplateTests
    {
        [Test]
        public void Template_has_subject_and_body()
        {
            Template t = new Template();
            Assert.IsNotNull(t.Subject);
            Assert.IsNotNull(t.Body);
        }

        [Test]
        public void Template_has_parameters()
        {
            const string name = "EmployeeName";
            const string value = "Csaba Trucza";

            Template t = new Template();
            t.SetParameter(name, value);

            var actual = t.GetParameter(name);

            Assert.AreEqual(value, actual);
        }
    }

    public class Template
    {
        public string Subject = "";
        public string Body = "";
        private Dictionary<string, string> parameters = new Dictionary<string, string>(); 

        public void SetParameter(string name, string value)
        {
            parameters[name] = value;
        }

        public string GetParameter(string name)
        {
            return parameters[name];
        }
    }
}
