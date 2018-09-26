using CustomerApp.Core.DomainService;
using Microsoft.EntityFrameworkCore;
using petShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetApp.Infrastructure.SQLRepositorie
{
    public class SQLPetRepository : IPetRepository1
    {
        private readonly PetShopAppContext _dtx;

        public SQLPetRepository(PetShopAppContext  dtx)
        {
            _dtx = dtx;
        }

        public int Count()
        {
            return _dtx.Pet.Count();
        }

        public Pet Create(Pet pet)
        {
            if (pet.PreviousOwner.Id == null && pet.PreviousOwner.Id > 0)
            {
                pet.PreviousOwner= _dtx.Owner
               .FirstOrDefault(c => c.Id == pet.PreviousOwner.Id);
            }
          var greatePet=  _dtx.Pet.Add(pet).Entity;
            _dtx.SaveChanges();
            return greatePet;
        }

        public Pet Delete(int id)
        {
            var removed = _dtx.Remove(new Pet { ID = id }).Entity;
            _dtx.SaveChanges();
            return removed;
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _dtx.Pet.Include(o => o.PreviousOwner);
        }

        public IEnumerable<Pet> ReadAll(Filter filter = null)
        {
            if (filter == null)
            {
                return _dtx.Pet;
            }

            return _dtx.Pet
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
        }

        public Pet ReadyById(int id)
        {
           
            return _dtx.Pet.Include(o => o.PreviousOwner)
               .FirstOrDefault(c => c.ID == id);
        }

        public Pet Update(Pet petUpdate)
        {
            if (petUpdate.PreviousOwner != null && _dtx.ChangeTracker.Entries<Pet>().
                FirstOrDefault(pe => pe.Entity.ID == petUpdate.ID) == null)
            {
                _dtx.Attach(petUpdate.PreviousOwner);
            }
            else
            {
                _dtx.Entry(petUpdate).Reference(p => p.PreviousOwner).IsModified = true;
            }
            var updated = _dtx.Pet.Update(petUpdate).Entity;
            _dtx.SaveChanges();
            return updated;
        }

    }
}
