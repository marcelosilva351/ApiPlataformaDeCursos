using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Dto_s.Helpers
{
    public class NotasAluno
    {
        public int Bimestre { get; set; }
        public List<Double> Notas { get; set; } = new List<double>();
    }
}
