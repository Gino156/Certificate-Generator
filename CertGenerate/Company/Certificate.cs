using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Model;
using System.Collections.Generic;

namespace CertGenerate.Company
{
    public partial class Certificate : DevExpress.XtraReports.UI.XtraReport
    {
        List<vw_Employee> _employee;

        public Certificate(List<vw_Employee> employees)
        {
            InitializeComponent();
            _employee = employees;
            DataSource = _employee;
        }
    }
}