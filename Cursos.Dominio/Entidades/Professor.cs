using System.Collections.Generic;

namespace Cursos.Dominio.Entidades
{
    public class Professor : EntidadeBase
    {
        public string Nome { get; set; }
        public List<ProfessorCurso> Cursos { get; set; } = new List<ProfessorCurso>();
    }
}