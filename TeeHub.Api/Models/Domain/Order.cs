namespace TeeHub.Api.Models.Domain
{
    public class Order
    {
        public Guid OrderID { get; set; }
        public DateTime OrderDate { get; set; }

        public User? User { get; set; }
    }

}