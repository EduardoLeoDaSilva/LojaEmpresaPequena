using System;
using System.Collections.Generic;
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

        public Result(bool success, params string[] errors)
        {
            Success = success;
            Errors = errors;
        }

        public Result(Entity data, bool success, string[] errors)
        {
            Data = data;
            Success = success;
            Errors = errors;
        }

        public static  Task<Result<Entity>> Fail(bool v, params string[] erros)
        {
            var result = new Result<Entity>(false, erros);
            return Task.FromResult(result);
        }


        public static Task<Result<Entity>> Ok(Entity data)
        {
            var result = new Result<Entity>(data,true, null);
            return Task.FromResult(result);
        }
    }
}
