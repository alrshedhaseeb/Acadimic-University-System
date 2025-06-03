Imports MySql.Data.MySqlClient
Public Class clinic
    Dim flag As Integer = 0
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim dtable As DataTable
    Dim ck = 0
    Private Sub clinic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.MinDate = Date.Now
        DateTimePicker2.MinDate = Date.Now


    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Dim sdt As DateTime
        Dim edt As DateTime
        Dim ts As TimeSpan
        Dim m = 0
        sdt = Convert.ToDateTime(DateTimePicker1.Value.Date)
        edt = Convert.ToDateTime(DateTimePicker2.Value.Date)
        ts = edt.Subtract(sdt)
        Me.Label11.Text = 0
        Me.Label11.Text = FormatNumber(ts.TotalDays, 0)
        If Label11.Text = 1 Or Label11.Text = 2 Or Label11.Text = 3 Or Label11.Text = 4 Or Label11.Text = 5 Or Label11.Text = 6 Or Label11.Text = 7 Or Label11.Text = 8 Or Label11.Text = 9 Or Label11.Text = 10 Then
            Label12.Text = "أيام"
        Else
            Label12.Text = "يوم"

        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        ck = 1
        Label8.Visible = True
        Label9.Visible = True
        Label10.Visible = True
        Label11.Visible = True
        Label12.Visible = True
        DateTimePicker1.Visible = True
        DateTimePicker2.Visible = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        ck = 2
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False
        DateTimePicker1.Visible = False
        DateTimePicker2.Visible = False

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        flag = 0
        '''''''''''''''''''''''''''''''''''''''''''''''
        Panel4.Visible = False
        Panel5.Visible = False
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

    Private Sub خروجToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles خروجToolStripMenuItem.Click
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Panel4.Visible = True
        Panel5.Visible = False
        flag = 0
        flag = 1

        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox4.Enabled = True
        Button4.Visible = False

        DataGridView1.Visible = False

        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True
        Label7.Visible = True

        TextBox1.Visible = True
        TextBox2.Visible = True
        TextBox3.Visible = True

        RadioButton1.Visible = True
        RadioButton2.Visible = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button4.Visible = False
        Panel5.Visible = True
        Panel4.Visible = False

        flag = 0
        flag = 2

        TextBox4.Enabled = True
        DataGridView1.Visible = True
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox1.Visible = False
        TextBox2.Visible = False
        TextBox3.Visible = False
        RadioButton1.Visible = False
        RadioButton2.Visible = False
        DateTimePicker1.Visible = False
        DateTimePicker2.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
        Label7.Visible = False
        Label8.Visible = False
        Label9.Visible = False
        Label10.Visible = False
        Label11.Visible = False
        Label12.Visible = False

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If Me.TextBox4.Text = Nothing Then
            TextBox4.Text = Nothing
            Button4.Visible = False
        Else
            Button4.Visible = True
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If flag = 1 Then
            com = New MySqlCommand
            adabter = New MySqlDataAdapter
            Dim tablee As New DataTable

            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try

                conn.Open()

                Dim query11 As String

                query11 = " select * from academy.std_info where id_std='" & TextBox4.Text & "' "
                com = New MySqlCommand(query11, conn)
                adabter.SelectCommand = com
                adabter.Fill(tablee)
                If tablee.Rows.Count > 0 Then
                    DataGridView1.Visible = False
                    Button3.Visible = True
                    TextBox1.Enabled = True
                    TextBox1.ReadOnly = True
                    TextBox2.Enabled = True
                    TextBox3.Enabled = True
                    RadioButton1.Enabled = True
                    RadioButton2.Enabled = True
                    '''''''''''''''''''''''''
                    TextBox1.Text = tablee(0)(1)
                    Button3.Enabled = True
                Else
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()
                    MsgBox("عذرآ لا يوجد سجل لهذا الطالب")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try


        ElseIf flag = 2 Then

            com = New MySqlCommand
            adabter = New MySqlDataAdapter
            Dim tablee As New DataTable

            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try

                conn.Open()

                Dim query11 As String

                query11 = " select * from academy.clinic where std_id='" & TextBox4.Text & "' "
                com = New MySqlCommand(query11, conn)
                adabter.SelectCommand = com
                adabter.Fill(tablee)
                If tablee.Rows.Count > 0 Then
                    Button3.Visible = False
                    DataGridView1.Visible = True
                    DataGridView1.Columns.Clear()
                    DataGridView1.DataSource = tablee

                Else
                    DataGridView1.Columns.Clear()
                    MsgBox("عذرآ لا يوجد سجل لهذا الطالب")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If flag = 1 Then

            If TextBox4.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.TextBox4, "أدخل الرقم الجامعى")
                Return
            ElseIf TextBox1.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.TextBox1, "أدخل اسم المريض")
                Return
            ElseIf TextBox2.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.TextBox2, "أدخل الحالة")
                Return
            ElseIf TextBox3.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.TextBox3, "أدخل تشخيص الطبيب")
                Return
            ElseIf ck = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.Label7, "أختر قرار الطبيب")
                Return
            ElseIf DateTimePicker1.Value = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.DateTimePicker1, "أدخل تاريخ بداية الراحة")
                Return
            ElseIf DateTimePicker2.Value = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.DateTimePicker2, "أدخل تاريخ نهاية الراحة")
                Return
            Else
                Me.ErrorProvider1.Clear()

                conn = New MySqlConnection
                conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
                adabter = New MySqlDataAdapter

                conn.Open()

                Dim ta As New DataTable
                Dim query11 As String

                query11 = " select * from academy.clinic where std_id='" & TextBox4.Text & "' "
                com = New MySqlCommand(query11, conn)
                adabter.SelectCommand = com
                adabter.Fill(ta)

                If ta.Rows.Count > 0 Then
                    Dim datee = ta(0)(2)
                    Dim d_n = Date.Now.ToString("yyy-MM-dd")
                    If datee = d_n Then
                        MsgBox("عذرآ لايمكن سحب اكثر من اورنيك مرضى")

                    Else

                        Try


                            If Label11.Text = 0 And RadioButton1.Checked = True Then
                                MsgBox("الرجاء تحديد فترة الراحه")
                            Else

                                Dim qyk0 As String = ""
                                Dim tbb0 As New DataTable

                                Dim qu010 As String = " insert into academy.clinic  (Patient_name,n_Diagnosis, Diagnosis, b_rest, e_rest, d_name, time_rest,std_id,date_up) value('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & DateTimePicker1.Value & "','" & DateTimePicker2.Value & "','" & Label16.Text & "','" & Label11.Text & "','" & TextBox4.Text & "','" & Date.Now.ToString("yyy-MM-dd") & "')"
                                com = New MySqlCommand(qu010, conn)
                                If com.ExecuteNonQuery > 0 Then

                                    MsgBox(" تم ادخال أورنيك مرضى     ")

                                Else
                                    MsgBox("لم يتم")
                                End If
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            conn.Dispose()
                        End Try

                    End If


                Else

                End If

            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If flag = 1 Then
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            RadioButton1.Checked = False

            RadioButton2.Checked = False
            Label11.Text = 0
            Button3.Enabled = False
            DateTimePicker1.Visible = False
            DateTimePicker2.Visible = False
            Label8.Visible = False
            Label9.Visible = False
            Label10.Visible = False
            Label11.Visible = False
            Label12.Visible = False

        ElseIf flag = 2 Then
            DataGridView1.Columns.Clear()
            TextBox4.Clear()
            Button3.Enabled = False
        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            If flag = 1 Then
                com = New MySqlCommand
                adabter = New MySqlDataAdapter
                Dim tablee As New DataTable

                conn = New MySqlConnection
                conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
                Try

                    conn.Open()

                    Dim query11 As String

                    query11 = " select * from academy.std_info where id_std='" & TextBox4.Text & "' "
                    com = New MySqlCommand(query11, conn)
                    adabter.SelectCommand = com
                    adabter.Fill(tablee)
                    If tablee.Rows.Count > 0 Then
                        DataGridView1.Visible = False
                        Button3.Visible = True
                        TextBox1.Enabled = True
                        TextBox1.ReadOnly = True
                        TextBox2.Enabled = True
                        TextBox3.Enabled = True
                        RadioButton1.Enabled = True
                        RadioButton2.Enabled = True
                        '''''''''''''''''''''''''
                        TextBox1.Text = tablee(0)(1)
                        Button3.Enabled = True
                    Else
                        TextBox1.Clear()
                        TextBox2.Clear()
                        TextBox3.Clear()
                        TextBox4.Clear()
                        MsgBox("عذرآ لا يوجد سجل لهذا الطالب")
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()

                End Try


            ElseIf flag = 2 Then

                com = New MySqlCommand
                adabter = New MySqlDataAdapter
                Dim tablee As New DataTable

                conn = New MySqlConnection
                conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
                Try

                    conn.Open()

                    Dim query11 As String

                    query11 = " select * from academy.clinic where std_id='" & TextBox4.Text & "' "
                    com = New MySqlCommand(query11, conn)
                    adabter.SelectCommand = com
                    adabter.Fill(tablee)
                    If tablee.Rows.Count > 0 Then
                        Button3.Visible = False
                        DataGridView1.Visible = True
                        DataGridView1.Columns.Clear()
                        DataGridView1.DataSource = tablee

                    Else
                        DataGridView1.Columns.Clear()
                        MsgBox("عذرآ لا يوجد سجل لهذا الطالب")
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()

                End Try
            End If
        End If
    End Sub
End Class