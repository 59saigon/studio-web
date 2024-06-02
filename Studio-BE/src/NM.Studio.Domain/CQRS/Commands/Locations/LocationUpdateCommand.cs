using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Entities.Locations;
using NM.Studio.Domain.Models.Locations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.CQRS.Commands.Locations
{
    public class LocationUpdateCommand : UpdateCommand<LocationView>
    {
        public string LocationName { get; set; }
        public Guid CityId { get; set; }

        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
