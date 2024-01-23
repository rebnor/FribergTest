using FribergTest.Data.Interface;
using FribergTest.Models;

namespace FribergTest.Data.Repository
{
    public class RentRepository : IRent
    {
        public Rent AddRent(Car car, Customer customer)
        {
            Rent rent = new Rent();
            rent.Car = car;
            rent.Customer = customer;   
            return rent;
        }
    }
}
