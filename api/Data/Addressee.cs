using System;
using System.Collections.Generic;

#nullable disable

namespace api.Data
{
    public partial class Addressee
    {
        public Addressee()
        {
            Intermediaries = new HashSet<Intermediary>();
            Lenders = new HashSet<Lender>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Intermediary> Intermediaries { get; set; }
        public virtual ICollection<Lender> Lenders { get; set; }
    }
}
