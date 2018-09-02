using Microsoft.Extensions.DependencyInjection;
using CustomerApp.Core.DomainService;
using PetApp.Infrastructure;
using CustomerApp.Core.ApplicationService.Services;
using CustomerApp.Core.ApplicationService;
using PetApp.Infrastructure.Repository;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            FAKEDB.InitData();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository1, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            ////then build provider 
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();
        }
    }
}
