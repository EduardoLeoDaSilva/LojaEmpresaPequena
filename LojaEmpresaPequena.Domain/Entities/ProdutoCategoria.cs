using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities
{
    public class ProdutoCategoria
    {
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
