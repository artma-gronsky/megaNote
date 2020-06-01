using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public virtual Guid Id { get; set; }
    }
}
