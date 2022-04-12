using System;

namespace Training.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ContentMini { get; set; }
        public string ImageBanner { get; set; }
        public int PostCateId { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public DateTime Created_time { get; set; }
        public DateTime Updated_time { get; set; }

        public PostCategory PostCategory { get; set; }
        public User User { get; set; }
    }
}