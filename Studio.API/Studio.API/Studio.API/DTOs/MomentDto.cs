namespace Studio.API.DTOs
{
    public class MomentDto
    {
        public string? Picture { get; set; }
     
        
        public DateTime Date { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
