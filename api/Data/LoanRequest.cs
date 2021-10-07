using System;
using System.Collections.Generic;

#nullable disable

namespace api.Data
{
    public partial class LoanRequest
    {
        public int LoanRequestId { get; set; }
        public DateTime Date { get; set; }
        public int? BorrowerId { get; set; }
        public decimal? Amount { get; set; }
        public string Description { get; set; }
        public DateTime? Payday { get; set; }

        public virtual Borrower Borrower { get; set; }
    }
}
