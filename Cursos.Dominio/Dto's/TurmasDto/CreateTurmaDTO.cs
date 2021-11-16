using Cursos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Dto_s.TurmasDto
{
   public class CreateTurmaDTO
    {
        [Required]
        public int NumeroTurma { get; set; }
        [Required]
        public int CursoId { get; set; }
    }
}
