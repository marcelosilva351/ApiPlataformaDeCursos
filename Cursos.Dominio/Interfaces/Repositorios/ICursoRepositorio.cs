using Cursos.Dominio.Dto_s.CursosDto;
using Cursos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Interfaces.Repositorios
{
    public interface ICursoRepositorio : IRepositorio<Curso>
    {
        Task AdicionarTurmaAoCurso(int idTurma, int idCurso);
        Task AdicionarProfessorAoCurso(int idProfessor, int IdCurso);
        Task<List<ReadCursoDTO>> ObterCursosInclude();
    }
}
