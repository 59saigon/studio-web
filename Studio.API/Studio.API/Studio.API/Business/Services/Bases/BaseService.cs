using AutoMapper;
using Serilog;
using Studio.API.Business.Domain.Contracts.Repositories.Bases;
using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.Contracts.UnitOfWorks;
using Studio.API.Business.Domain.Entities.Bases;
using Studio.API.Business.Domain.Results.Bases;
using Studio.API.Business.Domain.Results.Messages;
using Studio.API.Business.Domain.Utilities;

namespace Studio.API.Business.Services.Bases
{
    public abstract class BaseService
    {
        
    }
    public abstract class BaseService<TEntity> : BaseService, IBaseService 
        where TEntity : BaseEntity
    {
        protected readonly IMapper _mapper;

        protected readonly IBaseRepository<TEntity> _baseRepository;
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _baseRepository = _unitOfWork.GetRepositoryByEntity<TEntity>();
        }

        public async Task<MessageResults<TResult>> GetAll<TResult>() where TResult : BaseResult
        {
            // call repo
            var results = await _baseRepository.GetAll();
            // map  
            var content = _mapper.Map<IList<TEntity>, List<TResult>>(results);
            var msgResults = AppMessage.GetMessageResults<TResult>(content);
            // return
            return msgResults;
        }

        public async Task<MessageResult<TResult>> GetById<TResult>(Guid id) where TResult : BaseResult
        {
            // call repo
            var result = await _baseRepository.GetById(id);
            // map  
            var content = _mapper.Map<TEntity, TResult>(result);
            var msgResults = AppMessage.GetMessageResult<TResult>(content);
            // return
            return msgResults;
        }

        
    }
}
