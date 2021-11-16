using System.Collections.Generic;

namespace Cursos.Dominio.Entidades
{
    public class Curso : EntidadeBase
    {
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public List<Turma> Turmas { get; set; } = new List<Turma>();
        public List<ProfessorCurso> Professores { get; set; } = new List<ProfessorCurso>();
    }
}