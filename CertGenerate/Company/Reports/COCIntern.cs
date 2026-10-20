using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Model;
using System.Collections.Generic;

namespace CertGenerate.Company.Reports
{
    public partial class COCIntern : DevExpress.XtraReports.UI.XtraReport
    {
        List<vw_Employees> _employee;

        public COCIntern(List<vw_Employees> employees)
        {
            InitializeComponent();
            _employee = employees;
            DataSource = _employee;
        }

    }
}
