using petShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Core.DomainService
{
    public interface IOwnerRepository
    {
        Owner Create(Owner pet);

        Owner ReadyById(int id);

        IEnumerable<Owner> ReadAll();

        Owner Update(Owner petUpdate);

        Owner Delete(int id);
    }
}
