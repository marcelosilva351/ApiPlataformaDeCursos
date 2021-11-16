using Cursos.Dominio.Dto_s.ProfessorDto;
using Cursos.Dominio.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CursosApiDdd.Controllers
{
    [ApiController]
    [Route("v1/professore")]
       
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }


        [HttpPut("AdicionarProfessorAoCurso/{idProfessor}/{idCurso}")]
        public async Task<ActionResult> AdicionarProfessorAoCurso(int idProfessor, int idCurso)
        {
            try
            {
                await _professorService.AdicionarProfessorACurso(idProfessor, idCurso);
                return NoContent();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("ObterProfessoresInclude")]
        public async Task<ActionResult<List<ReadProfessorDTO>>> ObterProfessoresInclude()
        {
            var professores = await _professorService.ObterProfessoresInclude();
            if(professores == null)
            {
                return NotFound(); 
            }
            return professores;
        }

        [HttpPost("CriarProfessor")]

        public async Task<ActionResult> CriarProfessor([FromBody] CreateProfessorDTO createProfessorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _professorService.CriarProfessor(createProfessorDTO);
                return Created("Professor criado", createProfessorDTO);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }



    }
}
