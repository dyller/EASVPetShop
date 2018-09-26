using petShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.DomainService
{
   public interface IPetRepository1
    {
        
        Pet Create(Pet pet);
         Pet ReadyById(int id);
        IEnumerable<Pet> ReadAll();

        Pet Update(Pet petUpdate);
        IEnumerable<Pet> ReadAll(Filter filter = null);
        int Count();
        Pet Delete(int id);
    }
}
