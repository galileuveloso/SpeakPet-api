using MediatR;
using SpeakPet.Dominio.Base;
using SpeakPet.Dominio.Models;
using SpeakPet.Dominio.Servico.Interfaces;
using System;
using System.IO;
using System.Media;
using System.Threading;
using System.Threading.Tasks;

namespace SpeakPet.Features.Audio.Command
{
    public class ReproduzirAudioCommand : IRequest<ReproduzirAudioResponse>
    {
        public int IdAudio { get; set; }
    }

    public class ReproduzirAudioResponse : BaseResponse
    {
    }

    public class ReproduzirAudioHandler : IRequestHandler<ReproduzirAudioCommand, ReproduzirAudioResponse>
    {
        private readonly IAudioService _audio;

        public ReproduzirAudioHandler(IAudioService audio)
        {
            _audio = audio;
        }

        public object Taks { get; private set; }

        public Task<ReproduzirAudioResponse> Handle(ReproduzirAudioCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException();
            AudioModel audio;

            try
            {
                audio = _audio.ObterAudio(request.IdAudio);
            }
            catch
            {
                return Task.FromResult(new ReproduzirAudioResponse
                {
                    Mensagem = "Ocorreu um erro ao encontrar o audio.",
                    Sucesso = false
                });
            }

            try
            {
                using Stream stream = new MemoryStream(audio.Bytes);
                SoundPlayer sound = new SoundPlayer(stream);
                sound.Play();
            }
            catch
            {
                return Task.FromResult(new ReproduzirAudioResponse
                {
                    Mensagem = "Ocorreu um erro ao tentar reprodu",
                    Sucesso = false
                });
            }

            return Task.FromResult(new ReproduzirAudioResponse
            {
                Mensagem = "Audio reproduzido com sucesso.",
                Sucesso = true
            });
        }
    }
}