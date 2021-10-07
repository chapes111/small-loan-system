using System;
using System.Collections.Generic;

#nullable disable

namespace api.Data
{
    public partial class LenderBorrower
    {
        public int BorrowerId { get; set; }
        public int LenderId { get; set; }
        public DateTime? LoanDate { get; set; }
        public int? Percentage { get; set; }

        public virtual Borrower Borrower { get; set; }
        public virtual Lender Lender { get; set; }
    }
}
