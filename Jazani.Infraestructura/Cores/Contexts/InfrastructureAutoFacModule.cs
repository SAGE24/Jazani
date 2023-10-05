using Autofac;
using System.Reflection;

namespace Jazani.Infraestructure.Cores.Contexts;
public class InfrastructureAutoFacModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();
    }
}
