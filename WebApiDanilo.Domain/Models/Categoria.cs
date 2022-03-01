using System;
using System.Collections.Generic;

namespace WebApiDanilo.Domain.Models 
{
    public class Categoria : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
