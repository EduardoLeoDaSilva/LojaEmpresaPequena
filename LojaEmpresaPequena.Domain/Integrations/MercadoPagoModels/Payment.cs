using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Integrations.MercadoPagoModels
{
	public class Payment
	{
		public long? Id { get; set; }
		public string Token { get; set; }
		public int Installments { get; set; }

		public string Status { get; set; }
		public string? Status_detail { get; set; }
		public float Transaction_amount { get; set; }
		public string Description { get; set; }

		public string Payment_method_id { get; set; }

		public Payer Payer { get ; set; }
		public string Payment_type_id { get; set; }
		public string Notification_url { get; set; }
		public string Sponsor_id { get; set; }
		public bool Binary_mode { get; set; }
		public string External_reference { get; set; }

		public string Statement_descriptor { get; set; }

		public AdditionalInfo Additional_info { get; set; }
	}
}
