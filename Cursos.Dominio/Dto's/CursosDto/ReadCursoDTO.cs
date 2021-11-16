using Cursos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Dto_s.CursosDto
{
    public class ReadCursoDTO
    {
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public List<Turma> Turmas { get; set; } = new List<Turma>();
        public List<Professor> Professores { get; set; } = new List<Professor>();
    }
}
