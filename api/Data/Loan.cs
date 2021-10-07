using System;
using System.Collections.Generic;

#nullable disable

namespace api.Data
{
    public partial class Loan
    {
        public Loan()
        {
            Intermediaries = new HashSet<Intermediary>();
        }

        public DateTime Date { get; set; }
        public DateTime? DeadlineAgreedDate { get; set; }
        public DateTime? RepaymentDate { get; set; }

        public virtual Deadline DeadlineAgreedDateNavigation { get; set; }
        public virtual Repayment RepaymentDateNavigation { get; set; }
        public virtual ICollection<Intermediary> Intermediaries { get; set; }
    }
}
