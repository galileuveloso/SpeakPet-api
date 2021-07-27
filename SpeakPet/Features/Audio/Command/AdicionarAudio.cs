using MediatR;
using SpeakPet.Dominio.Base;
using SpeakPet.Dominio.Models;
using SpeakPet.Dominio.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SpeakPet.Features.Audio.Command
{
    public class AdicionarAudioCommand : IRequest<AdicionarAudioResponse>
    {
        public IList<AudioModel> Audios { get; set; }
    }

    public class AdicionarAudioResponse : BaseResponse
    {
    }

    public class AdicionarAudioHandler : IRequestHandler<AdicionarAudioCommand, AdicionarAudioResponse>
    {
        IAudioService _audio;

        public AdicionarAudioHandler(IAudioService audio)
        {
            _audio = audio;
        }

        public Task<AdicionarAudioResponse> Handle(AdicionarAudioCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException();

            try
            {
                _audio.InserirAudios(request.Audios);
            }
            catch
            {
                return Task.FromResult(new AdicionarAudioResponse
                {
                    Mensagem = "Ocorreu um erro ao tentar adicionar os audios.",
                    Sucesso = false
                });
            }

            return Task.FromResult(new AdicionarAudioResponse
            {
                Mensagem = "Audios adicionados com sucesso.",
                Sucesso = true
            });
        }
    }
}
