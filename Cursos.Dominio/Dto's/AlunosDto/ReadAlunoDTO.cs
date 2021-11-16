using Cursos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Dto_s.AlunosDto
{
    public class ReadAlunoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Turma Turma { get; set; } = new Turma();
        public List<Nota> Nota { get; set; } = new List<Nota>();
    }
}
