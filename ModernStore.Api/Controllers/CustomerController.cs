using System;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Handlers;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Transactions;

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

        [HttpPost]
        [Route("")]
        public ActionResult Post([FromServices] CustomerCommandHandler handler, [FromServices] IUow uow, [FromBody] RegisterCustomerCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return BadRequest(new GenericCommandResult(false, "Erro ao validar o commando!", command.Notifications));

            var customer = handler.Handle(command);

            uow.Commit();

            return Ok(customer);
        }

        [HttpPut]
        [Route("")]
        public ActionResult Update([FromServices] CustomerCommandHandler handler, [FromServices] IUow uow, [FromBody] UpdateCustomerCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return BadRequest(new GenericCommandResult(false, "Erro ao validar o commando de update!", command.Notifications));

            var customer = handler.Handle(command);

            uow.Commit();

            return Ok(customer);
        }
    }
}