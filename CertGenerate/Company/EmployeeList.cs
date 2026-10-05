using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CertGenerate.Extensions;
using Service.Employee;
using CertGenerate.Company1;
using Model;

namespace CertGenerate.Company
{

    /// <summary>
    /// Unused Class/ Single export (Status: Working)
    /// </summary>
    public partial class EmployeeList : DevExpress.XtraEditors.XtraUserControl
    {
        public EmployeeList()
        {
            InitializeComponent();
            ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            gvEmployee.InitDefaultGridState();
            Load += async (o, e) =>
            {
                await LoadDatasource();
            };
            InitButtonActions();
        }

        private async Task LoadDatasource()
        {
            var datasource = await new EmployeeService().GetAllAsync();
            gcEmployee.DataSource = datasource;
        }

        private void InitButtonActions()
        {
            bbiNew.ItemClick += async (o, e) =>
            {
                await AddEmployee();
            };
            gvEmployee.DoubleClick += async (o, e) =>
            {
                await EditEmployee();
            };
        }

        private async Task AddEmployee()
        {
            var form = new EmployeeEditForm(new Employee());
            form.ShowDialog();
            await LoadDatasource();
        }
        private async Task EditEmployee()
        {
            var id = gvEmployee.GetRecordId(nameof(Employee.EmployeeID));
            var employee = await new EmployeeService().GetByIdAsync(id);
            var form = new EmployeeEditForm(employee);
            form.ShowDialog();
            await LoadDatasource();
        }
    }
}
