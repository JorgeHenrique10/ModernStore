using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Handlers;
using ModernStore.Infra.Transactions;

namespace ModernStore.Api.Controllers
{
    [ApiController]
    [Route("v1/order")]
    public class OrderController : ControllerBase
    {

        [HttpPost]
        [Route("")]
        public ActionResult Post([FromServices] OrderCommandHandler handler, [FromServices] IUow uow, [FromBody] RegisterOrderCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return BadRequest(new GenericCommandResult(false, "Erro no command Pedido!", command.Notifications));

            var order = handler.Handle(command);

            uow.Commit();

            return Ok(order);
        }


    }
}