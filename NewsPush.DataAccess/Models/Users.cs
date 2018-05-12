using System;
using System.Collections.Generic;

namespace NewsPush.DataAccess.Models
{
    public partial class Users
    {
        public Users()
        {
            UsersCategories = new HashSet<UsersCategories>();
        }

        public int IdUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DeviceId { get; set; }

        public ICollection<UsersCategories> UsersCategories { get; set; }
    }
}
