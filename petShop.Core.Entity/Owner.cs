using System;
using System.Collections.Generic;
using System.Text;

namespace petShop.Core.Entity
{
    public class Owner
    {
        public int Id { get; set; }
        public String Firstname { get; set; }
        public String LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<Pet> pets { get; set; }
    }
}
