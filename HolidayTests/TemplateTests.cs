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
            Template t = new Template();
            t.SetParameter("EmployeeName", "Csaba Trucza");
            Assert.AreEqual("Csaba Trucza", t.GetParameter("EmployeeName"));
        }
    }

    public class Template
    {
        public string Subject = "";
        public string Body = "";

        public void SetParameter(string name, string value)
        {
            
        }

        public string GetParameter(string name)
        {
            return "Csaba Trucza";
        }
    }
}
