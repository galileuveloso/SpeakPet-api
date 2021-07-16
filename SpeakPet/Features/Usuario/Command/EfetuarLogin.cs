using MediatR;
using SpeakPet.Dominio.Base;
using SpeakPet.Dominio.Interfaces.Servico;
using SpeakPet.Dominio.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpeakPet.Features.Usuario.Command
{
    public class EfetuarLoginCommand : IRequest<EfetuarLoginResponse>
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }

    public class EfetuarLoginResponse : BaseResponse
    {
        public int? IdUsuario { get; set; }
    }

    public class EfetuarLoginHandler : IRequestHandler<EfetuarLoginCommand, EfetuarLoginResponse>
    {
        private readonly IUsuarioService _usuario;

        public EfetuarLoginHandler(IUsuarioService usuario)
        {
            _usuario = usuario;
        }

        public Task<EfetuarLoginResponse> Handle(EfetuarLoginCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new NullReferenceException();

            UsuarioModel usuario;

            try
            {
                usuario = _usuario.EfetuarLogin(request.Login, request.Senha);
                
                if(usuario == null || !usuario.IdUsuario.HasValue)
                    return Task.FromResult(new EfetuarLoginResponse
                    {
                        Mensagem = "Usuário inválido",
                        Sucesso = true,
                        IdUsuario = null
                    });
            }
            catch
            {
                return Task.FromResult(new EfetuarLoginResponse
                {
                    Mensagem = "Ocorreu um erro ao tentar Efetuar o Login",
                    Sucesso = false
                });
            }

            return Task.FromResult(new EfetuarLoginResponse
            {
                Mensagem = "Usuario obtido com sucesso.",
                Sucesso = true,
                IdUsuario = usuario.IdUsuario
            });
        }
    }
}
