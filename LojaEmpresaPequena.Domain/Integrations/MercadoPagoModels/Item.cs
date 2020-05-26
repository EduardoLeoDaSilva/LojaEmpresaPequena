using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Integrations.MercadoPagoModels
{
    public class Item
    {
        public string Id { get; set; }
        public string Title  { get; set; }
        public string Picture_url { get; set; }
        public string Quantity { get; set; }
        public double Unit_price { get; set; }
    }
}
