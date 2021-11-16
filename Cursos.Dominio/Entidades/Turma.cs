using System.Collections.Generic;

namespace Cursos.Dominio.Entidades
{
    public class Turma : EntidadeBase
    {
        public int NumeroTurma { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}