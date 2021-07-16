using MediatR;
using SpeakPet.Dominio.Base;
using SpeakPet.Dominio.Interfaces.Servico;
using SpeakPet.Dominio.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpeakPet.Features.Usuario.Command
{
    public class AdicionarUsuarioCommand : IRequest<AdicionarUsuarioResponse>
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }

    public class AdicionarUsuarioResponse : BaseResponse
    {
    }

    public class AdicionarUsuarioHandler : IRequestHandler<AdicionarUsuarioCommand, AdicionarUsuarioResponse>
    {
        private readonly IUsuarioService _usuario;

        public AdicionarUsuarioHandler(IUsuarioService usuario)
        {
            _usuario = usuario;
        }

        public Task<AdicionarUsuarioResponse> Handle(AdicionarUsuarioCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new NullReferenceException();

            UsuarioModel usuario = new UsuarioModel(request.Login, request.Senha);

            try
            {
                _usuario.InserirUsuario(usuario);
            }
            catch
            {
                return Task.FromResult(new AdicionarUsuarioResponse
                {
                    Mensagem = "Ocorreu um erro ao inserir o Usuario.",
                    Sucesso = false
                });
            }

            return Task.FromResult(new AdicionarUsuarioResponse
            {
                Mensagem = "Usuario cadastrado com sucesso.",
                Sucesso = true
            });
        }
    }
}
