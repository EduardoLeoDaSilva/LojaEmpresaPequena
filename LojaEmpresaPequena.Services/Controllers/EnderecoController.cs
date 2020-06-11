using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaEmpresaPequena.Application.Commands.EnderecoMediator;
using LojaEmpresaPequena.Application.Queries.EnderecoMediator;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaEmpresaPequena.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnderecoController : ControllerBase
    {

        private readonly IMediator _media;
        public EnderecoController(IMediator media)
        {
            _media = media;
        }


        [HttpPost]
        public async Task<IActionResult> Save([FromBody]CreateEndereco.CreateEnderecoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnderecos(GetAllEnderecos.GetAllEnderecosContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetEnderecoById(GetEndereco.GetEnderecoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEndereco([FromBody]UpdateEndereco.UpdateEnderecoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEndereco(DeleteEndereco.DeleteEnderecoContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

    }
}