using System;
using System.Threading.Tasks;
using WebApiDanilo.Data.Context;
using WebApiDanilo.Domain.Interfaces;
using WebApiDanilo.Domain.Models;

namespace WebApiDanilo.Data.Repositories
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        protected readonly IProdutoRepository _produtoRepository;
        public CategoriaRepository(MyContext context, IProdutoRepository produtoRepository) : base(context) 
        {
            _produtoRepository = produtoRepository;
        }

        public async override Task Delete(Guid id)
        {
            if (await _produtoRepository.AnyHasAsync(id)) throw new NotSupportedException("A categoria é de um produto registrado!");
            await base.Delete(id);
        }
    }
}
