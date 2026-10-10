using CertGenerate;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Employee
{
    public class EventService : GenericService<Event>
    {
        public async Task<List<vw_Events>> GetViewAsync()
        {
            try
            {
                return await _context.vw_Events
                                     .AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<vw_Events> GetViewAsyncById(int id)
        {
            try
            {
                return await _context.vw_Events
                                     .AsNoTracking()
                                     .SingleOrDefaultAsync(x => x.EventsId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
