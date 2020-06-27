using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaEmpresaPequena.Application.Commands.ItemPedidoMediator;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaEmpresaPequena.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private readonly IMediator _media;
        public ItemPedidoController(IMediator media)
        {
            _media = media;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateItemPedido.UpdateItemPedidoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]DeleteItemPedido.DeleteItemPedidoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }
    }
}