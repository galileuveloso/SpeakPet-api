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
                _reproducao.InserirReproducao(request.Reproducao);
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
