using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Entities.Base;

namespace Core.Entities
{
    public class Ticket : BaseEntity
    {
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } // Price of the ticket

        [Required]
        public int TicketType { get; set; }

        [ForeignKey(nameof(Invoice))]
        public Guid InvoiceId { get; set; } // Foreign key referencing Invoice

        public virtual Invoice Invoice { get; set; } // Navigation property to Invoice
    }
}