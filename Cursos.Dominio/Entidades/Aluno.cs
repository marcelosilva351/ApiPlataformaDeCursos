using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Entidades
{
   public class Aluno : EntidadeBase
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Idade { get; set; }
        [Required]
        public int IdTurma { get; set; }
        public Turma Turma { get; set; } 
        public List<Nota> Notas { get; set; } = new List<Nota>();

    }
}
