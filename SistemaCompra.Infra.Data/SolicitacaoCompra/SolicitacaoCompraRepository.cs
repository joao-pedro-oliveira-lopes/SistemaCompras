using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SolicitacaoCompraAggregate = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Infra.Data.UoW;
using System.Threading.Tasks;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public SolicitacaoCompraRepository(SistemaCompraContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task RegistrarCompra(SolicitacaoCompraAggregate.SolicitacaoCompra solicitacaoCompra)
        {
            solicitacaoCompra.ValidarRegrasDeNegocio();

            await _context.SolicitacoesCompra.AddAsync(solicitacaoCompra);
            _unitOfWork.Commit();
        }

    }
}
