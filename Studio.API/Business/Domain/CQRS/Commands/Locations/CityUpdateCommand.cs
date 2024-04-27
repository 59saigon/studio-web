using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Locations;

namespace Studio.API.Business.Domain.CQRS.Commands.Locations
{
    public class CityUpdateCommand : UpdateCommand<CityView>
    {
        public string CityName { get; set; }

        public Guid CountryId { get; set; }

        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
