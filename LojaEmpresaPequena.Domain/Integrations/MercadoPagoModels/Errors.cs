using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Integrations.MercadoPagoModels
{
    public static class Errors
    {
        public static string GetErrorMsg(string error, string nameCobranca = "testeEmpresa")
        {
            var msg = "";
            switch (error)
            {
                case "accredited":
                    msg = $"Pronto, seu pagamento foi aprovado! No resumo, você verá a cobrança do valor como {nameCobranca}.";
                    break;
                case "pending_contingency":
                    msg = $"Estamos processando o pagamento. Não se preocupe, em menos de 2 dias úteis informaremos por e-mail se foi creditado.";
                    break;
                case "pending_review_manual": 
                    msg = $"Estamos processando seu pagamento. Não se preocupe, em menos de 2 dias úteis informaremos por e-mail se foi creditado ou se necessitamos de mais informação."; break;
                case "cc_rejected_bad_filled_card_number": 
                    msg = $"Revise o número do cartão."; break;
                case "cc_rejected_bad_filled_date": 
                    msg = $"Revise a data de vencimento."; break;
                case "cc_rejected_bad_filled_other":
                    msg = $"Revise os dados."; break;
                case "cc_rejected_bad_filled_security_code":
                    msg = $"Revise o código de segurança do cartão."; break;
                case "cc_rejected_blacklist":
                    msg = $"Não pudemos processar seu pagamento."; break;
                case "cc_rejected_call_for_authorize":
                    msg = $"Você deve autorizar ao cartão o pagamento do valor ao Mercado Pago."; break;
                case "cc_rejected_card_disabled":
                    msg = $"Ligue para a operadora do seu cartão para ativar seu cartão. O telefone está no verso do seu cartão."; break;
                case "cc_rejected_card_error":
                    msg = $"Não conseguimos processar seu pagamento."; break;
                case "cc_rejected_duplicated_payment":
                    msg = $"Você já efetuou um pagamento com esse valor. Caso precise pagar novamente, utilize outro cartão ou outra forma de pagamento."; break;
                case "cc_rejected_high_risk":
                    msg = $"Seu pagamento foi recusado. Escolha outra forma de pagamento.Recomendamos meios de pagamento em dinheiro."; break;
                case "cc_rejected_insufficient_amount":
                    msg = $"O cartão possui saldo insuficiente."; break;
                case "cc_rejected_invalid_installments":
                    msg = $"O cartão não processa pagamentos em nessa quantidades de parcelas."; break;
                case "cc_rejected_max_attempts":
                    msg = $"Você atingiu o limite de tentativas permitido. Escolha outro cartão ou outra forma de pagamento"; break;
                case "cc_rejected_other_reason":
                    msg = $"O cartão não processa o pagamento."; break;
                default:
                    msg = "Ocorreu um erro, por favor tente mais tarde.";
                    break;
            }
            return msg;

        }


    }
}
