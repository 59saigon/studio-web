using MediatR;
using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Base;
using Studio.API.Business.Domain.Models.Messages;
using Studio.API.Business.Domain.Models.Weddings;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Weddings;

namespace Studio.API.Business.Domain.CQRS.Commands.Weddings
{
    public class WeddingUpdateCommand : UpdateCommand<WeddingView>
    {
        public string WeddingTittle { get; set; }
        
        public string? WeddingDescription { get; set; }
        
        public string? Status { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }   

        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
