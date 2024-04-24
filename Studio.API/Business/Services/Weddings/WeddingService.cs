using AutoMapper;
using Serilog;
using Studio.API.Business.Domain.Contracts.Repositories.Weddings;
using Studio.API.Business.Domain.Contracts.Services.Weddings;
using Studio.API.Business.Domain.Contracts.UnitOfWorks;
using Studio.API.Business.Domain.CQRS.Queries.Weddings;
using Studio.API.Business.Domain.Entities.Weddings;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Results.Weddings;
using Studio.API.Business.Services.Bases;

namespace Studio.API.Business.Services.Weddings
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
