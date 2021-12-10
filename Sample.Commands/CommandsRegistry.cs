using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sample.Commands.Products.Add;

namespace Sample.Commands
{
    public static class CommandsRegistry
    {
        public static IServiceCollection AddCommands(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(typeof(AddProductCommandHandler));

            return serviceCollection;
        }
    }
}
