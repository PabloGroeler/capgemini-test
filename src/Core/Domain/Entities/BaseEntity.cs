using System;
using System.ComponentModel.DataAnnotations;

namespace capgemini_test.src.Core.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } 
    }
}