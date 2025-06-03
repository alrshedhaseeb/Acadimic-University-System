<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class schedular
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TimeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim TimeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Dim TimeRuler3 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.ResourcesTree1 = New DevExpress.XtraScheduler.UI.ResourcesTree()
        Me.colIdSort = New DevExpress.XtraScheduler.Native.ResourceTreeColumn()
        Me.colId = New DevExpress.XtraScheduler.Native.ResourceTreeColumn()
        Me.colDescription = New DevExpress.XtraScheduler.Native.ResourceTreeColumn()
        Me.SchedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
        Me.SchedulerDataStorage1 = New DevExpress.XtraScheduler.SchedulerDataStorage(Me.components)
        Me.TaskDependenciesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ScheduelrDataSet = New Acadimey.scheduelrDataSet()
        Me.AppointmentsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ResourcesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AppointmentsTableAdapter = New Acadimey.scheduelrDataSetTableAdapters.AppointmentsTableAdapter()
        Me.ResourcesTableAdapter = New Acadimey.scheduelrDataSetTableAdapters.ResourcesTableAdapter()
        Me.TaskDependenciesTableAdapter = New Acadimey.scheduelrDataSetTableAdapters.TaskDependenciesTableAdapter()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.ResourcesTree1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SchedulerDataStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TaskDependenciesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ScheduelrDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AppointmentsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResourcesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.ResourcesTree1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.SchedulerControl1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(800, 450)
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'ResourcesTree1
        '
        Me.ResourcesTree1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() {Me.colIdSort, Me.colId, Me.colDescription})
        Me.ResourcesTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ResourcesTree1.Location = New System.Drawing.Point(0, 0)
        Me.ResourcesTree1.Name = "ResourcesTree1"
        Me.ResourcesTree1.OptionsBehavior.Editable = False
        Me.ResourcesTree1.SchedulerControl = Me.SchedulerControl1
        Me.ResourcesTree1.Size = New System.Drawing.Size(100, 450)
        Me.ResourcesTree1.TabIndex = 1
        Me.ResourcesTree1.VertScrollVisibility = DevExpress.XtraTreeList.ScrollVisibility.Never
        '
        'colIdSort
        '
        Me.colIdSort.FieldName = "IdSort"
        Me.colIdSort.Name = "colIdSort"
        Me.colIdSort.SortOrder = System.Windows.Forms.SortOrder.Ascending
        '
        'colId
        '
        Me.colId.FieldName = "Id"
        Me.colId.Name = "colId"
        '
        'colDescription
        '
        Me.colDescription.FieldName = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.Visible = True
        Me.colDescription.VisibleIndex = 0
        '
        'SchedulerControl1
        '
        Me.SchedulerControl1.DataStorage = Me.SchedulerDataStorage1
        Me.SchedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SchedulerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SchedulerControl1.Name = "SchedulerControl1"
        Me.SchedulerControl1.Size = New System.Drawing.Size(695, 450)
        Me.SchedulerControl1.Start = New Date(2018, 10, 11, 0, 0, 0, 0)
        Me.SchedulerControl1.TabIndex = 0
        Me.SchedulerControl1.Text = "SchedulerControl1"
        Me.SchedulerControl1.Views.DayView.TimeRulers.Add(TimeRuler1)
        Me.SchedulerControl1.Views.FullWeekView.Enabled = True
        Me.SchedulerControl1.Views.FullWeekView.TimeRulers.Add(TimeRuler2)
        Me.SchedulerControl1.Views.WeekView.Enabled = False
        Me.SchedulerControl1.Views.WorkWeekView.TimeRulers.Add(TimeRuler3)
        '
        'SchedulerDataStorage1
        '
        Me.SchedulerDataStorage1.AppointmentDependencies.AutoReload = False
        Me.SchedulerDataStorage1.AppointmentDependencies.DataSource = Me.TaskDependenciesBindingSource
        Me.SchedulerDataStorage1.AppointmentDependencies.Mappings.DependentId = "DependentId"
        Me.SchedulerDataStorage1.AppointmentDependencies.Mappings.ParentId = "ParentId"
        Me.SchedulerDataStorage1.AppointmentDependencies.Mappings.Type = "Type"
        Me.SchedulerDataStorage1.Appointments.DataSource = Me.AppointmentsBindingSource
        Me.SchedulerDataStorage1.Appointments.Mappings.AllDay = "AllDay"
        Me.SchedulerDataStorage1.Appointments.Mappings.AppointmentId = "UniqueId"
        Me.SchedulerDataStorage1.Appointments.Mappings.Description = "Description"
        Me.SchedulerDataStorage1.Appointments.Mappings.End = "EndDate"
        Me.SchedulerDataStorage1.Appointments.Mappings.Label = "Label"
        Me.SchedulerDataStorage1.Appointments.Mappings.Location = "Location"
        Me.SchedulerDataStorage1.Appointments.Mappings.PercentComplete = "PercentComplete"
        Me.SchedulerDataStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
        Me.SchedulerDataStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo"
        Me.SchedulerDataStorage1.Appointments.Mappings.ResourceId = "ResourceId"
        Me.SchedulerDataStorage1.Appointments.Mappings.Start = "StartDate"
        Me.SchedulerDataStorage1.Appointments.Mappings.Status = "Status"
        Me.SchedulerDataStorage1.Appointments.Mappings.Subject = "Subject"
        Me.SchedulerDataStorage1.Appointments.Mappings.TimeZoneId = "TimeZoneId"
        Me.SchedulerDataStorage1.Appointments.Mappings.Type = "Type"
        Me.SchedulerDataStorage1.Resources.CustomFieldMappings.Add(New DevExpress.XtraScheduler.ResourceCustomFieldMapping("IdSort", "IdSort"))
        Me.SchedulerDataStorage1.Resources.DataSource = Me.ResourcesBindingSource
        Me.SchedulerDataStorage1.Resources.Mappings.Caption = "Description"
        Me.SchedulerDataStorage1.Resources.Mappings.Color = "Color"
        Me.SchedulerDataStorage1.Resources.Mappings.Id = "Id"
        Me.SchedulerDataStorage1.Resources.Mappings.Image = "Image"
        Me.SchedulerDataStorage1.Resources.Mappings.ParentId = "ParentId"
        '
        'TaskDependenciesBindingSource
        '
        Me.TaskDependenciesBindingSource.DataMember = "TaskDependencies"
        Me.TaskDependenciesBindingSource.DataSource = Me.ScheduelrDataSet
        '
        'ScheduelrDataSet
        '
        Me.ScheduelrDataSet.DataSetName = "scheduelrDataSet"
        Me.ScheduelrDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'AppointmentsBindingSource
        '
        Me.AppointmentsBindingSource.DataMember = "Appointments"
        Me.AppointmentsBindingSource.DataSource = Me.ScheduelrDataSet
        '
        'ResourcesBindingSource
        '
        Me.ResourcesBindingSource.DataMember = "Resources"
        Me.ResourcesBindingSource.DataSource = Me.ScheduelrDataSet
        '
        'AppointmentsTableAdapter
        '
        Me.AppointmentsTableAdapter.ClearBeforeFill = True
        '
        'ResourcesTableAdapter
        '
        Me.ResourcesTableAdapter.ClearBeforeFill = True
        '
        'TaskDependenciesTableAdapter
        '
        Me.TaskDependenciesTableAdapter.ClearBeforeFill = True
        '
        'schedular
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Name = "schedular"
        Me.Text = "schedular"
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.ResourcesTree1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SchedulerDataStorage1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TaskDependenciesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ScheduelrDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AppointmentsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResourcesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents ResourcesTree1 As DevExpress.XtraScheduler.UI.ResourcesTree
    Friend WithEvents SchedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
    Friend WithEvents SchedulerDataStorage1 As DevExpress.XtraScheduler.SchedulerDataStorage
    Friend WithEvents ScheduelrDataSet As scheduelrDataSet
    Friend WithEvents AppointmentsBindingSource As BindingSource
    Friend WithEvents AppointmentsTableAdapter As scheduelrDataSetTableAdapters.AppointmentsTableAdapter
    Friend WithEvents ResourcesBindingSource As BindingSource
    Friend WithEvents ResourcesTableAdapter As scheduelrDataSetTableAdapters.ResourcesTableAdapter
    Friend WithEvents TaskDependenciesBindingSource As BindingSource
    Friend WithEvents TaskDependenciesTableAdapter As scheduelrDataSetTableAdapters.TaskDependenciesTableAdapter
    Friend WithEvents colIdSort As DevExpress.XtraScheduler.Native.ResourceTreeColumn
    Friend WithEvents colId As DevExpress.XtraScheduler.Native.ResourceTreeColumn
    Friend WithEvents colDescription As DevExpress.XtraScheduler.Native.ResourceTreeColumn
End Class
