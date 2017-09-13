using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rcate_blog.Models
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Update { get; set; }
        public string MediaUrl { get; set; }
        public bool Published { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}