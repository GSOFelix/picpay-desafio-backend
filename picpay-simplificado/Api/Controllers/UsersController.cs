using Aplicacao.Dtos;
using Aplicacao.UseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserUseCase _useCase;

        public UsersController(IUserUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<ActionResult> IsertUser(UsersDto request)
        {
            var response =  await _useCase.SaveUser(request);
            return CreatedAtAction(nameof(SelectUser),new {id = response.Id},response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> SelectUser([FromRoute] long id)
        {
            return Ok(await _useCase.GetUserById(id));
        }

        [HttpGet]
        public async Task<ActionResult> SelectAll()
        {
            return Ok(await _useCase.GetAllUsers());
        }


    }
}
