using System;
using System.Collections.Generic;
using capgemini_test.src.Core.Domain.Dtos;
using capgemini_test.src.Core.Domain.Entities;

namespace capgemini_test.test.Services
{
    public class ProdutoBaseTest
    {
        public static Guid Id;
        public DateTime DataEntrega { get; set; }
        public string Descricao { get; set; }
        public decimal Quantidade { get; set; }
        public decimal Unitario { get; set; }
        public ProdutoEntity entity;
        public ProdutoDtoGet produtoDtoGet;
        public IEnumerable<ProdutoDtoGet> produtosDtoGet;
        public List<ProdutoDtoPost> produtos;
        public ProdutoBaseTest()
        {
            produtos = new List<ProdutoDtoPost>();
            produtos.Add(new ProdutoDtoPost {
                DataEntrega = DateTime.Now.AddDays(1),
                Descricao = "DESCRIÇÃO 1",
                Quantidade = new decimal(10.0),
                Unitario = new decimal(100.0),
            }); 
            produtos.Add(new ProdutoDtoPost {
                DataEntrega = DateTime.Now.AddDays(1),
                Descricao = "DESCRIÇÃO 2",
                Quantidade = new decimal(10.0),
                Unitario = new decimal(100.0),
            });

            entity = new ProdutoEntity {
                Id = Id,
                DataEntrega = DataEntrega,
                Descricao = Descricao,
                Quantidade = Quantidade,
                Unitario = Unitario
            };

            produtoDtoGet = new ProdutoDtoGet {
                Id = Id,
                DataEntrega = DataEntrega,
                Descricao = Descricao,
                Quantidade = Quantidade,
                Unitario = Unitario
            };

        }
    }
}