using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaEmpresaPequena.Application.Commands.UsuarioMediator;
using LojaEmpresaPequena.Application.Queries.UsuarioMediator;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaEmpresaPequena.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IMediator _media;
        public UsuarioController(IMediator media)
        {
            _media = media;
        }


        [HttpPost]
        public async Task<IActionResult> Save([FromBody]CreateUsuarioAdmin.CreateUsuarioAdminContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios(GetAllUsuarios.GetAllUsuariosContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUsuarioById(GetUsuario.GetUsuarioContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUsuario([FromBody]UpdateUsuario.UpdateUsuarioContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn([FromBody]SignIn.SignInContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

    }
}