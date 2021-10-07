using System;
using System.Collections.Generic;

#nullable disable

namespace api.Data
{
    public partial class Borrower
    {
        public Borrower()
        {
            LenderBorrowers = new HashSet<LenderBorrower>();
            LoanRequests = new HashSet<LoanRequest>();
        }

        public int Id { get; set; }
        public int? AddresseeId { get; set; }

        public virtual ICollection<LenderBorrower> LenderBorrowers { get; set; }
        public virtual ICollection<LoanRequest> LoanRequests { get; set; }
    }
}
