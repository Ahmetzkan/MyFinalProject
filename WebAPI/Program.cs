using Microsoft.AspNetCore.Cors.Infrastructure;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Autofac;
using Business.DependencyResolvers.Autofac;
using Autofac.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//Autofac,Ninject,CastleWindsor,StructureMap,LightInject,DryInject --> Ioc Container
//Postsharp
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Arkaplanda referans istenirse diye; 1.isterse,2.yi ver mant���yla
//bu �ekilde yap�yoruz.
//T�m bellekte bir tane singleton ve manager olu�turyor.
//1 mn client da gelse ayn� referans� veriyor.
//Singleton ise i�erisinde data yoksa kullan�l�r.
//builder.Services.AddSingleton<IProductService, ProductManager>();
//builder.Services.AddSingleton<IProductDal, EfProductDal>();


//.Net Container yerine ba�ka bir Ioc Container kullan�lmas� istenildi�i zaman
//bu �ekilde tan�mlan�r.
builder.Host
.UseServiceProviderFactory(new AutofacServiceProviderFactory())
.ConfigureContainer<ContainerBuilder>(builder =>
 {
     builder.RegisterModule(new AutofacBusinessModule());
 });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

