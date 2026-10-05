using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Service.Employee;
using Model;
using DevExpress.XtraReports;
using CertGenerate.Company;
using CertGenerate.Extensions;

namespace CertGenerate.Company1
{
    public partial class EmployeeEditForm : DevExpress.XtraEditors.XtraForm
    {
        Employee _employee;
        public EmployeeEditForm(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            BindControls();
            btnSave.Click += async (o, e) =>
            {
                await Save();
            };
            btnGenerate.Click += (o, e) =>
            {
                //GenerateCert();
            };
        }

        private void BindControls()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged;
            txtFullName.DataBindings.Add("EditValue", _employee, nameof(_employee.FullName), true, mode);
            txtDepartment.DataBindings.Add("EditValue", _employee, nameof(_employee.Department), true, mode);
            txtPosition.DataBindings.Add("EditValue", _employee, nameof(_employee.Position), true, mode);
            cmbStatus.DataBindings.Add("EditValue", _employee, nameof(_employee.Status), true, mode);
        }

        private async Task Save()
        {
            bool isSuccess;
            if (_employee.EmployeeID == 0)
            {
                isSuccess = await new EmployeeService().InsertAsync(_employee);
            }
            else
            {
                isSuccess = await new EmployeeService().UpdateAsync(_employee);
            }

            if (isSuccess)
            {
                Close();
            }
        }

        //private void GenerateCert()
        //{
        //    try
        //    {
        //        if (_employee == null)
        //        {
        //            XtraMessageBox.Show("No items found to generate report.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        var report = new Certificate(new List<Employee> {_employee});
        //        ReportLauncher.ShowReport(report);
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
    }
}