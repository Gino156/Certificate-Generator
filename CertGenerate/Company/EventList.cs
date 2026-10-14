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
            gvEventType.InitDefaultGridState();

            Load += async (o, e) =>
            {
                InitButtonActions();
                await LoadDataSource();
                await LoadEventTypeDataSource();
                await LoadCalendarAsync("Default");
            };
        }

        private async Task LoadDataSource() //Event
        {
            var eve = new EventService();
            var datasource = await eve.GetViewAsync();
            gcEvents.DataSource = datasource;
        }

        private async Task LoadEventTypeDataSource() //Event Type
        {
            var eventType = new EventTypeService();
            var datasource = await eventType.GetViewAsync();
            gcEventType.DataSource = datasource;
        }

        private void InitButtonActions()
        {
            bbiNew.ItemClick += async (o, e) => //New Event Type
            {
                await AddEventType();
            };
            bbiDelete.ItemClick += async (o, e) => //Delete Event Type
            {
                await DeleteEventType();
            };
            bbiEdit.ItemClick += async (o, e) => //Edit Event Type
            {
                await EditEventType();
            };

            bbiNewEvent.ItemClick += async (o, e) => //New Event
            {
                await AddEvent();
            };
            bbiDeleteEvent.ItemClick += async (o, e) => //Delete Event
            {
                await DeleteEvent();
            };
            bbiEditEvent.ItemClick += async (o, e) => //Edit Event
            {
                await EditEvent();
            };

            gvEventType.DoubleClick += async (o, e) =>
            {
                await EditEventType();
            };
            gvEvents.DoubleClick += async (o, e) =>
            {
                await EditEvent();
            };
        }

        private async Task LoadCalendarAsync(string calendarType)
        {
            if (schedulerDataStorage1?.Appointments == null) return;

            var now = DateTime.Now;

            if (schedulerControl1 != null)
            {
                var firstDay = new DateTime(now.Year, now.Month, 1);
                schedulerControl1.Start = firstDay;
            }

            try
            {
                var service = new EmployeeService();
                var employeeList = await service.GetViewAsync();

                if (employeeList == null) return;

                var birthdayAppointments = employeeList
                    .Where(emp => emp != null && emp.BirthDate.HasValue)
                    .Select(emp => new
                    {
                        Subject = $"{emp.FullName}🎂",
                        StartDate = new DateTime(now.Year, emp.BirthDate.Value.Month, emp.BirthDate.Value.Day),
                        EndDate = new DateTime(now.Year, emp.BirthDate.Value.Month, emp.BirthDate.Value.Day),
                        AllDay = true,
                        LabelId = 8
                    })
                    .ToList();

                schedulerDataStorage1.Appointments.DataSource = birthdayAppointments;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Error loading calendar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task AddEventType() //Event Type
        {
            var form = new EventTypeEditForm(new EventType());
            form.ShowDialog();
            await LoadEventTypeDataSource();
        }

        private async Task AddEvent() //Event
        {
            var form = new EventsEditForm(new Event());
            form.ShowDialog();
            await LoadDataSource();
        }

        private async Task EditEventType() //Event Type
        {
            var id = gvEventType.GetRecordId(nameof(EventType.EventTypeId));
            if (id <= 0) return;

            var type = await new EventTypeService().GetByIdAsync(id);
            if (type == null) return;

            var form = new EventTypeEditForm(type);
            form.ShowDialog();
            await LoadEventTypeDataSource();
        }

        private async Task EditEvent() //Event
        {
            var id = gvEvents.GetRecordId(nameof(Event.EventsId));
            if (id <= 0) return;

            var ev = await new EventService().GetByIdAsync(id);
            if (ev == null) return;

            var form = new EventsEditForm(ev);
            form.ShowDialog();
            await LoadDataSource();
        }

        private async Task DeleteEventType() //Event Type
        {
            var id = gvEventType.GetRecordId(nameof(EventType.EventTypeId));
            if (id <= 0)
            {
                XtraMessageBox.Show("Please select an event type to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = XtraMessageBox.Show("Are you sure you want to delete this event type?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                   
                    var eventService = new EventService();
                    var allEvents = await eventService.GetViewAsync(); 

                    bool isUsed = allEvents != null && allEvents.Any(e => e.EventTypeId == id); 

                    if (isUsed)
                    {
                        XtraMessageBox.Show("Cannot delete this Event Type because it is currently being used by existing Events.", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var service = new EventTypeService();
                    bool success = await service.DeleteAsync(id);
                    if (success)
                    {
                        XtraMessageBox.Show("Event Type successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadEventTypeDataSource();
                        splitContainerControl1.Collapsed = true;
                    }
                    else
                    {
                        XtraMessageBox.Show("Failed to delete the event type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Fallback sakaling sumabog sa database (Foreign Key violation exception)
                    var innerMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                    if (innerMessage.Contains("REFERENCE constraint") || innerMessage.Contains("FK_"))
                    {
                        XtraMessageBox.Show("Cannot delete this Event Type because it is referenced by existing events.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        XtraMessageBox.Show($"An error occurred while deleting: {innerMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async Task DeleteEvent() //Event
        {
            var id = gvEvents.GetRecordId(nameof(Event.EventsId));
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
                    }
                    else
                    {
                        XtraMessageBox.Show("Failed to delete the event.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    var innerMessage = ex.InnerException?.InnerException?.Message ?? ex.InnerException?.Message ?? ex.Message;
                    XtraMessageBox.Show($"Detailed Error: {innerMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}