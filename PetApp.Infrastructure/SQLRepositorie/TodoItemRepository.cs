using CustomerApp.Core.DomainService;
using Microsoft.EntityFrameworkCore;
using petShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetApp.Infrastructure.SQLRepositorie
{
    public class TodoItemRepository : IUserRepository<TodoItem>
    {
        private readonly PetShopAppContext db;

        public TodoItemRepository(PetShopAppContext context)
        {
            db = context;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return db.TodoItems.ToList();
        }

        public TodoItem Get(long id)
        {
            return db.TodoItems.FirstOrDefault(b => b.Id == id);
        }

        public void Add(TodoItem entity)
        {
            db.TodoItems.Add(entity);
            db.SaveChanges();
        }

        public void Edit(TodoItem entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(long id)
        {
            var item = db.TodoItems.FirstOrDefault(b => b.Id == id);
            db.TodoItems.Remove(item);
            db.SaveChanges();
        }
    }
}
