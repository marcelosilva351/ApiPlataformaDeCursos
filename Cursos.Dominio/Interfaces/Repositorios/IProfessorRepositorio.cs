using Cursos.Dominio.Dto_s.ProfessorDto;
using Cursos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Interfaces.Repositorios
{
    public interface IProfessorRepositorio : IRepositorio<Professor>
    {
        Task<List<ReadProfessorDTO>> ObterProfessoresInclude();
        Task AdicionarProfessorACurso(int idProfessor, int idCurso);
    }
}
