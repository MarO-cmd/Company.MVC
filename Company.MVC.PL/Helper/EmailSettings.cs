using Company.MVC.DAL.Models;
using Company.MVC.PL.ViewModels.Auth;
using System.Net;
using System.Net.Mail;

namespace Company.MVC.PL.Helper
{
	public static class EmailSettings
	{
		public static void SendEmail(Email email)
		{
			// you can send email using (gmail or outlock, ...etc) -> this called Mail Server
			// Any server has Mail Server
			// I will use Mail Server for google which is (gmail.com)
			// Need this protocol: smtp

			var client = new SmtpClient("smtp.gmail.com", 587);
			client.EnableSsl = true; // enable encryption

			client.Credentials = new NetworkCredential("maroasd33@gmail.com", "wpkymcofuyxedkfl");
            // wpkymcofuyxedkfl
            client.Send("maroasd33@gmail.com", email.To, email.Subject, email.Body);

		}
	}
}
