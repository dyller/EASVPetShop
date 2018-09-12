using petShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetApp.Infrastructure.Repository
{
    
   public static class FAKEDB
    {
        public static int PetId = 1;
    public static IEnumerable<Pet> pet;
        public static int OwnerId = 1;
        public static IEnumerable<Owner> owner;
        public static void InitData()

        {
            var owner1 = new Owner()
            {
                Address = "bongo",
                Email = "hey@hey",
                Firstname = " jacob",
                Id = OwnerId++,
                LastName = "Dyrvig",
                PhoneNumber = "42512351"
            };
            var owner2 = new Owner()
            {
                Address = "vejle",
                Email = "asd@hey",
                Firstname = " Jens",
                Id = OwnerId++,
                LastName = "hrgs",
                PhoneNumber = "1231112"
            };
            var owner3 = new Owner()
            {
                Address = "Hometown",
                Email = "hey@kage",
                Firstname = " peter",
                Id = OwnerId++,
                LastName = "Petersen",
                PhoneNumber = "54226115"
            };

            owner = new List<Owner> { owner1, owner2, owner3 };

            var pet1 = new Pet()
            {
                ID = PetId++,
                PreviousOwner = owner.ToList()[1],
                Birthdate = new DateTime(2014, 8, 7),
                Color = "red",
                SoldDate = new DateTime(2015, 10, 7),
                Type = "Dog",
                Name = "Dylan",
                Price = 200
            };
            
            var pet2 = new Pet()
            {
                ID = PetId++,
                PreviousOwner = owner.ToList()[1],
            Birthdate = new DateTime(2012, 2, 2),
                Color = "blue",
                SoldDate = new DateTime(2015, 6, 5),
                Type = "Horse",
                Name = "Kyle",
                Price = 20
            };
            var pet3 = new Pet()
            {
                ID = PetId++,
                PreviousOwner = owner.ToList()[0],
                Birthdate = new DateTime(2000, 2, 2),
                Color = "blue",
                SoldDate = new DateTime(2015, 6, 5),
                Type = "Horse",
                Name = "Rose",
                Price = 230
            };
            var pet4 = new Pet()
            {
                ID = PetId++,
                PreviousOwner = owner.ToList()[0],
                Birthdate = new DateTime(2012, 2, 2),
                Color = "blue",
                SoldDate = new DateTime(2015, 6, 5),
                Type = "Dog",
                Name = "Chi",
                Price = 210
            };
            var pet5 = new Pet()
            {
                ID = PetId++,
                PreviousOwner = owner.ToList()[2],
                Birthdate = new DateTime(2012, 2, 2),
                Color = "blue",
                SoldDate = new DateTime(2015, 6, 5),
                Type = "Horse",
                Name = "Spiderman",
                Price = 200_000
            };
            var pet6 = new Pet()
            {
                ID = PetId++,
                PreviousOwner = owner.ToList()[1],
                Birthdate = new DateTime(2012, 2, 2),
                Color = "blue",
                SoldDate = new DateTime(2015, 6, 5),
                Type = "Pig",
                Name = "Wild",
                Price = 2110
            };
            var pet7 = new Pet()
            {
                ID = PetId++,
                PreviousOwner = owner.ToList()[1],
                Birthdate = new DateTime(2012, 2, 2),
                Color = "blue",
                SoldDate = new DateTime(2015, 6, 5),
                Type = "Horse",
                Name = "Son",
                Price = 2230
            };
            var pet8 = new Pet()
            {
                ID = PetId++,
                PreviousOwner = owner.ToList()[1],
                Birthdate = new DateTime(2012, 2, 2),
                Color = "blue",
                SoldDate = new DateTime(2015, 6, 5),
                Type = "Dog",
                Name = "dog",
                Price = 270
            };
            pet = new List<Pet> { pet1, pet2, pet3, pet4, pet5,pet6,pet7,pet8 };

        }
    }
}
