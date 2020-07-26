using LojaEmpresaPequena.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LojaEmpresaPequena.Domain.Entities.Api
{
    public class Result<Entity> 
    {
        public Entity Data { get; set; }
        public bool Success { get; set; }
        public  string [] Errors { get; set; }

        public string Msg { get; set; }

        public Result(Entity data, bool success, string[] errors,string msg)
        {
            Data = data;
            Success = success;
            Errors = errors;
            Msg = msg;
        }

        public Result(bool success, params string[] errors)
        {
            Success = success;
            Errors = errors;
        }

        

        public static  Task<Result<Entity>> Fail(params string[] erros)
        {
            var result = new Result<Entity>(false, erros);
            return Task.FromResult(result);
        }

        public static Result<Entity> FailToMiddleware(params string[] erros)
        {
            throw new DominioException(erros.ToList());
        }


        public static Task<Result<Entity>> Ok(Entity data)
        {
            var result = new Result<Entity>(data,true, null,null);
            return Task.FromResult(result);
        }
    }
}
