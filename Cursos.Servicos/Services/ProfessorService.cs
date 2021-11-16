using AutoMapper;
using Cursos.Dominio.Dto_s.ProfessorDto;
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
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepositorio _professorRepositorio;
        private readonly IMapper _mapper;

        public ProfessorService(IProfessorRepositorio professorRepositorio, IMapper mapper)
        {
            _professorRepositorio = professorRepositorio;
            _mapper = mapper;
        }

        public async Task AdicionarProfessorACurso(int idProfessor, int idCurso)
        {
            try
            {
                await _professorRepositorio.AdicionarProfessorACurso(idProfessor, idCurso);
            }
            catch (Exception)
            {

                throw new Exception("Não foi possivel adicionar o professor ao curso");
            }
        }

        public async Task AtualizarProfessor(int id, CreateProfessorDTO updatturmaDTO)
        {
            var professorAtualizar = await _professorRepositorio.ObterPorId(id);
            professorAtualizar.Nome = updatturmaDTO.Nome;



            try
            {
                await _professorRepositorio.Atualizar(professorAtualizar);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao atualizar professor");
            }
        }

        public async Task CriarProfessor(CreateProfessorDTO createTurmaDTO)
        {
            var professorAdd = _mapper.Map<Professor>(createTurmaDTO);
            try
            {

                await _professorRepositorio.Criar(professorAdd);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao criar professor");
            }
        }

        public async Task DeletarProfessor(int id)
        {
            var professorDeletar = await _professorRepositorio.ObterPorId(id);
            try
            {
                await _professorRepositorio.Deletar(professorDeletar);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao deletar professor");
            }
        }

        public async Task<List<ReadProfessorDTO>> ObterProfessoresInclude()
        {
            var listaProfessoresInclude = await _professorRepositorio.ObterProfessoresInclude();
            if(listaProfessoresInclude == null)
            {
                return null;
            }
            return listaProfessoresInclude;
        }
    }

}
