Imports DevExpress.XtraScheduler
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Text
Imports System.Windows.Forms

Imports System.Data.SqlClient

Public Class schedular
    Dim id = 0
    Private Sub schedular_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'ScheduelrDataSet.TaskDependencies' table. You can move, or remove it, as needed.
        Me.TaskDependenciesTableAdapter.Fill(Me.ScheduelrDataSet.TaskDependencies)
        'TODO: This line of code loads data into the 'ScheduelrDataSet.Resources' table. You can move, or remove it, as needed.
        Me.ResourcesTableAdapter.Fill(Me.ScheduelrDataSet.Resources)
        'TODO: This line of code loads data into the 'ScheduelrDataSet.Appointments' table. You can move, or remove it, as needed.
        Me.AppointmentsTableAdapter.Fill(Me.ScheduelrDataSet.Appointments)
        'TODO: This line of code loads data into the 'ScheduelrDataSet.Appointments' table. You can move, or remove it, as needed.
        Me.AppointmentsTableAdapter.Fill(Me.ScheduelrDataSet.Appointments)

        'SchedulerDataStorage1.Appointments.DataSource = False
        ' AppointmentsTableAdapter.Adapter.UpdateCommand = New SqlRowUpdatedEventHandler((Appr())

        SchedulerControl1.ActiveViewType = SchedulerViewType.Gantt
        SchedulerControl1.GroupType = SchedulerGroupType.Resource
        SchedulerControl1.GanttView.ShowResourceHeaders = True
        SchedulerControl1.GanttView.CellsAutoHeightOptions.Enabled = True

    End Sub




    Private Sub SchedulerDataStorage1_AppointmentsChanged(sender As Object, e As PersistentObjectsEventArgs) Handles SchedulerDataStorage1.AppointmentsChanged

        AppointmentsTableAdapter.Update(ScheduelrDataSet)
        ScheduelrDataSet.AcceptChanges()

    End Sub

    Private Sub SchedulerDataStorage1_AppointmentsDeleted(sender As Object, e As PersistentObjectsEventArgs) Handles SchedulerDataStorage1.AppointmentsDeleted

        AppointmentsTableAdapter.Update(ScheduelrDataSet)
        ScheduelrDataSet.AcceptChanges()
    End Sub

    Private Sub SchedulerDataStorage1_AppointmentsInserted(sender As Object, e As PersistentObjectsEventArgs) Handles SchedulerDataStorage1.AppointmentsInserted

        AppointmentsTableAdapter.Update(ScheduelrDataSet)
        ScheduelrDataSet.AcceptChanges()

    End Sub

    '   Public Sub comitTask()
    '      AppointmentsTableAdapter.Update(ScheduelrDataSet)
    '     ScheduelrDataSet.AcceptChanges()

    'End Sub
    'Public Sub comitTaskDependency()

    '   TaskDependenciesTableAdapter.Update(ScheduelrDataSet)
    '  ScheduelrDataSet.AcceptChanges()

    'End Sub
    Private Sub Appr(sender As Object, e As SqlRowUpdatedEventArgs)
        If (e.Status = UpdateStatus.Continue AndAlso e.StatementType = StatementType.Insert) Then
            Dim cmd = New SqlCommand("select * identity", AppointmentsTableAdapter.Connection)
            id = Convert.ToInt32(cmd.ExecuteScalar())
            e.Row("Uniqueid") = id
        End If
    End Sub


End Class