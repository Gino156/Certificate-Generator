using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using Model;

namespace CertGenerate.Company.Reports
{
    public partial class LateNotice : DevExpress.XtraReports.UI.XtraReport
    {
        List<vw_Employees> _employee;

        public LateNotice(List<vw_Employees> employees)
        {
            InitializeComponent();
            _employee = employees;
            DataSource = _employee;
        }
    }
}
