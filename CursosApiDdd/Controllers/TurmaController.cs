using Cursos.Dominio.Dto_s.TurmasDto;
using Cursos.Dominio.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursosApiDdd.Controllers
{
    [ApiController]
    [Route("v1/turmas")]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService _turmaService;

        public TurmaController(ITurmaService turmaService)
        {
            _turmaService = turmaService;
        }

        [HttpPost]
        public async Task<ActionResult> CriarTurma([FromBody] CreateTurmaDTO createTurmaDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                
                await _turmaService.CriarTurma(createTurmaDTO);
                return Created("Turma criada", createTurmaDTO);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ReadTurmaDTO>>> ObterTurmasInclude()
        {
            var turmas = await _turmaService.ObterTurmasInclude();
            if(turmas == null)
            {
                return NotFound("Lista de turmas vazia");
            }
            return Ok(turmas);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarTurma(int id, [FromBody] CreateTurmaDTO updateTurma)
        {
            try
            {
                await _turmaService.AtualizarTurma(id, updateTurma);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarTurma(int id)
        {
            try
            {
                await _turmaService.DeletarTurma(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
            
    }
}
