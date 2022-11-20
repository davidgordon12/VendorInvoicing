using VendorInvoicing.Entities;

namespace VendorInvoicing.Models
{
    public class VendorInvoices
    {
        public Vendor? Vendor { get; set; }
        public List<InvoiceLineItem>? InvoiceLineItems { get; set; }
    }
}
