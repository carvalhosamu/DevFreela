
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Commands.LoginUser;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetUsersById;
using DevFreela.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        /*private readonly IUserService _service;*/
        private readonly IMediator _mediator;

        public UsersController(/*IUserService service,*/ IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetUserByIdQuery(id));
                return Ok(result);
            }
            catch (ArgumentException ex)
            {

                return NotFound(ex.Message);
            }

        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand createUserModel)
        {

            int result = await _mediator.Send(createUserModel);
            return CreatedAtAction(nameof(GetById), new { id = result }, createUserModel);

        }

        [HttpPut("/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginModel)
        {
            var result = await _mediator.Send(loginModel);

            if (result == null)
            {
                return BadRequest(new {Message = "Usuário ou senha errados"});
            }

            return Ok(result);
        }


    }
}
