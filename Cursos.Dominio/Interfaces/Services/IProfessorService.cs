using Cursos.Dominio.Dto_s.ProfessorDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Interfaces.Services
{
    public interface IProfessorService
    {
        Task CriarProfessor(CreateProfessorDTO createTurmaDTO);
        Task AtualizarProfessor(int id, CreateProfessorDTO updatturmaDTO);
        Task DeletarProfessor(int id);
        Task<List<ReadProfessorDTO>> ObterProfessoresInclude();
        Task AdicionarProfessorACurso(int idProfessor, int idCurso);
    }
}
