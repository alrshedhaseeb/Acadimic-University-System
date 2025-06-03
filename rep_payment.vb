Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class rep_payment
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim table As DataTable

    Private Sub load()
        adabter = New MySqlDataAdapter
        bsourc = New BindingSource
        '        table = New DataTable
        Dim ds As New DataSet1

        conn = New MySqlConnection

        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try

            conn.Open()
            adabter.SelectCommand = New MySqlCommand(" SELECT * FROM academy.payment", conn)
            adabter.Fill(ds.Tables(0))

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
            ReportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Reports\r.rdlc"
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables(0)))
            ReportViewer1.DocumentMapCollapsed = True
            ReportViewer1.Refresh()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub
    Private Sub rep_payment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dataset1.payment' table. You can move, or remove it, as needed.
        'Me.paymentTableAdapter.Fill(Me.DataSet1.payment)
        load()
        Me.ReportViewer1.RefreshReport()

    End Sub


    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        load()
        Me.ReportViewer1.RefreshReport()

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
End Class