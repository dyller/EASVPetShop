using CustomerApp.Core.DomainService;
using Microsoft.EntityFrameworkCore;
using PetApp.Infrastructure.Repository;
using petShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetApp.Infrastructure
{
    public class PetRepository: IPetRepository1

    {


        readonly PetShopAppContext _ctx;

        public PetRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Pet Create(Pet pet)
        {

            pet.ID = FAKEDB.PetId++;
            var petList = FAKEDB.pet.ToList();
             petList.Add(pet);
            FAKEDB.pet = petList;
           return pet;
        }

        public void Delete(int id)
        {
            var PetFound = this.ReadyById(id);
            if (PetFound != null)
            {
            var petList = FAKEDB.pet.ToList();
            petList.Remove(PetFound);
            FAKEDB.pet = petList;
            }

        }
        public IEnumerable<Pet> ReadAll()
        {
            return FAKEDB.pet.ToList();
        }

        public IEnumerable<Pet> ReadAll(Filter filter = null)
        {
            throw new NotImplementedException();
        }

        public Pet ReadyById(int id)
        {
            foreach (var pet in FAKEDB.pet.ToList())
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

            _ctx.Attach(petUpdate).State = EntityState.Modified;
            _ctx.Entry(petUpdate).Reference(o => o.PreviousOwner).IsModified = true;
            _ctx.SaveChanges();
            return petUpdate;
        }

        Pet IPetRepository1.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }

       
    }
