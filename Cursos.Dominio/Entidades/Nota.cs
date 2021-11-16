namespace Cursos.Dominio.Entidades
{
    public class Nota : EntidadeBase
    {
        public int Bimestre { get; set; }

        public double Valor { get; set; }

        public int AlunoId { get; set; }

        public Aluno Aluno { get; set; }
    }
}