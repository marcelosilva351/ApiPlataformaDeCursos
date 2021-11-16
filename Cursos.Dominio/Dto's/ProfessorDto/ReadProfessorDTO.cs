using Cursos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Dto_s.ProfessorDto
{
    public class ReadProfessorDTO
    {
        public string Nome { get; set; }
        public List<Curso> Cursos { get; set; } = new List<Curso>();
    }
}
