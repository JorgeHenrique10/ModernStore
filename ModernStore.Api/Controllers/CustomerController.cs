using System;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Repositories;

namespace ModernStore.Api.Controllers
{
    [ApiController]
    [Route("v1/customer")]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public ActionResult Get([FromServices] ICustomerRepository customerRepository, Guid id)
        {
            var customer = customerRepository.Get(id);
            return Ok(new GenericCommandResult(true, "Lista de Clintes", customer));
        }

        [HttpGet]
        [Route("user/{id}")]
        public ActionResult GetByUserId([FromServices] ICustomerRepository customerRepository, Guid id)
        {

            var customer = customerRepository.Get(id);

            if (customer == null)
                return BadRequest(new GenericCommandResult(false, "Lista de Clintes", null));

            return Ok(new GenericCommandResult(true, "Lista de Clintes", customer));
        }
    }
}