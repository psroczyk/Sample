using System;
using Sample.Domain.Base;
using Sample.Domain.Product.Exceptions;

namespace Sample.Domain.Product
{
    public class Product : AggregateRoot<Guid>
    {
        public string Name { get; private set; }


        public static Product Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new RequiredFieldNotProvidedException(nameof(name));
            }

            return new Product(name);
        }

        private Product(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        private Product()
        {
        }
    }
}
