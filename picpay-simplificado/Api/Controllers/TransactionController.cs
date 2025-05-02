using Aplicacao.Dtos;
using Aplicacao.UseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransectionUseCase _useCase;

        public TransactionController(ITransectionUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<ActionResult> MakeTransfer([FromBody] TransectionDto request)
        {
            var transaction = await _useCase.CreateTransection(request);

            return CreatedAtAction(nameof(MakeTransfer), new { id = transaction.Id }, transaction);
        }

        [HttpGet("by-id")]
        public async Task<ActionResult> SelecTransactionById([FromQuery] long id)
        {
            return Ok(await _useCase.SelectTransectionById(id));
        }


        [HttpGet]
        public async Task<ActionResult> SelectAllTransactions()
        {
            return Ok(await _useCase.SelectAllTransactions());
        }



    }
}
