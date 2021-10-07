using System;
using System.Collections.Generic;

#nullable disable

namespace api.Data
{
    public partial class Intermediary
    {
        public int Id { get; set; }
        public int? AddresseeId { get; set; }
        public DateTime? LoanDate { get; set; }

        public virtual Addressee Addressee { get; set; }
        public virtual Loan LoanDateNavigation { get; set; }
    }
}
