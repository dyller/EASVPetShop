using petShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.ApplicationService
{
   public  interface IOwnerService
    {

        Owner AddOwner(Owner pet);

        Owner FindOwnerById(int id);
        List<Owner> GetAllOwner();

        Owner UpdateOwner(Owner UpdateOwner);

        Owner DeleteOwner(int id);
    }
}
