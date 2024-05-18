using MediatR;
using NM.Studio.Domain.CQRS.Commands.Base;
using NM.Studio.Domain.Models.Base;
using NM.Studio.Domain.Models.Messages;
using NM.Studio.Domain.Models.Weddings;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results.Weddings;

namespace NM.Studio.Domain.CQRS.Commands.Weddings
{
    public class WeddingCreateCommand : CreateCommand<WeddingView>
    {
        public string WeddingTittle { get; set; }
        
        public string? WeddingDescription { get; set; }
        
        public string? Status { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }   

        public Guid? Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
