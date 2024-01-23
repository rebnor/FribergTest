using System.ComponentModel.DataAnnotations;

namespace FribergTest.Models
{
    public class Rent
    {
        public int RentId { get; set; }
        public Customer Customer { get; set; }
        public Car Car { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime RenturnDate { get; set; }
    }
}
