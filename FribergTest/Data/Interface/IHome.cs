using FribergTest.Models;
using FribergTest.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace FribergTest.Data.Interface
{
    public interface IHome
    {

        public IEnumerable<Car> GetRentableCars();
        public Car GetCarById(int id);
        public Customer GetCustomerById(int id);
        public Customer GetCustomerByEmail(string email);
        public Admin GetAdminByUsername(string username);
        public Customer AddCustomer(Customer customer);

        public Rent AddRent(Rent rent);
        public Rent GetRentById(int id);

        IEnumerable<Car> GetAllCars();
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Rent> GetRents();


    }
}
