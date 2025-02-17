using System;
using System.ComponentModel.DataAnnotations;

namespace capgemini_test.src.Core.Domain.Models
{
    public class ProdutoModel : BaseModel
    {
        [Required]
        public DateTime DataEntrega { get; set; }
        [Required]
        [MinLength(50)]
        public string Descricao { get; set; }
        [Required]
        public decimal Quantidade { get; set; }
        [Required]
        public decimal Unitario { get; set; }
        
    }
}