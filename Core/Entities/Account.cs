using Core.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Core.Entities
{
    public class Account : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; } // Nullable in case DOB is not provided

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(20)]
        public string IdentityCard { get; set; }

        [StringLength(255)]
        public string Image { get; set; } // Path to the image

        public DateTime RegisterDate { get; set; } // Date of registration

        public string Status { get; set; } // Could be an enum or a string, based on your needs

        // Gender can be an enum for better type safety
        public string Gender { get; set; }


        public Guid RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}