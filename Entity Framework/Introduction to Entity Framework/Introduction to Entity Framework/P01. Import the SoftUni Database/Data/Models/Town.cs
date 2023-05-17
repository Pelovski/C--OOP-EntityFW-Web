using System;
using System.Collections.Generic;

namespace P01._Import_the_SoftUni_Database.Data.Models
{
    public partial class Town
    {
        public Town()
        {
            Addresses = new HashSet<Addresse>();
        }

        public int TownId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Addresse> Addresses { get; set; }
    }
}
