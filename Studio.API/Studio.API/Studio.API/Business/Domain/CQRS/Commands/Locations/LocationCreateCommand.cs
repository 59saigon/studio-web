using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Locations;

namespace Studio.API.Business.Domain.CQRS.Commands.Locations
{
    public class LocationCreateCommand : CreateCommand<LocationView>
    {
        public string LocationName { get; set; }
        public Guid CityId { get; set; }

        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
