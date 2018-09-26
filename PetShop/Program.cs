using Microsoft.Extensions.DependencyInjection;
using CustomerApp.Core.DomainService;

using CustomerApp.Core.ApplicationService.Services;
using CustomerApp.Core.ApplicationService;
using System;
using PetApp.Infrastructure;
using PetApp.Infrastructure.Repository;
using PetApp.Infrastructure.SQLRepositorie;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            FAKEDB.InitData();

            var service = new ServiceCollection();
            service.AddScoped<IPetRepository1, SQLPetRepository>();
            service.AddScoped<IPetService, PetService>();

            service.AddScoped<IOwnerRepository, SQLOwnerRepository>();
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
