using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerApp.Core.DomainService;
using petShop.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;
        public OwnerService(IOwnerRepository ownerRepo)
        {
            _ownerRepo = ownerRepo;
        }


        public Owner AddOwner(Owner owner)
        {
            return _ownerRepo.Create(owner);
        }

        public void DeleteOwner(int id)
        {
             _ownerRepo.Delete(id);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepo.ReadyById(id);
        }

        public List<Owner> GetAllOwner()
        {
            return _ownerRepo.ReadAll().ToList();
        }

        public Owner UpdateOwner(Owner UpdateOwner)
        {
        
            return _ownerRepo.Update(UpdateOwner);
        }
    }
}
