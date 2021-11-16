using Cursos.Dominio.Dto_s.TurmasDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Interfaces.Services
{
    public interface ITurmaService
    {
        Task CriarTurma(CreateTurmaDTO createTurmaDTO);
        Task AtualizarTurma(int id, CreateTurmaDTO updatturmaDTO);
        Task DeletarTurma(int id);
        Task<List<ReadTurmaDTO>> ObterTurmasInclude();

    }
}
