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
         public async Task<List<vw_Employees>> GetViewAsync()
        {
            try
            {
                return await _context.vw_Employees
                                     .AsNoTracking()
                                     .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<vw_Employees> GetViewAsyncById(int id)
        {
            try
            {
                return await _context.vw_Employees
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
