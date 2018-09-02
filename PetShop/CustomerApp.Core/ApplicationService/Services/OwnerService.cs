using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using petShop.Core.Entity;

namespace CustomerApp.Core.ApplicationService.Services
{
   public class OwnerService : IOwnerService
    {
        readonly IOwnerService _ownerRepo;
        public OwnerService(IOwnerService ownerRepo)
        {
            _ownerRepo = ownerRepo;
        }
       
        
        public Owner AddOwner(Owner owner)
        {
            return _ownerRepo.AddOwner(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepo.DeleteOwner(id);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepo.FindOwnerById(id);
        }

        public List<Owner> GetAllOwner()
        {
            return _ownerRepo.GetAllOwner().ToList();
        }

        public Owner UpdateOwner(Owner UpdateOwner)
        {
            var owner = FindOwnerById(UpdateOwner.Id);
            
            return owner; 
        }
    }
}
