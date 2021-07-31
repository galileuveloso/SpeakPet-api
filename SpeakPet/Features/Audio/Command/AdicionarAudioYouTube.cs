using MediatR;
using SpeakPet.Dominio.Base;
using SpeakPet.Dominio.Models;
using SpeakPet.Dominio.Servico.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpeakPet.Features.Audio.Command
{
    public class AdicionarAudioYouTubeCommand : IRequest<AdicionarAudioYouTubeResponse>
    {
        public AudioYouTubeModel AudioYouTube { get; set; }
    }

    public class AdicionarAudioYouTubeResponse : BaseResponse
    {
    }

    public class AdicionarAudioYouTubeHandler : IRequestHandler<AdicionarAudioYouTubeCommand, AdicionarAudioYouTubeResponse>
    {
        IAudioService _audio;

        public AdicionarAudioYouTubeHandler(IAudioService audio)
        {
            _audio = audio;
        }

        public Task<AdicionarAudioYouTubeResponse> Handle(AdicionarAudioYouTubeCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException();

            try
            {
                _audio.InserirAudioYoutube(request.AudioYouTube);
            }
            catch
            {
                return Task.FromResult(new AdicionarAudioYouTubeResponse
                {
                    Mensagem = "Ocorreu um erro ao tentar adicionar o audio.",
                    Sucesso = false
                });
            }

            return Task.FromResult(new AdicionarAudioYouTubeResponse
            {
                Mensagem = "Audio adicionado com sucesso.",
                Sucesso = true
            });
        }
    }
}
