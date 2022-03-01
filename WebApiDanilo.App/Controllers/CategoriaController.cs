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
    [Route("api/category")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        // GET: Categoria
        [HttpGet]
        [Route("Get")]
        public async Task<List<Categoria>> GetCategorias()
        {
            return await _categoriaRepository.GetAll();
        }

        // GET: Categoria/Details/5
        [HttpGet("{id}")]
        [Route("Get/{id}")]
        public async Task<Categoria> GetbyId(Guid? id)
        {
            if (id == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            var categoria = await _categoriaRepository.GetById(id.Value);
            if (categoria == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            return categoria;
        }

        
        [HttpPost]
        [Route("Create")]
        public async Task Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                categoria.Id = Guid.NewGuid();
                await _categoriaRepository.Create(categoria);
                await _categoriaRepository.SaveChanges();
            }
        }


        // POST: Categoria/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public async Task Edit(Guid id, Categoria categoria)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoriaRepository.Update(categoria);
                    await _categoriaRepository.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw new FormatException("Não foi possível realizar o update!");
                    
                }
            }
        }

        // POST: Categoria/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task Delete(Guid id)
        {
            await _categoriaRepository.Delete(id);
            await _categoriaRepository.SaveChanges();
        }
    }
}
