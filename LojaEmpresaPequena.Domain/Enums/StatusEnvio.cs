using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Enums
{
    public enum StatusEnvio
    {
        EsperandoAprovacao = 0,
        EmPreparacao = 1,
        Enviado = 2,
        Entregue =3,
        PagamentoRejeitado=4

    }
}
