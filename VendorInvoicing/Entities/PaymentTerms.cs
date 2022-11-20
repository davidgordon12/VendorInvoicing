namespace VendorInvoicing.Entities
{
    public class PaymentTerms
    {
        public int PaymentTermsId { get; set; }

        public string Description { get; set; } = null!;

        public int DueDays { get; set; } = 30;

        // Nav to invoices:
        public ICollection<Invoice>? Invoices { get; set; }
    }
}
