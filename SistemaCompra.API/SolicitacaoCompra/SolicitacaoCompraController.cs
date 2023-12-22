using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using SistemaCompras.Application.SolicitacaoCompra.Command;
using System.Threading.Tasks;

namespace SistemaCompra.API.SolicitacaoCompra
{
    [ApiController]
    [Route("[controller]")]
    public class SolicitacaoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarCompra([FromBody] RegistrarCompraCommand command)
        {
            if (command == null)
            {
                return BadRequest("Comando inválido");
            }

            var resultado = await _mediator.Send(command);

            if (resultado)
                return Ok("Compra registrada com sucesso");
            else
                return BadRequest("Erro ao registrar a compra");
        }
    }
}
