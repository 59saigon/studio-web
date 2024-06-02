using AutoMapper;
using Serilog;
using NM.Studio.Domain.Contracts.Repositories.Weddings;
using NM.Studio.Domain.Contracts.Services.Weddings;
using NM.Studio.Domain.Contracts.UnitOfWorks;
using NM.Studio.Domain.CQRS.Queries.Weddings;
using NM.Studio.Domain.Entities.Weddings;
using NM.Studio.Domain.Results.Messages;
using NM.Studio.Domain.Results.Weddings;
using NM.Studio.Services.Bases;

namespace NM.Studio.Services.Weddings
{
    public class WeddingService : BaseService<Wedding>, IWeddingService
    {
        private readonly IWeddingRepository _weddingRepository;

        public WeddingService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _weddingRepository = _unitOfWork.WeddingRepository;
        }

    }
}
