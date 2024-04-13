using Studio.API.Business.Domain.Entities.Weddings.Events;
using Studio.API.Business.Domain.Results.Bases;
using Studio.API.Business.Domain.Results.Weddings.Events;

namespace Studio.API.Business.Domain.Results.Weddings
{
    public class WeddingResult : BaseResult
    {
        public string Wedding_Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public IList<EventResult> Events { get; set; }
    }
}
