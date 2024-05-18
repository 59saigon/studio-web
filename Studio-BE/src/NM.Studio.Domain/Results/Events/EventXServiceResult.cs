using NM.Studio.Domain.Entities.Events;
using NM.Studio.Domain.Entities.Services;
using NM.Studio.Domain.Results.Bases;
using NM.Studio.Domain.Results.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.Results.Events
{
    public class EventXServiceResult : BaseResult
    {
        public Guid? EventId { get; set; }

        public Guid? ServiceId { get; set; }

        public EventResult Event { get; set; }

        public ServiceResult Service { get; set; }
    }
}
