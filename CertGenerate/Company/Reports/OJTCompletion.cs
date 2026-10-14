using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Model;
using System.Collections.Generic;

namespace CertGenerate.Company.Reports
{
    public partial class OJTCompletion : DevExpress.XtraReports.UI.XtraReport
    {
        List<vw_Employees> _employee;

        public OJTCompletion(List<vw_Employees> employees)
        {
            InitializeComponent();
            _employee = employees;
            DataSource = _employee;
        }

    }
}
