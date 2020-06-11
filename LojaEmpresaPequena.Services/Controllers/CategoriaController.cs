using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaEmpresaPequena.Application.Commands.CategoriaMediator;
using LojaEmpresaPequena.Application.Queries.CategoriaMediator;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaEmpresaPequena.Services.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _media;
        public CategoriaController(IMediator media)
        {
            _media = media;
        }


        [HttpPost]
        public async Task<IActionResult> Save([FromBody]CreateCategoria.CreateCategoriaContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategorias([FromQuery] GetAllCategorias.GetAllCategoriasContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpGet("lista")]
        public async Task<IActionResult> GetAllCategoriasList([FromQuery] GetAllCategoriasList.GetAllCategoriasListContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoriaById([FromRoute] GetCategoria.GetCategoriaContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCategoria([FromBody]UpdateCategoria.UpdateCategoriaContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria([FromRoute]DeleteCategoria.DeleteCategoriaContract contract)
        {
            var result = await _media.Send(contract);
            return Ok(result);
        }


    }
}