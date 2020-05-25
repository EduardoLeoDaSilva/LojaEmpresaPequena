using LojaEmpresaPequena.Domain.Entities.Email;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Interfaces.Services.Email
{
    public interface IEmailService
    {
        Task SendEmail(EmailModel emailModel);
    }
}
