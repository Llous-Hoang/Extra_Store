using Extra_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Extra_Store.Data
{
    public partial class ExtraStoreContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<OrderCart> OrderCarts { get; set; }

        public ExtraStoreContext(DbContextOptions<ExtraStoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Product and ProductType
            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductType)
                .WithMany(pt => pt.Products)
                .HasForeignKey(p => p.ProductTypeId);

            // Account and Invoice
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Invoices)
                .WithOne(i => i.Customer)
                .HasForeignKey(i => i.CustomerId);

            // Account and OrderCart
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Carts)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);

            // Invoice and InvoiceDetail
            modelBuilder.Entity<Invoice>()
                .HasMany(i => i.InvoiceDetails)
                .WithOne(d => d.Invoice)
                .HasForeignKey(d => d.InvoiceId);

            // Product and InvoiceDetail
            modelBuilder.Entity<InvoiceDetail>()
                .HasOne(d => d.Product)
                .WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.ProductId);

            // OrderCart and Product
            modelBuilder.Entity<OrderCart>()
                .HasOne(oc => oc.Product)
                .WithMany(p => p.OrderCarts)
                .HasForeignKey(oc => oc.ProductId);

            // OrderCart and Account
            modelBuilder.Entity<OrderCart>()
                .HasOne(oc => oc.Customer)
                .WithMany(a => a.Carts)
                .HasForeignKey(oc => oc.CustomerId);
        }
    }
}
