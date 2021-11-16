using Cursos.Dominio.Interfaces.Repositorios;
using Cursos.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursos.Infra.Repositories
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        protected readonly Context _context;

        public Repositorio(Context context)
        {
            _context = context;
        }

        public async Task Atualizar( T entidadeAtualizar)
        {
            _context.Set<T>().Update(entidadeAtualizar);
            await _context.SaveChangesAsync();
        }

        public async Task Criar(T entidadeAdd)
        {
            _context.Set<T>().Add(entidadeAdd);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(T entidadeDeletar)
        {
            _context.Set<T>().Remove(entidadeDeletar);
            await _context.SaveChangesAsync();
        }

        public async Task<T> ObterPorId(int id)
        {
            var entidadeId = await _context.Set<T>().FindAsync(id);
            return entidadeId;
        }

        public async Task<List<T>> ObterTodos()
        {
            var entidades = await _context.Set<T>().ToListAsync();
            return entidades;
        }
    }
}
