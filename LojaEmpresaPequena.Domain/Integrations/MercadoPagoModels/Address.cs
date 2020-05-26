using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Integrations.MercadoPagoModels
{
    public class Address
    {
        public string Zip_code { get; set; }
        public string Street_name { get; set; }
        public int Street_number { get; set; }
    }
}
