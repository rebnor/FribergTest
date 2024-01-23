using FribergTest.Data.Interface;
using FribergTest.Models;
using FribergTest.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FribergTest.Data.Repository
{
    public class HomeRepository : IHome
    {
        private readonly ApplicationDBContext appDBctx;

        public HomeRepository(ApplicationDBContext appDBctx)
        {
            this.appDBctx = appDBctx;
        }

        public IEnumerable<Car> GetRentableCars()
        {
            return appDBctx.Cars.Where(c=>c.IsRented == false);
        }

        public Customer GetCustomerByEmail(string email)
        {
            return appDBctx.Customers.FirstOrDefault(c=>c.CustomerEmail == email);
        }

        public Admin GetAdminByUsername(string username)
        {
            return appDBctx.Admins.FirstOrDefault(a=>a.AdminUserName == username);
        }

        public Customer AddCustomer(Customer customer)
        {
            appDBctx.Add(customer);
            appDBctx.SaveChanges();
            return customer;
        }

        public Car GetCarById(int id)
        {
            return appDBctx.Cars.FirstOrDefault(c=>c.CarId == id);
        }

        public Rent AddRent(Rent rent)
        {
            appDBctx.Add(rent);
            appDBctx.SaveChanges();
            return rent; 
        }

        public Customer GetCustomerById(int id)
        {
            return appDBctx.Customers.FirstOrDefault(c=>c.CustomerId == id);
        }

        public Rent GetRentById(int id)
        {
            return appDBctx.Rents.FirstOrDefault(r=>r.RentId == id);
        }


        public IEnumerable<Car> GetAllCars()
        {
            return appDBctx.Cars.OrderBy(c => c.Brand);
        }


        public IEnumerable<Customer> GetAllCustomers()
        {
            return appDBctx.Customers.OrderBy(c => c.CustomerId);
        }
        public IEnumerable<Rent> GetRents()
        {
            return appDBctx.Rents.OrderBy(r => r.StartDate);
        }



    }
}
