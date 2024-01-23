using FribergTest.Models;
using Microsoft.EntityFrameworkCore;
using FribergTest.ViewModels;

namespace FribergTest.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Rent> Rents { get; set; }
        public DbSet<RentCustomerCarViewModel> RentCustomerCarViewModels { get; set; }
    }
}
