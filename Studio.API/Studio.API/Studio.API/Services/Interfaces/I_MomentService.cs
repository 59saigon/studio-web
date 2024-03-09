using Microsoft.AspNetCore.Mvc;
using Studio.API.DTOs;
using Studio.API.Models;

namespace Studio.API.Services.Interfaces
{
    public interface I_MomentService
    {
        IActionResult GetMoments();
        IActionResult CreateMoment(MomentDto momentDto);
    }
}
