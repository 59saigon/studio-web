using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Studio.API.DTOs;
using Studio.API.Models;
using Studio.API.Repositories.Interfaces;
using Studio.API.Services.Interfaces;

namespace Studio.API.Services.Classes
{
    public class MomentService : I_MomentService
    {
        private readonly I_MomentRepository _MomentRepository;
        private readonly I_UserRepository _UserRepository;
        private readonly IMapper _mapper;

        public MomentService(I_MomentRepository momentRepository, I_UserRepository userRepository, IMapper mapper)
        {
            _MomentRepository = momentRepository;
            _UserRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateMoment(MomentDto momentDto)
        {
            try
            {
                Moment moment = _mapper.Map<Moment>(momentDto);
                bool isSuccess = await _MomentRepository.CreateMoment(moment);
                return isSuccess;
            } catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteMoment(Guid id)
        {
            // get object from Guid id
            
            try
            {
                Moment moment = await _MomentRepository.GetMoment(id);
                if(moment == null)
                {
                    return false;
                }
                _MomentRepository.DeleteMoment(moment);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<MomentDto>> GetMoments()
        {
            List<MomentDto> _list_momentDto =  _mapper.Map<List<MomentDto>>( await _MomentRepository.GetMoments());
            return _list_momentDto;
        }

        public bool IsMomentDtoEmpty(MomentDto momentDto)
        {
            // Kiểm tra Picture
            if (string.IsNullOrEmpty(momentDto.Picture))
                return true;

            // Kiểm tra Date
            // Không cần kiểm tra vì Date là kiểu dữ liệu nguyên thủy (primitive) không thể rỗng

            // Kiểm tra Title
            if (string.IsNullOrEmpty(momentDto.Title))
                return true;

            // Kiểm tra Content
            if (string.IsNullOrEmpty(momentDto.Content))
                return true;

            // Kiểm tra UserId
            if (momentDto.UserId == Guid.Empty)
                return true;

            // Kiểm tra CreatedBy
            if (string.IsNullOrEmpty(momentDto.CreatedBy))
                return true;

            // Không cần kiểm tra CreatedDate vì nó là một kiểu dữ liệu nguyên thủy không thể rỗng

            return false; // Không rỗng
        }
    }
}
