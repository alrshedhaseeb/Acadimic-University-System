Imports MySql.Data.MySqlClient
Public Class R_student
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Private Sub load()
        adabter = New MySqlDataAdapter
        Dim ds As New r_stu

        conn = New MySqlConnection

        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try

            conn.Open()

            adabter.SelectCommand = New MySqlCommand(" select id,name_std,name_mother,id_std_h,id_std from academy.std_info where colage='" & mol7.ComboBox5.Text & "' and department='" & mol7.ComboBox4.Text & "'  and depart_certificate='" & mol7.ComboBox2.Text & "' and patch='" & mol7.ComboBox6.Text & "'", conn)
            adabter.Fill(ds.Tables(0))

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
            ReportViewer1.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Reports\r_student.rdlc"
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

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        load()
        ReportViewer1.RefreshReport()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Me.Close()
    End Sub

    Private Sub R_student_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load()
        ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
End Class