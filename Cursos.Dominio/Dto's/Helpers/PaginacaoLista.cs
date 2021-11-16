using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Dto_s.Helpers
{
    public class PaginacaoLista<T> where T : class
    {
        public int NumeroPaginaAtual { get; set; }
        public int RegistrosPorPagina { get; set; }
        public int TotalDeRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public List<T> ListaPaginada { get; set; } = new List<T>();
    }
}
