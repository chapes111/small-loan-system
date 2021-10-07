using System;
using System.Collections.Generic;

#nullable disable

namespace api.Data
{
    public partial class Deadline
    {
        public Deadline()
        {
            Loans = new HashSet<Loan>();
        }

        public DateTime AgreedDate { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
