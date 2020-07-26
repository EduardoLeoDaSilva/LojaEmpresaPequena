using LojaEmpresaPequena.Domain.Entities;
using LojaEmpresaPequena.Domain.Integrations.MercadoPagoModels;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Interfaces.Integrations
{
    public interface IMercadoPagoIntegrationService
    {
        Task<Payment> PayOrder(Usuario usuario,string produto, float preco, int quantidade, string paymentMethod, string tokenCard, int parcelas = 1, string paymentType = "credit_card");
        Payment GetInfoPayment(long id);
        Payment RefundPayment(long id, decimal valueToRefund = 0);
    }
}