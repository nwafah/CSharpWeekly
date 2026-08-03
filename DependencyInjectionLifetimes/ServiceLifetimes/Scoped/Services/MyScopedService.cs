using DependencyInjectionLifetimes.Scoped.Contracts;
using DependencyInjectionLifetimes.ServiceLifetimes.GeneralServices;

namespace DependencyInjectionLifetimes.Scoped.Services
{
    public class MyScopedService(IScopedOperation operation1) : IMyScopedService
    {
        public void CallOperation()
        {
           Console.WriteLine($"Service Operation  Scoped ID: {operation1.Id}");
        }
    }
}
