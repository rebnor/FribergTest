using FribergTest.Models;

namespace FribergTest.Data.Interface
{
    public interface IAdmin
    {
        IEnumerable<Car> GetAllCars();
        Car GetCarById(int id);
        Car AddCar(Car car);
        Car UpdateCar(Car car);
        void RemoveCar(Car car);

        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
        void RemoveCustomer(Customer customer);


        IEnumerable<Rent> GetRents();
        Rent GetRent(int id);
        Rent CreateRent(Rent rent);

        IEnumerable<Admin> GetAllAdmins();
        Admin GetAdmin(int id);
        //Admin GetAdmin(int id);
        //Admin FindAdmin(Admin admin);




    }
}
