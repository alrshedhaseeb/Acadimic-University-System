Imports MySql.Data.MySqlClient

Public Class set_res
    Dim flag As Integer = 0
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader

    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim dtable As DataTable
    Dim grade As String
    Dim res As Double = 0
    Dim lec As String = ""
    Dim ressult As String = ""
    Dim set_exam = 0
    Dim set_mol = 1
    Public Sub out()
        DateTimePicker1.Value = Date.Now
        'Dim qu As String
        '       qu = " update academy.login set time_out='" & DateTimePicker1.Value & "' where username='" & Label14.Text & "'"

        'Dim comm = New MySqlCommand(qu, conn)
        'If comm.ExecuteNonQuery > 0 Then
        'reader = comm.ExecuteReader
        'MsgBox(DateTimePicker1.Value & "   ..زمن الخروج")

        'Else
        'MsgBox("عذرآ تاكد من اعدادات الوقت")
        'End If

    End Sub

    Private Sub set_result_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



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

    Private Sub بياناتسجلالطالبToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form1.Label22.Text = Label16.Text
        Form1.Label23.Text = Label18.Text
        Form1.Label18.Text = Label19.Text
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub السجلالماليToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form3.Label9.Text = Label16.Text
        Form3.Label13.Text = Label18.Text
        Form3.Label12.Text = Label19.Text
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub استعلامعنبياناتطالبToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles استعلامعنبياناتطالبToolStripMenuItem.Click
        record_academy.Label14.Text = Label16.Text
        record_academy.Label15.Text = Label18.Text
        record_academy.Label12.Text = Label19.Text
        record_academy.Show()
        Me.Close()
    End Sub

    Private Sub نافذةسدادالرسومToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        add_fees.Label15.Text = Label16.Text
        add_fees.Label16.Text = Label18.Text
        add_fees.Label13.Text = Label19.Text
        add_fees.Show()
        Me.Close()
    End Sub

    Private Sub خروجToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles خروجToolStripMenuItem.Click
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

    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
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

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim minNum As Integer = 2018
        Dim maxNum As Integer = 2050
        ComboBox6.Items.AddRange(Enumerable.Range(minNum, maxNum - minNum + 1).Select(Function(s) s.ToString()).ToArray())

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        adabter = New MySqlDataAdapter
        bsourc = New BindingSource
        dtable = New DataTable



        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            'DataGridView1.Columns.Clear()
            ' ComboBox5.Text = Nothing
            ComboBox1.Items.Clear()
            conn.Open()
            Dim query As String
            query = " select* from academy.record_academy where  depart_name='" & ComboBox4.Text & "' AND semester='" & ComboBox3.Text & "'and depart_certificate='" & ComboBox2.Text & "'"
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)
            While reader.Read
                Dim sname = reader.GetString("lecture")
                ComboBox1.Items.Add(sname)
            End While



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        DataGridView1.Columns.Clear()

        If flag = 1 Then
            Dim adapter = New MySqlDataAdapter
            Dim bsorc = New BindingSource
            Dim table = New DataTable

            Dim conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try
                conn.Open()
                Dim query As String
                query = " select id_std as'الرقم الجامعى',name_std as'اسم الطالب',semester as'الفصل الدراسى' from academy.std_info where colage='" & ComboBox5.Text & "' and department='" & ComboBox4.Text & "' and semester='" & ComboBox3.Text & "' and depart_certificate='" & ComboBox2.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "'"
                com = New MySqlCommand(query, conn)
                adapter.SelectCommand = com
                adapter.Fill(table)
                bsorc.DataSource = table
                reader = com.ExecuteReader
                adabter.Update(table)
                DataGridView1.Columns.Clear()

                ' Dim combo As New DataGridViewComboBoxColumn() With {.HeaderText = "lecture"}
                ' combo.Items.Add(ComboBox1.Text)
                Dim exam As New DataGridViewTextBoxColumn() With {.HeaderText = "degre_exam", .Name = "exam", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                Dim metarm As New DataGridViewTextBoxColumn() With {.HeaderText = "degre_metarm", .Name = "metarm", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                Dim chk As New DataGridViewCheckBoxColumn() With {.HeaderText = "select", .Name = "chk", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells, .FlatStyle = FlatStyle.Popup, .ThreeState = True}

                Dim row As Integer = DataGridView1.Rows.Count
                For i = 0 To row - 1 Step +1

                    If DataGridView1.Rows(i).Cells(4).Value = Nothing Then
                        chk.ThreeState = False
                    Else
                        chk.ThreeState = True
                    End If
                Next
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

                DataGridView1.Columns.Insert(0, chk)
                DataGridView1.DataSource = table
                ' DataGridView1.Columns.Add("", "")
                'DataGridView1.Columns.Insert(3, combo)

                DataGridView1.Columns.Insert(4, metarm)
                DataGridView1.Columns.Insert(5, exam)

                DataGridView1.Columns(0).Width = 70
                DataGridView1.Columns(3).Width = 200
                DataGridView1.Columns(4).Width = 200

                Button4.Enabled = True
                Button3.Enabled = True

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                com.Parameters.Clear()
                reader.Close()
                conn.Dispose()

            End Try
        ElseIf flag = 2 Then

            Dim adapter = New MySqlDataAdapter
            Dim bsorc = New BindingSource
            Dim table = New DataTable

            Dim conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try
                conn.Open()
                Dim query As String
                query = " select std_id as'الرقم الجامعى',name_std as'اسم الطالب',semester as'الفصل الدراسى' from academy.res_lecture where colage='" & ComboBox5.Text & "' and department='" & ComboBox2.Text & "' and lecture='" & ComboBox1.Text & "' and semester='" & ComboBox3.Text & "' and dep_name='" & ComboBox4.Text & "' and mol7ag='نعم' and set_exam='1' and patch='" & ComboBox6.Text & "' and active='" & 0 & "'"
                com = New MySqlCommand(query, conn)
                adapter.SelectCommand = com
                adapter.Fill(table)
                bsorc.DataSource = table
                reader = com.ExecuteReader
                adabter.Update(table)
                DataGridView1.Columns.Clear()

                ' Dim combo As New DataGridViewComboBoxColumn() With {.HeaderText = "lecture"}
                ' combo.Items.Add(ComboBox1.Text)
                Dim exam As New DataGridViewTextBoxColumn() With {.HeaderText = "degre_exam", .Name = "exam", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                Dim chk As New DataGridViewCheckBoxColumn() With {.HeaderText = "select", .Name = "chk", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells, .FlatStyle = FlatStyle.Popup, .ThreeState = True}

                Dim row As Integer = DataGridView1.Rows.Count
                For i = 0 To row - 1 Step +1
                    If DataGridView1.Rows(i).Cells(4).Value > Val(100) Then
                        MsgBox("عذرآ لقد أدخلت درجه خاطئه")
                    End If
                    If DataGridView1.Rows(i).Cells(4).Value = Nothing Then
                        chk.ThreeState = False
                    Else
                        chk.ThreeState = True
                    End If
                Next
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

                DataGridView1.Columns.Insert(0, chk)
                DataGridView1.DataSource = table
                ' DataGridView1.Columns.Add("", "")
                'DataGridView1.Columns.Insert(3, combo)

                DataGridView1.Columns.Insert(4, exam)

                DataGridView1.Columns(0).Width = 70
                DataGridView1.Columns(3).Width = 200
                DataGridView1.Columns(4).Width = 200

                Button4.Enabled = True
                Button3.Enabled = True

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                com.Parameters.Clear()
                reader.Close()
                conn.Dispose()

            End Try

        End If

    End Sub


    Public Sub resultcondition(ByVal sender)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If flag = 1 Then


            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"

            Try
                conn.Open()
                '  Dim qu As String
                Dim row As Integer = DataGridView1.Rows.Count
                Dim qu As String

                For i = 0 To row - 1 Step +1

                    If DataGridView1.Rows(i).Cells(4).Value = Nothing Or DataGridView1.Rows(i).Cells(5).Value = Nothing Then

                        MsgBox("عذرأ عليك ملء جميع الحقول" & DataGridView1.Rows(i).Cells(1).Value, vbOKOnly + vbExclamation, "خطاء ")

                        Exit For
                    End If

                    If DataGridView1.Rows(i).Cells(4).Value > 40 Then
                            MsgBox("عذرأ الدرجه الكامله ل اعمال السنه 40 " & DataGridView1.Rows(i).Cells(1).Value, vbOKOnly + vbExclamation, "خطاء ")
                            Exit For
                            '                    Exit Sub
                        ElseIf DataGridView1.Rows(i).Cells(5).Value > 60 Then
                            MsgBox("عذرأ الدرجه الكامله ل المقرر 60 " & DataGridView1.Rows(i).Cells(1).Value, vbOKOnly + vbExclamation, "خطاء ")
                            Exit For
                        End If

                        If DataGridView1.Rows(i).Cells(0).Value = False Then

                            MsgBox(DataGridView1.Rows(i).Cells(2).Value & " ::   اسم الطالب   " & DataGridView1.Rows(i).Cells(1).Value & " ::  الرقم الجامعى" & ":: الرجاء ادخال درجات جمبع الطلاب :: عليك مراجعة سجل الطالب")

                        Else
                            adabter = New MySqlDataAdapter

                            Dim qy01 As String
                            Dim tb01 As New DataTable
                        qy01 = " select lecture,semester,degre_metarm from academy.res_lecture where  std_id='" & DataGridView1.Rows(i).Cells(1).Value & "' and  patch='" & ComboBox6.Text & "' and flag ='1' and active='" & 0 & "'"
                        Dim cm01 = New MySqlCommand(qy01, conn)
                            adabter.SelectCommand = cm01
                            adabter.Fill(tb01) '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            res = Val(DataGridView1.Rows(i).Cells(5).Value) + Val(DataGridView1.Rows(i).Cells(4).Value)
                            If res >= 90 Then
                                grade = "A"
                                ressult = "نجاح"
                            ElseIf res >= 80 Then
                                grade = "B+"
                                ressult = "نجاح"
                            ElseIf res >= 70 Then
                                grade = "B"
                                ressult = "نجاح"
                            ElseIf res >= 60 Then
                                grade = "C+"
                                ressult = "نجاح"
                            ElseIf res >= 50 Then
                                grade = "C"
                                ressult = "نجاح"

                            ElseIf res < 50 Then
                                ressult = "رسوب"
                                set_exam = 1
                                grade = "F"
                            End If
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            If tb01.Rows.Count > 0 Then
                                adabter = New MySqlDataAdapter
                            '    MsgBox("1i")
                            Dim qyk0 As String
                                Dim tbb0 As New DataTable
                            qyk0 = " select * from academy.res_lecture where  std_id='" & DataGridView1.Rows(i).Cells(1).Value & "' and lecture='" & ComboBox1.Text & "' and  patch='" & ComboBox6.Text & "' and flag ='1' and active='" & 0 & "'"
                            Dim com13 = New MySqlCommand(qyk0, conn)
                                adabter.SelectCommand = com13
                                adabter.Fill(tbb0)

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                If tbb0.Rows.Count > 0 Then
                                    MsgBox(tbb0.Rows.Count)
                                    lec = tbb0(0)(2)

                                    If lec = ComboBox1.Text Then
                                        Dim Ans As MsgBoxResult
                                        Ans = MsgBox("؟..   " & DataGridView1.Rows(i).Cells(1).Value & "   لقد تمت إضافه نتيجه هذا الطالب مسبقآ هل تريد تعديل بيانات هذا الطالب", vbYesNo + vbExclamation, "تعديل ")
                                        If Ans = vbNo Then

                                        ' Exit Sub
                                        Continue For
                                    Else

                                            Dim qq As String
                                        qq = " update academy.res_lecture set set_exam='" & set_exam & "',result='" & ressult & "',degre='" & DataGridView1.Rows(i).Cells(5).Value & "',degre_metarm='" & DataGridView1.Rows(i).Cells(4).Value & "',flag ='1',grade='" & grade & "',total_degre_exam='" & res & "' where std_id='" & DataGridView1.Rows(i).Cells(1).Value & "' and lecture='" & ComboBox1.Text & "' and  patch='" & ComboBox6.Text & "' and flag ='1' and active='" & 0 & "'"

                                        com = New MySqlCommand(qq, conn)
                                            If com.ExecuteNonQuery > 0 Then
                                                reader = com.ExecuteReader
                                                MsgBox("   تم التعديل")
                                                reader.Close()
                                                com.Parameters.Clear()
                                            Else
                                                MsgBox("لم بتم التعديل")

                                            End If

                                        End If
                                    End If
                                Else

                                qu = " insert into academy.res_lecture  (std_id,name_std,lecture,degre,colage,dep_name, department,semester,grade,time_set,degre_metarm,total_degre_exam,flag,result,set_exam,patch,active) value('" & DataGridView1.Rows(i).Cells(1).Value & "','" & DataGridView1.Rows(i).Cells(2).Value & "','" & ComboBox1.Text & "','" & DataGridView1.Rows(i).Cells(5).Value & "','" & ComboBox5.Text & "','" & ComboBox4.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & grade & "','" & Date.Now & "','" & DataGridView1.Rows(i).Cells(4).Value & "','" & res & "','1','" & ressult & "','" & set_exam & "','" & ComboBox6.Text & "','" & 0 & "')"
                                com = New MySqlCommand(qu, conn)
                                    reader = com.ExecuteReader
                                    MsgBox(DataGridView1.Rows(i).Cells(2).Value & " ::   اسم الطالب   " & DataGridView1.Rows(i).Cells(1).Value & " ::  الرقم الجامعى" & "  ::   تم ادخال نتيجة الطالب    ")
                                    reader.Close()
                                    com.Parameters.Clear()

                                End If
                            Else
                            qu = " insert into academy.res_lecture  (std_id,name_std,lecture,degre,colage,dep_name, department,semester,grade,time_set,degre_metarm,total_degre_exam,flag,result,set_exam,patch,active) value('" & DataGridView1.Rows(i).Cells(1).Value & "','" & DataGridView1.Rows(i).Cells(2).Value & "','" & ComboBox1.Text & "','" & DataGridView1.Rows(i).Cells(5).Value & "','" & ComboBox5.Text & "','" & ComboBox4.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & grade & "','" & Date.Now & "','" & DataGridView1.Rows(i).Cells(4).Value & "','" & res & "','1','" & ressult & "','" & set_exam & "','" & ComboBox6.Text & "','" & 0 & "')"
                            com = New MySqlCommand(qu, conn)
                                reader = com.ExecuteReader
                                MsgBox(DataGridView1.Rows(i).Cells(2).Value & " ::   اسم الطالب   " & DataGridView1.Rows(i).Cells(1).Value & " ::  الرقم الجامعى" & "  ::   تم ادخال نتيجة الطالب    ")
                                reader.Close()
                                com.Parameters.Clear()
                            End If


                        End If

                            'End If
                Next

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try


        ElseIf flag = 2 Then


            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Dim deg = 0
                    Dim mol As String = ""
                    Try
                        conn.Open()
                        '  Dim qu As String
                        Dim row As Integer = DataGridView1.Rows.Count
                        Dim qu As String
                        For i = 0 To row - 1 Step +1

                    If DataGridView1.Rows(i).Cells(4).Value = Nothing Then
                        MsgBox("عذرأ عليك ملء جميع الحقول" & DataGridView1.Rows(i).Cells(1).Value, vbOKOnly + vbExclamation, "خطاء ")
                        Exit For
                    End If
                    If DataGridView1.Rows(i).Cells(4).Value > 100 Then
                        MsgBox("عذرأ الدرجه الكامله ل المقرر 100 " & DataGridView1.Rows(i).Cells(1).Value, vbOKOnly + vbExclamation, "خطاء ")
                        Exit For
                    End If

                    If DataGridView1.Rows(i).Cells(0).Value = False Then

                                MsgBox(DataGridView1.Rows(i).Cells(2).Value & " ::   اسم الطالب   " & DataGridView1.Rows(i).Cells(1).Value & " ::  الرقم الجامعى" & ":: الرجاء ادخال درجات جمبع الطلاب :: عليك مراجعة سجل الطالب")

                            Else
                                adabter = New MySqlDataAdapter

                                Dim qy01 As String
                                Dim tb01 As New DataTable
                        qy01 = " select lecture,semester,degre_metarm from academy.res_lecture where  std_id='" & DataGridView1.Rows(i).Cells(1).Value & "' and patch='" & ComboBox6.Text & "' and flag ='1' and active='" & 0 & "'"
                        Dim cm01 = New MySqlCommand(qy01, conn)
                                adabter.SelectCommand = cm01
                                adabter.Fill(tb01) '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                res = Val(DataGridView1.Rows(i).Cells(4).Value)
                                If res >= 50 Then
                                    grade = "C"
                                ElseIf res < 50 Then
                                    set_exam = 2
                                    grade = "F"
                                End If
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                If tb01.Rows.Count > 0 Then
                                    adabter = New MySqlDataAdapter
                            '    MsgBox("1i")
                            Dim qyk0 As String
                                    Dim tbb0 As New DataTable
                            qyk0 = " select * from academy.res_lecture where  std_id='" & DataGridView1.Rows(i).Cells(1).Value & "' and lecture='" & ComboBox1.Text & "' and patch='" & ComboBox6.Text & "' and flag ='1' and active='" & 0 & "'"
                            Dim com13 = New MySqlCommand(qyk0, conn)
                                    adabter.SelectCommand = com13
                                    adabter.Fill(tbb0)

                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    If tbb0.Rows.Count > 0 Then
                                        MsgBox(tbb0.Rows.Count)
                                        lec = tbb0(0)(2)

                                        If lec = ComboBox1.Text Then
                                            Dim Ans As MsgBoxResult
                                            Ans = MsgBox("؟..   " & DataGridView1.Rows(i).Cells(1).Value & "   لقد تمت إضافه نتيجه هذا الطالب مسبقآ هل تريد تعديل بيانات هذا الطالب", vbYesNo + vbExclamation, "تعديل ")
                                            If Ans = vbNo Then

                                        '   Exit Sub
                                        Continue For
                                            Else
                                                If DataGridView1.Rows(i).Cells(4).Value < 50 Then
                                                    mol = "نعم"
                                                    ressult = "رسوب"
                                                Else
                                                    mol = "لا"
                                                    ressult = "نجاح"

                                                End If

                                        Dim qq As String
                                        qq = " update academy.res_lecture set  set_exam='" & set_exam & "',mol7ag='" & mol & "', set_mol='" & set_mol & "',degre='" & DataGridView1.Rows(i).Cells(4).Value & "',degre_metarm='" & deg & "',grade='" & grade & "',total_degre_exam='" & res & "',result='" & ressult & "' where std_id='" & DataGridView1.Rows(i).Cells(1).Value & "' and lecture='" & ComboBox1.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "'"

                                        com = New MySqlCommand(qq, conn)
                                                If com.ExecuteNonQuery > 0 Then
                                                    reader = com.ExecuteReader
                                                    MsgBox("   تم التعديل")
                                                    reader.Close()
                                                    com.Parameters.Clear()
                                                Else
                                                    MsgBox("لم بتم التعديل")

                                                End If

                                            End If
                                        End If
                                    Else
                                qu = " insert into academy.res_lecture  (std_id,name_std,lecture,degre,colage,dep_name, department,semester,grade,time_set,degre_metarm,total_degre_exam,mol7ag,result,set_exam,patch,set_mol,active) value('" & DataGridView1.Rows(i).Cells(1).Value & "','" & DataGridView1.Rows(i).Cells(2).Value & "','" & ComboBox1.Text & "','" & DataGridView1.Rows(i).Cells(4).Value & "','" & ComboBox5.Text & "','" & ComboBox4.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & grade & "','" & Date.Now & "','" & deg & "','" & res & "','" & mol & "','" & ressult & "','" & set_exam & "','" & ComboBox6.Text & "','" & set_mol & "','" & 0 & "')"
                                com = New MySqlCommand(qu, conn)
                                        reader = com.ExecuteReader
                                        MsgBox(DataGridView1.Rows(i).Cells(2).Value & " ::   اسم الطالب   " & DataGridView1.Rows(i).Cells(1).Value & " ::  الرقم الجامعى" & "  ::   تم ادخال نتيجة الطالب    ")
                                        reader.Close()
                                        com.Parameters.Clear()

                                    End If
                                Else

                            qu = " insert into academy.res_lecture  (std_id,name_std,lecture,degre,colage,dep_name, department,semester,grade,time_set,degre_metarm,total_degre_exam,mol7ag,result,set_exam,patch,set_mol,active) value('" & DataGridView1.Rows(i).Cells(1).Value & "','" & DataGridView1.Rows(i).Cells(2).Value & "','" & ComboBox1.Text & "','" & DataGridView1.Rows(i).Cells(4).Value & "','" & ComboBox5.Text & "','" & ComboBox4.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & grade & "','" & Date.Now & "','" & deg & "','" & res & "','" & mol & "','" & ressult & "','" & set_exam & "','" & ComboBox6.Text & "','" & set_mol & "','" & 0 & "')"
                            com = New MySqlCommand(qu, conn)
                                    reader = com.ExecuteReader
                                    MsgBox(DataGridView1.Rows(i).Cells(2).Value & " ::   اسم الطالب   " & DataGridView1.Rows(i).Cells(1).Value & " ::  الرقم الجامعى" & "  ::   تم ادخال نتيجة الطالب    ")
                                    reader.Close()
                                    com.Parameters.Clear()
                                End If


                            End If

                            'End If
                        Next

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conn.Dispose()

                    End Try
                End If

    End Sub



    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
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

    Private Sub النتيجةالنهائيهToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles النتيجةالنهائيهToolStripMenuItem.Click
        result.Label16.Text = Label16.Text
        result.Label18.Text = Label18.Text
        result.Label19.Text = Label19.Text
        result.Show()

        Me.Close()
    End Sub


    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim no As New note
        no.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        DataGridView1.Columns.Clear()

        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing

        Button4.Enabled = False



    End Sub

    Private Sub إجلاسالطلابللامتحانToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles إجلاسالطلابللامتحانToolStripMenuItem.Click
        set_std_to_exam.Show()
        Me.Close()

    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        DataGridView1.Columns.Clear()
        Label3.Text = "إدخال نتيجة مقرر"
        Panel4.Visible = True
        Panel5.Visible = False
        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        ComboBox1.Enabled = True
        ComboBox6.Text = Nothing
        ComboBox6.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        flag = 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.Columns.Clear()
        Label3.Text = "إدخال نتيجة ملحق"
        Panel5.Visible = True
        Panel4.Visible = False
        ComboBox6.Text = Nothing
        ComboBox6.Enabled = True
        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        flag = 2

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        flag = 0
        '''''''''''''''''''''''''''''''''''''''''''''''
        Label3.Text = "إدخال نتيجة"
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


    Private Sub جدولالفصلالدراسىToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles جدولالفصلالدراسىToolStripMenuItem.Click
        attendees.Show()
        Me.Close()
    End Sub

    Private Sub جدولالامتحاناتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles جدولالامتحاناتToolStripMenuItem.Click
        atendees_exam.Show()
        Me.Close()
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged

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
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        reji.Label14.Text = Label16.Text
        reji.Label13.Text = Label18.Text
        reji.Label12.Text = Label19.Text
        reji.Show()

        Me.Close()
    End Sub
End Class