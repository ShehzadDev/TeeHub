namespace TeeHub.Api.Models.Domain
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public int StarsCount { get; set; } // Should be between 1 and 5
        public string? FeedbackMessage { get; set; }
        public DateTime FeedbackDate { get; set; }

        public User? User { get; set; }
    }
}