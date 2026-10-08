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
using Model;
using Service.Employee;

namespace CertGenerate.Company
{
    public partial class EventList : DevExpress.XtraEditors.XtraUserControl
    {
        public EventList()
        {
            InitializeComponent();
            ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            gvEvent.InitDefaultGridState();
            Load += async (o, e) =>
            {
                InitButtonActions();
                await LoadDataSource();
            };
        }
        private async Task LoadDataSource()
        {
            var service = new EventService();
            var datasource = await service.GetViewAsync();
            gcEvent.DataSource = datasource;
        }

        private void InitButtonActions()
        {
            bbiNew.ItemClick += async (o, e) => //New Event
            {
                await AddEvent();
            };
            bbiDelete.ItemClick += async (o, e) => //Delete Event
            {
                await Delete();
            };
            bbiEdit.ItemClick += async (o, e) => //Edit Event
            {
                await EditEvent();
            };

            gvEvent.FocusedRowChanged += async (o, e) =>
            {
                splitContainerControl1.Collapsed = false;
                await LoadCalendarAsync("Birthdays");
            };
            gvEvent.DoubleClick += async (o, e) =>
           {
               await EditEvent();
           };

        }
        private async Task LoadCalendarAsync(string calendarType)
        {
            if (schedulerDataStorage1 == null || schedulerDataStorage1.Appointments == null) return;

            var now = DateTime.Now;

            if (schedulerControl1 != null)
            {
                var firstDay = new DateTime(now.Year, now.Month, 1);
                var lastDay = firstDay.AddMonths(1).AddDays(-1);

                schedulerControl1.Start = firstDay;
                schedulerControl1.LimitInterval.Start = firstDay;
                schedulerControl1.LimitInterval.End = lastDay.AddDays(1);
            }

            switch (calendarType)
            {
                case "Birthdays":
                    var service = new EmployeeService();
                    var employeeList = await service.GetViewAsync();

                    if (employeeList == null) return;
                    var birthdayAppointments = employeeList
                        .Where(emp => emp != null && emp.BirthDate.HasValue)
                        .Select(emp => new
                        {
                            Subject = $"🎂 Happy Birthday {emp.FullName}!",
                            StartDate = new DateTime(now.Year, emp.BirthDate.Value.Month, emp.BirthDate.Value.Day),
                            EndDate = new DateTime(now.Year, emp.BirthDate.Value.Month, emp.BirthDate.Value.Day),
                            AllDay = true,
                            LabelId = 8
                        })
                        .ToList();

                    schedulerDataStorage1.Appointments.DataSource = birthdayAppointments;
                    break;


                default:
                    schedulerDataStorage1.Appointments.DataSource = null;
                    break;

                case "test":
                    break;
            }
        }
        private async Task AddEvent()
        {
            var form = new EventEditForm(new Event());
            form.ShowDialog();
            await LoadDataSource();
        }

        private async Task EditEvent()
        {
            var id = gvEvent.GetRecordId(nameof(Event.EventId));
            var brand = await new EventService().GetByIdAsync(id);
            var form = new EventEditForm(brand);
            form.ShowDialog();
            await LoadDataSource();
        }
        private async Task Delete()
        {
            var id = gvEvent.GetRecordId(nameof(Event.EventId));
            if (id <= 0)
            {
                XtraMessageBox.Show("Please select an event to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = XtraMessageBox.Show("Are you sure you want to delete this event?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var service = new EventService();
                    bool success = await service.DeleteAsync(id);
                    if (success)
                    {
                        XtraMessageBox.Show("Event successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataSource();
                        splitContainerControl1.Collapsed = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("Failed to delete the event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"An error occurred while deleting: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
