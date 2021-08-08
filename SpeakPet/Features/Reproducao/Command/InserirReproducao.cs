using MediatR;
using SpeakPet.Dominio.Base;
using SpeakPet.Dominio.Interfaces.Servico;
using SpeakPet.Dominio.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpeakPet.Features.Reproducao.Command
{
    public class InserirReproducaoCommand : IRequest<InserirReproducaoResponse>
    {
        public ReproducaoModel Reproducao { get; set; }
    }

    public class InserirReproducaoResponse : BaseResponse
    {
        public bool Reproduzindo { get; set; }
        public int? IdReproducao { get; set; }
    }

    public class InserirReproducaoHandler : IRequestHandler<InserirReproducaoCommand, InserirReproducaoResponse>
    {
        IReproducaoService _reproducao;

        public InserirReproducaoHandler(IReproducaoService reproducao)
        {
            _reproducao = reproducao;
        }

        public Task<InserirReproducaoResponse> Handle(InserirReproducaoCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException();

            try
            {
                int? atual = _reproducao.ObterReproducaoAtual(request.Reproducao.IdUsuario);
                if (atual == null || !atual.HasValue || atual == 0)
                    _reproducao.InserirReproducao(request.Reproducao);
                else
                    return Task.FromResult(new InserirReproducaoResponse
                    {
                        Mensagem = "Existe um Audio em reproducao no momento.",
                        Sucesso = false,
                        Reproduzindo = true,
                        IdReproducao = atual
                    });
            }
            catch
            {
                return Task.FromResult(new InserirReproducaoResponse
                {
                    Mensagem = "Ocorreu um erro ao registrar a reprodução.",
                    Sucesso = false
                });
            }

            return Task.FromResult(new InserirReproducaoResponse
            {
                Mensagem = "Reprodução registrada com sucesso.",
                Sucesso = true
            });
        }
    }
}
