using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rcate_blog.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string Reason { get; set; }

        public virtual Post Post { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}