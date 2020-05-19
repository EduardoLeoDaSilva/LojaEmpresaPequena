using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public  double Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
