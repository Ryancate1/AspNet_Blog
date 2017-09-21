using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rcate_blog.Models
{
    public class SearchHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IQueryable<Post> IndexSearch(string searchStr)
        {
            IQueryable<Post> result = null;
            if (searchStr != null)
            {
                result = db.Posts.AsQueryable();
                result = result.Where(p => p.Title.Contains(searchStr));
            }
            else
            {
                result = db.Posts.AsQueryable();
            }
            return result;
        }
    }
}