using FribergTest.Models;

namespace FribergTest.Data.Interface
{
    public interface IRent
    {
        public Rent AddRent(Car car, Customer customer);

    }
}
