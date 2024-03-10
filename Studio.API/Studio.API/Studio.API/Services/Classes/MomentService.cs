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

        public bool CreateMoment(MomentDto momentDto)
        {
            Moment moment = _mapper.Map<Moment>(momentDto);
            bool isSuccess = _MomentRepository.CreateMoment(moment);
            return isSuccess;
        }

        public IEnumerable<MomentDto> GetMoments()
        {
            List<MomentDto> _list_momentDto = _mapper.Map<List<MomentDto>>(_MomentRepository.GetMoments());
            return _list_momentDto;
        }
    }
}
