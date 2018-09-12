using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Core.ApplicationService;
using Microsoft.AspNetCore.Mvc;
using petShop.Core.Entity;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        public PetController(IPetService petService)
        {
            _petService = petService;
        }
   
        private readonly IPetService _petService;


        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetAllPet();
        }
        

        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.GetAllPet().FirstOrDefault(pet => pet.ID == id); 
        }
        

        [HttpPost]
        public ActionResult<Pet> Post ([FromBody] Pet pet)
        {
            pet.ID = 0;
            if (string.IsNullOrEmpty(pet.Type))
            {
                return null;
            }
            return _petService.AddPet(pet);
        }
        
        [HttpPut("{id}")]
        public void Put( [FromBody] Pet pet)
        {
            var petToUpdate = _petService.UpdatePet(pet);
            petToUpdate.Name = pet.Name;
            petToUpdate.Price = pet.Price;
            petToUpdate.PreviousOwner = pet.PreviousOwner;
                }
        

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.DeletePet(id);
        }
    }
}
