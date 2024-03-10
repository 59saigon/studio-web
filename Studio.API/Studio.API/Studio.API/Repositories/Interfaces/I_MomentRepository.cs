using Studio.API.DTOs;
using Studio.API.Models;

namespace Studio.API.Repositories.Interfaces
{
    public interface I_MomentRepository
    {
        ICollection<Moment> GetMoments();
        Moment GetMoment(string tittle);
        //Moment GetMoment(string name);
        //Moment GetMomentTrimToUpper(MomentDto MomentCreate);
        //decimal GetMomentRating(int pokeId);
        bool MomentExists(int pokeId);
        bool CreateMoment(Moment Moment);
        bool UpdateMoment(int ownerId, int categoryId, Moment Moment);
        bool DeleteMoment(Moment Moment);
        bool Save();
    }
}
