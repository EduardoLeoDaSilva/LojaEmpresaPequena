using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaEmpresaPequena.Application.Commands.ProdutoMediator;
using LojaEmpresaPequena.Application.ProdutoMediator.Commands;
using LojaEmpresaPequena.Application.Queries.ProdutoMediator;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaEmpresaPequena.Services.Controllers
{

    [Authorize]
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
        public async Task<IActionResult> Save(SaveProduto.SaveProdutoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto([FromRoute]GetProduto.GetProdutoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProdutos([FromQuery]GetAllProdutos.GetAllProdutosContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduto([FromForm]UpdateProduto.UpdateProdutoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto([FromRoute]DeleteProduto.DeleteProdutoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpPost("GetLinkFoto")]
        public async Task<IActionResult> GetLinkFoto([FromForm]GetProdutoFotos.GetProdutoFotoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }
    }
}