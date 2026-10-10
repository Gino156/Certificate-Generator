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
using DevExpress.XtraGauges.Core.Customization;
using Model;
using Service.Employee;
using CertGenerate.Helper;

namespace CertGenerate.Company
{
    public partial class EventsEditForm : DevExpress.XtraEditors.XtraForm
    {
        Event _event;
        public EventsEditForm(Event Event)
        {
            InitializeComponent();
            _event = Event;
            BindControls();
            btnSave.Click += async (o, e) =>
            {
                await Save();
            };
            Load += async (o, e) =>
            {
                await LoadEventTypeDataSource();
            };

        }
        private async Task LoadEventTypeDataSource()
        {
            var eve = await new EventTypeService().GetAllAsync();
            var datasource = eve
                .Select(x => new
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
        public void BindControls()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged;
            txtTitle.DataBindings.Add("EditValue", _event, nameof(_event.Title), true, mode);
            dtStartDate.DataBindings.Add("EditValue", _event, nameof(_event.start_date), true, mode);
            dtEndDate.DataBindings.Add("EditValue", _event, nameof(_event.end_date), true, mode);
            sluEventType.DataBindings.Add("EditValue", _event, nameof(_event.EventTypeId), true, mode);
        }

        public async Task Save()
        {
            var service = new EventService();
            bool success = false;

            if (_event.EventsId == 0)
            {
                success = await service.InsertAsync(_event);
            }
            else
            {
                success = await service.UpdateAsync(_event);
            }

            if (success)
            {
                Close();
            }
        }
    }
}