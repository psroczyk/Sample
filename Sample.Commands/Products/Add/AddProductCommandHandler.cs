using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sample.Domain.Product;
using Sample.Domain.Product.Repositories;

namespace Sample.Commands.Products.Add
{
    public class AddProductCommand : IRequest<Guid>
    {
        public AddProductCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;

        public AddProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.Create(request.Name);
            _productRepository.Add(product);
            return Task.FromResult(product.Id);
        }
    }
}
