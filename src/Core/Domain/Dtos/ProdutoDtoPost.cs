using System;
using System.ComponentModel.DataAnnotations;

namespace capgemini_test.src.Core.Domain.Dtos
{
    public class ProdutoDtoPost
    {
        [Required]
        public DateTime DataEntrega { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public decimal Quantidade { get; set; }
        [Required]
        public decimal Unitario { get; set; } 
    }
}