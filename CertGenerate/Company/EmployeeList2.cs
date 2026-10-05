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
using Model;
using CertGenerate.Extensions;
using Service.Employee;
using DevExpress.XtraReports;

namespace CertGenerate.Company
{
    public partial class EmployeeList2 : DevExpress.XtraEditors.XtraUserControl
    {
        Employee _employee;
        vw_Employee _viewEmployee;
        public EmployeeList2()
        {
            InitializeComponent();
            ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            gvEmployee2.InitDefaultGridState();
            Load += async (o, e) =>
            {
                InitButtonActions();
                await LoadDataSource();
            };
        }

        private void InitButtonActions()
        {
            bbiNew.ItemClick += (o, e) =>
            {
                splitContainerControl1.Collapsed = false;
                lcg.ClearDataBindings();
                _employee = new Employee();
                btnSave.Enabled = true;
                BindControls();
            };
            bbiDelete.ItemClick += async (o, e) =>
            {
                await Delete();
            };
            bbiBulkGenerate.ItemClick += (o, e) =>
            {
                //await BulkGenerate();
                BulkGenerateCertificate();
            };

            gvEmployee2.Click += async (o, e) =>
            {
                await GetSelectedEmployee();
                splitContainerControl1.Collapsed = false;
            };

            btnSave.Click += async (o, e) =>
            {
                await Save();
            };
            btnGenerate.Click += (o, e) =>
            {
               // BulkGenerateCertificate();
            };
        }

        private async Task GetSelectedEmployee()
        {
            var id = gvEmployee2.GetRecordId(nameof(Employee.EmployeeID));
            if (id < 0) return;

            var service = new EmployeeService();
            _employee = await service.GetByIdAsync(id) ?? new Employee();
            _viewEmployee = await service.GetViewAsyncById(id) ?? new vw_Employee();

            BindControls();
            btnSave.Enabled = true;
        }

        private void BulkGenerateCertificate()
        {
            var selectedRows = gvEmployee2.GetSelectedRows();
            List<int> ids = new List<int>();
            if(selectedRows != null)
            {
                foreach(var rowHandle in selectedRows)
                {
                    var id = (int)gvEmployee2.GetRowCellValue(rowHandle, nameof(vw_Employee.EmployeeID));
                    ids.Add(id);
                }
            }
            var datasource = gcEmployee2.DataSource as List<vw_Employee>;
            if(datasource != null)
            {
                var employees = datasource.Where(x => ids.Contains(x.EmployeeID)).ToList();
                IReport report = new Certificate(employees);
                ReportLauncher.ShowReport(report);
            }
        }


        private void BindControls()
        {

            lcg.ClearDataBindings();

            var mode = DataSourceUpdateMode.OnPropertyChanged;
            txtFullName.DataBindings.Add("EditValue", _employee, nameof(_employee.FullName), true, mode);
            txtDepartment.DataBindings.Add("EditValue", _employee, nameof(_employee.Department), true, mode);
            txtPosition.DataBindings.Add("EditValue", _employee, nameof(_employee.Position), true, mode);
            cmbStatus.DataBindings.Add("EditValue", _employee, nameof(_employee.Status), true, mode);
            
        }

        private async Task LoadDataSource()
        {
            var service = new EmployeeService();
            var datasource = await service.GetViewAsync();
            gcEmployee2.DataSource = datasource;
        }

        private async Task Delete()
        {
            var id = gvEmployee2.GetRecordId(nameof(Employee.EmployeeID));
            if (id <= 0)
            {
                XtraMessageBox.Show("Please select an employee to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = XtraMessageBox.Show("Are you sure you want to delete this employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var service = new EmployeeService();
                    bool success = await service.DeleteAsync(id);
                    if (success)
                    {
                        XtraMessageBox.Show("Employee successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataSource();
                        splitContainerControl1.Collapsed = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("Failed to delete the employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred while deleting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task Save()
        {
            gvEmployee2.PostEditor();
            gvEmployee2.UpdateCurrentRow();

            if (_employee == null) return;

            try
            {
                var service = new EmployeeService();
                bool success = false;

                if (_employee.EmployeeID == 0)
                {
                    success = await service.InsertAsync(_employee);
                }
                else
                {
                    success = await service.UpdateAsync(_employee);
                }

                if (success)
                {
                    XtraMessageBox.Show("Employee information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataSource();
                    splitContainerControl1.Collapsed = true;
                }
                else
                {
                    XtraMessageBox.Show("Failed to save employee information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        //        var report = new Certificate(new List<Employee> { _employee });
        //        ReportLauncher.ShowReport(report);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        //private async Task BulkGenerate()
        //{
        //    try
        //    {
        //        gvEmployee2.PostEditor();
        //        gvEmployee2.UpdateCurrentRow();

        //        var list = gcEmployee2.DataSource as List<vw_Employee>;
        //        if (list == null || !list.Any())
        //        {
        //            XtraMessageBox.Show(" Walang data na mahanap sa grid.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        var selectedViewEmployees = list.Where(x => x.IsSelected).ToList();

        //        if (!selectedViewEmployees.Any())
        //        {
        //            XtraMessageBox.Show(" Mangyaring pumili muna ng kahit isang empleyado gamit ang checkbox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }

        //        var service = new EmployeeService();
        //        var selectedEmployees = new List<Employee>();

        //        foreach (var viewEmp in selectedViewEmployees)
        //        {
        //            var emp = await service.GetByIdAsync(viewEmp.EmployeeID);
        //            if (emp != null)
        //            {
        //                selectedEmployees.Add(emp);
        //            }
        //        }

        //        var report = new Certificate(selectedEmployees);
        //        ReportLauncher.ShowReport(report);
        //    }
        //    catch (Exception ex)
        //    {
        //        XtraMessageBox.Show($" Nagkaroon ng error sa pag-generate ng certificate: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
    }
}
