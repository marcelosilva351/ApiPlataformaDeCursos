using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Dominio.Interfaces.Repositorios
{
    public interface IRepositorio<T> where T : class
    {
        Task Criar(T entidadeAdd);
        Task Atualizar(T entidadeAtualizar);
        Task Deletar(T entidadeDeletar);
        Task<List<T>> ObterTodos();
        Task<T> ObterPorId(int id);
    }
}
