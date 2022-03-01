using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebApiDanilo.Data.Context;
using WebApiDanilo.Domain.Interfaces;
using WebApiDanilo.Domain.Models;

namespace WebApiDanilo.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MyContext context) : base(context) { }

        public async Task<bool> AnyHasAsync(Guid id)
        {
            return await DbSet.AnyAsync(t => t.CategoriaId == id);
        }
    }
}
