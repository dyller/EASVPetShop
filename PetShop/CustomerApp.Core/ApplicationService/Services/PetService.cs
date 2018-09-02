using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerApp.Core.DomainService;
using petShop.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
 public   class PetService : IPetService
    {
        readonly IPetRepository1 _PetRepo;

        public PetService(IPetRepository1 PetRepo)
        {
            _PetRepo = PetRepo;
        }
        public Pet AddPet(Pet pet)
        {
            return _PetRepo.Create(pet);
        }

        public Pet DeletePet(int id)
        {
            return _PetRepo.Delete(id);
        }

        public Pet FindPetById(int id)
        {
            foreach (var item in _PetRepo.ReadAll())
            {
                if (item.ID == id)
                {
                    return item;
                        }
            }
            return null;

        }

        public List<Pet> GetAllPet()
        {
            return _PetRepo.ReadAll().ToList();

        }

        public Pet UpdatePet(Pet UpdatePet)
        {
            var pet = FindPetById(UpdatePet.ID);
            pet.Name = UpdatePet.Name;
            pet.Color = UpdatePet.Color;
            pet.Birthdate = UpdatePet.Birthdate;
            pet.PreviousOwner = UpdatePet.PreviousOwner;
            pet.Price = UpdatePet.Price;
            pet.SoldDate = UpdatePet.SoldDate;
            pet.Type = UpdatePet.Type;
            return pet;
        }
    }
}
