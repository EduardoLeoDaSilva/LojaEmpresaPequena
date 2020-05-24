using System;
using System.Collections.Generic;
using System.Text;

namespace LojaEmpresaPequena.Domain.Entities.Api
{
    public class Result
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }

        public Result(bool success, List<string> errors)
        {
            Success = success;
            Errors = errors;
        }
    }
}
