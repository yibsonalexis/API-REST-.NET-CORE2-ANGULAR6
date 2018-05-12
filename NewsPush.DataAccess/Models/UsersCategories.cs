using System;
using System.Collections.Generic;

namespace NewsPush.DataAccess.Models
{
    public partial class UsersCategories
    {
        public int IdUsersCategories { get; set; }
        public int? IdUser { get; set; }
        public int? IdCategory { get; set; }

        public Categories IdCategoryNavigation { get; set; }
        public Users IdUserNavigation { get; set; }
    }
}
