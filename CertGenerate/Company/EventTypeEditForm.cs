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
    public partial class EventTypeEditForm : DevExpress.XtraEditors.XtraForm
    {
        EventType _eventType;
        public EventTypeEditForm(EventType EventType)
        {
            InitializeComponent();
            _eventType = EventType;
            BindControls();
            btnSave.Click += async (o, e) =>
            {
                await Save();
            };
        }

        public void BindControls()
        {
            var mode = DataSourceUpdateMode.OnPropertyChanged;
            txtEventName.DataBindings.Add("EditValue", _eventType, nameof(_eventType.EventTypeName), true, mode);
        }

        public async Task Save()
        {
            var service = new EventTypeService();
            bool success = false;

            if (_eventType.EventTypeId == 0)
            {
                success = await service.InsertAsync(_eventType);
            }
            else
            {
                success = await service.UpdateAsync(_eventType);
            }

            if (success)
            {
                Close();
            }
        }
    }
}