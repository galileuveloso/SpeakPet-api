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
    public class ListarAudiosCommand : IRequest<ListarAudiosResponse>
    {
        public ListarAudiosCommand(int idUsuario)
        {
            IdUsuario = idUsuario;
        }

        public int IdUsuario { get; set; }
    }

    public class ListarAudiosResponse : BaseResponse
    {
        public IEnumerable<AudioModel> Audios { get; set; }
    }

    public class ListarAudiosHandler : IRequestHandler<ListarAudiosCommand, ListarAudiosResponse>
    {
        private readonly IAudioService _audio;

        public ListarAudiosHandler(IAudioService audio)
        {
            _audio = audio;
        }

        public Task<ListarAudiosResponse> Handle(ListarAudiosCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new NullReferenceException();

            IEnumerable<AudioModel> audios;
            try
            {
                audios = _audio.ListarAudios(request.IdUsuario);
            }
            catch(Exception ex)
            {
                return Task.FromResult(new ListarAudiosResponse
                {
                    Mensagem = "Ocorreu um erro ao tentar listar os audios." + ex.Message,
                    Sucesso = false
                });
            }

            return Task.FromResult(new ListarAudiosResponse
            {
                Mensagem = "Audios listados com sucesso.",
                Sucesso = true,
                Audios = audios
            });
        }
    }
}
