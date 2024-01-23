using FribergTest.Data.Interface;
using FribergTest.Models;

namespace FribergTest.Data.Repository
{
    public class AdminRepository : IAdmin
    {
        private readonly ApplicationDBContext appDBctx;

        public AdminRepository(ApplicationDBContext appDBctx)
        {
            this.appDBctx = appDBctx;
        }
        public Car GetCarById(int id)
        {
            return appDBctx.Cars.FirstOrDefault(c => c.CarId == id);
        }
        public IEnumerable<Car> GetAllCars()
        {
            return appDBctx.Cars.OrderBy(c => c.Brand);
        }
        public Car AddCar(Car car)
        {
            appDBctx.Add(car);
            appDBctx.SaveChanges();
            return car;
        }
        public Car UpdateCar(Car car)
        {
            appDBctx.Update(car);
            appDBctx.SaveChanges();
            return car;
        }
        public void RemoveCar(Car car)
        {
            appDBctx.Remove(car);
            appDBctx.SaveChanges();
        }

        public Customer GetCustomerById(int id)
        {
            return appDBctx.Customers.FirstOrDefault(c => c.CustomerId == id);
        }
        public IEnumerable<Customer> GetAllCustomers()
        {
            return appDBctx.Customers.OrderBy(c => c.CustomerId);
        }
        public Customer AddCustomer(Customer customer)
        {
            appDBctx.Add(customer);
            appDBctx.SaveChanges();
            return customer;
        }
        public Customer UpdateCustomer(Customer customer)
        {
            appDBctx.Update(customer);
            appDBctx.SaveChanges();
            return customer;
        }
        public void RemoveCustomer(Customer customer)
        {
            appDBctx.Remove(customer);
            appDBctx.SaveChanges();
        }











        public Rent GetRent(int id)
        {
            return appDBctx.Rents.FirstOrDefault(c => c.RentId == id);
        }
        public IEnumerable<Rent> GetRents()
        {
            return appDBctx.Rents.OrderBy(r => r.StartDate);
        }
        public Rent CreateRent(Rent rent)
        {
            if (rent != null)
            {
                appDBctx.Add(rent);
                appDBctx.SaveChanges();
                return rent;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Admin> GetAllAdmins()
        {
            return appDBctx.Admins.OrderBy(c => c.AdminId);
        }

        public Admin GetAdmin(int id)
        {
            return appDBctx.Admins.FirstOrDefault(a => a.AdminId == id);
        }








    }
}
