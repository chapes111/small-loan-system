using System;
using System.Collections.Generic;

#nullable disable

namespace api.Data
{
    public partial class Repayment
    {
        public Repayment()
        {
            Loans = new HashSet<Loan>();
        }

        public DateTime Date { get; set; }
        public decimal? Amount { get; set; }

        public virtual ICollection<Loan> Loans { get; set; }
    }
}
