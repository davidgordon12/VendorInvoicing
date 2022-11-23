using VendorInvoicing.Services;
using VendorInvoicing.Entities;
using Xunit;
using VendorInvoicing.Data;
using VendorInvoicesTests;

namespace VendorServiceTests
{
    public class VendorServiceTests : IClassFixture<VendorDataFixture>
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        public VendorServiceTests(VendorDataFixture fixture)
            => Fixture = fixture;

        public VendorDataFixture Fixture { get; }

        [Fact]
        public void AddVendor_ShouldCreateVendor()
        {
            // Arrange
            bool expected = true;
            using var context = Fixture.CreateContext();

            VendorService vendorService = new VendorService(context);

            // Act
            bool actual = vendorService.AddVendor(new Vendor
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

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void UpdateVendor_ShouldUpdateVendor()
        {
            // Arrange
            bool expected = true;
            using var context = Fixture.CreateContext();

            VendorService vendorService = new VendorService(context);

            // Act
            bool actual = vendorService.UpdateVendorInformation(new Vendor
            {
                Name = "Kwik-E-Mart",
                Address1 = "Fake Street Rd",
                Address2 = "Backup Address",
                City = "Springfield",
                ProvinceOrState = "Oregon",
                ZipOrPostalCode = "80085",
                VendorPhone = "8008880008",
                VendorContactLastName = "Nahasapeemapetilon",
                VendorContactFirstName = "Apu",
                VendorContactEmail = "apu@KwikEMart.com",
                IsDeleted = false,
                Invoices = Enumerable.Empty<Invoice>().ToList()
            });

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RemoveVendor_ShouldRemoveVendor()
        {
            // Arrange
            bool expected = true;
            using var context = Fixture.CreateContext();

            VendorService vendorService = new VendorService(context);

            // Act
            bool actual = vendorService.RemoveVendor(
                context.Vendors
                .Where(v=>v.VendorContactEmail == "apu@KwikEMart.com")
                .FirstOrDefault()
                .VendorId
            );

            // Assert
            Assert.Equal(expected, actual);
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}