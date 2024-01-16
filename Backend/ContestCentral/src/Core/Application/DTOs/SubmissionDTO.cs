namespace Application.DTOs
{
    public class SubmissionDTO
    {
        public Guid Id { get; set; }
        public string QuestionId { get; set; } = default!;
        public int Trial { get; set; }
        public int Points { get; set; }
        public Guid? TeamId { get; set; }
        public Guid? UserId { get; set; }
        public Guid ContestId { get; set; }
    }
}
