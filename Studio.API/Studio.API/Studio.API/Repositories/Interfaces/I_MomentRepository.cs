using Studio.API.DTOs;
using Studio.API.Models;

namespace Studio.API.Repositories.Interfaces
{
    public interface I_MomentRepository
    {
        Task<ICollection<Moment>> GetMoments();
        Moment GetMoment(string tittle);
        Task<Moment> GetMoment(Guid id);
        //Moment GetMoment(string name);
        //Moment GetMomentTrimToUpper(MomentDto MomentCreate);
        //decimal GetMomentRating(int pokeId);
        bool MomentExists(int pokeId);
        Task<bool> CreateMoment(Moment Moment);
        bool UpdateMoment(int ownerId, int categoryId, Moment Moment);
        Task<bool> DeleteMoment(Moment Moment);
        bool Save();
    }
}
