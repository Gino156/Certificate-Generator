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
    public class BirthdayDetailService : GenericService<BirthdayDetail>
    {
        public async Task<BirthdayDetail> GetByEventIdAsync(int eventsId)
        {
            try
            {
                return await _context.BirthdayDetails
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