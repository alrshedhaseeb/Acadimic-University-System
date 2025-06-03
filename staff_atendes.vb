Imports MySql.Data.MySqlClient

Public Class staff_atendes
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim dtable As DataTable

    Public Sub load()

        Dim adapter = New MySqlDataAdapter
        Dim bsorc = New BindingSource
        Dim table = New DataTable

        Dim conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            conn.Open()

            Dim query As String
            query = " select name as'اسم الموظف',staff_id as'هوية الموظف' from academy.staff  ORDER BY name ASC"
            com = New MySqlCommand(query, conn)
            adapter.SelectCommand = com
            adapter.Fill(table)

            Label3.Text = table.Rows.Count
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

            DataGridView1.DataSource = table

            Dim atendes As New DataGridViewComboBoxColumn() With {.HeaderText = "الحضور", .Name = "atendes", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}

            atendes.Items.Clear()

            atendes.Items.Add("حضور")
            atendes.Items.Add("غياب")
            If ComboBox1.Text = Nothing Then
                DataGridView1.Columns.Insert(2, atendes)
            End If
            Dim row As Integer = DataGridView1.Rows.Count
            For i = 0 To row - 1 Step +1
                If DataGridView1.Rows(i).Cells(2).Value = "حضور" Then
                    Dim x As Integer = 0
                    x = i + 1

                    Label4.Text = x
                ElseIf DataGridView1.Rows(i).Cells(2).Value = "غياب" Then
                    Dim x As Integer = 0
                    x = i + 1

                    Label4.Text = x
                End If
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()
        End Try

    End Sub
    Private Sub staff_atendes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.Label10.Text = Date.Now
            load()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub خروجToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles خروجToolStripMenuItem.Click
        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub

        Else

            Me.Close()
            Form2.Show()
            Form2.TextBox2.Clear()
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        adabter = New MySqlDataAdapter

        Try

            conn.Open()

          
            Dim row As Integer = DataGridView1.Rows.Count
            For i = 0 To row - 1 Step +1

                If DataGridView1.Rows(i).Cells(2).Value = Nothing Then
                    MsgBox("عذرآ أختر الحضور")

                Else
                    Me.ErrorProvider1.Clear()

                    Dim qyk0 As String = ""
                    Dim tbb0 As New DataTable

                    qyk0 = " select * from academy.staff_atendess where staff_id='" & DataGridView1.Rows(i).Cells(1).Value & "' and staff_date='" & Date.Now.ToString("yyy-MM") & "'"
                    Dim com13 = New MySqlCommand(qyk0, conn)
                    adabter.SelectCommand = com13
                    adabter.Fill(tbb0)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If tbb0.Rows.Count > 0 Then
                        
                        Dim Ans As MsgBoxResult
                        Ans = MsgBox("؟..   " & DataGridView1.Rows(i).Cells(0).Value & "   لقد تم تسجيل حضور هذا الموظف مسبقآ هل تريد تعديل حظور هذا الموظف", vbYesNo + vbExclamation, "تعديل ")
                        If Ans = vbNo Then

                            Exit Sub

                        Else
                            ''''''''''''''''''update old

                            Dim qq As String = ""
                            qq = " update academy.staff_atendess set staff_id='" & DataGridView1.Rows(i).Cells(1).Value & "',attendees_in='" & Date.Now.ToString("hh:mm:ss") & "',staff_date='" & Date.Now.ToString("yyy-MM") & "' where staff_id='" & DataGridView1.Rows(i).Cells(1).Value & "' and staff_date='" & Date.Now.ToString("yyy-MM") & "'"

                            com = New MySqlCommand(qq, conn)
                            If com.ExecuteNonQuery > 0 Then
                                MsgBox("   تم التعديل")
                            Else
                                MsgBox("لم بتم التعديل")

                            End If


                        End If

                    Else
                        '''''''''''''''insert new 
                        MsgBox("00025")
                        Dim qu010 As String = " insert into academy.staff_atendess  (staff_id, attendees, attendees_in,staff_date) value('" & DataGridView1.Rows(i).Cells(1).Value & "','" & DataGridView1.Rows(i).Cells(2).Value & "','" & Date.Now.ToString("hh:mm:ss") & "','" & Date.Now.ToString("yyy-MM") & "')"
                        com = New MySqlCommand(qu010, conn)
                        If com.ExecuteNonQuery > 0 Then

                            MsgBox(" ::   تم ادخال حظور الموظف    " & DataGridView1.Rows(i).Cells(1).Value)

                        Else
                            MsgBox("لم يتم")
                        End If

                    End If
                End If
            Next i

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()
        End Try


        ''''''''
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim row As Integer = DataGridView1.Rows.Count
        For i = 0 To row - 1 Step +1
            If ComboBox1.Text = "حضور" Then
                DataGridView1.Rows(i).Cells(2).Value = "حضور"
                '        

            ElseIf ComboBox1.Text = "غياب" Then
                DataGridView1.Rows(i).Cells(2).Value = "غياب"
                '       

            Else
                Label4.Text = 0
            End If

        Next i
     
    End Sub

    Private Sub حسابالموظفToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles حسابالموظفToolStripMenuItem.Click
        HR_acount.Show()

        HR_acount.Label20.Text = Label15.Text
        HR_acount.Label24.Text = Label16.Text
        HR_acount.Label25.Text = Label13.Text

        Me.Close()
    End Sub

    Private Sub اعداداتموToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles اعداداتموToolStripMenuItem.Click

        HR_add_staff.Show()

        HR_add_staff.Label16.Text = Label15.Text
        HR_add_staff.Label18.Text = Label16.Text
        HR_add_staff.Label19.Text = Label13.Text

        Me.Close()
    End Sub

    Private Sub التحكمفىصرفياتالموظفينToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles التحكمفىصرفياتالموظفينToolStripMenuItem.Click
        Dim a As New Form8
        a.Label15.Text = Label15.Text
        a.Label4.Text = Label16.Text
        a.Label19.Text = Label13.Text
        a.ShowDialog()
    End Sub

    Private Sub إدارةصلاحيهموظفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles إدارةصلاحيهموظفToolStripMenuItem.Click
        Form4.Label14.Text = Label15.Text
        Form4.Label13.Text = Label16.Text
        Form4.Label12.Text = Label13.Text
        Form4.Show()
        Me.Close()

    End Sub
End Class