using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using capgemini_test.src.Core.Domain.Dtos;
using capgemini_test.src.Core.Domain.Entities;
using capgemini_test.src.Core.Domain.Interfaces.Services;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace capgemini_test.src.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        // GET: api/v1/produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDtoGet>>> GetAllProdutos()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch (System.Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        // GET: api//v1/produtos/{id}
        [HttpGet("{id}", Name = "GetProduto")]
        public async Task<ActionResult<ProdutoDtoGet>> GetProduto(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Get(id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] IFormFile file) {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }    

            List<ProdutoDtoPost> produtos = new List<ProdutoDtoPost>();

            try
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        while (reader.Read())
                        {
                            DateTime data;
                            
                            if (DateTime.TryParseExact(reader.GetValue(0).ToString(),
                                                       "dd/MM/yyyy hh:mm:ss",
                                                        CultureInfo.InvariantCulture,
                                                        DateTimeStyles.None, out data)) {

                                produtos.Add(new ProdutoDtoPost {
                                    DataEntrega = data,
                                    Descricao = reader.GetValue(1).ToString(), 
                                    Quantidade = Convert.ToDecimal(reader.GetValue(2).ToString()), 
                                    Unitario = Convert.ToDecimal(reader.GetValue(3).ToString())
                                });
                            }
                        }
                    }
                }                
               
                return Ok(await _service.Post(produtos));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}