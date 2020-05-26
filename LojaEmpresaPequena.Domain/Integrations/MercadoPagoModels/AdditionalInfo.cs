using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Integrations.MercadoPagoModels
{
    public class AdditionalInfo
    {
        public IList<Item> Items { get; set; }
        public Payer Payer { get; set; }

        public Shipments Shipments { get; set; }
    }
}
