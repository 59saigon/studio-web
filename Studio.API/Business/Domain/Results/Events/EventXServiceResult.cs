using Studio.API.Business.Domain.Entities.Events;
using Studio.API.Business.Domain.Entities.Services;
using Studio.API.Business.Domain.Results.Bases;
using Studio.API.Business.Domain.Results.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Results.Events
{
    public class EventXServiceResult : BaseResult
    {
        public Guid? EventId { get; set; }

        public Guid? ServiceId { get; set; }

        public EventResult Event { get; set; }

        public ServiceResult Service { get; set; }
    }
}
