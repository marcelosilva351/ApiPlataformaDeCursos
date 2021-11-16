using AutoMapper;
using Cursos.Dominio.Dto_s.TurmasDto;
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
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepositorio _turmaRepositorio;
        private readonly IMapper _mapper;

        public TurmaService(ITurmaRepositorio turmaRepositorio, IMapper mapper)
        {
            _turmaRepositorio = turmaRepositorio;
            _mapper = mapper;
        }

        public async Task AtualizarTurma(int id, CreateTurmaDTO updatturmaDTO)
        {
            var turmaAtualizar = await _turmaRepositorio.ObterPorId(id);
            turmaAtualizar.NumeroTurma = updatturmaDTO.NumeroTurma;
            turmaAtualizar.CursoId = updatturmaDTO.CursoId;
            try
            {
                await _turmaRepositorio.Atualizar(turmaAtualizar);

            }
            catch (Exception)
            {

                throw new Exception("Erro ao atualiar turma");
            }


        }

        public async Task CriarTurma(CreateTurmaDTO createTurmaDTO)
        {
            var turma = _mapper.Map<Turma>(createTurmaDTO);
            try
            {
                await _turmaRepositorio.Criar(turma);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task DeletarTurma(int id)
        {
            var turmaDeletar = await _turmaRepositorio.ObterPorId(id);
            await _turmaRepositorio.Deletar(turmaDeletar);
        }

        public async Task<List<ReadTurmaDTO>> ObterTurmasInclude()
        {
            var turmasInclude = await _turmaRepositorio.ObterTurmasInclude();
            if(turmasInclude == null)
            {
                return null;
            }
            return turmasInclude;
        }

       
    }
}
