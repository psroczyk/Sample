using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sample.Domain.Product;
using Sample.Domain.Product.Repositories;

namespace Sample.Queries.Products.GetAll
{
    public class GetAllProductQuery : IRequest<IEnumerable<Product>> //TODO: create DTO object
    {
    }

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken) =>
            Task.FromResult(_productRepository.GetAll());
    }
}
