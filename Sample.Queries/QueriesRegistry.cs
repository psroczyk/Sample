using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sample.Queries.Products.Get;

namespace Sample.Queries
{
    public static class QueriesRegistry
    {
        public static IServiceCollection AddQueries(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(GetProductQueryHandler));

            return serviceCollection;
        }
    }
}
