using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Core.ApplicationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using petShop.Core.Entity;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        public OwnerController(IOwnerService ownerServie)
        {
            _ownerServie = ownerServie;
        }

        private readonly IOwnerService _ownerServie;


        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerServie.GetAllOwner();
        }


        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerServie.GetAllOwner().FirstOrDefault(owner => owner.Id == id);
        }


        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            owner.Id = 0;
            if (string.IsNullOrEmpty(owner.Address))
            {
                return null;
            }
            return _ownerServie.AddOwner(owner);
        }

        [HttpPut("{id}")]
        public void Put([FromBody] Owner owner)
        {
            var ownerToUpdate = _ownerServie.UpdateOwner(owner);
            ownerToUpdate.PhoneNumber = owner.PhoneNumber;
            ownerToUpdate.Email = owner.Email;
            ownerToUpdate.Address = owner.Address;
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ownerServie.DeleteOwner(id);
        }
    }
    
}
