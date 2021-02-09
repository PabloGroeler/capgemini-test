using System;
using System.ComponentModel.DataAnnotations;

namespace capgemini_test.src.Core.Domain.Models
{
    public class BaseModel
    {
        [Required]
        public Guid Id {get; set;}        
    }
}