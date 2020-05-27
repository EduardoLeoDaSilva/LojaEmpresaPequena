using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaEmpresaPequena.Application.Commands.EnderecoMediator;
using LojaEmpresaPequena.Application.Queries.EnderecoMediator;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaEmpresaPequena.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {

        private readonly IMediator _media;
        public EnderecoController(IMediator media)
        {
            _media = media;
        }


        [HttpPost]
        public async Task<IActionResult> Save([FromBody]CreateEndereco.CreateEnderecoContract endereco)
        {
            var result = await _media.Send(endereco);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnderecos(GetAllEnderecos.GetAllEnderecosContract endereco)
        {
            var result = await _media.Send(endereco);
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetEnderecoById(GetAllEnderecos.GetAllEnderecosContract endereco)
        {
            var result = await _media.Send(endereco);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEndereco([FromBody]UpdateEndereco.UpdateEnderecoContract endereco)
        {
            var result = await _media.Send(endereco);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEndereco(DeleteEndereco.DeleteEnderecoContract endereco)
        {
            var result = await _media.Send(endereco);
            return Ok(result);
        }

    }
}