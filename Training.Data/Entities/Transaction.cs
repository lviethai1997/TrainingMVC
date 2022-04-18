using System;

namespace Training.Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public DateTime Created_time { get; set; }
        public DateTime Updated_time { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }
    }
}