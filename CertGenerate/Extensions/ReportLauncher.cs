using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertGenerate.Extensions
{
    public static class ReportLauncher
    {
        public static void ShowReport(IReport report)
        {
            try
            {
                ReportPrintTool rpt = new ReportPrintTool(report)
                {
                    AutoShowParametersPanel = true
                };
                rpt.ShowRibbonPreviewDialog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
