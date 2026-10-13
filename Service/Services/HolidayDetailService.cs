using CertGenerate;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class HolidayDetailService : GenericService<HolidayDetail>
    {
        public async Task<HolidayDetail> GetByEventIdAsync(int eventsId)
        {
            try
            {
                return await _context.HolidayDetails
                                     .AsNoTracking()
                                     .SingleOrDefaultAsync(x => x.EventsId == eventsId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
