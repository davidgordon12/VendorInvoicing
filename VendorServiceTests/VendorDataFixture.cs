using Microsoft.EntityFrameworkCore;
using VendorInvoicing.Data;
using VendorInvoicing.Entities;

namespace VendorInvoicesTests
{
    public class VendorDataFixture
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentsDGordon3238;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public VendorDataFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Add(
                            new Vendor
                            {
                                Name = "Kwik-E-Mart",
                                Address1 = "Fake Street Rd",
                                Address2 = "Backup Address",
                                City = "Springfield",
                                ProvinceOrState = "Maybe Illinois",
                                ZipOrPostalCode = "80085",
                                VendorPhone = "8008880008",
                                VendorContactLastName = "Nahasapeemapetilon",
                                VendorContactFirstName = "Apu",
                                VendorContactEmail = "apu@KwikEMart.com",
                                IsDeleted = false,
                                Invoices = Enumerable.Empty<Invoice>().ToList()
                            });
                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public VendorDataContext CreateContext()
            => new VendorDataContext(
                new DbContextOptionsBuilder<VendorDataContext>()
                    .UseSqlServer(ConnectionString)
                    .Options);
    }
}