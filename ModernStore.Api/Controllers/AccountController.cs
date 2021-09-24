using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Api.Services;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Repositories;

namespace ModernStore.Api.Controllers
{
    [ApiController]
    [Route("v1/account")]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromServices] ICustomerRepository customerRepository, [FromForm] AuthenticateCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return BadRequest(new GenericCommandResult(false, "Autenticação Falhou", command.Notifications));

            var pass = Settings.EncryptPassword(command.Password);

            var customer = customerRepository.GetByAuthentication(command.UserName, pass);

            if (customer == null)
                return BadRequest(new GenericCommandResult(false, "Usuario/Senha está incorreta!", null));

            var token = TokenService.GenerateToken(customer);

            return Ok(new GenericCommandResult(true, "Login Efetuado com sucesso!", new
            {
                user = customer.User.UserName,
                token = token
            }));
        }
    }
}