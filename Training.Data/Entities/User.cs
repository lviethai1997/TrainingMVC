using System;
using System.Collections.Generic;

namespace Training.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }
        public DateTime Created_time { get; set; }
        public DateTime Updated_time { get; set; }

        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
        public IEnumerable<Cart> Carts { get; set; }
    }
}