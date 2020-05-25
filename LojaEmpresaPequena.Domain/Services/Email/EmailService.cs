using LojaEmpresaPequena.Domain.Entities.Email;
using LojaEmpresaPequena.Domain.Exceptions;
using LojaEmpresaPequena.Domain.Interfaces.Services.Email;
using LojaEmpresaPequena.Domain.Resources;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly string _host;
        private readonly string _from;
        private readonly int _port;
        public EmailService(IConfiguration configuration)
        {
            var configEmail = configuration.GetSection("EmailService");
            VerifyDomainRules.CreateInstance()
                .VerifyRule(configEmail == null, ProgramMessages.ConfigErro)
                .ThrowExceptionDomain();
            _host = configEmail.GetSection("host").Value ;
            _from = configEmail.GetSection("host").Value;
            _port = int.Parse(configEmail.GetSection("host").Value);
        }


        public async Task SendEmail(EmailModel emailModel)
        {
            VerifyDomainRules.CreateInstance()
                .VerifyRule(emailModel == null, ProgramMessages.SendEmailErro)
                .ThrowExceptionDomain();
            using (var smtp = new SmtpClient(_host, _port)) {
                smtp.EnableSsl = true;
                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_from);
                mailMessage.To.Add(emailModel.To);
                mailMessage.Subject = emailModel.Subject;
                mailMessage.Body = emailModel.Message;
                mailMessage.IsBodyHtml = emailModel.IsBodyHtml;
                await smtp.SendMailAsync(mailMessage);
            }
            

        }
    }
}
