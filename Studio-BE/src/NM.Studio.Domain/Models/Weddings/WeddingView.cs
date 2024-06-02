using NM.Studio.Domain.Models.Base;

namespace NM.Studio.Domain.Models.Weddings
{
    public class WeddingView : BaseView
    {
        public string WeddingTittle { get; set; }
        
        public string? WeddingDescription { get; set; }
        
        public string? Status { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }   

    }
}
