using AutoMapper;
using Cursos.Dominio.Dto_s.AlunosDto;
using Cursos.Dominio.Dto_s.Helpers;
using Cursos.Dominio.Entidades;
using Cursos.Dominio.Interfaces.Repositorios;
using Cursos.Dominio.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Servicos.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepositorio _alunorepositorio;
        private readonly IMapper _mapper;

        public AlunoService(IAlunoRepositorio alunorepositorio, IMapper mapper)
        {
            _alunorepositorio = alunorepositorio;
            _mapper = mapper;
        }

        public async Task AdicionarAlunoATurma(int idAluno, int idTurma)
        {
            try
            {
                await _alunorepositorio.AdicionarAlunoATurma(idAluno, idTurma);
            }
            catch (Exception)
            {

                throw new Exception("Error: Não foi possivel adicionar Aluno a turma");
            }
        } 
        
        public async Task AdicionarNotarAluno(int idAluno, NotasAluno notas)
        {

            try
            {
                await _alunorepositorio.AdicionarNotarAluno(idAluno,notas);
            }
            catch (Exception)
            {
                throw new Exception("Error: Não foi possivel adicionar notas ao Aluno");
            }


        }

        public async Task<List<ReadAlunoDTO>> ObterAlunosInclude()
        {
            var alunosInclude = await _alunorepositorio.ObterAlunosInclude();
            if(alunosInclude == null)
            {
                return null;
            }
            return alunosInclude;
            
        }
    
    

    public async Task<PaginacaoLista<ReadAlunoDTO>> ObterAlunosPaginado(int numeroPagina, int RegistrosPorPagina)
        {
            var paginacaoLista = await _alunorepositorio.ObterAlunosPaginado(numeroPagina, RegistrosPorPagina);
            if(paginacaoLista.ListaPaginada == null)
            {
                throw new Exception("Pagina sem registros");
            }
            return paginacaoLista;
        }

        public async Task CriarAluno(CreateAlunoDTO createAlunoDTO)
        {
            try
            {
                var Aluno = _mapper.Map<Aluno>(createAlunoDTO);
                await _alunorepositorio.Criar(Aluno);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task AtualiarAluno(int id, CreateAlunoDTO updateAlunoDto)
        {
            var alunoAtualizar = await _alunorepositorio.ObterPorId(id);
            alunoAtualizar.Idade = updateAlunoDto.Idade;
            alunoAtualizar.Nome = updateAlunoDto.Nome;
            try
            {
                await _alunorepositorio.Atualizar(alunoAtualizar);

            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro ao atualizar o aluno");
            }
        }

        public async Task DeletarAluno(int id)
        {
            var alunoDeletar = await _alunorepositorio.ObterPorId(id);
            try
            {
                await _alunorepositorio.Deletar(alunoDeletar);
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um ao deletar o aluno");
            }
        }

  
        public async Task<List<Aluno>> ObterTodos()
        {
            var alunos = await _alunorepositorio.ObterTodos();
            if(alunos == null)
            {
                return null;
            }
            return alunos;
        }

        public async Task<Aluno> ObterPorId(int id)
        {
            var aluno = await _alunorepositorio.ObterPorId(id);
            if(aluno == null)
            {
                return null;
            }
            return aluno;
        }

        public async Task<List<ReadAlunoDTO>> ObterAlunosPorTurma(int idTurma)
        {
            var AlunosPorTurma = await _alunorepositorio.ObterAlunosPorTurma(idTurma);
            if(AlunosPorTurma == null)
            {
                return null;
            }
            return AlunosPorTurma;
        }
    }
}
