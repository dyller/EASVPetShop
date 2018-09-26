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
        public ActionResult<IEnumerable<Pet>> Get([FromQuery]Filter filter)
        {
           
            return _petService.GetFilteredPet(filter);
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
        public ActionResult<Pet> Put(int id,[FromBody] Pet pet)
        {
            if (id < 1 || id != pet.ID)
            {
                return BadRequest("Parameter Id and pet ID must be the same");
            }

            return Ok(_petService.UpdatePet(pet));
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.DeletePet(id);
        }
    }
}
