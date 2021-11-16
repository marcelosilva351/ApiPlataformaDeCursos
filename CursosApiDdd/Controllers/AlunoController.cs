using Cursos.Dominio.Dto_s.AlunosDto;
using Cursos.Dominio.Dto_s.Helpers;
using Cursos.Dominio.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CursosApiDdd.Controllers
{

    [ApiController]
    [Route("v1/alunos")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }


        [HttpGet("ObterAlunosPorTurma/{IdTurma}")]
        public async Task<ActionResult<List<ReadAlunoDTO>>> ObterAlunosPorTurma(int IdTurma)
        {
            var alunos = await _alunoService.ObterAlunosPorTurma(IdTurma);
            if(alunos == null){
                return NotFound("Lista de alunos vazia");
            }
            return Ok(alunos);
        }
        [HttpPut("AdicionarAluno-Turma/{idAluno}/{idTurma}")]
        public async Task<ActionResult> AddAlunoTurma(int idAluno, int idTurma)
        {
            try
            {
                await _alunoService.AdicionarAlunoATurma(idAluno, idTurma);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpPut("AdicionarNotasAluno/{idAluno}")]
        public async Task<ActionResult> AddNotasAluno(int idAluno, [FromBody] NotasAluno notasAluno)
        {
            try
            {
                await _alunoService.AdicionarNotarAluno(idAluno, notasAluno);
                return NoContent();

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("ObterAlunosInclude")]
        public async Task<ActionResult<List<ReadAlunoDTO>>> ObterAlunosInclude()
        {
           var alunos = await _alunoService.ObterAlunosInclude();
            if(alunos == null)
            {
                return NotFound("Lista de alunos vazia");
            }
            return Ok(alunos);
        }

        [HttpGet("ObterAlunosPaginados/{numPag}/{numReg}")]
        public async Task<ActionResult<List<ReadAlunoDTO>>> AlunosPaginados(int numPag, int numReg)
        {
            var paginacaoListaAlunos = await _alunoService.ObterAlunosPaginado(numPag, numReg);
            if(paginacaoListaAlunos == null)
            {
                return NotFound("Pagina não existe");
            }
            Response.Headers.Add("Pagination-X", JsonConvert.SerializeObject(paginacaoListaAlunos));
            return Ok(paginacaoListaAlunos.ListaPaginada);
        }


        [HttpPost("CriarAluno")]
        public async Task<ActionResult> CriarAluno([FromBody] CreateAlunoDTO createAlunoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                await _alunoService.CriarAluno(createAlunoDTO);
                return Created("Aluno criado", createAlunoDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        } 

        [HttpPut("AtulizarAluno/{alunoId}")]
        public async Task<ActionResult> AtualizarAluno(int alunoId, [FromBody] CreateAlunoDTO updateAlunoDTO)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {

                await _alunoService.AtualiarAluno(alunoId, updateAlunoDTO);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete("ExcluirAluno/{idAluno}")]
        public async Task<ActionResult> ExcluirAluno(int idAluno)
        {
            try
            {
                await _alunoService.DeletarAluno(idAluno);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }









    }
}
