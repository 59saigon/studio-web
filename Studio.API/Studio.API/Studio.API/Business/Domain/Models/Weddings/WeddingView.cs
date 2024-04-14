using Studio.API.Business.Domain.Models.Base;

namespace Studio.API.Business.Domain.Models.Weddings
{
    public class WeddingView : BaseView
    {
        public string Wedding_Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
