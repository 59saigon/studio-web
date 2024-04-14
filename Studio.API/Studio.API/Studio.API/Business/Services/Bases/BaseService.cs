using AutoMapper;
using Serilog;
using Studio.API.Business.Domain.Contracts.Repositories.Bases;
using Studio.API.Business.Domain.Contracts.Services.Bases;
using Studio.API.Business.Domain.Contracts.UnitOfWorks;
using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Entities.Bases;
using Studio.API.Business.Domain.Models.Base;
using Studio.API.Business.Domain.Models.Messages;
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

        public async Task<MessageView<TView>> CreateOrUpdate<TView>(CreateOrUpdateCommand<TView> createOrUpdateCommand) where TView : BaseView
        {
            // call repo 
            var result = await CreareOrUpdateEntity(createOrUpdateCommand);
            // map 
            var content = _mapper.Map<TEntity, TView>(result);
            var msgViews = AppMessage.GetMessageView<TView>(content);
            // return
            return msgViews;
        }

        private async Task<TEntity> CreareOrUpdateEntity<TView>(CreateOrUpdateCommand<TView> createOrUpdateCommand)
            where TView : BaseView
        {
            TEntity entity;
            if(createOrUpdateCommand is UpdateCommand<TView> updateCommand)
            {
                // Update
                entity = await _baseRepository.GetById(updateCommand.Id);
                if(entity == null)
                {
                    return null;
                }
                _mapper.Map(updateCommand, entity);
                _baseRepository.Update(entity);
            }
            else
            {
                // Create
                entity = _mapper.Map<TEntity>(createOrUpdateCommand);
                if (entity == null)
                {
                    return null;
                }
                entity.Id = Guid.NewGuid();
                _baseRepository.Add(entity);
            }

            var saveChanges = await _unitOfWork.SaveChanges();
            return saveChanges ? entity : default;
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

        public async Task<MessageView<TView>> DeleteById<TView>(Guid id) where TView : BaseView
        {
            // call repo
            var result = await DeleteEntity(id);
            //map
            var content = _mapper.Map<TEntity, TView>(result);
            var msgView = AppMessage.GetMessageView<TView>(content);
            return msgView;
        }

        private async Task<TEntity> DeleteEntity(Guid id)
        {
            TEntity entity;
            entity = await _baseRepository.GetById(id);
            if (entity == null)
            {
                return null;
            }
            _baseRepository.Delete(entity);

            var saveChanges = await _unitOfWork.SaveChanges();
            return saveChanges ? entity : default;
        }


    }
}
