using Microsoft.AspNetCore.Mvc;
using Studio.API.DTOs;
using Studio.API.Models;

namespace Studio.API.Services.Interfaces
{
    public interface I_MomentService
    {
        Task<IEnumerable<MomentDto>> GetMoments();
        Task<bool> CreateMoment(MomentDto momentDto);
        Task<bool> DeleteMoment(Guid id);
        bool IsMomentDtoEmpty(MomentDto momentDto);
    }
}
