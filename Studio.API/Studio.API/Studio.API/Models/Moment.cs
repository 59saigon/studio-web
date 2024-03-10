using System;
using System.Collections.Generic;

namespace Studio.API.Models
{
    public partial class Moment
    {
        public int Id { get; set; }

        public string MomentId { get; set; } = null!;
        public string? Picture { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
