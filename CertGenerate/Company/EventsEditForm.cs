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
using Model;
using Service.Employee;
using CertGenerate.Helper;

namespace CertGenerate.Company
{
    public partial class EventsEditForm : DevExpress.XtraEditors.XtraForm
    {
        private Event _event;
        private Employee _employee;

        public EventsEditForm(Event Event)
        {
            InitializeComponent();

            _event = Event ?? new Event();
            _employee = new Employee();

            BindControls();

            sluEventType.EditValueChanged += SluEventType_EditValueChanged;

            btnSave.Click += async (o, e) =>
            {
                await Save();
            };

            Load += async (o, e) =>
            {
                await LoadEventTypeDataSource();
                await LoadEmployeeDataSource();
                LoadHolidayTypeDataSource();

                ToggleFieldVisibility();
            };
        }

        private async Task LoadEventTypeDataSource()
        {
            var eve = await new EventTypeService().GetAllAsync();
            var datasource = eve.Select(x => new
            {
                x.EventTypeId,
                x.EventTypeName
            }).ToList();

            SearchLookupHelper.BindSearchLookUp(
                sluEventType,
                datasource,
                "EventTypeId",
                "EventTypeName",
                "Select Event Type..."
            );
        }

        private async Task LoadEmployeeDataSource()
        {
            var employees = await new EmployeeService().GetAllAsync();
            var datasource = employees.Select(x => new
            {
                x.EmployeeID,
                x.FullName
            }).ToList();

            SearchLookupHelper.BindSearchLookUp(
                sluEmployee,
                datasource,
                "EmployeeID",
                "FullName",
                "Select Employee..."
            );
        }

        private void LoadHolidayTypeDataSource()
        {
            cmbHolidayType.Properties.Items.Clear();
            cmbHolidayType.Properties.Items.Add("Regular Holiday");
            cmbHolidayType.Properties.Items.Add("Special Non-Working Holiday");
            cmbHolidayType.Properties.Items.Add("Special Working Holiday");
        }

        public void BindControls()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged;

            txtTitle.DataBindings.Add("EditValue", _event, nameof(_event.Title), true, mode);
            dtStartDate.DataBindings.Add("EditValue", _event, nameof(_event.start_date), true, mode);
            dtEndDate.DataBindings.Add("EditValue", _event, nameof(_event.end_date), true, mode);
            sluEventType.DataBindings.Add("EditValue", _event, nameof(_event.EventTypeId), true, mode);

            sluEmployee.DataBindings.Add("EditValue", _employee, nameof(_employee.EmployeeID), true, mode);

        }

        private void SluEventType_EditValueChanged(object sender, EventArgs e)
        {
            ToggleFieldVisibility();
        }

        private void ToggleFieldVisibility()
        {
            if (sluEventType.EditValue != null && int.TryParse(sluEventType.EditValue.ToString(), out int eventTypeId))
            {
                if (eventTypeId == 1) // Birthday
                {
                    lciEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciHoliday.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else if (eventTypeId == 5) // Holiday
                {
                    lciHoliday.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    lciEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else if (eventTypeId == 6) // Company
                {
                    lciHoliday.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
                else
                {
                    lciEmployee.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    lciHoliday.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
        }

        public async Task Save()
        {
            if (string.IsNullOrWhiteSpace(_event.Title))
            {
                XtraMessageBox.Show("Please enter an event title.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            int eventTypeId = _event.EventTypeId ?? 0;

            if (eventTypeId == 1 && _employee.EmployeeID == 0)
            {
                XtraMessageBox.Show("Please select an employee for this birthday event.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                sluEmployee.Focus();
                return;
            }

            var eventService = new EventService();
            bool success = false;

            if (_event.EventsId == 0)
            {
                success = await eventService.InsertAsync(_event);
            }
            else
            {
                success = await eventService.UpdateAsync(_event);
            }
        }
    }
}