using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sample.Domain.Product.Exceptions;
using Sample.Domain.Product.Repositories;

namespace Sample.Persistence.Product.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ICollection<Domain.Product.Product> _products = new List<Domain.Product.Product>();

        public void Add(Domain.Product.Product product)
        {
            if (_products.Any(x => x.Id == product.Id))
            {
                throw new ProductExistsException($"Product with id:{product.Id} already exists");
            }

            _products.Add(product);
        }

        public void Update(Domain.Product.Product product)
        {
            var existingProduct = _products.SingleOrDefault(x => x.Id == product.Id);
            _products.Remove(existingProduct);

            _products.Add(product);
        }

        public void Delete(Guid id)
        {
            var existingProduct = _products.SingleOrDefault(x => x.Id == id);

            if (existingProduct != null)
                _products.Remove(existingProduct);
        }

        public Domain.Product.Product Get(Guid id) => _products.SingleOrDefault(x => x.Id == id);

        public IEnumerable<Domain.Product.Product> GetAll() => _products.ToList();
    }
}
