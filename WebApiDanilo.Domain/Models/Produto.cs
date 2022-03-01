using System;

namespace WebApiDanilo.Domain.Models
{
    public class Produto : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public string Brand { get; set; }
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
