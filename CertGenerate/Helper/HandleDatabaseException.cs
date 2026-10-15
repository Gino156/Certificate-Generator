using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CertGenerate.Helper
{
    public static class HandleDatabaseException
    {
        public static void HandleDatabaseExc(Exception ex)
        {
            var innerMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;

            if (innerMessage.Contains("REFERENCE constraint") || innerMessage.Contains("FK_"))
            {
                XtraMessageBox.Show("Cannot delete this record because it is referenced by other data.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                XtraMessageBox.Show($"An error occurred: {innerMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
