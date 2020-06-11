using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaEmpresaPequena.Application.Commands.PedidoMediator;
using LojaEmpresaPequena.Application.Queries.PedidoMediator;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaEmpresaPequena.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PedidoController : ControllerBase
    {

        private readonly IMediator _media;
        public PedidoController(IMediator media)
        {
            _media = media;
        }


        [HttpPost]
        public async Task<IActionResult> Save([FromBody]CreatePedido.CreatePedidoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPedidos(GetAllPedidos.GetAllPedidosContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPedidoById(GetPedido.GetPedidoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePedido([FromBody]UpdatePedido.UpdatePedidoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }
    }
}