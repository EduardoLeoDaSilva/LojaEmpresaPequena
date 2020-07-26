window.Mercadopago.setPublishableKey("TEST-6e3b5050-bb5c-456a-9ff8-a62b79d46b8c");
window.Mercadopago.getIdentificationTypes();


document.getElementById('cardNumber').addEventListener('keyup', guessPaymentMethod);
document.getElementById('cardNumber').addEventListener('change', guessPaymentMethod);

document.getElementById('pagarButton').setAttribute("disabled", "true");


function guessPaymentMethod(event) {

    let cardnumber = document.getElementById("cardNumber").value;

    if (cardnumber.length >= 6) {
        let bin = cardnumber.substring(0, 6);
        window.Mercadopago.getPaymentMethod({
            "bin": bin
        }, setPaymentMethod);
    }
};

function setPaymentMethod(status, response) {
    if (status === 200) {
        let paymentMethodId = response[0].id;
        let element = document.getElementById('payment_method_id');
        element.value = paymentMethodId;
        getInstallments();
    } else {
        swal("Mensagem!", "Não aceitamos esse cartão no momento", "error");
    }
}

function getInstallments() {
    window.Mercadopago.getInstallments({
        "payment_method_id": document.getElementById('payment_method_id').value,
        "amount": parseFloat(document.getElementById('transaction_amount').value)

    }, function (status, response) {
        if (status === 200) {
            document.getElementById('installments').options.length = 0;
            response[0].payer_costs.forEach(installment => {
                let opt = document.createElement('option');
                opt.text = installment.recommended_message;
                opt.value = installment.installments;
                document.getElementById('installments').appendChild(opt);
            });
        } else {
            alert("installments method info error:" + response);
        }
    });
}

doSubmit = false;

document.getElementById('confirmarButton').addEventListener('click', doPay);


//document.getElementById('credit_card').addEventListener('click', checkPaymentType);
//document.getElementById('debit_card').addEventListener('click', checkPaymentType);


//function checkPaymentType(event) {

//    localStorage.setItem('paymentType', event.currentTarget.id);

//}

function doPay(event) {
    event.preventDefault();
    if (!doSubmit) {
        var $form = document.querySelector('#pay');

        
        window.Mercadopago.createToken($form, sdkResponseHandler);

        return false;
    }
};

function sdkResponseHandler(status, response) {
    if (status !== 200 && status !== 201) {

        switch (response.cause[0].code) {
            case '205': swal("Mensagem!", "Digite o numero do seu cartao.", "error"); break;
            case '208': swal("Mensagem!", "Escolha um mes.", "error");  break;
            case '209': swal("Mensagem!", "Escolha um ano.", "error");  break;
            case '212': swal("Mensagem!", "Informe seu documento.", "error");  break;
            case '213': swal("Mensagem!", "Informe seu documento.", "error"); break;
            case '214': swal("Mensagem!", "Informe seu documento.", "error"); break;
            case '220': swal("Mensagem!", "Informe seu banco emissor.", "error");  break;
            case '221': swal("Mensagem!", "Digite o nome e sobrenome.", "error"); break;
            case '224': swal("Mensagem!", "Digite o código de segurança.", "error"); break;
            case 'E301': swal("Mensagem!", "Ha algo de errado com esse número. Digite novamente.", "error"); break;
            case 'E302': swal("Mensagem!", "Confira o codigo de segurança.", "error");  break;
            case '316': swal("Mensagem!", "Por favor, digite um nome valido.", "error");  break;
            case '322': swal("Mensagem!", "Confira seu documento.", "error");  break;
            case '323': swal("Mensagem!", "Confira seu documento.", "error"); break;
            case '324': swal("Mensagem!", "Confira seu documento.", "error");  break;
            case '325': swal("Mensagem!", "Confira a data.", "error"); break;
            case '326': swal("Mensagem!", "Confira a data.", "error");  break;
            default: swal("Mensagem!", "Confira os dados.", "error");
                }

        
    } else {
        swal("Mensagem!", "Dados validados!", "success");

        document.getElementById('pagarButton').removeAttribute("disabled");

        var form = document.querySelector('#pay');
        var card = document.createElement('input');
        var paymentMethod = document.getElementById('payment_method_id');



        card.setAttribute('name', 'token');
        card.setAttribute('type', 'hidden');
        card.setAttribute('value', response.id);
        form.appendChild(card);
        doSubmit = true;
        localStorage.setItem('token', card.value);
        localStorage.setItem('paymentMethod', paymentMethod.value);
        window.Mercadopago.clearSession();


    }
};
