using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Exceptions
{
    public class DominioException : ArgumentException
    {
        public List<string> Errors { get; set; }
        public DominioException(List<string> errors) : base("Ocorreu um erro no dominio")
        {
            Errors = errors;
        }
    }
}
