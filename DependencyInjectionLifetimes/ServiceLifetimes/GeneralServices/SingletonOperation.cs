using DependencyInjectionLifetimes.Scoped.Contracts;

namespace DependencyInjectionLifetimes.ServiceLifetimes.GeneralServices
{
    public class SingletonOperation : ISingletonOperation
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
