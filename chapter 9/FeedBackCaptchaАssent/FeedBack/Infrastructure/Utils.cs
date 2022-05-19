using System.Net.Mail;

namespace FeedBack.Infrastructure
{
    public class Utils
    {
        public static string SendMsg(string reply, IConfiguration settings)
        {
            string result = string.Empty;
            try
            {
                string MailSender = settings["EmailSender"];
                string ToMail = settings["Email"];
                string SmtpServ = settings["SmtpServer"];
                MailMessage TheMailMessage = new MailMessage();
                TheMailMessage.From = new MailAddress(MailSender);
                TheMailMessage.To.Add(new MailAddress(ToMail));
                TheMailMessage.Subject = "От приложения FeedBack поступило сообщение";
                TheMailMessage.Body = reply;
                TheMailMessage.IsBodyHtml = true;
                SmtpClient Smtp = new SmtpClient(SmtpServ);
                Smtp.Credentials = new System.Net.NetworkCredential(settings["userMail"], settings["pwdMail"]);
                Smtp.Send(TheMailMessage);
            }
            catch (Exception err)
            {
                result = err.Message;
            }
            return result;
        }
    }
}
