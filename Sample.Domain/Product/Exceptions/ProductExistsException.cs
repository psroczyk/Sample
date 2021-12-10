using Sample.Domain.Base;

namespace Sample.Domain.Product.Exceptions
{
    public class ProductExistsException : DomainException
    {
        public ProductExistsException(string msg) : base(msg)
        {
        }
    }
}
