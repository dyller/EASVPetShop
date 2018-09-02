using CustomerApp.Core.ApplicationService;
using petShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop
{
    public class Printer : IPrinter
    {
        readonly IPetService _petService;
        readonly IOwnerService _ownerService;
        public Printer(IPetService petService, IOwnerService ownerService)
        {
            _ownerService = ownerService;
               _petService = petService;
                

        }
        public void StartUI()
        {
            string[] menuItems = {
                "List All Pet",
                "Add Pet",
                "Delete pet",
                "Edit pet",
                "Search Pets by Type ",
                "Sort pet by Price",
                "Get 5 cheapest pet",
                "Exit"
            };

            var selection = ShowMenu(menuItems);

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        var petss = _petService.GetAllPet();
                        ListPet(petss);
                        break;
                    case 2:
                        Pet pet = new Pet(); ;
                       
                        pet.Name = AskQuestion("pet name: ");
                        Console.WriteLine("owner option out of work" );
                        //for (int p = 0; p < _ownerService.GetAllOwner().Count; p++)
                        //{
                        //    foreach (var owner in _ownerService.GetAllOwner())
                        //    {
                        //        Console.WriteLine(p + " " + owner.Firstname + " " + owner.LastName);
                        //    }
                        //}

                        int i; 
                        while(!int.TryParse(AskQuestion("Price: "), out i)||0>i)
                        {
                            Console.WriteLine("Try again it need to be a number above 0");
                        }

                        pet.Price =  i;
                        int year, month, day;
                        while (!int.TryParse(AskQuestion("Year it is born: "), out year) || 0 > year||year>DateTime.Today.Year)
                        {
                            Console.WriteLine("Try again it need to be a Year above 0, and before "+ DateTime.Today.Year);
                        }
                        while (!int.TryParse(AskQuestion("month it is born: "), out month) || 0 > month || month > 12)
                        {
                            Console.WriteLine("Try again it need to be a month above 0, and before " + 12);
                        }
                        while (!int.TryParse(AskQuestion("day it is born: "), out day) || 0 > day || day > 31)
                        {
                            Console.WriteLine("Try again it need to be a day above 0, and before " + 31);
                        }
                        pet.Birthdate = new DateTime(year, month, day);
                        pet.Color = AskQuestion("Color : ");

                        

                        while (!int.TryParse(AskQuestion("Year it is Sold: "), out year) || 0 > year || year > DateTime.Today.Year)
                        {
                            Console.WriteLine("Try again it need to be a Year above 0, and before " + DateTime.Today.Year);
                        }
                        while (!int.TryParse(AskQuestion("month it is Sold: "), out month) || 0 > month || month > 12)
                        {
                            Console.WriteLine("Try again it need to be a month above 0, and before " + 12);
                        }
                        while (!int.TryParse(AskQuestion("day it is Sold: "), out day) || 0 > day || day > 31)
                        {
                            Console.WriteLine("Try again it need to be a day above 0, and before " + 31);
                        }
                        pet.SoldDate = new DateTime(year, month, day);
                        pet.Type = AskQuestion("What type of animal");
                        var pets = _petService.AddPet(pet);
                        break;
                    case 3:
                        var idForDelete = PrintFindCustomeryId();
                        _petService.DeletePet(idForDelete);
                        break;
                    case 4:
                        var idForEdit = PrintFindCustomeryId();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        Console.WriteLine("Updating " + petToEdit.Name + " Price:" + petToEdit.Price);
                        petToEdit.Name = AskQuestion("Name: ");
                        int k;
                        while (!int.TryParse(AskQuestion("Price: "), out k) || 0 > k)
                        {
                            Console.WriteLine("Try again it need to be a number above 0");
                        }
                        petToEdit.Price = k;

                        _petService.UpdatePet(petToEdit);
                        break;
                    case 5:
                        var type = AskQuestion("What type of animal");
                        List<Pet> petByType = petByTypeList(type);
                        ListPet(petByType);
                        break;
                    case 6:
                        var petsss = _petService.GetAllPet();
                        SortedListByPrice(petsss);
                        ListPet(petsss);
                        break;
                    case 7:
                        var pes = _petService.GetAllPet();
                        SortedListByPrice(pes);
                        for (int p = 0; p < pes.Count&&p<5; p++)
                        {
                            Console.WriteLine($"Id: {pes[p].ID} Name: {pes[p].Name} " + " PreviousOwner: " +
                            $"{pes[p].PreviousOwner.Firstname} {pes[p].PreviousOwner.LastName} " +
                            $"Price: {pes[p].Price}\nBirthdate: {pes[p].Birthdate} SoldDate:  {pes[p].SoldDate} Type: {pes[p].Type}\n");

                        }

                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Bye bye!");

            Console.ReadLine();
        }

        private void SortedListByPrice(List<Pet> petsss)
        {
            petsss.Sort(delegate (Pet x, Pet y)
            {
                return x.Price.CompareTo(y.Price);
            });
        }

        private List<Pet> petByTypeList(string type)
        {
            type.Trim();
            List<Pet> petsByType = new List<Pet>();
            for (int i = 0; i < _petService.GetAllPet().Count; i++)
            {
                if (_petService.GetAllPet()[i].Type.Equals(type))
                {
                    petsByType.Add(_petService.GetAllPet()[i]);
                }
            }
            return petsByType;
        }

        int PrintFindCustomeryId()
        {
            Console.WriteLine("Insert Customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }

        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        void ListPet(List<Pet> pets)
        {
            Console.WriteLine("\nList of Customers");
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.ID} Name: {pet.Name} "+" PreviousOwner: " +
                                $"{pet.PreviousOwner.Firstname} {pet.PreviousOwner.LastName} " +
                                $"Price: {pet.Price}\nBirthdate: {pet.Birthdate} SoldDate:  {pet.SoldDate} Type: {pet.Type}\n");
            }
            Console.WriteLine("\n");

        }
             
        int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 8)
            {
                Console.WriteLine("Please select a number between 1-8");
            }

            return selection;
        }

      
        
    }
}
