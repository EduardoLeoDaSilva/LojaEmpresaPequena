using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
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

        [AllowAnonymous]
        [HttpGet("jsFile")]
        public IActionResult GetJavaScript()
        {
            return PhysicalFile(Path.Combine(Assembly.GetEntryAssembly().Location, @"arqs/mercadopago.js") , "application/javascript");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllPedidos([FromQuery]GetAllPedidos.GetAllPedidosContract contract)
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

        [HttpPost("GetByUserId")]
        public async Task<IActionResult> GetPedidoByUserId([FromBody]GetPedidoByUsername.GetPedidoByUsernameContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }


        [HttpPost("GetCurrentPedido")]
        public async Task<IActionResult> GetCurrentPedidoId(GetCurrentPedido.GetCurrentPedidoContract contract)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var email = User.FindFirst(x => x.Type == ClaimTypes.Name).Value;
            contract.Email = email;

            var result = await _media.Send(contract);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdatePedido([FromBody]UpdatePedido.UpdatePedidoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }


        [HttpPut("statusEnvio")]
        public async Task<IActionResult> UpdateStatusEnvio([FromBody]UpdateStatusEnvio.UpdateStatusEnvioContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpPut("Paypedido")]
        public async Task<IActionResult> Paypedido([FromBody]PayPedido.PayPedidoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }
    }
}