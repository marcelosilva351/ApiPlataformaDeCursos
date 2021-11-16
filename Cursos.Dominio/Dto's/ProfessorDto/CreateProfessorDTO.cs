using Cursos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Dto_s.ProfessorDto
{
    public class CreateProfessorDTO
    {
        [Required]
        public string Nome { get; set; }
    }
}
