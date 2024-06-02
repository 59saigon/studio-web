using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models.Locations;

namespace NM.Studio.Domain.CQRS.Commands.Locations
{
    public class CountryUpdateCommand : UpdateCommand<CountryView>
    {
        public string CountryName { get; set; }

        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
