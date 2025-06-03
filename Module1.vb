Imports MySql.Data.MySqlClient



Module Module1
    Public Class log
        Dim conn As MySqlConnection
        Dim com As MySqlCommand
        Dim reader As MySqlDataReader
        Dim adabter As MySqlDataAdapter
        Dim bsourc As BindingSource
        Dim dtable As DataTable

        Public Sub out(ByRef sender)

            Dim qu As String
            qu = " update academy.login set time_out='" & Date.Now & "' where username='" & set_res.Label16.Text & "'"

            Dim comm = New MySqlCommand(qu, conn)
            If comm.ExecuteNonQuery > 0 Then
                reader = comm.ExecuteReader
                MsgBox(Date.Now & "   ..زمن الخروج")

            Else
                MsgBox("عذرآ تاكد من اعدادات الوقت")
            End If

        End Sub
    End Class
End Module
