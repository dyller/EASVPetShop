using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CustomerApp.Core.DomainService;
using petShop.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
 public   class PetService : IPetService
    {
        readonly IPetRepository1 _PetRepo;
        readonly IOwnerRepository _OwnerRepo;
        public PetService(IPetRepository1 PetRepo, IOwnerRepository OwnerRepo)
        {
            _PetRepo = PetRepo;
            _OwnerRepo = OwnerRepo;
        }
        public Pet AddPet(Pet pet)
        {
               if(pet.PreviousOwner == null || pet.PreviousOwner.Id <= 0)
                throw new InvalidDataException("To create Order you need a Customer");
                if(_OwnerRepo.ReadyById(pet.PreviousOwner.Id) == null)
                throw new InvalidDataException("Customer Not found");

            return _PetRepo.Create(pet);
        }

        public void DeletePet(int id)
        {
             _PetRepo.Delete(id);
        }

        public Pet FindPetById(int id)
        {
            return _PetRepo.ReadyById(id);

        }

        public List<Pet> GetAllPet()
        {
            return _PetRepo.ReadAll().ToList();

        }

        public List<Pet> GetFilteredPet(Filter filter)
        {
            if (filter.CurrentPage <= 0 || filter.ItemsPrPage <= 0)
            {
                throw new InvalidDataException("CurrentPage and ItemsPage Must zero or more");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _PetRepo.Count())
            {
                throw new InvalidDataException("Index out bounds, CurrentPage is to high");
            }

            return _PetRepo.ReadAll(filter).ToList();
        }

        public Pet UpdatePet(Pet UpdatePet)
        {


            return _PetRepo.Update(UpdatePet); 
        }
    }
}
