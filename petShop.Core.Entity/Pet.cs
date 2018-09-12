using System;

namespace petShop.Core.Entity
{
    public class Pet
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public String Color { get; set; }
        public Owner  PreviousOwner { get; set; }
        public double Price { get; set; }
    }
}
