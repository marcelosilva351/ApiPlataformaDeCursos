using Cursos.Dominio.Dto_s.ProfessorDto;
using Cursos.Dominio.Entidades;
using Cursos.Dominio.Interfaces.Repositorios;
using Cursos.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Infra.Repositories
{
    public class ProfessorRepositorio : Repositorio<Professor>, IProfessorRepositorio
    {
        public ProfessorRepositorio(Context context) : base(context)
        {
        }   

        public async Task AdicionarProfessorACurso(int idProfessor, int idCurso)
        {
            var professorCurso = new ProfessorCurso(idProfessor, idCurso);
            _context.ProfessorCursos.Add(professorCurso);
            await _context.SaveChangesAsync();
        }

        public async  Task<List<ReadProfessorDTO>> ObterProfessoresInclude()
        {
            var professoresInclude = await _context.Professor.Include(x => x.Cursos).ThenInclude(x => x.Curso).
                Select(x => new ReadProfessorDTO
                {
                    Nome = x.Nome,
                    Cursos = x.Cursos.Select(X => X.Curso).ToList()
                }).ToListAsync();
            if (professoresInclude == null)
            {
                return null;
            }
            return professoresInclude;
        }
    }
}
