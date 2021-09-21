using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Repositories;

namespace ModernStore.Api.Controllers
{
    [ApiController]
    [Route("v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductCustomerRepository _productRepository;
        public ProductController(IProductCustomerRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            var products = _productRepository.Get();
            return Ok(new GenericCommandResult(true, "Lista de Produtos!", products));
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(Guid id)
        {
            var product = _productRepository.Get(id);
            return Ok(new GenericCommandResult(true, "Produto!", product));
        }
    }
}