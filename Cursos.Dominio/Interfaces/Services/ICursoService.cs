using Cursos.Dominio.Dto_s.CursosDto;
using Cursos.Dominio.Dto_s.CursosDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Interfaces.Services
{
    public interface ICursoService
    {
        Task CriarCurso(CreateCursoDTO createCursoDTO);
        Task AtualizarCurso(int id, CreateCursoDTO updateCursoDTO);
        Task DeletarCurso(int id);
        Task AdicionarTurmaAoCurso(int idTurma, int idCurso);
        Task AdicionarProfessorAoCurso(int idProfessor, int IdCurso);
        Task<List<ReadCursoDTO>> ObterCursosInclude();
    }
}
