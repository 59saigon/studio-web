using Microsoft.EntityFrameworkCore;
using Studio.API.Context;
using Studio.API.Models;
using Studio.API.Repositories.Interfaces;
using System.Collections.Generic;

namespace Studio.API.Repositories.Classes
{
    public class MomentRepository : I_MomentRepository
    {
        public async Task<bool> CreateMoment(Moment moment)
        {
            try
            {
                using (var _context = new StudioContext())
                {
                    await _context.Moments.AddAsync(moment);
                    await _context.SaveChangesAsync();
                    return true;
                }   
            } catch (Exception ex)
            {
                
            }
            return false;
        }

        public Task<bool> DeleteMoment(Moment Moment)
        {
            throw new NotImplementedException();
        }

        public Moment GetMoment(string tittle)
        {
            throw new NotImplementedException();
        }

        public async Task<Moment> GetMoment(Guid id)
        {
            try
            {
                using (var _context = new StudioContext())
                {
                    return await _context.Moments.Where(p=>p.Equals(id)).SingleOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<ICollection<Moment>> GetMoments()
        {
            List<Moment> list =  new List<Moment>(); 
            try
            {
                using (var _context = new StudioContext())
                {
                    list = await _context.Moments.ToListAsync();
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
