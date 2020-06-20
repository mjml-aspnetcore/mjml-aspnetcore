using System;
using Jering.Javascript.NodeJS;
using Microsoft.Extensions.DependencyInjection;

namespace Mjml.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMjmlServices(this IServiceCollection serviceCollection)
        {
            AddMjmlServices(serviceCollection, o => { });
        }

        public static void AddMjmlServices(this IServiceCollection serviceCollection, Action<MjmlServiceOptions> configure)
        {
            var options = new MjmlServiceOptions();

            configure(options);

            serviceCollection.AddNodeJS();
            serviceCollection.AddSingleton(options);
            serviceCollection.AddSingleton<IMjmlServices, MjmlServices>();
        }
    }
}