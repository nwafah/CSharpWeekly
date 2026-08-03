using DependencyInjectionLifetimes.Scoped.Contracts;

namespace DependencyInjectionLifetimes.ServiceLifetimes.GeneralServices
{
    public class TransientOperation : ITransientOperation
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
