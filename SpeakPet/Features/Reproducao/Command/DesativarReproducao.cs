using MediatR;
using SpeakPet.Dominio.Base;
using SpeakPet.Dominio.Interfaces.Servico;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpeakPet.Features.Reproducao.Command
{
    public class DesativarReproducaoCommand : IRequest<DesativarReproducaoResponse>
    {
        public int IdReproducao { get; set; }
    }

    public class DesativarReproducaoResponse : BaseResponse
    {

    }

    public class DesativarReproducaoHandler : IRequestHandler<DesativarReproducaoCommand, DesativarReproducaoResponse>
    {
        IReproducaoService _reproducao;

        public DesativarReproducaoHandler(IReproducaoService reproducao)
        {
            _reproducao = reproducao;
        }

        public Task<DesativarReproducaoResponse> Handle(DesativarReproducaoCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException();

            try
            {
                _reproducao.DesativarReproducao(request.IdReproducao);
            }
            catch
            {
                return Task.FromResult(new DesativarReproducaoResponse
                {
                });
            }

            return Task.FromResult(new DesativarReproducaoResponse
            {
                Mensagem = "Audio desativado com sucesso.",
                Sucesso = false
            });
        }
    }
}
