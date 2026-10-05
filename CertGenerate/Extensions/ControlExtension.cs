using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertGenerate.Extensions
{
    public static class ControlExtension
    {
        /// <summary>
        /// Recursively clears DataBindings for all controls hosted inside a DevExpress LayoutGroup.
        /// </summary>
        public static void ClearDataBindings(this LayoutGroup group)
        {
            if (group == null) return;

            foreach (BaseLayoutItem item in group.Items)
            {
                // If the item hosts a control, clear its bindings
                if (item is LayoutControlItem layoutItem && layoutItem.Control != null)
                {
                    layoutItem.Control.DataBindings.Clear();
                }
                // If the item is a nested group (e.g., TabbedControlGroup or Sub-LayoutControlGroup)
                else if (item is LayoutGroup subGroup)
                {
                    subGroup.ClearDataBindings();
                }
            }
        }
    }
}
