Imports MySql.Data.MySqlClient
Public Class mol7

    Dim flag = 0
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim dtable As DataTable
    Private Sub mol7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
        Button6.Enabled = False
        adabter = New MySqlDataAdapter
        bsourc = New BindingSource
        dtable = New DataTable



        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            'DataGridView1.Columns.Clear()
            'ComboBox1.Text = Nothing
            ComboBox5.Items.Clear()
            conn.Open()
            Dim query As String
            query = " select* from academy.colage "
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)
            While reader.Read
                Dim sname = reader.GetString("colage_name")
                ComboBox5.Items.Add(sname)

            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        Dim adabter = New MySqlDataAdapter
        Dim bsourc = New BindingSource
        Dim dtable = New DataTable



        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            ComboBox4.Items.Clear()

            'DataGridView1.Columns.Clear()
            conn.Open()
            Dim query As String
            query = " select* from academy.depart_colage where colage='" & ComboBox5.Text & "'"
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)

            While reader.Read
                Dim sname = reader.GetString("dep_name")
                ComboBox4.Items.Add(sname)

            End While




        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim adabter = New MySqlDataAdapter
        Dim bsourc = New BindingSource
        Dim dtable = New DataTable



        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            'DataGridView1.Columns.Clear()

            conn.Open()
            Dim query As String
            query = " select* from academy.depart_colage where colage='" & ComboBox5.Text & "' AND dep_name='" & ComboBox4.Text & "' "
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)

            While reader.Read
                ComboBox2.Items.Clear()

                Dim sname = reader.GetString("department")
                If sname = "بكالاريوس+دبلوم" Then
                    ComboBox2.Items.Add("بكالاريوس")
                    ComboBox2.Items.Add("دبلوم")
                Else
                    ComboBox2.Items.Add(sname)
                End If

            End While




        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim minNum As Integer = 2018
        Dim maxNum As Integer = 2050
        ComboBox6.Items.AddRange(Enumerable.Range(minNum, maxNum - minNum + 1).Select(Function(s) s.ToString()).ToArray())

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If flag = 2 Then

            com = New MySqlCommand
            adabter = New MySqlDataAdapter
            Dim table As New DataTable

            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"

            Try

                conn.Open()

                DataGridView1.Columns.Clear()

                Dim query1 As String
                query1 = " select id ,std_id as'الرقم الجامعى',name_std as'اسم الطالب',lecture as'المقرر' from academy.res_lecture where colage='" & ComboBox5.Text & "' and dep_name='" & ComboBox4.Text & "' and semester='" & ComboBox3.Text & "' and department='" & ComboBox2.Text & "'  and patch='" & ComboBox6.Text & "' and set_exam=1"
                com = New MySqlCommand(query1, conn)
                adabter.SelectCommand = com
                adabter.Fill(table)
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders

                DataGridView1.DataSource = table
                Button6.Enabled = True

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try


        ElseIf flag = 1 Then
            com = New MySqlCommand
            adabter = New MySqlDataAdapter
            Dim tablee As New DataTable

            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try

                conn.Open()

                DataGridView2.Columns.Clear()

                Dim query11 As String

                query11 = " select id,std_id as'الرقم الجامعى',semester as'الفصل الدراسى',res_degre as'الدرجة',res_char as'النتيجة',grade as'التقدير' from academy.result where colage='" & ComboBox5.Text & "' and dep_name='" & ComboBox4.Text & "' and semester='" & ComboBox3.Text & "' and department='" & ComboBox2.Text & "' and patch='" & ComboBox6.Text & "' "
                com = New MySqlCommand(query11, conn)
                adabter.SelectCommand = com
                adabter.Fill(tablee)
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders

                DataGridView2.DataSource = tablee
                Button6.Enabled = True
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        If flag = 2 Then
            R_mol7ag.Show()

        ElseIf flag = 1 Then
            query_result.Show()

        ElseIf flag = 3 Then
            R_res_year.Show()

        ElseIf flag = 4 Then
            R_student.Show()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click, Button7.Click


        DataGridView1.Columns.Clear()
        DataGridView2.Columns.Clear()

        Label8.Text = Nothing
        Label8.Text = "استعلام عن النتيجه"

        Panel4.Visible = True
        Panel5.Visible = False
        Panel6.Visible = False
        Panel11.Visible = False

        Button6.Enabled = False
        ComboBox1.Items.Clear()

        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        ComboBox6.Text = Nothing
        ComboBox1.Text = Nothing
        ComboBox3.Text = Nothing

        Label9.Visible = True

        Label10.Visible = False

        ComboBox1.Visible = False
        ComboBox3.Visible = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        ComboBox6.Enabled = True
        ComboBox1.Enabled = True
        ComboBox3.Enabled = True

        flag = 1

        DataGridView1.Visible = False
        DataGridView2.Visible = True
        DataGridView1.Enabled = False
        DataGridView2.Enabled = True
        '''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click, Button8.Click

        DataGridView1.Columns.Clear()
        DataGridView2.Columns.Clear()

        Label8.Text = Nothing
        Label8.Text = "استعلام عن الجالسين للملاحق"

        Panel5.Visible = True
        Panel4.Visible = False
        Panel6.Visible = False
        Panel11.Visible = False

        Button6.Enabled = False
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        ComboBox6.Text = Nothing
        ComboBox1.Text = Nothing
        ComboBox3.Text = Nothing

        Label9.Visible = True

        Label10.Visible = False

        ComboBox1.Items.Clear()

        ComboBox1.Visible = False
        ComboBox3.Visible = True
        ComboBox1.Enabled = True

        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        ComboBox6.Enabled = True
        ComboBox1.Enabled = True
        ComboBox3.Enabled = True

        flag = 2

        DataGridView1.Visible = True
        DataGridView2.Visible = False
        DataGridView2.Enabled = False
        DataGridView1.Enabled = True


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        ComboBox1.Items.Clear()

        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        ComboBox6.Text = Nothing

        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
        ComboBox6.Enabled = False

        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False

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

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint, Panel10.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        DataGridView1.Columns.Clear()
        DataGridView2.Columns.Clear()

        Label8.Text = Nothing
        Label8.Text = "استعلام عن النتيجه"

        flag = 3

        Panel6.Visible = True
        Panel5.Visible = False
        Panel4.Visible = False
        Panel11.Visible = False

        Button6.Enabled = False
        ComboBox1.Items.Clear()

        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        ComboBox6.Text = Nothing

        ComboBox1.Text = Nothing
        ComboBox3.Text = Nothing

        Label10.Visible = True

        Label9.Visible = False

        ComboBox1.Visible = True
        ComboBox3.Visible = False
        ComboBox1.Enabled = True

        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        ComboBox6.Enabled = True
        ComboBox1.Enabled = True
        ComboBox3.Enabled = True

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        DataGridView1.Columns.Clear()
        If flag = 3 Then
            com = New MySqlCommand
            adabter = New MySqlDataAdapter
            Dim table1 As New DataTable

            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try

                conn.Open()

                DataGridView2.Columns.Clear()

                Dim query1 As String
                query1 = " select std_id as'الرقم الجامعى',year as'السنة الدراسية',res_degre as'الدرجة',grade as'التقدير',res_char as'النتيجة',result as'القرار' from academy.result_year where colage='" & ComboBox5.Text & "' and dep_name='" & ComboBox4.Text & "' and year='" & ComboBox1.Text & "' and department='" & ComboBox2.Text & "' and patch='" & ComboBox6.Text & "' "
                com = New MySqlCommand(query1, conn)
                adabter.SelectCommand = com
                adabter.Fill(table1)

                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

                DataGridView2.DataSource = table1
                Button6.Enabled = True
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try
        End If
    End Sub

    Private Sub استعلامعنبياناتطالبToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles استعلامعنبياناتطالبToolStripMenuItem.Click
        record_academy.Label14.Text = Label14.Text
        record_academy.Label15.Text = Label13.Text
        record_academy.Label12.Text = Label12.Text
        record_academy.Show()

        Me.Close()
    End Sub

    Private Sub ادخالنتيجهمقررToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ادخالنتيجهمقررToolStripMenuItem.Click
        set_res.Label16.Text = Label14.Text
        set_res.Label18.Text = Label13.Text
        set_res.Label19.Text = Label12.Text

        set_res.Show()

        Me.Close()
    End Sub

    Private Sub إجلاسالطلابللامتحانToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles إجلاسالطلابللامتحانToolStripMenuItem.Click
        set_std_to_exam.Label16.Text = Label14.Text
        set_std_to_exam.Label18.Text = Label13.Text
        set_std_to_exam.Label19.Text = Label12.Text

        set_std_to_exam.Show()
        Me.Close()
    End Sub

    Private Sub السجلالماليToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form3.Label9.Text = Label14.Text
        Form3.Label13.Text = Label13.Text
        Form3.Label12.Text = Label12.Text
        Form3.Show()
        Me.Close()

    End Sub

    Private Sub بياناتسجلالطالبToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form1.Label22.Text = Label14.Text
        Form1.Label23.Text = Label13.Text
        Form1.Label18.Text = Label12.Text

        Form1.Show()
        Me.Close()
    End Sub

    Private Sub جدولالفصلالدراسىToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles جدولالفصلالدراسىToolStripMenuItem.Click
        attendees.Label16.Text = Label14.Text
        attendees.Label18.Text = Label13.Text
        attendees.Label19.Text = Label12.Text

        attendees.Show()
        Me.Close()
    End Sub

    Private Sub جدولالامتحاناتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles جدولالامتحاناتToolStripMenuItem.Click
        atendees_exam.Label16.Text = Label14.Text
        atendees_exam.Label18.Text = Label13.Text
        atendees_exam.Label19.Text = Label12.Text

        atendees_exam.Show()
        Me.Close()
    End Sub

    Private Sub النتيجةالنهائيةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles النتيجةالنهائيةToolStripMenuItem.Click
        result.Label16.Text = Label14.Text
        result.Label18.Text = Label13.Text
        result.Label19.Text = Label12.Text
        result.Show()

        Me.Close()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        DataGridView1.Columns.Clear()
        DataGridView2.Columns.Clear()

        Label8.Text = Nothing
        Label8.Text = "استعلام عن الطلاب "

        Panel11.Visible = True
        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False

        Button6.Enabled = False
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        ComboBox6.Text = Nothing
        ComboBox1.Text = Nothing
        ComboBox3.Text = Nothing

        Label9.Visible = True

        Label10.Visible = False

        ComboBox1.Items.Clear()

        ComboBox1.Visible = False
        ComboBox3.Visible = True
        ComboBox1.Enabled = False
        ComboBox3.Enabled = False

        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        ComboBox6.Enabled = True

        flag = 4

        DataGridView2.Visible = True
        DataGridView1.Visible = False
        DataGridView1.Enabled = False
        DataGridView2.Enabled = True


    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged

        If flag = 3 And ComboBox2.Text = "بكالاريوس" Then
            ComboBox1.Items.Clear()
            ComboBox1.Items.Add("السنةالاولي")
            ComboBox1.Items.Add("السنةالثانية")
            ComboBox1.Items.Add("السنةالثالثة")
            ComboBox1.Items.Add("السنةالرابعة")
            ComboBox1.Items.Add("السنةالخامسة")
        ElseIf flag = 3 And ComboBox2.Text = "دبلوم" Then
            ComboBox1.Items.Clear()
            ComboBox1.Items.Add("السنةالاولي")
            ComboBox1.Items.Add("السنةالثانية")
            ComboBox1.Items.Add("السنةالثالثة")


        End If

        Dim adabter = New MySqlDataAdapter
        Dim bsourc = New BindingSource
        Dim dtable = New DataTable
        Dim table = New DataTable


        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try

            conn.Open()
            Dim query As String
            query = " select* from academy.depart_colage where colage='" & ComboBox5.Text & "' and dep_name='" & ComboBox4.Text & "'"
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)

            While reader.Read
                Dim sname = reader.GetString("dep_name")
                'TextBox7.Text = sname

                'TextBox7.Text = dtable(0)(1)
                'TextBox7.Text = dtable(0)(2)
                'TextBox9.Text = dtable(0)(29)

                com.Parameters.Clear()
                ' Dim sname As String

                If ComboBox4.Text = sname And ComboBox2.Text = "بكالاريوس" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل الاول")
                    ComboBox3.Items.Add("الفصل الثانى")
                    ComboBox3.Items.Add("الفصل الثالث")
                    ComboBox3.Items.Add("الفصل الرابع")
                    ComboBox3.Items.Add("الفصل الخامس")
                    ComboBox3.Items.Add("الفصل السادس")
                    ComboBox3.Items.Add("الفصل السابع")
                    ComboBox3.Items.Add("الفصل الثامن")
                ElseIf ComboBox4.Text = sname And ComboBox2.Text = "دبلوم" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل الاول")
                    ComboBox3.Items.Add("الفصل الثانى")
                    ComboBox3.Items.Add("الفصل الثالث")
                    ComboBox3.Items.Add("الفصل الرابع")
                    ComboBox3.Items.Add("الفصل الخامس")
                    ComboBox3.Items.Add("الفصل السادس")

                ElseIf ComboBox2.Text = "it" And ComboBox3.Text = "ماجستير" Or ComboBox2.Text = "it2" And ComboBox3.Text = "ماجستير" Or ComboBox2.Text = "it3" And ComboBox3.Text = "ماجستير" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل الاول")
                    ComboBox3.Items.Add("الفصل الثانى")
                    ComboBox3.Items.Add("الفصل الثالث")
                    ComboBox3.Items.Add("الفصل الرابع")
                End If
            End While

            If flag = 4 Then
                com = New MySqlCommand
                adabter = New MySqlDataAdapter
                Dim tablee As New DataTable

                conn = New MySqlConnection
                conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
                Try

                    conn.Open()

                    DataGridView2.Columns.Clear()

                    Dim query11 As String

                    query11 = " select id,name_std as'اسم الطالب',name_mother as'اسم الوالدة',id_std_h as'الرقم الجامعى من التعليم العالى',id_std as'الرقم الجامعى' from academy.std_info where colage='" & ComboBox5.Text & "' and department='" & ComboBox4.Text & "'  and depart_certificate='" & ComboBox2.Text & "' and patch='" & ComboBox6.Text & "' "
                    com = New MySqlCommand(query11, conn)
                    adabter.SelectCommand = com
                    adabter.Fill(tablee)
                    DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                    DataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders

                    DataGridView2.DataSource = tablee
                    Button6.Enabled = True

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()

                End Try

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        reji.Label14.Text = Label14.Text
        reji.Label13.Text = Label13.Text
        reji.Label12.Text = Label12.Text
        reji.Show()

        Me.Close()
    End Sub
End Class