using CustomerApp.Core.ApplicationService;
using CustomerApp.Core.DomainService;
using petShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetApp.Infrastructure.SQLRepositorie
{
  public  class SQLOwnerRepository : IOwnerRepository
    {
       

        private readonly PetShopAppContext _ptx;

        public SQLOwnerRepository(PetShopAppContext ptx)
        {
            _ptx = ptx;
        }
        public Owner Create(Owner owner)
        {
            List<Pet> pets = new List<Pet>();
            foreach (var item in owner.pets)
            {


                if (item.ID == null && item.ID > 0)
                {
                    pets.Add (_ptx.Pet
                   .FirstOrDefault(c => c.ID == item.ID));
                }
            }
            owner.pets = pets;
            var greatePet = _ptx.Owner.Add(owner).Entity;
            _ptx.SaveChanges();
            return greatePet;

        }

        public Owner Delete(int id)
        {

            var custRemoved = _ptx.Remove(new Owner { Id = id }).Entity;
            _ptx.SaveChanges();
            return custRemoved;
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _ptx.Owner;
        }

        public Owner ReadyById(int id)
        {
            return _ptx.Owner.FirstOrDefault(c => c.Id == id);
        }

        public Owner Update(Owner ownerUpdate)
        {

            _ptx.Owner.Update(ownerUpdate);
            _ptx.SaveChanges();
            return ownerUpdate;
        }
    }
}
