using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.Data.Entities
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }

        public int? CustommerId { get; set; }

        public string CustommerName { get; set; }

        public string CustommerAdress { get; set; }

        public string CustommerEmail { get; set; }

        public string CustommerPhone { get; set; }

        public string CustommerMessage { get; set; }
        public int Status { get; set; }
        public DateTime Created_time { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; }
    }
}