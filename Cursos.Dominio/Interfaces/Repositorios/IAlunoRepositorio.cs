using Cursos.Dominio.Dto_s.AlunosDto;
using Cursos.Dominio.Dto_s.Helpers;
using Cursos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Interfaces.Repositorios
{
    public interface IAlunoRepositorio : IRepositorio<Aluno>
    {
        
        Task AdicionarAlunoATurma(int idAluno, int idTurma);

        Task AdicionarNotarAluno(int idAluno, NotasAluno notas);

        Task<List<ReadAlunoDTO>> ObterAlunosInclude();

        Task<PaginacaoLista<ReadAlunoDTO>> ObterAlunosPaginado(int numeroPagina, int RegistrosPorPagina);
        Task<List<ReadAlunoDTO>> ObterAlunosPorTurma(int idTurma);

    }



}
