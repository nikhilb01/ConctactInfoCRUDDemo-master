using ConctactInfoCRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConctactInfoCRUDDemo.Helpers
{
    public static class EmailHelper
    {
        public static readonly string EMAIL_SENDER = ""; 
        public static readonly string EMAIL_CREDENTIALS = "";
        public static readonly string SMTP_CLIENT = "smtp.gmail.com";
        public static readonly string EMAIL_BODY = "Reset your Password <a href='http://{0}.safetychain.com/api/Account/forgotPassword?{1}'>Here.</a>";
        private static string senderAddress;
        private static string clientAddress;
        private  static string netPassword;
        static EmailHelper()
        {

        }

        public static void Init(string sender, string Password, string client)
        {
            senderAddress = sender;
            netPassword = Password;
            clientAddress = client;
        }
        public static bool SendEMail(EmailModel emailModel)
        {
            bool isMessageSent = false;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(clientAddress);
            client.Port = 587;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = true;
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(senderAddress, netPassword);
            client.EnableSsl = true;
            client.Credentials = credentials;
            try
            {
                var mail = new System.Net.Mail.MailMessage(senderAddress.Trim(), emailModel.Recipient.Trim());
                mail.Subject = emailModel.Subject;
                mail.Body = emailModel.Message;
                mail.IsBodyHtml = true;
                //System.Net.Mail.Attachment attachment;  
                //attachment = new Attachment(@"C:\Users\XXX\XXX\XXX.jpg");  
                //mail.Attachments.Add(attachment);  
                client.Send(mail);
                isMessageSent = true;
            }
            catch (Exception ex)
            {
                isMessageSent = false;
            }
            return isMessageSent;
        }
    }
}