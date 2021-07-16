using MediatR;
using SpeakPet.Dominio.Base;
using SpeakPet.Dominio.Servico.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpeakPet.Features.Audio.Command
{
    public class EditarAudioCommand : IRequest<EditarAudioResponse>
    {
        public int IdAudio { get; set; }
        public string NovoTitulo { get; set; }
    }

    public class EditarAudioResponse : BaseResponse
    {
    }

    public class EditarAudioHandler : IRequestHandler<EditarAudioCommand, EditarAudioResponse>
    {
        private readonly IAudioService _audio;

        public EditarAudioHandler(IAudioService audio)
        {
            _audio = audio;
        }

        public Task<EditarAudioResponse> Handle(EditarAudioCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new NullReferenceException();

            if (String.IsNullOrEmpty(request.NovoTitulo))
                return Task.FromResult(new EditarAudioResponse
                {
                    Mensagem = "O Titulo do audio não pode ser vazio.",
                    Sucesso = true
                });

            try
            {
                _audio.EditarAudio(request.IdAudio, request.NovoTitulo);
            }
            catch
            {
                return Task.FromResult(new EditarAudioResponse
                {
                    Mensagem = "Ocorreu um erro ao tentar editar o audio.",
                    Sucesso = false
                });
            }

            return Task.FromResult(new EditarAudioResponse
            {
                Mensagem = "Audio editado com sucesso.",
                Sucesso = true
            });
        }
    }
}
