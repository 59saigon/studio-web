using Studio.API.Business.Domain.Results.Bases;
using System.ComponentModel.DataAnnotations.Schema;
namespace Studio.API.Business.Domain.Results.Events
{
    public class Event_ServiceResult : BaseResult
    {
        public string Event_Service_Name { get; set; }
        public Guid Event_Id { get; set; }
        public double Price { get; set; }

        public EventResult _Event { get; set; }
    }
}
