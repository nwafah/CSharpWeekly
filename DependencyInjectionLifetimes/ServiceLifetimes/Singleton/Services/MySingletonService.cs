using DependencyInjectionLifetimes.ServiceLifetimes.GeneralServices;
using DependencyInjectionLifetimes.Singleton.Contracts;

namespace DependencyInjectionLifetimes.Singleton.Services
{
    public class MySingletonService(ISingletonOperation operation1) : IMySingletonService
    {
        public void CallOperation()
        {
           Console.WriteLine($"Service Operation Singleton ID: {operation1.Id}");
        }
    }
}
