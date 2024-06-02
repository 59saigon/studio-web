using NM.Studio.Domain.Models.Base;
using NM.Studio.Domain.Models.Services;

namespace NM.Studio.Domain.Models.Events
{
    public class EventXServiceView : BaseView
    {
        public Guid? EventId { get; set; }

        public Guid? ServiceId { get; set; }

    }
}
