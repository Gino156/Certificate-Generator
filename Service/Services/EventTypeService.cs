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
    public class EventTypeService : GenericService<EventType>
    {
        public async Task<List<vw_EventType>> GetViewAsync()
        {
            try
            {
                return await _context.vw_EventType
                                     .AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<vw_EventType> GetViewAsyncById(int id)
        {
            try
            {
                return await _context.vw_EventType
                                     .AsNoTracking()
                                     .SingleOrDefaultAsync(x => x.EventTypeId == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
