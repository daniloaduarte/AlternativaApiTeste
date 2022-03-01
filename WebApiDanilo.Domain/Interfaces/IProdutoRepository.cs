using System;
using System.Threading.Tasks;
using WebApiDanilo.Domain.Models;

namespace WebApiDanilo.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        public Task<bool> AnyHasAsync(Guid id);

    }
}
