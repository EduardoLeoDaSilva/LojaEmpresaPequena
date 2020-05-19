using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Categoria(global::System.Int32 id, global::System.String nome)
        {
            Id = id;
            Nome = nome;
        }

        public Categoria()
        {
        }
    }
}
