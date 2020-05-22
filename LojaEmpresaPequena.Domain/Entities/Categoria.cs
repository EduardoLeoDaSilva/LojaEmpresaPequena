using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
   public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set; }

        public Categoria(global::System.Int32 id, global::System.String nome, List<Produto> produtos)
        {
            Id = id;
            Nome = nome;
            Produtos = produtos;
        }

        public Categoria()
        {
        }
    }
}
