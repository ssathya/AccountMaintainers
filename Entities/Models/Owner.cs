using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Owner
    {
        public Owner()
        {
            Name = "";
            Address = "";
            DateOfBirth = new DateTime(1900, 1, 1);
        }

        [Column("OwnerId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name too long (max 60 characters)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date of Birth required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address too long (max 100 characters)")]
        public string Address { get; set; }
    }
}