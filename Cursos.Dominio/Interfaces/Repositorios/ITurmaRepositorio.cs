using Cursos.Dominio.Dto_s.TurmasDto;
using Cursos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Interfaces.Repositorios
{
    public interface ITurmaRepositorio : IRepositorio<Turma>
    {
        Task<List<ReadTurmaDTO>> ObterTurmasInclude();

    }
}
