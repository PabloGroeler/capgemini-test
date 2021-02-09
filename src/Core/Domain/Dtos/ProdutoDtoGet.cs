using System;

namespace capgemini_test.src.Core.Domain.Dtos
{
    public class ProdutoDtoGet
    {
        public Guid Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public string Descricao { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Unitario { get; set; }
    }
}