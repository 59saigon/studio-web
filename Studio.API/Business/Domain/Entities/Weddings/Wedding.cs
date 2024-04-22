using Studio.API.Business.Domain.Entities.Bases;
using Studio.API.Business.Domain.Entities.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Entities.Weddings
{
    [Table("Wedding")]
    public class Wedding : BaseEntity
    {
        [Column(TypeName = "nvarchar(255)")]
        public string WeddingTittle { get; set; }
        
        [Column(TypeName = "nvarchar(255)")]
        public string? WeddingDescription { get; set; }
        
        public string? Status { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }   

        public virtual IList<Event> Events { get; set; }
    }
}
