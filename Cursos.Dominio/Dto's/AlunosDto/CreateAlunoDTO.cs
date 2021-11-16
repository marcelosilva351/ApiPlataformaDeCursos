using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Dto_s.AlunosDto
{
    public class CreateAlunoDTO
    {
        public string Nome { get; set; }
        
        public int Idade { get; set; }
        public int IdTurma { get; set; }
    }
}
