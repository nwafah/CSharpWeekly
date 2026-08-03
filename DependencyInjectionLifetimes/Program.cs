
using DependencyInjectionLifetimes.Scoped.Contracts;
using DependencyInjectionLifetimes.Scoped.Services;
using DependencyInjectionLifetimes.ServiceLifetimes.GeneralServices;
using DependencyInjectionLifetimes.Singleton.Contracts;
using DependencyInjectionLifetimes.Singleton.Services;
using DependencyInjectionLifetimes.Transient.Contracts;
using DependencyInjectionLifetimes.Transient.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<IScopedOperation, ScopedOperation>();
builder.Services.AddScoped<IMyScopedService, MyScopedService>();

builder.Services.AddSingleton<ISingletonOperation, SingletonOperation>();
builder.Services.AddSingleton<IMySingletonService, MySingletonService>();

builder.Services.AddTransient<ITransientOperation, TransientOperation>();
builder.Services.AddTransient<IMyTransientService, MyTransientService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
