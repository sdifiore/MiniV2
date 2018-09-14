using MiniV2.Core;
using MiniV2.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MiniV2.Services
{
    public class Email : IEmail
    {
        public async Task SendAsync(Contato contato)
        {
            var manuelaIbiEmail = new ManuelaIbiEmail();

            var smtpClient = new SmtpClient
            {
                Host = "smtp.sendgrid.net",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(manuelaIbiEmail.Username, manuelaIbiEmail.Password)
            };

            string corpo = contato.Comentario + "\n\r Telefone: " + contato.Telefone;

            using (var message = new MailMessage(contato.Email, "difiores@outlook.com")
            {
                Subject = "Email de Manuela Ibi Nutrição Integrada",
                Body = corpo
            })
            {
                await smtpClient.SendMailAsync(message);
            }
        }
    }
}