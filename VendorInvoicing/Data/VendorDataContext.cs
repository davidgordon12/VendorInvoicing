using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.IO;
using VendorInvoicing.Entities;

namespace VendorInvoicing.Data
{
    public class VendorDataContext : DbContext
    {
        public VendorDataContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLineItem> InvoiceItems { get; set; }
        public DbSet<PaymentTerms> PaymentTerms { get; set; }
    }
}
