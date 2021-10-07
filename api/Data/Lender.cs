using System;
using System.Collections.Generic;

#nullable disable

namespace api.Data
{
    public partial class Lender
    {
        public Lender()
        {
            LenderBorrowers = new HashSet<LenderBorrower>();
        }

        public int Id { get; set; }
        public int AddresseeId { get; set; }

        public virtual Addressee Addressee { get; set; }
        public virtual ICollection<LenderBorrower> LenderBorrowers { get; set; }
    }
}
