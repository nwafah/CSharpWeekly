using DependencyInjectionLifetimes.ServiceLifetimes.GeneralServices;
using DependencyInjectionLifetimes.Transient.Contracts;

namespace DependencyInjectionLifetimes.Transient.Services
{
    public class MyTransientService(ITransientOperation operation1) : IMyTransientService
    {
        public void CallOperation()
        {
           Console.WriteLine($"Service Operation Transient ID: {operation1.Id}");
        }
    }
}
