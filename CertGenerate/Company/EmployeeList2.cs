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
using CertGenerate.Company.Reports;
using DevExpress.XtraEditors.Filtering.Templates;

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
            bbiNew.ItemClick += (o, e) => //New Employee
            {
                splitContainerControl1.Collapsed = false;
                lcg.ClearDataBindings();
                _employee = new Employee();
                btnSave.Enabled = true;
                BindControls();
            };
            bbiDelete.ItemClick += async (o, e) => //Delete Employee
            {
                await Delete();
            };
            bbiBulkGenerate.ItemClick += (o, e) => //Employee of the Month
            {
                GenerateReport("Employee of the Month");
            };
            bbiFiveYears.ItemClick += (o, e) => //5 Years Tenure
            {
                GenerateReport("5 Years Tenurity");
            };
            barListItem1.ListItemClick += (o, e) => //Dropdown Template
            {
                string selected = barListItem1.Strings[e.Index];
                GenerateReport(selected);
            };

            gvEmployee2.Click += async (o, e) => //Click Employee
            {
                await GetSelectedEmployee();
                splitContainerControl1.Collapsed = false;
            };

            btnSave.Click += async (o, e) => //Save Employee
            {
                await Save();
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

        private void GenerateReport(string reportType) //Generate Multiple Report
        {
            var employees = gvEmployee2.GetSelectedRows()?
            .Select(rowHandle => gvEmployee2.GetRow(rowHandle) as vw_Employee)
            .Where(emp => emp != null)
            .ToList();

            if (employees == null || employees.Count == 0) return;
            switch (reportType)
            {
                case "Employee of the Month":
                    ReportLauncher.ShowReport(new Certificate(employees));
                    break;

                case "5 Years Tenurity":
                    var eligibleEmployees = employees
                        .Where(emp => emp.HireDate != null && emp.HireDate.Value <= DateTime.Today.AddYears(-5))
                        .ToList();
                    if (eligibleEmployees.Count > 0)
                    {
                        ReportLauncher.ShowReport(new FiveYearsTenure(eligibleEmployees));
                    }
                    break;

                case "OJT Completion":
                    var onlyOJT = employees
                        .Where(emp => emp.IsOJT == true)
                        .ToList();
                    if(onlyOJT.Count > 0)
                    {
                        ReportLauncher.ShowReport(new OJTCompletion(onlyOJT));
                    }
                    break;

                case "Late Notice":
                    ReportLauncher.ShowReport(new LateNotice(employees));
                    break;

                case "Absent Notice":
                    ReportLauncher.ShowReport(new AbsentNotice(employees));
                    break;

                case "Complete Attendance":
                    //ReportLauncher.ShowReport(new CompleteAttendance(employees));
                    break;


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
            dtHireDate.DataBindings.Add("EditValue", _employee, nameof(_employee.HireDate), true, mode);
            tsOJT.DataBindings.Add("EditValue", _employee, nameof(_employee.IsOJT), true, mode);
            dtBirthDate.DataBindings.Add("EditValue", _employee, nameof(_employee.BirthDate), true, mode);
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

    }
}
