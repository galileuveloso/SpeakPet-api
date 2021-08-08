using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpeakPet.Features.Reproducao.Command;
using System;
using System.Threading.Tasks;

namespace SpeakPet.Features.Reproducao
{
    [Route("/reproducao")]
    [ApiController]
    public class ReproducaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReproducaoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("inserir")]
        public async Task<IActionResult> Post([FromBody] InserirReproducaoCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("desativar")]
        public async Task<IActionResult> Post([FromBody] DesativarReproducaoCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
