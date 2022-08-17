using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appenix_B_01.Models
{
    public class Invoice
    {
        public int CustomerId { get; set; }
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? BillingAddress { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingState { get; set; }
        public string? BillingCountry { get; set; }
        public string? BillingPostalCode { get; set; }
        public SqlDecimal Total { get; set; }

    }
}
