Imports MySql.Data.MySqlClient
Public Class atendees_exam
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim dtable As DataTable
    Dim re As MySqlDataReader

    Dim flag As Integer = 0
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        DataGridView1.Columns.Clear()
        ' Label3.Text = "إدخال نتيجة مقرر"
        Button1.Enabled = False
        Panel4.Visible = True
        Panel5.Visible = False
        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        ComboBox6.Text = Nothing
        ComboBox6.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        flag = 1
        MsgBox(flag)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.Columns.Clear()
        '  Label3.Text = "إدخال نتيجة ملحق"
        Button1.Enabled = False
        Panel5.Visible = True
        Panel4.Visible = False
        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        ComboBox6.Text = Nothing
        ComboBox6.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        flag = 2

        MsgBox(flag)
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

    Private Sub atendees_exam_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        adabter = New MySqlDataAdapter
        bsourc = New BindingSource
        dtable = New DataTable

        Button1.Enabled = False
        Me.Label10.Text = Date.Now.ToString("yyy/MM/dd")

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
        ComboBox7.Items.AddRange(Enumerable.Range(minNum, maxNum - minNum + 1).Select(Function(s) s.ToString()).ToArray())

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        adabter = New MySqlDataAdapter
        bsourc = New BindingSource
        dtable = New DataTable



        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            ComboBox6.Items.Clear()
            conn.Open()
            Dim query As String
            query = " select* from academy.record_academy where  depart_name='" & ComboBox4.Text & "' AND semester='" & ComboBox3.Text & "'and depart_certificate='" & ComboBox2.Text & "' "
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)
            While reader.Read
                Dim sname = reader.GetString("lecture")
                ComboBox6.Items.Add(sname)
            End While



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        If flag = 1 Then
            Dim adapter = New MySqlDataAdapter
            Dim bsorc = New BindingSource
            Dim table = New DataTable

            Dim conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try
                conn.Open()
                DataGridView1.Columns.Clear()

                Dim query As String
                query = " select id_std as 'الرقم الجامعى',name_std as 'اسم الطالب' from academy.std_info where colage='" & ComboBox5.Text & "' and department='" & ComboBox4.Text & "' and semester='" & ComboBox3.Text & "' and depart_certificate='" & ComboBox2.Text & "' and patch='" & ComboBox7.Text & "' and active='" & 0 & "' ORDER BY id_std ASC"
                com = New MySqlCommand(query, conn)
                adapter.SelectCommand = com
                adapter.Fill(table)
                Label6.Text = table.Rows.Count

                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

                DataGridView1.DataSource = table
                Button1.Enabled = True
                Dim atendes As New DataGridViewComboBoxColumn() With {.HeaderText = "الحضور", .Name = "atendes"}

                atendes.Items.Clear()

                atendes.Items.Add("حضور")
                atendes.Items.Add("غياب")
                '  If ComboBox1.Text = Nothing Then
                DataGridView1.Columns.Insert(2, atendes)
                ' End If


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
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
                DataGridView1.Columns.Clear()

                Dim query1 As String
                query1 = " select std_id as 'الرقم الجامعى',name_std as 'اسم الطالب' from academy.res_lecture where colage='" & ComboBox5.Text & "' and department='" & ComboBox2.Text & "' and lecture='" & ComboBox6.Text & "' and semester='" & ComboBox3.Text & "' and dep_name='" & ComboBox4.Text & "' and mol7ag='نعم' and active='" & 0 & "' ORDER BY std_id ASC"
                com = New MySqlCommand(query1, conn)
                adapter.SelectCommand = com
                adapter.Fill(table)
                Label6.Text = table.Rows.Count

                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

                DataGridView1.DataSource = table
                Button1.Enabled = True
                Dim atendes As New DataGridViewComboBoxColumn() With {.HeaderText = "الحضور", .Name = "atendes"}

                atendes.Items.Clear()

                atendes.Items.Add("حضور")
                atendes.Items.Add("غياب")
                '  If ComboBox1.Text = Nothing Then
                DataGridView1.Columns.Insert(2, atendes)
                ' End If


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try

        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim row As Integer = DataGridView1.Rows.Count
        For i = 0 To row - 1 Step +1
            If ComboBox1.Text = "حضور" Then
                DataGridView1.Rows(i).Cells(2).Value = "حضور"
                '        

            ElseIf ComboBox1.Text = "غياب" Then
                DataGridView1.Rows(i).Cells(2).Value = "غياب"
                '       
            End If

        Next i

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If flag = 1 Then
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
                        Dim qyk0 As String = ""
                        Dim tbb0 As New DataTable

                        qyk0 = " select * from academy.atendees_exam where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and lecture='" & ComboBox6.Text & "' and flag='1' and active='" & 0 & "'"
                        Dim com13 = New MySqlCommand(qyk0, conn)
                        adabter.SelectCommand = com13
                        adabter.Fill(tbb0)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If tbb0.Rows.Count > 0 Then

                            Dim Ans As MsgBoxResult
                            Ans = MsgBox(DataGridView1.Rows(i).Cells(0).Value & " ؟..  لقد تم تسجيل حضور هذا الطالب مسبقآ هل تريد تعديل حظور هذا الطالب", vbYesNo + vbExclamation, "تعديل ")
                            If Ans = vbNo Then

                                Exit Sub

                            Else
                                ''''''''''''''''''update old

                                Dim qq As String = ""
                                qq = " update academy.atendees_exam set atendees='" & DataGridView1.Rows(i).Cells(2).Value & "',date='" & Date.Now.ToString("yyy-MMM-dd") & "' where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and lecture='" & ComboBox6.Text & "' and active='" & 0 & "'"

                                com = New MySqlCommand(qq, conn)
                                If com.ExecuteNonQuery > 0 Then
                                    Dim qq1 As String = ""
                                    Dim de As String = "'" + ComboBox6.Text + "/" + ComboBox3.Text + "/" + ComboBox7.Text + "/" + ComboBox2.Text + "/" + ComboBox4.Text + "/" + ComboBox5.Text + "'"
                                    Dim mass As String = de & "لقد تم تعديل حضور امتحانات الفصل الدراسى للطلاب"

                                    qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label18.Text & "','" & Label16.Text & "' )"

                                    com = New MySqlCommand(qq1, conn)

                                    MsgBox("   تم التعديل")
                                Else
                                    MsgBox("لم بتم التعديل")

                                End If


                            End If

                        Else
                            '''''''''''''''insert new 
                            Dim qu010 As String = " insert into academy.atendees_exam  (std_id, lecture, atendees, colage, dep_name, department, semester,flag,date,active) value('" & DataGridView1.Rows(i).Cells(0).Value & "','" & ComboBox6.Text & "','" & DataGridView1.Rows(i).Cells(2).Value & "','" & ComboBox5.Text & "','" & ComboBox4.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & flag & "','" & Date.Now.ToString("yyy-MM-dd") & "','" & 0 & "')"
                            com = New MySqlCommand(qu010, conn)
                            If com.ExecuteNonQuery > 0 Then
                                Dim qq1 As String = ""
                                Dim de As String = "'" + ComboBox6.Text + "/" + ComboBox3.Text + "/" + ComboBox7.Text + "/" + ComboBox2.Text + "/" + ComboBox4.Text + "/" + ComboBox5.Text + "'"
                                Dim mass As String = de & "لقد تم ادخال حضور امتحانات الفصل الدراسى للطلاب"
                                qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label18.Text & "','" & Label16.Text & "' )"

                                com = New MySqlCommand(qq1, conn)

                                MsgBox(" ::   تم ادخال حظور     " & DataGridView1.Rows(i).Cells(1).Value)

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

        ElseIf flag = 2 Then
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
                        Dim qyk0 As String = ""
                        Dim tbb0 As New DataTable

                        qyk0 = " select * from academy.atendees_exam where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and lecture='" & ComboBox6.Text & "' and flag='2' and active='" & 0 & "'"
                        Dim com13 = New MySqlCommand(qyk0, conn)
                        adabter.SelectCommand = com13
                        adabter.Fill(tbb0)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If tbb0.Rows.Count > 0 Then

                            Dim Ans As MsgBoxResult
                            Ans = MsgBox(DataGridView1.Rows(i).Cells(0).Value & " ؟..  لقد تم تسجيل حضور هذا الطالب مسبقآ هل تريد تعديل حظور هذا الطالب", vbYesNo + vbExclamation, "تعديل ")
                            If Ans = vbNo Then

                                Exit Sub

                            Else
                                ''''''''''''''''''update old

                                Dim qq As String = ""
                                qq = " update academy.atendees_exam set atendees='" & DataGridView1.Rows(i).Cells(2).Value & "',date='" & Date.Now.ToString("yyy-MMM-dd") & "' where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and lecture='" & ComboBox6.Text & "' and active='" & 0 & "'"

                                com = New MySqlCommand(qq, conn)
                                If com.ExecuteNonQuery > 0 Then
                                    Dim qq1 As String = ""
                                    Dim mass As String = "لقد تم تعديل حضور امتحانات الملاحق للفصل الدراسى للطلاب"
                                    qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label18.Text & "','" & Label16.Text & "' )"

                                    com = New MySqlCommand(qq1, conn)
                                    MsgBox("   تم التعديل")
                                Else
                                    MsgBox("لم بتم التعديل")

                                End If


                            End If

                        Else
                            '''''''''''''''insert new 
                            Dim qu010 As String = " insert into academy.atendees_exam  (std_id, lecture, atendees, colage, dep_name, department, semester,flag,date,active) value('" & DataGridView1.Rows(i).Cells(0).Value & "','" & ComboBox6.Text & "','" & DataGridView1.Rows(i).Cells(2).Value & "','" & ComboBox5.Text & "','" & ComboBox4.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "','" & flag & "','" & Date.Now.ToString("yyy-MM-dd") & "','" & 0 & "')"
                            com = New MySqlCommand(qu010, conn)
                            If com.ExecuteNonQuery > 0 Then

                                Dim qq1 As String = ""
                                Dim mass As String = "لقد تم ادخال حضور امتحانات الملاحق للفصل الدراسى للطلاب"
                                qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label18.Text & "','" & Label16.Text & "' )"

                                com = New MySqlCommand(qq1, conn)
                                MsgBox(" ::   تم ادخال حظور     " & DataGridView1.Rows(i).Cells(1).Value)

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

    Private Sub جدولالفصلالدراسىToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles جدولالفصلالدراسىToolStripMenuItem.Click
        attendees.Show()
        Me.Close()

    End Sub

    Private Sub جدولالامتحاناتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles جدولالامتحاناتToolStripMenuItem.Click
        Me.Show()

    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.SelectedIndexChanged
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

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        ComboBox7.Text = DateTimePicker1.MinDate = Date.Today.ToString("yyy")
    End Sub

    Private Sub بياناتسجلالطالبToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form1.Show()
        Me.Close()

    End Sub

    Private Sub السجلالماليToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub إجلاسالطلابللامتحانToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles إجلاسالطلابللامتحانToolStripMenuItem.Click
        set_std_to_exam.Show()
        Me.Close()
    End Sub

    Private Sub النتيجةالنهائيهToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles النتيجةالنهائيهToolStripMenuItem.Click
        result.Show()
        Me.Close()
    End Sub

    Private Sub استعلامعنبياناتطالبToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles استعلامعنبياناتطالبToolStripMenuItem.Click
        record_academy.Show()
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        reji.Label14.Text = Label16.Text
        reji.Label13.Text = Label18.Text
        reji.Label12.Text = Label19.Text
        reji.Show()

        Me.Close()

    End Sub
End Class