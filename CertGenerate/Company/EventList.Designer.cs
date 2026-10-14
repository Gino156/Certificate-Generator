namespace CertGenerate.Company
{
    partial class EventList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventList));
            DevExpress.XtraScheduler.TimeRuler timeRuler7 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler8 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler9 = new DevExpress.XtraScheduler.TimeRuler();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiNewEvent = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditEvent = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeleteEvent = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcEventType = new DevExpress.XtraGrid.GridControl();
            this.vwEventTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvEventType = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEventTypeId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEventTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gcEvents = new DevExpress.XtraGrid.GridControl();
            this.vwEventsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvEvents = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEventsId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstart_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colend_date = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEventTypeId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEventType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwEventTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEventType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwEventsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bbiNew,
            this.bbiEdit,
            this.bbiDelete,
            this.bbiNewEvent,
            this.bbiEditEvent,
            this.bbiDeleteEvent});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 22;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(967, 150);
            // 
            // bbiNew
            // 
            this.bbiNew.Caption = "New";
            this.bbiNew.Id = 1;
            this.bbiNew.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiNew.ImageOptions.SvgImage")));
            this.bbiNew.Name = "bbiNew";
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "Edit";
            this.bbiEdit.Id = 2;
            this.bbiEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiEdit.ImageOptions.SvgImage")));
            this.bbiEdit.Name = "bbiEdit";
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 3;
            this.bbiDelete.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiDelete.ImageOptions.SvgImage")));
            this.bbiDelete.Name = "bbiDelete";
            // 
            // bbiNewEvent
            // 
            this.bbiNewEvent.Caption = "New Event";
            this.bbiNewEvent.Id = 19;
            this.bbiNewEvent.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiNewEvent.ImageOptions.SvgImage")));
            this.bbiNewEvent.Name = "bbiNewEvent";
            // 
            // bbiEditEvent
            // 
            this.bbiEditEvent.Caption = "Edit Event";
            this.bbiEditEvent.Id = 20;
            this.bbiEditEvent.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiEditEvent.ImageOptions.SvgImage")));
            this.bbiEditEvent.Name = "bbiEditEvent";
            // 
            // bbiDeleteEvent
            // 
            this.bbiDeleteEvent.Caption = "Delete Event";
            this.bbiDeleteEvent.Id = 21;
            this.bbiDeleteEvent.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bbiDeleteEvent.ImageOptions.SvgImage")));
            this.bbiDeleteEvent.Name = "bbiDeleteEvent";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Events";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiNew);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiEdit);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Event Type Actions";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiNewEvent);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiEditEvent);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiDeleteEvent);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Events Actions";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Collapsed = true;
            this.splitContainerControl1.CollapsePanel = DevExpress.XtraEditors.SplitCollapsePanel.Panel1;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 150);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcEventType);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(967, 458);
            this.splitContainerControl1.TabIndex = 1;
            // 
            // gcEventType
            // 
            this.gcEventType.DataSource = this.vwEventTypeBindingSource;
            this.gcEventType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEventType.Location = new System.Drawing.Point(0, 0);
            this.gcEventType.MainView = this.gvEventType;
            this.gcEventType.MenuManager = this.ribbonControl1;
            this.gcEventType.Name = "gcEventType";
            this.gcEventType.Size = new System.Drawing.Size(0, 0);
            this.gcEventType.TabIndex = 0;
            this.gcEventType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEventType});
            // 
            // vwEventTypeBindingSource
            // 
            this.vwEventTypeBindingSource.DataSource = typeof(Model.vw_EventType);
            // 
            // gvEventType
            // 
            this.gvEventType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEventTypeId,
            this.colEventTypeName});
            this.gvEventType.GridControl = this.gcEventType;
            this.gvEventType.Name = "gvEventType";
            // 
            // colEventTypeId
            // 
            this.colEventTypeId.FieldName = "EventTypeId";
            this.colEventTypeId.Name = "colEventTypeId";
            this.colEventTypeId.Visible = true;
            this.colEventTypeId.VisibleIndex = 0;
            // 
            // colEventTypeName
            // 
            this.colEventTypeName.FieldName = "EventTypeName";
            this.colEventTypeName.Name = "colEventTypeName";
            this.colEventTypeName.Visible = true;
            this.colEventTypeName.VisibleIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gcEvents);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.schedulerControl1);
            this.splitContainer1.Size = new System.Drawing.Size(957, 458);
            this.splitContainer1.SplitterDistance = 443;
            this.splitContainer1.TabIndex = 2;
            // 
            // gcEvents
            // 
            this.gcEvents.DataSource = this.vwEventsBindingSource;
            this.gcEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEvents.Location = new System.Drawing.Point(0, 0);
            this.gcEvents.MainView = this.gvEvents;
            this.gcEvents.MenuManager = this.ribbonControl1;
            this.gcEvents.Name = "gcEvents";
            this.gcEvents.Size = new System.Drawing.Size(443, 458);
            this.gcEvents.TabIndex = 1;
            this.gcEvents.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEvents});
            // 
            // vwEventsBindingSource
            // 
            this.vwEventsBindingSource.DataSource = typeof(Model.vw_Events);
            // 
            // gvEvents
            // 
            this.gvEvents.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEventsId,
            this.colTitle,
            this.colstart_date,
            this.colend_date,
            this.colEventTypeId1});
            this.gvEvents.GridControl = this.gcEvents;
            this.gvEvents.Name = "gvEvents";
            this.gvEvents.OptionsBehavior.Editable = false;
            // 
            // colEventsId
            // 
            this.colEventsId.FieldName = "EventsId";
            this.colEventsId.Name = "colEventsId";
            // 
            // colTitle
            // 
            this.colTitle.FieldName = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Visible = true;
            this.colTitle.VisibleIndex = 0;
            // 
            // colstart_date
            // 
            this.colstart_date.FieldName = "start_date";
            this.colstart_date.Name = "colstart_date";
            this.colstart_date.Visible = true;
            this.colstart_date.VisibleIndex = 1;
            // 
            // colend_date
            // 
            this.colend_date.FieldName = "end_date";
            this.colend_date.Name = "colend_date";
            this.colend_date.Visible = true;
            this.colend_date.VisibleIndex = 2;
            // 
            // colEventTypeId1
            // 
            this.colEventTypeId1.FieldName = "EventTypeId";
            this.colEventTypeId1.Name = "colEventTypeId1";
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Month;
            this.schedulerControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("schedulerControl1.BackgroundImage")));
            this.schedulerControl1.DataStorage = this.schedulerDataStorage1;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl1.MenuManager = this.ribbonControl1;
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.OptionsCustomization.AllowAppointmentCreate = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentDelete = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentDrag = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentDragBetweenResources = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.OptionsCustomization.AllowAppointmentEdit = DevExpress.XtraScheduler.UsedAppointmentType.None;
            this.schedulerControl1.Size = new System.Drawing.Size(510, 458);
            this.schedulerControl1.Start = new System.DateTime(2026, 10, 4, 0, 0, 0, 0);
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler7);
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler8);
            this.schedulerControl1.Views.GanttView.Enabled = false;
            this.schedulerControl1.Views.TimelineView.Enabled = false;
            this.schedulerControl1.Views.WeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler9);
            // 
            // schedulerDataStorage1
            // 
            // 
            // 
            // 
            this.schedulerDataStorage1.AppointmentDependencies.AutoReload = false;
            // 
            // 
            // 
            this.schedulerDataStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerDataStorage1.Appointments.Mappings.End = "EndDate";
            this.schedulerDataStorage1.Appointments.Mappings.Label = "LabelId";
            this.schedulerDataStorage1.Appointments.Mappings.Start = "StartDate";
            this.schedulerDataStorage1.Appointments.Mappings.Subject = "Subject";
            // 
            // EventList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "EventList";
            this.Size = new System.Drawing.Size(967, 608);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcEventType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwEventTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEventType)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwEventsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.BarButtonItem bbiNew;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gcEvents;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEvents;
        private DevExpress.XtraGrid.GridControl gcEventType;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEventType;
        private DevExpress.XtraGrid.Columns.GridColumn colEventTypeId;
        private DevExpress.XtraGrid.Columns.GridColumn colEventTypeName;
        private System.Windows.Forms.BindingSource vwEventsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEventsId;
        private DevExpress.XtraGrid.Columns.GridColumn colTitle;
        private DevExpress.XtraGrid.Columns.GridColumn colstart_date;
        private DevExpress.XtraGrid.Columns.GridColumn colend_date;
        private DevExpress.XtraGrid.Columns.GridColumn colEventTypeId1;
        private System.Windows.Forms.BindingSource vwEventTypeBindingSource;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bbiNewEvent;
        private DevExpress.XtraBars.BarButtonItem bbiEditEvent;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteEvent;
    }
}
