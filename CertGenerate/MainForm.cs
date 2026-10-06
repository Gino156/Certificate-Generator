using CertGenerate.Company;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CertGenerate
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            tabbedView1.QueryControl += (o, e) =>
            {
                switch (e.Document.ControlName)
                {
                    case nameof(EmployeeList2): e.Control = PrepareUserControl(new EmployeeList2()); break;
                }
            };

            tabbedView1.DocumentActivated += (o, e) =>
            {
                UpdateRibbonMerge(e.Document?.Control as XtraUserControl);
            };

            tabbedView1.DocumentClosed += (o, e) =>
            {
                UpdateRibbonMerge(tabbedView1.ActiveDocument?.Control as XtraUserControl);
            };

            aceEmployee.Click += (o, e) => LoadDocument("Employee", nameof(EmployeeList2));
        }

        private Control PrepareUserControl(XtraUserControl uc)
        {
            if (uc != null)
            {
                var childRibbon = uc.Controls.OfType<RibbonControl>().FirstOrDefault();
                if (childRibbon != null)
                {
                    childRibbon.Visible = false;
                }
            }
            return uc;
        }

        private void UpdateRibbonMerge(XtraUserControl activeControl)
        {
            ribbon.UnMergeRibbon();

            if (activeControl != null)
            {
                var childRibbon = activeControl.Controls.OfType<RibbonControl>().FirstOrDefault();
                if (childRibbon != null)
                {
                    ribbon.MergeRibbon(childRibbon);
                }
            }
        }

        private void LoadDocument(string caption, string controlName)
        {
            try
            {
                if (!tabbedView1.Documents.Exists(d => d.ControlName == controlName))
                {
                    tabbedView1.AddDocument(caption, controlName);
                }

                tabbedView1.Controller.Activate((Document)tabbedView1.Documents
                    .SingleOrDefault(d => d.ControlName == controlName));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
