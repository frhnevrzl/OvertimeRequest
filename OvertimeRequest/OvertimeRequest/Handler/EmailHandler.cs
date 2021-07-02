using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OvertimeRequest.Handler
{
    public class EmailHandler
    {
        public void SendNotification(string resetCode, string email)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("utimarutiiii@gmail.com", "ImNumber1234");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            NetworkCredential nc = new NetworkCredential("utimarutiiii@gmail.com", "ImNumber1234");
            smtp.Credentials = nc;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("utimarutiiii@gmail.com", "Overtime Request Reset Password");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Reset Password " + DateTime.Now.ToString("HH:mm:ss");
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "Hi " + "\nThis is new password for your account. \n\n" + resetCode + "\n\nThank You";
            smtp.Send(mailMessage);
        }
        public void SendPassword(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");


            MailMessage mm = new MailMessage("utimarutiiii@gmail.com", email)
            {
                Subject = "Email Register Confirmation - " + time24 + ",",
                Body = "Hi," + "<br/> Your password is <b>B0o7c@mp</b>" + "<br/> Please login with your password.",

                IsBodyHtml = true
            };
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true
            };
            NetworkCredential NetworkCred = new NetworkCredential("utimarutiiii@gmail.comm", "ImNumber1234");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }

        public void SendNotificationToEmployee(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");


            MailMessage mm = new MailMessage("utimarutiiii@gmail.com", email)
            {
                Subject = "Request Notification - " + time24 + ",",
                Body = "Hi," + "<br/> Your approval has been sent to your Supervisor" + "<br/> Please Wait for a momment",

                IsBodyHtml = true
            };
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true
            };
            NetworkCredential NetworkCred = new NetworkCredential("utimarutiiii@gmail.com", "ImNumber1234");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }

        public void SendApproveNotificationToEmployee(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");


            MailMessage mm = new MailMessage("utimarutiiii@gmail.com", email)
            {
                Subject = "Approval Result - " + time24 + ",",
                Body = "Hi," + "<br/> Your approval Has Been Approved",

                IsBodyHtml = true
            };
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true
            };
            NetworkCredential NetworkCred = new NetworkCredential("utimarutiiii@gmail.com", "ImNumber1234");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }

        public void SendRejectNotificationToEmployee(string email)
        {
            var time24 = DateTime.Now.ToString("HH:mm:ss");


            MailMessage mm = new MailMessage("utimarutiiii@gmail.com", email)
            {
                Subject = "Approval Result - " + time24 + ",",
                Body = "Hi," + "<br/> Your approval Has Been Rejected",

                IsBodyHtml = true
            };
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true
            };
            NetworkCredential NetworkCred = new NetworkCredential("utimarutiiii@gmail.com", "ImNumber1234");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
        }
    }
}
