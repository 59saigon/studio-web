using Microsoft.AspNetCore.Mvc;
using Studio.API.DTOs;
using Studio.API.Models;

namespace Studio.API.Services.Interfaces
{
    public interface I_MomentService
    {
        IEnumerable<MomentDto> GetMoments();
        bool CreateMoment(MomentDto momentDto);
    }
}
