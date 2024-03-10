﻿using AutoMapper;
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

        public IActionResult CreateMoment(MomentDto momentDto)
        {
            BadRequestResult bad = new BadRequestResult();
            OkResult ok = new OkResult();
            // map thành moment (fix not yet)
            


            if(momentDto != null)
            {
                Moment moment = _mapper.Map<Moment>(momentDto);
                bool isSuccess = _MomentRepository.CreateMoment(moment);
                if (!isSuccess)
                {
                    return bad;
                }
                return ok;
            }
            return bad;

            
        }



        IActionResult I_MomentService.GetMoments()
        {
            throw new NotImplementedException();
        }
    }
}
