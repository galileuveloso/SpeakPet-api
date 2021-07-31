using MediatR;
using SpeakPet.Dominio.Base;
using SpeakPet.Dominio.Enums;
using SpeakPet.Dominio.Servico.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpeakPet.Features.Acao.Command
{
    public class RegistarAcaoAudioCommand : IRequest<RegistrarAcaoAudioResponse>
    {
        public AcaoEnum Acao { get; set; }
        public int IdAudio { get; set; }
        public int IdUsuario { get; set; }
    }

    public class RegistrarAcaoAudioResponse : BaseResponse
    {
    }

    public class ReproduzirAudioHandler : IRequestHandler<RegistarAcaoAudioCommand, RegistrarAcaoAudioResponse>
    {
        private readonly IAudioService _audio;

        public ReproduzirAudioHandler(IAudioService audio)
        {
            _audio = audio;
        }

        public object Taks { get; private set; }

        public Task<RegistrarAcaoAudioResponse> Handle(RegistarAcaoAudioCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException();

            try
            {
                //audio = _audio.ObterAudio(request.IdAudio);
            }
            catch
            {
                return Task.FromResult(new RegistrarAcaoAudioResponse
                {
                    Mensagem = "Ocorreu um erro ao tentar " + request.Acao.ToString() + " o Audio.",
                    Sucesso = false
                });
            }

            return Task.FromResult(new RegistrarAcaoAudioResponse
            {
                Mensagem = "Sucesso ao " + request.Acao.ToString() + "o Audio.",
                Sucesso = true
            });
        }
    }
}