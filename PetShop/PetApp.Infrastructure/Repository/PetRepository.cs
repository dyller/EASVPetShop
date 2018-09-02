using CustomerApp.Core.DomainService;
using PetApp.Infrastructure.Repository;
using petShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetApp.Infrastructure
{
    public class PetRepository: IPetRepository1

    {
       
        private List<Pet> _pet = FAKEDB.pet.ToList();

        
        public Pet Create(Pet pet)
        {
            pet.ID = FAKEDB.PetId++;
            _pet.Add(pet);
            return pet;
        }

        public Pet Delete(int id)
        {
            var PetFound = this.ReadyById(id);
            if (PetFound != null)
            {
                _pet.Remove(PetFound);
                return PetFound;
            }
            return null;
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _pet;
        }

        public Pet ReadyById(int id)
        {
            foreach (var pet in _pet)
            {
                if (pet.ID == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public Pet Update(Pet petUpdate)
        {
            var PetFromDB = this.ReadyById(petUpdate.ID);
            if (PetFromDB != null)
            {

                PetFromDB.Name = petUpdate.Name;
                PetFromDB.Color = petUpdate.Color;
                PetFromDB.Birthdate = petUpdate.Birthdate;
                PetFromDB.PreviousOwner = petUpdate.PreviousOwner;
                PetFromDB.Price = petUpdate.Price;
                PetFromDB.SoldDate = petUpdate.SoldDate;
                PetFromDB.Type = petUpdate.Type;
                return PetFromDB;
            }
            return null;
        }
    }
}
