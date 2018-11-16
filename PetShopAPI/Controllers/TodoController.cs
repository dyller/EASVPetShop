using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Core.DomainService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using petShop.Core.Entity;

namespace PetShopAPI.Controllers
{
    [Route("api/Todo")]
    public class TodoController : Controller
    {
        private readonly IUserRepository<TodoItem> repository;

        public TodoController(IUserRepository<TodoItem> repos)
        {
            repository = repos;
        }

        // GET: api/Todo
        [Authorize]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return repository.GetAll();
        }

        // GET: api/Todo/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST: api/Todo
        [HttpPost]
        public IActionResult Post([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            repository.Add(item);

            return CreatedAtRoute("Get", new { id = item.Id }, item);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] TodoItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = repository.Get(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.IsComplete = item.IsComplete;
            todo.Name = item.Name;

            repository.Edit(todo);
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = repository.Get(id);
            if (todo == null)
            {
                return NotFound();
            }

            repository.Remove(id);
            return new NoContentResult();
        }
    }
}