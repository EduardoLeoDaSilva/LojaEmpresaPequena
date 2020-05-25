using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaEmpresaPequena.Application.ProdutoMediator.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaEmpresaPequena.Services.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator _media;
        public ProdutoController(IMediator media)
        {
            _media = media;
        }

 
        [HttpPost]
        public async Task<IActionResult> Save(SaveProduto.SaveProdutoContract produto)
        {
            var result = await _media.Send(produto);
            return Ok(result);
        }
    }
}