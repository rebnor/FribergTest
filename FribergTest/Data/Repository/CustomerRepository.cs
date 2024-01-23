using FribergTest.Data.Interface;
using FribergTest.Models;

namespace FribergTest.Data.Repository
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDBContext appDBctx;

        public CustomerRepository(ApplicationDBContext appDBctx)
        {
            this.appDBctx = appDBctx;
        }

        public Car GetCarById(int id)
        {
            return appDBctx.Cars.FirstOrDefault(c=>c.CarId == id);
        }

        public Customer GetCustumer(int id)
        {
            return appDBctx.Customers.FirstOrDefault(c=>c.CustomerId == id);
        }

        public IEnumerable<Customer> GetCustomerAsEnumerable(int id)
        {
            return appDBctx.Customers.Where(c => c.CustomerId == id);
        }

        public IEnumerable<Car> GetRentableCars()
        {
            return appDBctx.Cars.Where(c=>c.IsRented == false);
        }

        public Rent RentCar(Rent rent, Customer customer, int carId)
        {
            rent.Customer = customer;
            rent.Car = appDBctx.Cars.FirstOrDefault(c => c.CarId == carId);
            return rent;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            appDBctx.Update(customer);
            appDBctx.SaveChanges();
            return customer;
        }

        public IEnumerable<Rent> GetRentHistory(int customerId)
        {
            var rents = appDBctx.Rents.Where(r=>r.Customer.CustomerId == customerId);
            return rents;
        }

        //public List<Car> RentedCars(int customerId)
        //{
        //    var customer = appDBctx.Customers.FirstOrDefault(c=>c.CustomerId == customerId);
        //    List<Rent> rent = appDBctx.Rents.Where(r=>r.Customer == customer).ToList();
        //    List<Car> cars = new List<Car>();
        //    foreach (var item in rent)
        //    {
        //        cars.Add(item.Car);
        //    }
        //    return cars;
        //}

        //public Customer UpdateCustomer(Customer customer)
        //{
        //    appDBctx.Update(customer);
        //    appDBctx.SaveChanges();
        //    return customer;
        //}
    }
}
