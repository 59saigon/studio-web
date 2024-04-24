using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Services;

namespace Studio.API.Business.Domain.CQRS.Commands.Services
{
    public class ServiceUpdateCommand : UpdateCommand<ServiceView>
    {
        public string ServiceTittle { get; set; }

        public string? ServiceDescription { get; set; }

        public string? Type { get; set; }

        public double Price { get; set; }

        public string? Status { get; set; }

        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
