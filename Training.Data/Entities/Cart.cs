using System;

namespace Training.Data.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int QuantityProduct { get; set; }
 
        public DateTime Created_time { get; set; }
        public DateTime Updated_time { get; set; }

        public Product Product { get; set; }
        public User User { get; set; }
    }
}