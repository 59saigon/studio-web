using Studio.API.Business.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Models.Locations
{
    public class CityView : BaseView
    {
        public string CityName { get; set; }
        
        public Guid CountryId { get; set; }
    }
}
