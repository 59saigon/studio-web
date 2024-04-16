using Studio.API.Business.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Models.Events
{
    public class Event_ServiceView : BaseView
    {
        public string Event_Service_Name { get; set; }
        public Guid Event_Id { get; set; }
        public double Price { get; set; }
    }
}
