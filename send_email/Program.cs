using System.Net;
using System.Net.Mail;
using System;

namespace email
{
    class Program
    {    
        static void Main(string[] args)
        {

            string mittente = "";
            string password = "";

            try
            {
                //mittente e ricevente
                MailAddress to = new MailAddress("", "Ricevente");
                MailAddress from = new MailAddress(mittente, "");
                MailMessage message = new MailMessage(from, to);

                //messaggio
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.Subject = "EmailProva";
                message.Body = @"";

                message.IsBodyHtml = true;

                // settare smtp-client con "basicAuthentication"
                using (SmtpClient client = new SmtpClient("localhost"))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    /*Console.Write("Account: " + mittente + "\nPassword: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.BackgroundColor = ConsoleColor.Green;
                    string password = Console.ReadLine();
                    //Console.Clear();
                    Console.ResetColor();*/

                    client.Credentials = new NetworkCredential(mittente, password);
                    client.Host = "smtp-relay.sendinblue.com";
                    client.Port = 587;
                    
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    client.Send(message);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Email sent");
                    Console.ResetColor();
                }
                
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
    }
}

