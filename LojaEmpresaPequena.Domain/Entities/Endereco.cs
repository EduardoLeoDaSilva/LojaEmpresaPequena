using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public  string Cidade  { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }

        public Endereco(global::System.Int32 id, global::System.String rua, global::System.String bairro, global::System.String cidade, global::System.String estado, global::System.String cep, global::System.String complemento)
        {
            Id = id;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Complemento = complemento;
        }

        public Endereco()
        {
        }
    }

}
