using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiDanilo.Data.Context;
using WebApiDanilo.Domain.Interfaces;
using WebApiDanilo.Domain.Models;

namespace WebApiDanilo.App.Controllers
{
    [Produces("application/json")]
    [Route("api/product")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // GET: Produto
        [HttpGet]
        [Route("Get")]
        public async Task<List<Produto>> GetProdutos()
        {
            return await _produtoRepository.GetAll();
        }

        // GET: Produto/Details/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public async Task<Produto> GetbyId(Guid? id)
        {
            if (id == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            var produto = await _produtoRepository.GetById(id.Value);
            if (produto == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            return produto;
        }


        [HttpPost]
        [Route("Create")]
        public async Task Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                produto.Id = Guid.NewGuid();
                await _produtoRepository.Create(produto);
                await _produtoRepository.SaveChanges();
            }
        }


        // POST: Produto/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public async Task Edit(Guid id, Produto produto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    await _produtoRepository.Update(produto);
                    await _produtoRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw new FormatException("Não foi possível realizar o update!");

                }
            }
        }

        // POST: Produto/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task Delete(Guid id)
        {
            await _produtoRepository.Delete(id);
            await _produtoRepository.SaveChanges();
        }
    }
}
