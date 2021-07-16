using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpeakPet.Features.Audio.Command;
using System;
using System.Threading.Tasks;

namespace SpeakPet.Features.Audio
{
    [Route("/audio")]
    [ApiController]
    public class AudioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AudioController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("reproduzir")]
        public async Task<IActionResult> Post([FromBody] ReproduzirAudioCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("adicionar")]
        public async Task<IActionResult> Post([FromBody] AdicionarAudioCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpDelete("excluir")]
        public async Task<IActionResult> Delete([FromBody] ExcluirAudioCommad request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPatch("editar")]
        public async Task<IActionResult> Patch([FromBody] EditarAudioCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpGet("listar/{idusuario}")]
        public async Task<IActionResult> Get(int idusuario)
        {
            return Ok(await _mediator.Send(new ListarAudiosCommand(idusuario)));
        }
    }
}
