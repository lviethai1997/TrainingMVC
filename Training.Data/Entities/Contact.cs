using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Training.Data.Entities
{
    [Table("Contacts")]
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public DateTime Created_time { get; set; }
    }
}