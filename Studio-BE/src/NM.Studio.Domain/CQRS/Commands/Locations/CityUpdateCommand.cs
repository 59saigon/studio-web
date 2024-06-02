using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models.Locations;

namespace NM.Studio.Domain.CQRS.Commands.Locations
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
