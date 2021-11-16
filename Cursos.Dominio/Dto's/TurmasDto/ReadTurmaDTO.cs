using Cursos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Dto_s.TurmasDto
{
    public class ReadTurmaDTO
    {
        public int Id { get; set; }
        public int NumeroTurma { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        public Curso Curso { get; set; }
    }
}
