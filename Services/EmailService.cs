using System.Net;
using System.Net.Mail;
using login2fa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;


namespace login2fa.Services
{
    public class EmailService
    {
        public async Task EnviarPinPorCorreo(string destino, string pin)
        {
            using var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("angdvi666@gmail.com", "asgxmmynyryguphi"),
                EnableSsl = true,
            };

            var mensaje = new MailMessage("angdvi666@gmail.com", destino)
            {
                Subject = "Código de Verificación - 2FA",
                Body = $"Tu código de verificación es: {pin}"
            };

            await smtp.SendMailAsync(mensaje);
        }
    }
}
 