using System;
using System.Collections.Generic;

namespace Sample.Domain.Product.Repositories
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(Guid id);
        Product Get(Guid id); //TODO: use strongly typed-id
        IEnumerable<Product> GetAll();//TODO: pagination, search queries
    }
}