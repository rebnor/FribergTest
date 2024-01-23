using FribergTest.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergTest.ViewModels
{
    public class RentCustomerCarViewModel
    {
        public int Id { get; set; }
        public Rent Rent{ get; set; }
        public Customer Customer { get; set; }
        public Car Car { get; set; }

    }
}
