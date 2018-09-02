using petShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.DomainService
{
   public interface IPetRepository1
    {
        
        Pet Create(Pet pet);
        

        IEnumerable<Pet> ReadAll();

        Pet Update(Pet petUpdate);

        Pet Delete(int id);
    }
}
