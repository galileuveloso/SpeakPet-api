using MediatR;
using Microsoft.AspNetCore.Mvc;
using SpeakPet.Features.Usuario.Command;
using System;
using System.Threading.Tasks;

namespace SpeakPet.Features.Usuario
{
    [Route("/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("inserir")]
        public async Task<IActionResult> Post([FromBody] AdicionarUsuarioCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody] EfetuarLoginCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
