using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TeeHub.Api.Models.Domain
{
    public class OrderStatusHistory
    {
        [Key]
        public Guid StatusChangeID { get; set; }

        [ForeignKey("Order")]
        public Guid OrderID { get; set; }

        public string? Status { get; set; }
        public DateTime ChangeDate { get; set; }

        public Order? Order { get; set; }
        public User? ChangedByUser { get; set; }
    }
}