using Microsoft.Extensions.DependencyInjection;
using CustomerApp.Core.DomainService;
using PetApp.Infrastructure;
using CustomerApp.Core.ApplicationService.Services;
using CustomerApp.Core.ApplicationService;
using PetApp.Infrastructure.Repository;
using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            FAKEDB.InitData();

            var service = new ServiceCollection();
            service.AddScoped<IPetRepository1, PetRepository>();
            service.AddScoped<IPetService, PetService>();

           
            
            service.AddScoped<IOwnerRepository, OwnerRepository>();
            service.AddScoped<IOwnerService, OwnerService>();
            var serviceProviderpet = service.BuildServiceProvider();
            var petService = serviceProviderpet.GetRequiredService<IPetService>();
            var ownerService = serviceProviderpet.GetRequiredService<IOwnerService>();


            new Printer(petService, ownerService);

            Console.ReadLine();
            /*////then build provider 
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();*/

            //FAKEDB.InitData();
            //var serviceCollection = new ServiceCollection();
            //serviceCollection.AddScoped<IPetRepository1, PetRepository>();
            //serviceCollection.AddScoped<IPetService, PetService>();
            //serviceCollection.AddScoped<IPrinter, Printer>();

            //////then build provider 
            //var serviceProvider = serviceCollection.BuildServiceProvider();
            //var printer = serviceProvider.GetRequiredService<IPrinter>();
            //printer.StartUI();
        }
    }
}
