using Cursos.Dominio.Dto_s.AlunosDto;
using Cursos.Dominio.Dto_s.TurmasDto;
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
    public class TurmaRepositorio : Repositorio<Turma>, ITurmaRepositorio
    {
        public TurmaRepositorio(Context context) : base(context)
        {
        }

        public async Task<List<ReadTurmaDTO>> ObterTurmasInclude()
        {
            var turmasInclude = await _context.Turmas.Include(x => x.Alunos).Include(x => x.Curso)
                .Select(x => new ReadTurmaDTO
                {
                    Id = x.Id,
                    Alunos = x.Alunos,
                    Curso = x.Curso,
                    NumeroTurma = x.NumeroTurma
                }).ToListAsync();
            if(turmasInclude == null)
            {
                return null;
            }
            return turmasInclude;
        }

    }
}
