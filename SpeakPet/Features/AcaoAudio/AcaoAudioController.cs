using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpeakPet.Features.Acao.Command;
using System;
using System.Threading.Tasks;

namespace SpeakPet.Features.Acao
{
    [Route("/acao")]
    [ApiController]
    public class AcaoAudioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AcaoAudioController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Post([FromBody] RegistarAcaoAudioCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
