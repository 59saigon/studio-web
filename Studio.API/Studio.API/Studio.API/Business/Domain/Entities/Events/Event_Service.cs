using Studio.API.Business.Domain.Entities.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Entities.Events
{
    [Table("Event_Service")]
    public class Event_Service : BaseEntity
    {
        public string Event_Service_Name { get; set; }
        [ForeignKey("_Event")]
        public Guid Event_Id { get; set; }
        public double Price { get; set; }

        public virtual Event _Event { get; set; }

    }
}
