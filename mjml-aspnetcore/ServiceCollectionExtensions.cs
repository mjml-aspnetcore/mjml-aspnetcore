using System;
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

            serviceCollection.AddNodeServices();
            serviceCollection.AddSingleton(options);
            serviceCollection.AddSingleton<IMjmlServices, MjmlServices>();
        }
    }
}
