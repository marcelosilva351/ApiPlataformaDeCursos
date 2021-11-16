using AutoMapper;
using Cursos.Dominio.Dto_s.CursosDto;
using Cursos.Dominio.Dto_s.CursosDTO;
using Cursos.Dominio.Entidades;
using Cursos.Dominio.Interfaces.Repositorios;
using Cursos.Dominio.Interfaces.Services;
using Cursos.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Servicos.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepositorio _cursoRepositorio;
        private readonly IMapper _mapper;

        public CursoService(ICursoRepositorio cursoRepositorio, IMapper mapper)
        {
            _cursoRepositorio = cursoRepositorio;
            _mapper = mapper;
        }

        public async Task AdicionarProfessorAoCurso(int idProfessor, int IdCurso)
        {
            try
            {
                await _cursoRepositorio.AdicionarProfessorAoCurso(idProfessor, IdCurso);
            }
            catch (Exception)
            {

                throw new Exception("Error: não foi possivel adicionar o professor ao curos");
            }
        }

        public async Task AdicionarTurmaAoCurso(int idTurma, int idCurso)
        {
            try
            {
                await _cursoRepositorio.AdicionarTurmaAoCurso(idTurma, idCurso);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao atualizar curso");
            }
        }

        public async Task AtualizarCurso(int id, CreateCursoDTO updateCursoDTO)
        {
            try
            {
                var cursoAtualizar = await _cursoRepositorio.ObterPorId(id);
                cursoAtualizar.Nome = updateCursoDTO.Nome;
                cursoAtualizar.CargaHoraria = updateCursoDTO.CargaHoraria;
                await _cursoRepositorio.Atualizar(cursoAtualizar);
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro ao atualizar o registro");
            }
        }

        public async Task CriarCurso(CreateCursoDTO createCursoDTO)
        {
            try
            {
                var curso = _mapper.Map<Curso>(createCursoDTO);
                await _cursoRepositorio.Criar(curso);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao criar curso");
            }
        }

        public async Task DeletarCurso(int id)
        {

            var curso = await _cursoRepositorio.ObterPorId(id);
            try
            {
                await _cursoRepositorio.Deletar(curso);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao excluir curso");
            }
        }

        public async Task<List<ReadCursoDTO>> ObterCursosInclude()
        {
            var CursosInclude = await _cursoRepositorio.ObterCursosInclude();
            if(CursosInclude == null)
            {
                return null;
            }
            return CursosInclude;
        }
    }
}
