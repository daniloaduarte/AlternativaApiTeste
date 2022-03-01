using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiDanilo.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = new Guid();
        }
        [Key]
        public Guid Id { get; set; }
    }
}
