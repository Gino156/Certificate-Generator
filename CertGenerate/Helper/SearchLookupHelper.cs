using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertGenerate.Helper
{
    public static class SearchLookupHelper
    {
        public static void BindSearchLookUp<T>(
           SearchLookUpEdit lookup,
           IEnumerable<T> dataSource,
           string valueMember,
           string displayMember,
           string nullText = "Select an item...")
        {
            // 1. Assign Data
            lookup.Properties.DataSource = dataSource;
            lookup.Properties.ValueMember = valueMember;
            lookup.Properties.DisplayMember = displayMember;
            lookup.Properties.NullText = nullText;

            // 2. Configure Common Behavior
            lookup.Properties.BestFitMode = BestFitMode.BestFit;
            lookup.Properties.PopupFilterMode = PopupFilterMode.Default;

            // 3. Clear existing columns and auto-populate based on the new data source
            lookup.Properties.View.Columns.Clear();
            lookup.Properties.PopulateViewColumns();

            // 4. UI Polish: Hide the ValueMember column (usually an ID) by default
            if (lookup.Properties.View.Columns[valueMember] != null)
            {
                lookup.Properties.View.Columns[valueMember].Visible = false;
            }
        }
    }
}
