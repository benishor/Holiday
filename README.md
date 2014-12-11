Holiday
=======

[![Gitter](https://badges.gitter.im/Join Chat.svg)](https://gitter.im/ctrucza/Holiday?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Part of the holiday request application, we needed to send various emails around:
- when an employee wants a holiday, it fills out a form and submits it. The request is sent to the user's manager.
- if someone is a manager, he will receive the an email when someone submits a holiday request. He can choose to approve or reject the request.
- when a request is approved by the manager, a mail is sent to the HR
- when a request is rejected, a mail is sent to the original user.

In this homework your job is to design a solution for sending the different mails as the result of the different actions.

You can assume that a skeletal HolidayRequest class is already prepared:

    public class HolidayRequest
    {
        public string EmployeeName;
        public string EmployeeEmail;
        public string ManagerEmail;
     
        // holiday period
        public DateTime From;
        public DateTime To;
    }
  
You can also assume you can use the email sending facilities from the .Net framework (you'll have to find them though :smile: )

Starting from the skeletal class above design and code up a solution which handles the email sending functionality. Feel free to create new classes or modify the provided skeletal class.

Focus on names, responsibilities, coupling, cohesion. Pay attention to code readability, method lengths etc.
