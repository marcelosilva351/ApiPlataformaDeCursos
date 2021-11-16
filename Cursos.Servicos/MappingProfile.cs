using AutoMapper;
using Cursos.Dominio.Dto_s.AlunosDto;
using Cursos.Dominio.Dto_s.CursosDTO;
using Cursos.Dominio.Dto_s.ProfessorDto;
using Cursos.Dominio.Dto_s.TurmasDto;
using Cursos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Servicos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCursoDTO, Curso>();
            CreateMap<CreateTurmaDTO, Turma>();
            CreateMap<CreateProfessorDTO, Professor>();
            CreateMap<CreateAlunoDTO, Aluno>();
        }
    }
}
