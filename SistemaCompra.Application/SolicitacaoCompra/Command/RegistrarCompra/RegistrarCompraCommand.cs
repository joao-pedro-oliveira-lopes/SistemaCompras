using MediatR;
using System;


namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool> 
    {
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        

        
    }
}
