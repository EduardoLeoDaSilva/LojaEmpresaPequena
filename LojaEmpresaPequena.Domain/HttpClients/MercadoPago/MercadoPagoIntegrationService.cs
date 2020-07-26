using LojaEmpresaPequena.Domain.Interfaces.Integrations;


using System;
using System.Collections.Generic;
using System.Text;
using LojaEmpresaPequena.Domain.Entities;
using System.Net.Http;
using Newtonsoft.Json;
using LojaEmpresaPequena.Domain.Integrations.MercadoPagoModels;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using LojaEmpresaPequena.Domain.Entities.Api;

namespace LojaEmpresaPequena.Domain.HttpClients.MercadoPagoIntegration
{

    public class MercadoPagoIntegrationService : IMercadoPagoIntegrationService
    {


        public async Task<Payment> PayOrder(Usuario usuario, String produto, float preco, int quantidade, string paymentMethod, string tokenCard, int parcelas = 1, string paymentType = "credit_card")
        {
            Payment payment = new Payment
            {
                Binary_mode = true,
                Description = produto,
                Transaction_amount = preco,
                Payment_method_id = paymentMethod,
                Token = tokenCard,
                Installments = 1,
                Payer = new Payer
                {
                    Email = "teste@gmail.com"
                }
            };
            Payment pay = null;
            string url = "https://api.mercadopago.com/v1/payments?access_token=TEST-6273695532108258-052619-ec4ed31f03cff13e638f2aac3c704ae7-275270239";
            using (var http = new HttpClient())
            {
                http.DefaultRequestHeaders.Accept.Clear();
                http.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var json = JsonConvert.SerializeObject(payment, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }).ToLower();
                ///melhorar depois
                ///
                HttpContent Content = new StringContent(json, Encoding.Default, "application/json");
                Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await http.PostAsync(url, Content);
                if(response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Created)
                {
                    var tt = await response.Content.ReadAsStringAsync();
                    Result<Payment>.FailToMiddleware(tt);
                }
                pay = JsonConvert.DeserializeObject<Payment>(await response.Content.ReadAsStringAsync());

            }

            return pay;
        }

        public Payment GetInfoPayment(long id)
        {
            // var payment = Payment.FindById(id);
            return null;
        }

        public Payment RefundPayment(long id, decimal valueToRefund = 0)
        {
            //var payment = Payment.FindById(id);
            if (valueToRefund == 0)
            {
                //  payment.Refund();
            }
            else
            {
                //payment.Refund(valueToRefund);
            }

            return null;
        }
    }
}
