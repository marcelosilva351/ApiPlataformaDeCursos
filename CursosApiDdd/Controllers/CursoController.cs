using Cursos.Dominio.Dto_s.CursosDto;
using Cursos.Dominio.Dto_s.CursosDTO;
using Cursos.Dominio.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursosApiDdd.Controllers
{
    [ApiController]
    [Route("v1/cursos")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpPut("AdicionarProfessorAoCurso/{idProfessor}/{idCurso}")]
        public async Task<ActionResult> adicionarProfessorAoCurso(int idProfessor, int idCurso)
        {
            try
            {
                await _cursoService.AdicionarProfessorAoCurso(idProfessor, idCurso);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("AdicionarTurmaAoCurso/{idTurma}/{idCurso}")]
        public async Task<ActionResult> AdicionarTurmaAoCurso(int idTurma, int idCurso)
        {
            try
            {
                await _cursoService.AdicionarTurmaAoCurso(idTurma, idCurso);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("AtualizarCurso/{id}")]
        public async Task<ActionResult> AtualizarCurso(int id, [FromBody] CreateCursoDTO cursoUpdateDto)
        {
            try
            {
                await _cursoService.AtualizarCurso(id, cursoUpdateDto);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        } 
        [HttpPost("CriarCurso")]
        public async Task<ActionResult> CriarCurso([FromBody] CreateCursoDTO criarCursoDTO)
        {
            try
            {
                await _cursoService.CriarCurso(criarCursoDTO);
                return Created("Curso criado", criarCursoDTO);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete("DeletarCurso/{id}")]
        public async Task<ActionResult> DeletarCurso(int id)
        {
            try
            {
                await _cursoService.DeletarCurso(id);

                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500,e.Message);
            }
        }

        [HttpGet("ObterCursosInclude")]
        public async Task<ActionResult<List<ReadCursoDTO>>> obterCursosInclude()
        {
            var cursos = await _cursoService.ObterCursosInclude();
            if(cursos == null)
            {
                return NotFound("Lista de cursos vazia");
            }
            return cursos;
        }
        





    }
}
