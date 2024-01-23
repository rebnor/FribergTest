using FribergTest.Models;

namespace FribergTest.Data.Interface
{
    public interface ICustomer
    {
        public Customer GetCustumer(int id);
        public Customer UpdateCustomer(Customer customer);
        public IEnumerable<Customer> GetCustomerAsEnumerable(int id);
        public IEnumerable<Car> GetRentableCars();
        public Car GetCarById(int id);
        public IEnumerable<Rent> GetRentHistory(int customerId);

        //public List<Car> RentedCars(int customerId);
        //public Rent RentCar(Rent rent, Customer customer, int carId);

    }
}
