using MediatR;
using SpeakPet.Dominio.Base;
using SpeakPet.Dominio.Servico.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpeakPet.Features.Audio.Command
{
    public class ExcluirAudioCommad : IRequest<ExcluirAudioResponse>
    {
        public int IdAudio { get; set; }
    }

    public class ExcluirAudioResponse : BaseResponse
    {
    }

    public class ExcluirAudioHandler : IRequestHandler<ExcluirAudioCommad, ExcluirAudioResponse>
    {
        private readonly IAudioService _audio;

        public ExcluirAudioHandler(IAudioService audio)
        {
            _audio = audio;
        }

        public Task<ExcluirAudioResponse> Handle(ExcluirAudioCommad request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new NullReferenceException();

            try
            {
                _audio.ExcluirAudio(request.IdAudio);
            }
            catch
            {
                return Task.FromResult(new ExcluirAudioResponse
                {
                    Mensagem = "Houve um erro ao tentar excluir o audio.",
                    Sucesso = false
                });
            }

            return Task.FromResult(new ExcluirAudioResponse
            {
                Mensagem = "Audio excluido com sucesso.",
                Sucesso = true
            });
        }
    }
}
