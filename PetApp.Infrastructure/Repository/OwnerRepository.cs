using CustomerApp.Core.DomainService;
using petShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetApp.Infrastructure.Repository
{
    public class OwnerRepository : IOwnerRepository
    {

        public Owner Create(Owner owner)
        {
            owner.Id = FAKEDB.OwnerId++;
            var ownerList = FAKEDB.owner.ToList();
            ownerList.Add(owner);
            FAKEDB.owner = ownerList;
            return owner;
        }

        public Owner Delete(int id)
        {
            var OwnerFound = this.ReadyById(id);
            if (OwnerFound != null)
            {
                var ownerList = FAKEDB.owner.ToList();
                ownerList.Add(OwnerFound);
                ownerList.Remove(OwnerFound);
                FAKEDB.owner = ownerList;
                return OwnerFound;
            }
            return null;
        }

        public IEnumerable<Owner> ReadAll()
        {
            return FAKEDB.owner.ToList();

        }

        public Owner ReadyById(int id)
        {
            foreach (var owner in FAKEDB.owner.ToList())
            {
                if (owner.Id == id)
                {
                    return owner;
                }
            }
            return null;
        }

        public Owner Update(Owner ownerUpdate)
        {
            var OwnerFromDB = this.ReadyById(ownerUpdate.Id);
            if (OwnerFromDB != null)
            {
                OwnerFromDB.Address = ownerUpdate.Address;
                OwnerFromDB.Email = ownerUpdate.Email;
                OwnerFromDB.Firstname = ownerUpdate.Firstname;
                OwnerFromDB.Id = ownerUpdate.Id;
                OwnerFromDB.LastName = ownerUpdate.LastName;
                OwnerFromDB.PhoneNumber = ownerUpdate.PhoneNumber;


                return OwnerFromDB;
            }
            return null;
        }
    }
}
