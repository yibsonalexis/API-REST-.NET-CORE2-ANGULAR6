using System;

namespace NewsPush.Entities
{
    public class Enews
    {
        public int IdNews { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public int? IdCategory { get; set; }
    }
}
