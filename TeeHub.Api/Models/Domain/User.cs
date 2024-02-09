namespace TeeHub.Api.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string? userName { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }
        
        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        Admin,
        Regular,
    }
}
