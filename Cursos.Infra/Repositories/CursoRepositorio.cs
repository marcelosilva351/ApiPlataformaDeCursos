using Cursos.Dominio.Dto_s.CursosDto;
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
   public class CursoRepositorio : Repositorio<Curso>, ICursoRepositorio
    {
        public CursoRepositorio(Context context) : base(context)
        {
        }

        public async Task AdicionarProfessorAoCurso(int idProfessor, int IdCurso)
        {
            var professorCurso = new ProfessorCurso(idProfessor, IdCurso);
            _context.ProfessorCursos.Add(professorCurso);
            await _context.SaveChangesAsync();
        }

        public async Task AdicionarTurmaAoCurso(int idTurma, int idCurso)
        {
            var curso = await ObterPorId(idCurso);
            var turma = await _context.Turmas.FindAsync(idTurma);
            curso.Turmas.Add(turma);
            await Atualizar(curso);
        }

        public async Task<List<ReadCursoDTO>> ObterCursosInclude()
        {
            var cursosInclude = await _context.Cursos.Include(x => x.Turmas).Include(x => x.Professores).ThenInclude(x => x.Professor).
                Select(x => new ReadCursoDTO
                {
                    CargaHoraria = x.CargaHoraria,
                    Nome = x.Nome,
                    Professores = x.Professores.Select(x => x.Professor).ToList(),
                    Turmas = x.Turmas.ToList()
                }).ToListAsync();


            if(cursosInclude == null)
            {
                return null;
            }

            return cursosInclude;
        }
    }
}
