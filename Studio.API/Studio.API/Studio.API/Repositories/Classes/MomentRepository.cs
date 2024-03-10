using Studio.API.Context;
using Studio.API.Models;
using Studio.API.Repositories.Interfaces;

namespace Studio.API.Repositories.Classes
{
    public class MomentRepository : I_MomentRepository
    {
        public bool CreateMoment(Moment moment)
        {
            try
            {
                using (var _context = new StudioContext())
                {
                    _context.Moments.Add(moment);
                    _context.SaveChanges();
                    return true;
                }
            } catch (Exception ex)
            {
                
            }
            return false;
        }

        public bool DeleteMoment(Moment Moment)
        {
            throw new NotImplementedException();
        }

        public Moment GetMoment(string tittle)
        {
            throw new NotImplementedException();
        }

        public ICollection<Moment> GetMoments()
        {
            List<Moment> list = new List<Moment>(); 
            try
            {
                using (var _context = new StudioContext())
                {
                    list = _context.Moments.ToList();
                    if(list.Count > 0)
                    {
                        return list;
                    }
                   
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public bool MomentExists(int pokeId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateMoment(int ownerId, int categoryId, Moment Moment)
        {
            throw new NotImplementedException();
        }
    }
}
