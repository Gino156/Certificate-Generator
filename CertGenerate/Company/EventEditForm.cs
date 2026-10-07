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

namespace CertGenerate.Company
{
    public partial class EventEditForm : DevExpress.XtraEditors.XtraForm
    {
        Event _event;
        public EventEditForm(Event Event)
        {
            InitializeComponent();
            _event = Event;
            BindControls();
            btnSave.Click += async (o, e) =>
            {
                await Save();
            };
        }

        public void BindControls()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged;
            txtEventName.DataBindings.Add("EditValue", _event, nameof(_event.EventName), true, mode);
            mmDesc.DataBindings.Add("EditValue", _event, nameof(_event.Description), true, mode);
        }

        public async Task Save()
        {
            var service = new EventService();
            bool success = false;

            if (_event.EventId == 0)
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