using Landing.DAL.Models;
using System.Net;
using System.Net.Mail;

namespace Landing.PL.Helper
{
    public class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("mohammadaljad.1234@gmail.com", "nrur egsy ryus fvrg");
            client.Send("mohammadaljad.1234@gmail.com",email.Recivers, email.Subject, email.Body);
        }
    }
}
