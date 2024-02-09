namespace TeeHub.Api.Models.Domain
{
    public class Cart
    {
        public Guid CartID { get; set; }
        public int Quantity { get; set; }

        public User? User { get; set; }
        public Design? Design { get; set; }
    }
} 