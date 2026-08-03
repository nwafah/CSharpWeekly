using DependencyInjectionLifetimes.Scoped.Contracts;

namespace DependencyInjectionLifetimes.ServiceLifetimes.GeneralServices
{
    public class ScopedOperation : IScopedOperation
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
