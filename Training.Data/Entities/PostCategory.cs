using System;
using System.Collections.Generic;

namespace Training.Data.Entities
{
    public class PostCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Show { get; set; }
        public int Status { get; set; }
        public DateTime Created_time { get; set; }
        public DateTime Updated_time { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}