using System.ComponentModel.DataAnnotations;

namespace FribergTest.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string AdminUserName { get; set; }
        public string AdminEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }

    }
}
