﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaEmpresaPequena.Application.Commands.PedidoMediator;
using LojaEmpresaPequena.Application.Queries.PedidoMediator;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaEmpresaPequena.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly IMediator _media;
        public PedidoController(IMediator media)
        {
            _media = media;
        }


        [HttpPost]
        public async Task<IActionResult> Save([FromBody]CreatePedido.CreatePedidoContract pedido)
        {
            var result = await _media.Send(pedido);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPedidos(GetAllPedidos.GetAllPedidosContract pedido)
        {
            var result = await _media.Send(pedido);
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPedidoById(GetAllPedidos.GetAllPedidosContract pedido)
        {
            var result = await _media.Send(pedido);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePedido([FromBody]UpdatePedido.UpdatePedidoContract pedido)
        {
            var result = await _media.Send(pedido);
            return Ok(result);
        }
    }
}