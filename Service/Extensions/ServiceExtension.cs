//using DevExpress.XtraEditors;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Service.Extensions
//{
//    public static class ServiceExtension
//    {
//        public static async Task<bool> SaveWithUIAsync<T>(
//            this CertGenerate.GenericService<T> service,
//            object id,
//            T entity,
//            Func<Task> onConflictRefresh = null,
//            string successMessage = "Record saved successfully.") where T : class
//        {
//            try
//            {
//                bool success = await service.SaveAsync(id, entity);
//                if (success)
//                {
//                    XtraMessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//                return success;
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                XtraMessageBox.Show(
//                    "This record was modified or deleted by another user.\nYour changes were not saved.",
//                    "Concurrency Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning
//                );

//                if (onConflictRefresh != null) await onConflictRefresh();
//                return false;
//            }
//            catch (Exception ex)
//            {
//                XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return false;
//            }
//        }
//    }
//}
