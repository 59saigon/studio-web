using Studio.API.Business.Domain.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Models.Locations
{
    public class CityView : BaseView
    {
        public string City_Name { get; set; }
        public Guid Country_Id { get; set; }
    }
}
