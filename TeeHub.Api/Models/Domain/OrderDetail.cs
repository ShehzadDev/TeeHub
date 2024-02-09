using System.ComponentModel.DataAnnotations.Schema;

namespace TeeHub.Api.Models.Domain
{
    public class OrderDetail
    {
        public Guid OrderDetailID { get; set; }
        public int Quantity { get; set; }

        public Order? Order { get; set; }
        public Design? Design { get; set; }
    }
}