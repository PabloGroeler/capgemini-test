using System;

namespace capgemini_test.src.Core.Domain.Entities
{
    public class ProdutoEntity : BaseEntity
    {
        public DateTime DataEntrega { get; set; }
        public string Descricao { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Unitario { get; set; }
    }
}