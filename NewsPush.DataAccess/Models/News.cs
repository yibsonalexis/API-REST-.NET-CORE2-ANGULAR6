using System;
using System.Collections.Generic;

namespace NewsPush.DataAccess.Models
{
    public partial class News
    {
        public int IdNews { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? IdCategory { get; set; }

        public Categories IdCategoryNavigation { get; set; }
    }
}
