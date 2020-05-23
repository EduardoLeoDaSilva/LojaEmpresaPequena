using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
   public class Categoria : BaseEntity
    {
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set; }

        public Categoria(string nome, List<Produto> produtos)
        {
            Nome = nome;
            Produtos = produtos;
        }

        public Categoria()
        {
        }
    }
}
