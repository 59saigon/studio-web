using Studio.API.Business.Domain.Results.Bases;
using Studio.API.Business.Domain.Results.Events;

namespace Studio.API.Business.Domain.Results.Weddings
{
    public class WeddingResult : BaseResult
    {
        public string WeddingTittle { get; set; }
        
        public string? WeddingDescription { get; set; }
        
        public string? Status { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }   

        public IList<EventResult> Events { get; set; }
    }
}
