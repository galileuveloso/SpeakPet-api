using MediatR;
using SpeakPet.Dominio.Base;
using SpeakPet.Dominio.Models;
using SpeakPet.Dominio.Servico.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpeakPet.Features.Audio.Command
{
    public class AdicionarAudioCommand : IRequest<AdicionarAudioResponse>
    {
        public string Titulo { get; set; }
        public byte[] Bytes { get; set; }
        public int IdUsuario { get; set; }
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

            AudioModel audio = new AudioModel(request.Titulo, request.Bytes, request.IdUsuario);

            try
            {
                _audio.InserirAudio(audio);
            }
            catch
            {
                return Task.FromResult(new AdicionarAudioResponse
                {
                    Mensagem = "Ocorreu um erro ao tentar adicionar o audio.",
                    Sucesso = false
                });
            }

            return Task.FromResult(new AdicionarAudioResponse
            {
                Mensagem = "Audio adicionado com sucesso.",
                Sucesso = true
            });
        }
    }
}
