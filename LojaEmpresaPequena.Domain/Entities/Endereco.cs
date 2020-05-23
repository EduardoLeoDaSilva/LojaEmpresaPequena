using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public  string Cidade  { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }

        public Usuario Usuario { get; set; }

        public Endereco(string rua, string bairro, string cidade, string estado, string cep, string complemento, Usuario usuario)
        {
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Complemento = complemento;
            Usuario = usuario;
        }

        public Endereco()
        {
        }
      
    }

}
