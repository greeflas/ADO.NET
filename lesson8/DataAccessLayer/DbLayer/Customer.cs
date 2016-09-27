using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.DbLayer
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        
        public DateTime Birthday { get; set; }
    }
}
