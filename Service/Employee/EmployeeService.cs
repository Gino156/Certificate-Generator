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
    public class EmployeeService : GenericService<Model.Employee>
    {
         public async Task<List<vw_Employee>> GetViewAsync()
        {
            try
            {
                return await _context.vw_Employee
                                     .AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<vw_Employee> GetViewAsyncById(int id)
        {
            try
            {
                return await _context.vw_Employee
                                     .AsNoTracking()
                                     .SingleOrDefaultAsync(x => x.EmployeeID == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
