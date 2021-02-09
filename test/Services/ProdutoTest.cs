using System;
using System.Threading.Tasks;
using capgemini_test.src.Core.Domain.Dtos;
using capgemini_test.src.Core.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace capgemini_test.test.Services
{
    public class ProdutoTest: ProdutoBaseTest
    {
        private IProdutoService _service;
        private Mock<IProdutoService> _serviceMock;

        [Fact(DisplayName = "Execute Create Test.")]
        public async Task ExecuteCreateTest()
        {
            _serviceMock = new Mock<IProdutoService>();
            _serviceMock.Setup(m => m.Post(produtos)).ReturnsAsync(produtosDtoGet);
            _service = _serviceMock.Object;

            var result = await _service.Post(produtos);
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Execute GET Test.")]
        public async Task ExecuteGetTest()
        {
            _serviceMock = new Mock<IProdutoService>();
            _serviceMock.Setup(m => m.Get(Id)).ReturnsAsync(produtoDtoGet);
            _service = _serviceMock.Object;

            var result = await _service.Get(Id);
            Assert.NotNull(result);
            Assert.Equal(Descricao, result.Descricao);
            
            _serviceMock = new Mock<IProdutoService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((ProdutoDtoGet)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(Guid.NewGuid());
            Assert.Null(_record);
        }
    }
}