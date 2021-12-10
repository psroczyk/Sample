using Microsoft.Extensions.DependencyInjection;
using Sample.Domain.Product.Repositories;
using Sample.Persistence.Product.Repositories;

namespace Sample.Persistence
{
    public static class PersistenceRegistry
    {
        public static IServiceCollection RegisterPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IProductRepository, ProductRepository>();

            return serviceCollection;
        }
    }
}
