using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sample.Domain.Product;
using Sample.Domain.Product.Repositories;

namespace Sample.Queries.Products.Get
{
    public class GetProductQuery : IRequest<Product> //TODO: create DTO object
    {
        public GetProductQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }

    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken) =>
            Task.FromResult(_productRepository.Get(request.Id));
    }
}
