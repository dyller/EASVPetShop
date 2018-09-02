using petShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.ApplicationService
{
   public interface IPetService
    {

        
        
        Pet AddPet(Pet pet);

        Pet FindPetById(int id);
        List<Pet> GetAllPet();

        Pet UpdatePet(Pet UpdatePet);
        
        Pet DeletePet(int id);
    }
}
