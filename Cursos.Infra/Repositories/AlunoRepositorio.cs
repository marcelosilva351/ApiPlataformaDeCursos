using Cursos.Dominio.Dto_s.AlunosDto;
using Cursos.Dominio.Dto_s.Helpers;
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
    public class AlunoRepositorio : Repositorio<Aluno>, IAlunoRepositorio
    {
        public AlunoRepositorio(Context context) : base(context)
        {
        }

        public async Task AdicionarAlunoATurma(int idAluno, int idTurma)
        {
            var aluno = await ObterPorId(idAluno);
            aluno.IdTurma = idTurma;
            await Atualizar(aluno);
        }
        
        public async Task<List<ReadAlunoDTO>> ObterAlunosPorTurma(int idTurma)
        {
            var alunosPorTurma = await _context.Alunos.Include(t => t.Turma).Where(x => x.Turma.Id == idTurma).Select(x => new ReadAlunoDTO
            {
                Id = x.Id,
                Idade = x.Id,
                Nome = x.Nome,
                Turma = x.Turma
            }).ToListAsync();
            return alunosPorTurma;
        }

        public async Task AdicionarNotarAluno(int idAluno, NotasAluno notas)
        {
            foreach (var item in notas.Notas)
            {
                var nota = new Nota();
                nota.AlunoId = idAluno;
                nota.Bimestre = notas.Bimestre;
                nota.Valor = item;
                _context.Notas.Add(nota);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<ReadAlunoDTO>> ObterAlunosInclude()
        {
            var alunosInclude = await _context.Alunos.Include(X => X.Turma).Include(X => X.Notas).Select
                (X => new ReadAlunoDTO {
                Id = X.Id,
                Idade = X.Idade,
                Nome = X.Nome,
                Turma = X.Turma,
                Nota = X.Notas.ToList()
                }).ToListAsync();
            if(alunosInclude == null)
            {
                return null;
            }
            return alunosInclude;
        }

        public async Task<PaginacaoLista<ReadAlunoDTO>> ObterAlunosPaginado(int numeroPagina, int RegistrosPorPagina)
        {
            //Adiciona lista paginada
            var paginacaoLista = new PaginacaoLista<ReadAlunoDTO>();
            var listaAlunos = await ObterAlunosInclude();
            var listapaginada = listaAlunos.Skip(numeroPagina - 1 * RegistrosPorPagina).Take(RegistrosPorPagina);


            //preenche a classe paginacao
            paginacaoLista.ListaPaginada.AddRange(listapaginada);
            paginacaoLista.NumeroPaginaAtual = numeroPagina;
            paginacaoLista.RegistrosPorPagina = RegistrosPorPagina;
            paginacaoLista.TotalDeRegistros = listaAlunos.Count();
            paginacaoLista.TotalPaginas = (int)Math.Ceiling((double)listaAlunos.Count() / RegistrosPorPagina);
            return paginacaoLista;

            
        }
    }
}
