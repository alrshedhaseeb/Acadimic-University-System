Imports MySql.Data.MySqlClient
Public Class Form3
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim dtable As DataTable
    Dim rej_pay As Double = 100
    Dim total As Double = 0
    Dim sem As String = ""
    Dim sem1 As String = ""
    Dim fees As Double = 0
    Dim res_year
    Dim flag = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        adabter = New MySqlDataAdapter
        Dim adapter = New MySqlDataAdapter
        Dim adapterr = New MySqlDataAdapter
        bsourc = New BindingSource
        dtable = New DataTable
        Dim table = New DataTable
        Dim tablee = New DataTable

        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try

            conn.Open()



            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim query As String
            query = " SELECT * FROM academy.std_info where id_std='" & TextBox5.Text & "' or name_std='" & TextBox5.Text & "' and active='" & 0 & "'"
            com = New MySqlCommand(query, conn)
            adabter.SelectCommand = com
            adabter.Fill(dtable)
            If dtable.Rows.Count > 0 Then

                Name_stdTextBox.Text = dtable(0)(1)
                Nam_motherTextBox.Text = dtable(0)(7)
                TextBox2.Text = dtable(0)(3)
                TextBox1.Text = dtable(0)(4)
                TextBox8.Text = dtable(0)(18)
                sem = dtable(0)(20)
                TextBox10.Text = dtable(0)(21)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If sem = "الفصل الثانى" Or sem = "الفصل الرابع" Or sem = "الفصل السادس" Or sem = "الفصل الثامن" Then


                    If sem = "الفصل الثانى" Then
                        sem1 = "السنةالاولي"
                    ElseIf sem = "الفصل الرابع" Then
                        sem1 = "السنةالثانية"
                    ElseIf sem = "الفصل السادس" Then
                        sem1 = "السنةالثالثة"
                    ElseIf sem = "الفصل الثامن" Then
                        sem1 = "السنةالرابعة"
                    ElseIf sem = "الفصل العاشر" Then
                        sem1 = "السنةالخامسة"
                    Else
                        MsgBox("عذرآ هنالك خطاء فى بيانات الطالب")
                    End If
                Else
                    MsgBox("عذرآ هذا الطالب لم تخلص فترته الدراسية")
                    Exit Sub
                End If

                Dim qqq As String
                qqq = " SELECT * FROM academy.result_year where std_id='" & TextBox5.Text & "'  and year='" & sem1 & "' and active='" & 0 & "'"
                Dim commm = New MySqlCommand(qqq, conn)

                adapterr.SelectCommand = commm
                adapterr.Fill(tablee)

                If tablee.Rows.Count > 0 Then

                    TextBox3.Text = tablee(0)(3)
                    res_year = tablee(0)(9)
                    Me.TextBox7.Text = res_year

                    TextBox4.Text = tablee(0)(2)
                    commm.Parameters.Clear()
                Else
                    MsgBox("عذرآ هذا الطالب لم يتم اكمال سنته الدراسيه او هنالك خطاء فى سجله مراجعة المسجل")
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim qy1 As String
                    Dim tb As New DataTable
                    MsgBox(sem)
                qy1 = " select* from academy.payment where std_id ='" & TextBox5.Text & "' and semester='" & sem & "' and active='0'"
                Dim cm = New MySqlCommand(qy1, conn)
                    adabter.SelectCommand = cm
                    adabter.Fill(tb)
                    cm.Parameters.Clear()
                    If tb.Rows.Count > 0 Then
                        fees = 0
                        fees = tb(0)(3)
                        MsgBox(fees)
                        Dim feess As Double = tb(0)(1)
                        If feess = 0 Then
                            Me.TextBox9.Text = "خالص ألرسوم"

                        Else
                        Me.TextBox9.Text = "لديه متبقى من الرسوم : " & feess
                    End If
                    Else
                        MsgBox("هنالك خطاء فى سداد الرسوم علي الطالب التوجه للحسابات لمعالجة المشكلة ")
                    End If


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else
                    MsgBox("تاكد من هوية الطالب")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try
    End Sub

    Private Sub خروجToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")

        If Ans = vbNo Then
            Exit Sub
        End If
        Me.Close()


    End Sub
    Public Sub out()
        DateTimePicker1.Value = Date.Now
        Dim qu As String
        qu = " update academy.login set time_out='" & DateTimePicker1.Value & "' where username='" & Label9.Text & "'"

        Dim comm = New MySqlCommand(qu, conn)
        If comm.ExecuteNonQuery > 0 Then
            reader = comm.ExecuteReader
            MsgBox(DateTimePicker1.Value & "   ..زمن الخروج")

        Else
            MsgBox("عذرآ تاكد من اعدادات الوقت")
        End If

    End Sub


    Private Sub بياناتسجلالطالبToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles بياناتسجلالطالبToolStripMenuItem.Click
        Form1.Label22.Text = Label9.Text
        Form1.Label23.Text = Label13.Text
        Form1.Label18.Text = Label12.Text
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub خروجToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles خروجToolStripMenuItem.Click
        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub

        End If
        Me.Close()
        Form2.Show()
        Form2.textbox2.Clear()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox10.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox7.Clear()
        ComboBox3.Items.Clear()
        TextBox5.Clear()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox6.Clear()
        Nam_motherTextBox.Clear()
        Name_stdTextBox.Clear()


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If TextBox5.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox5, "ادخل هوية الطالب")
            Return
        ElseIf Name_stdTextBox.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.Name_stdTextBox, "ادخل اسم الطالب")
            Return
        ElseIf Nam_motherTextBox.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.Nam_motherTextBox, "ادخل اسم الوالدة")
            Return
        ElseIf TextBox2.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox2, "ادخل اسم الكلية")
        ElseIf TextBox7.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox7, "ادخل الملاحق")
        ElseIf TextBox8.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox8, "ادخل الدرجة العلمية")
        ElseIf TextBox9.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox9, "ادخل الرسوم")
        ElseIf TextBox10.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox10, "ادخل اسم الدفعة")
        ElseIf TextBox1.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox1, "ادخل اسم القسم")
        ElseIf TextBox3.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox3, "ادخل النتيجة")
        ElseIf TextBox4.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox4, "ادخل المعدل")
        ElseIf ComboBox3.SelectedItem = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox3, "ادخل الفصل الدراسى")

        Else

            ErrorProvider1.Clear()
            ListBox1.Items.Clear()
            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"

            If flag = 1 Then

                Try
                    conn.Open()

                    Dim qyk As String
                    Dim tbb As New DataTable
                    qyk = " select * from academy.std_atendess where  std_id='" & TextBox5.Text & "' and semester='" & ComboBox3.Text & "' and patch='" & TextBox10.Text & "' and active='0'"
                    com = New MySqlCommand(qyk, conn)
                    adabter.SelectCommand = com
                    adabter.Fill(tbb)

                    If tbb.Rows.Count > 0 Then
                        MsgBox(tbb.Rows.Count)

                        Dim Ans As MsgBoxResult
                        Ans = MsgBox("؟..   " & TextBox5.Text & "   لقد تم تسجيل هذا الطالب مسبقآ ", vbOKOnly + vbExclamation, "تعديل ")
                        If Ans = vbOKOnly Then

                            Exit Sub

                        End If

                    Else
                        '''''''''''''''''''''''''''''''''''insert to student info ''''''''''''''''''''''''''''''''''''''''''''
                        Dim query = " update academy.std_info set semester='" & ComboBox3.Text & "' where id_std='" & TextBox5.Text & "' and patch='" & TextBox10.Text & "' and active='0'"
                        com = New MySqlCommand(query, conn)
                        reader = com.ExecuteReader
                        reader.Close()
                        If com.ExecuteNonQuery > 0 Then


                            '''''''''''''''''''''''''''''''''''''''''''''insert to payment ''''''''''''''''

                            Dim q12 = " Insert Into academy.payment(std_id,semester,pay_fees,patch,active) values('" & TextBox5.Text & "',  '" & ComboBox3.Text & "',  '" & fees & "' ,'" & TextBox10.Text & "','" & 0 & "')"
                            com = New MySqlCommand(q12, conn)
                            reader = com.ExecuteReader
                            MsgBox("p_m")
                            reader.Close()

                            ''''''''''''''''''''''''''''''''''' insert atendees ''''''''''''''''''''''''''''''''''''''''''''

                            Try
                                Dim qy2 As String
                                com = New MySqlCommand
                                Dim tbb020 As New DataTable

                                qy2 = " select * from academy.record_academy where semester ='" & ComboBox3.Text & "' and colage ='" & TextBox2.Text & "' and depart_name='" & TextBox1.Text & "' and depart_certificate='" & TextBox8.Text & "' "

                                com = New MySqlCommand(qy2, conn)
                                adabter.SelectCommand = com
                                adabter.Fill(tbb020)

                                reader = com.ExecuteReader

                                Dim n As String = ""

                                ListBox2.Items.Clear()

                                While reader.Read

                                    n = reader.GetString("lecture")
                                    ListBox2.Items.Add(n)


                                End While

                                reader.Close()

                                If tbb020.Rows.Count > 0 Then
                                    MsgBox(tbb020.Rows.Count)
                                    com = New MySqlCommand

                                    For Each b In ListBox2.Items


                                        Dim q5 = " Insert Into academy.std_atendess(std_id,lecture,semester,lec1,lec2,lec3,lec4,lec5,lec6,lec7,lec8,lec9,lec10,lec11,lec12,patch,active) values('" & TextBox5.Text & "',  '" & b & "',  '" & ComboBox3.Text & "',  '" & 0 & "',  '" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & TextBox10.Text & "' ,'" & 0 & "' )"
                                        com = New MySqlCommand(q5, conn)
                                        reader = com.ExecuteReader
                                        reader.Close()
                                    Next
                                Else
                                    MsgBox("not")

                                End If

                            Catch ex As Exception

                                MsgBox(ex.Message)
                            End Try
                            Dim qq1 As String = ""
                            Dim de As String = "'" + ComboBox3.Text + "/" + Name_stdTextBox.Text + "'"
                            Dim mass As String = de & "لقد تم تسجبل هذا الطالب فى الفصل الدراسى"

                            qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label13.Text & "','" & Label9.Text & "' )"

                            com = New MySqlCommand(qq1, conn)
                            MsgBox("لقد تم تسجبل هذا الطالب فى الفصل الدراسى " & Name_stdTextBox.Text)

                        Else
                            MsgBox("لم يتم تسجيل الطالب")
                            conn.Dispose()
                        End If


                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()

                End Try

            ElseIf flag = 2 Then

                Try
                    conn.Open()

                    Dim qyk As String
                    Dim tbb As New DataTable
                    qyk = " select * from academy.std_atendess where  std_id='" & TextBox5.Text & "' and semester='" & ComboBox3.Text & "' and patch='" & TextBox10.Text & "' and active='0'"
                    com = New MySqlCommand(qyk, conn)
                    adabter.SelectCommand = com
                    adabter.Fill(tbb)

                    If tbb.Rows.Count > 0 Then
                        MsgBox(tbb.Rows.Count)

                        Dim Ans As MsgBoxResult
                        Ans = MsgBox("؟..   " & TextBox5.Text & "   لقد تم تسجيل هذا الطالب مسبقآ ", vbOKOnly + vbExclamation, "تعديل ")
                        If Ans = vbOKOnly Then

                            Exit Sub

                        End If

                    Else
                        '''''''''''''''''''''''''''''''''''insert to student info ''''''''''''''''''''''''''''''''''''''''''''
                        Dim query = " update academy.std_info set semester='" & ComboBox3.Text & "' id_std='" & TextBox11.Text & "' where id_std='" & TextBox5.Text & "' and patch='" & TextBox10.Text & "' and active='0'"
                        com = New MySqlCommand(query, conn)
                        reader = com.ExecuteReader
                        reader.Close()
                        If com.ExecuteNonQuery > 0 Then


                            '''''''''''''''''''''''''''''''''''''''''''''insert to payment ''''''''''''''''

                            Dim q12 = " Insert Into academy.payment(std_id,semester,pay_fees,patch,active) values('" & TextBox11.Text & "',  '" & ComboBox3.Text & "',  '" & fees & "' ,'" & TextBox10.Text & "','" & 0 & "')"
                            com = New MySqlCommand(q12, conn)
                            reader = com.ExecuteReader
                            MsgBox("p_m")
                            reader.Close()

                            ''''''''''''''''''''''''''''''''''' insert atendees ''''''''''''''''''''''''''''''''''''''''''''

                            Try
                                Dim qy2 As String
                                com = New MySqlCommand
                                Dim tbb020 As New DataTable

                                qy2 = " select * from academy.record_academy where semester ='" & ComboBox3.Text & "' and colage ='" & TextBox2.Text & "' and depart_name='" & TextBox1.Text & "' and depart_certificate='" & TextBox8.Text & "' "

                                com = New MySqlCommand(qy2, conn)
                                adabter.SelectCommand = com
                                adabter.Fill(tbb020)

                                reader = com.ExecuteReader

                                Dim n As String = ""

                                ListBox2.Items.Clear()

                                While reader.Read

                                    n = reader.GetString("lecture")
                                    ListBox2.Items.Add(n)


                                End While

                                reader.Close()

                                If tbb020.Rows.Count > 0 Then
                                    MsgBox(tbb020.Rows.Count)
                                    com = New MySqlCommand

                                    For Each b In ListBox2.Items


                                        Dim q5 = " Insert Into academy.std_atendess(std_id,lecture,semester,lec1,lec2,lec3,lec4,lec5,lec6,lec7,lec8,lec9,lec10,lec11,lec12,patch,active) values('" & TextBox11.Text & "',  '" & b & "',  '" & ComboBox3.Text & "',  '" & 0 & "',  '" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & TextBox10.Text & "','" & 0 & "' )"
                                        com = New MySqlCommand(q5, conn)
                                        reader = com.ExecuteReader
                                        reader.Close()
                                    Next
                                Else
                                    MsgBox("not")

                                End If

                            Catch ex As Exception

                                MsgBox(ex.Message)
                            End Try

                            MsgBox("لقد تم تسجبل هذا الطالب فى الفصل الدراسى " & Name_stdTextBox.Text)

                        Else
                            MsgBox("لم يتم تسجيل الطالب")
                            conn.Dispose()
                        End If


                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()

                End Try


            End If

        End If
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim no As New note
        no.ShowDialog()
    End Sub

    Private Sub TextBox7_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox7.TextChanged
        adabter = New MySqlDataAdapter
        bsourc = New BindingSource
        dtable = New DataTable

        Dim sem0 As String = ""


        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"

        Try
            conn.Open()

            If Me.TextBox7.Text = "ينقل" Then

                Dim query As String
                query = " select* from academy.std_info where id_std='" & TextBox5.Text & "' and active='0' "
                com = New MySqlCommand(query, conn)
                reader = com.ExecuteReader
                'adabter.Update(dtable)
                While reader.Read
                    sem0 = reader.GetString("semester")

                End While
                'ComboBox3.Enabled = True

                If sem0 = "الفصل الاول" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل الثانى")

                ElseIf sem0 = "الفصل الثانى" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل الثالث")

                ElseIf sem0 = "الفصل الثالث" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل الرابع")

                ElseIf sem0 = "الفصل الرابع" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل الخامس")

                ElseIf sem0 = "الفصل الخامس" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل السادس")

                ElseIf sem0 = "الفصل السادس" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل السابع")

                ElseIf sem0 = "الفصل السابع" Then
                    ComboBox3.Items.Add("الفصل الثامن")

                Else
                    MsgBox("عذرآ هنالك خطاء فى الفصل الدراسي الرجاء مراجعة المسجل")

                End If

                reader.Close()
            ElseIf Me.TextBox7.Text = "إعادة" Then

                If sem0 = "الفصل الاول" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل الاول")

                ElseIf sem0 = "الفصل الثانى" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل الثانى")

                ElseIf sem0 = "الفصل الثالث" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل الثالث")

                ElseIf sem0 = "الفصل الرابع" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل الرابع")

                ElseIf sem0 = "الفصل الخامس" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل الخامس")

                ElseIf sem0 = "الفصل السادس" Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add("الفصل السادس")

                ElseIf sem0 = "الفصل السادس" And TextBox8.Text = "دبلوم" Then
                    ComboBox3.Items.Clear()
                    MsgBox("هذا اخر فصل للطالب")
                    ComboBox3.Items.Add("الفصل السادس")

                ElseIf sem0 = "الفصل السابع" Then
                    ComboBox3.Items.Add("الفصل السابع")

                ElseIf sem0 = "الفصل الثامن" Then
                    ComboBox3.Items.Add("الفصل الثامن")

                ElseIf sem0 = "الفصل الثامن" And TextBox8.Text = "بكالاريوس" Then

                    ComboBox3.Items.Add("الفصل الثامن")
                    MsgBox("هذا اخر فصل للطالب")

                Else
                    MsgBox("عذرآ هنالك خطاء فى الفصل الدراسي الرجاء مراجعة المسجل")

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub



    Private Sub إجلاسالطلابللامتحانToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        set_std_to_exam.Show()
        Me.Close()

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub النتيجةالنهائيهToolStripMenuItem_Click(sender As Object, e As EventArgs)
        attendees.Show()
        Me.Close()

    End Sub

    Private Sub جدولالفصلالدراسىToolStripMenuItem_Click(sender As Object, e As EventArgs)
        attendees.Show()
        Me.Close()
    End Sub

    Private Sub جدولالامتحاناتToolStripMenuItem_Click(sender As Object, e As EventArgs)
        atendees_exam.Show()
        Me.Close()
    End Sub

    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged
        If Me.TextBox7.Text = "ينقل" And Me.TextBox9.Text = "خالص ألرسوم" Then
            Me.ComboBox3.Enabled = True
            flag = 1

        ElseIf Me.TextBox7.Text = "إعادة" And Me.TextBox9.Text = "خالص ألرسوم" Then
            flag = 2
            Me.ComboBox3.Enabled = False
            ' If Me.TextBox7.Text = "إعادة" Then

            Me.TextBox11.Text = TextBox5.Text + "R"

            ' End If
        ElseIf Me.TextBox7.Text = "إعادة" Then

            Me.TextBox11.Text = TextBox5.Text + "R"


        End If
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then

            adabter = New MySqlDataAdapter
            Dim adapter = New MySqlDataAdapter
            Dim adapterr = New MySqlDataAdapter
            bsourc = New BindingSource
            dtable = New DataTable
            Dim table = New DataTable
            Dim tablee = New DataTable

            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try

                conn.Open()



                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim query As String
                query = " SELECT * FROM academy.std_info where id_std='" & TextBox5.Text & "' and active='0'"
                com = New MySqlCommand(query, conn)
                adabter.SelectCommand = com
                adabter.Fill(dtable)
                If dtable.Rows.Count > 0 Then

                    Name_stdTextBox.Text = dtable(0)(1)
                    Nam_motherTextBox.Text = dtable(0)(7)
                    TextBox2.Text = dtable(0)(3)
                    TextBox1.Text = dtable(0)(4)
                    TextBox8.Text = dtable(0)(18)
                    sem = dtable(0)(20)
                    TextBox10.Text = dtable(0)(21)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If sem = "الفصل الثانى" Or sem = "الفصل الرابع" Or sem = "الفصل السادس" Or sem = "الفصل الثامن" Then


                        If sem = "الفصل الثانى" Then
                            sem1 = "السنةالاولي"
                        ElseIf sem = "الفصل الرابع" Then
                            sem1 = "السنةالثانية"
                        ElseIf sem = "الفصل السادس" Then
                            sem1 = "السنةالثالثة"
                        ElseIf sem = "الفصل الثامن" Then
                            sem1 = "السنةالرابعة"
                        ElseIf sem = "الفصل العاشر" Then
                            sem1 = "السنةالخامسة"
                        Else
                            MsgBox("عذرآ هنالك خطاء فى بيانات الطالب")
                        End If
                    Else
                        MsgBox("عذرآ هذا الطالب لم تخلص فترته الدراسية")
                        Exit Sub
                    End If

                    Dim qqq As String
                    qqq = " SELECT * FROM academy.result_year where std_id='" & TextBox5.Text & "'  and year='" & sem1 & "' and active='0'"
                    Dim commm = New MySqlCommand(qqq, conn)

                    adapterr.SelectCommand = commm
                    adapterr.Fill(tablee)

                    If tablee.Rows.Count > 0 Then

                        TextBox3.Text = tablee(0)(3)
                        res_year = tablee(0)(9)
                        Me.TextBox7.Text = res_year

                        TextBox4.Text = tablee(0)(2)
                        commm.Parameters.Clear()
                    Else
                        MsgBox("عذرآ هذا الطالب لم يتم اكمال سنته الدراسيه او هنالك خطاء فى سجله مراجعة المسجل")
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim qy1 As String
                    Dim tb As New DataTable
                    MsgBox(sem)
                    qy1 = " select* from academy.payment where std_id ='" & TextBox5.Text & "' and semester='" & sem & "' and active='0'"
                    Dim cm = New MySqlCommand(qy1, conn)
                    adabter.SelectCommand = cm
                    adabter.Fill(tb)
                    cm.Parameters.Clear()
                    If tb.Rows.Count > 0 Then
                        fees = 0
                        fees = tb(0)(3)
                        MsgBox(fees)
                        Dim feess As Double = tb(0)(1)
                        If feess = 0 Then
                            Me.TextBox9.Text = "خالص ألرسوم"

                        Else
                            Me.TextBox9.Text = "لديه متبقى من الرسوم : " & feess
                        End If
                    Else
                        MsgBox("هنالك خطاء فى سداد الرسوم علي الطالب التوجه للحسابات لمعالجة المشكلة ")
                    End If


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else
                    MsgBox("تاكد من هوية الطالب")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try

        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        mosgel.Label4.Text = Label19.Text
        mosgel.Label13.Text = Label13.Text
        mosgel.Label12.Text = Label12.Text
        mosgel.Show()
        Me.Close()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub تـــجمــيدوفــكتــجميـدToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تـــجمــيدوفــكتــجميـدToolStripMenuItem.Click
        tagmeed.Label4.Text = Label9.Text
        tagmeed.Label13.Text = Label13.Text
        tagmeed.Label12.Text = Label12.Text
        tagmeed.Show()
        Me.Close()

    End Sub
End Class