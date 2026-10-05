using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertGenerate.Extensions
{
    public static class GridExtension
    {
        public static void InitDefaultGridState(this GridView grid)
        {
            grid.OptionsBehavior.ReadOnly = true;
            grid.OptionsBehavior.Editable = false;
            grid.OptionsBehavior.AutoExpandAllGroups = true;
            grid.OptionsSelection.EnableAppearanceFocusedRow = false;
        }

        public static int GetRecordId(this GridView gridview, string columnName)
        {
            int id = -1;
            try
            {
                if (columnName.Length > 0)
                {
                    id = (int)gridview.GetRowCellValue(gridview.FocusedRowHandle, columnName);
                }
                return id;
            }
            catch (Exception)
            {
                return id;
            }
        }
    }
}
