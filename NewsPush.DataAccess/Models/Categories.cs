using System;
using System.Collections.Generic;

namespace NewsPush.DataAccess.Models
{
    public partial class Categories
    {
        public Categories()
        {
            News = new HashSet<News>();
            UsersCategories = new HashSet<UsersCategories>();
        }

        public int IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<News> News { get; set; }
        public ICollection<UsersCategories> UsersCategories { get; set; }
    }
}
