using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.DbLayer
{
    public class Profile
    {
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public User User { get; set; }
    }
}
