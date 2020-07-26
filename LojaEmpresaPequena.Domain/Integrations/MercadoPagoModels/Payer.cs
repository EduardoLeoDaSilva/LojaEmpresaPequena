using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Integrations.MercadoPagoModels
{
    public class Payer
    {

        public string Email { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public Address Address { get; set; }

    }
}
