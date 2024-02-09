using System.ComponentModel.DataAnnotations.Schema;

namespace TeeHub.Api.Models.Domain
{
    public class Design
    {
        public int DesignID { get; set; }

        [ForeignKey("User")]
        public Guid? Id { get; set; }

        public string? DesignColor { get; set; }
        public string? DesignText { get; set; }
        public string? Photo { get; set; }
        public string? DesignSize { get; set; }

        // Navigation property to represent the relationship with the User model
        public User? User { get; set; }
    }
}
