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

        public EventsEditForm(Event Event)
        {
            InitializeComponent();

            _event = Event ?? new Event();

            BindControls();

            btnSave.Click += async (o, e) =>
            {
                await Save();
            };

            Load += async (o, e) =>
            {
                await LoadEventTypeDataSource();
                await LoadHolidayTypeDataSource();
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

        private async Task LoadHolidayTypeDataSource()
        {
            var holidayService = new GenericService<HolidayType>();
            var holidays = await holidayService.GetAllAsync();

            var datasource = holidays.Select(x => new
            {
                x.HolidayTypeId,
                x.HolidayTypeName
            }).ToList();

            SearchLookupHelper.BindSearchLookUp(
                sluHolidayType,
                datasource,
                "HolidayTypeId",
                "HolidayTypeName",
                "Select Holiday Type..."
            );
        }

        public void BindControls()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged;

            txtTitle.DataBindings.Add("EditValue", _event, nameof(_event.Title), true, mode);
            dtStartDate.DataBindings.Add("EditValue", _event, nameof(_event.start_date), true, mode);
            dtEndDate.DataBindings.Add("EditValue", _event, nameof(_event.end_date), true, mode);
            sluEventType.DataBindings.Add("EditValue", _event, nameof(_event.EventTypeId), true, mode);
            sluHolidayType.DataBindings.Add("EditValue", _event, nameof(_event.HolidayTypeId), true, mode);
        }


        public async Task Save()
        {
            if (string.IsNullOrWhiteSpace(_event.Title))
            {
                XtraMessageBox.Show("Please enter an event title.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            int eventTypeId = _event.EventTypeId ?? 0;

            if (eventTypeId == 6)
            {
                _event.HolidayTypeId = null;
            }
            if (eventTypeId != 5)
            {
                _event.HolidayTypeId = null;
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

            if (success)
            {
                XtraMessageBox.Show("Successfully saved!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
            else
            {
                XtraMessageBox.Show("Failed to save event.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}