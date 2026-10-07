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
        public async Task<List<vw_Event>> GetViewAsync()
        {
            try
            {
                return await _context.vw_Event
                                     .AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
