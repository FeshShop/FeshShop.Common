namespace FeshShop.Common.Mvc
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using System.Reflection;

    public static partial class ConfigurationExtensions
    {
        public static IServiceCollection AddInitializers(this IServiceCollection services, params Type[] initializers)
            => initializers == null
                ? services
                : services.AddTransient<IStartupInitializer, StartupInitializer>(c =>
                {
                    var startupInitializer = new StartupInitializer();
                    var validInitializers = initializers.Where(t => typeof(IInitializer).IsAssignableFrom(t));

                    foreach (var initializer in validInitializers)
                    {
                        startupInitializer.AddInitializer(c.GetService(initializer) as IInitializer);
                    }

                    return startupInitializer;
                });

        public static IServiceCollection AddServices(this IServiceCollection services, Assembly assembly)
            => services.Scan(scan => scan.FromAssemblies(assembly).AddClasses().AsMatchingInterface());
    }
}
