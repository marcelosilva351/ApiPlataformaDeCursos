using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Entidades
{
    public class ProfessorCurso
    {
        public ProfessorCurso(int idProfessor, int IdCurso)
        {
            this.IdProfessor = idProfessor;
            this.IdCurso = IdCurso;
        }

        public int IdProfessor { get; set; }
        public Professor Professor { get; set; }
        public int IdCurso { get; set; }
        public Curso Curso { get; set; }

    }
}
