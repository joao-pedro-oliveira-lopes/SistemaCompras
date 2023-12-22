using MediatR;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;
using System.Threading;
using System.Threading.Tasks;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;



namespace SistemaCompras.Application.SolicitacaoCompra.Command
{
    public class RegistrarCompraCommandHandler : IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarCompraCommandHandler(ISolicitacaoCompraRepository solicitacaoCompraRepository, IUnitOfWork unitOfWork)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            
            var solicitacaoCompra = new SistemaCompra.Domain.SolicitacaoCompraAggregate.SolicitacaoCompra("rodrigoasth", "rodrigoasth");

            _solicitacaoCompraRepository.RegistrarCompra(solicitacaoCompra);

            return _unitOfWork.Commit();
        }
    }
}
