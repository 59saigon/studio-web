using Studio.API.Business.Domain.Models.Base;
using Studio.API.Business.Domain.Models.Services;

namespace Studio.API.Business.Domain.Models.Events
{
    public class EventXServiceView : BaseView
    {
        public Guid? EventId { get; set; }

        public Guid? ServiceId { get; set; }

    }
}
