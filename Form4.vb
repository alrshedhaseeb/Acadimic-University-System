Imports MaterialSkin
Imports MySql.Data.MySqlClient

Public Class Form4
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim ad As MySqlDataAdapter
    Dim dtable As DataTable
    Dim dta As DataTable
    Dim staf_id As String = ""


    Public Sub out()
        DateTimePicker1.Value = Date.Now
        Dim qu As String
        qu = " update academy.login set time_out='" & DateTimePicker1.Value & "' where username='" & Label14.Text & "'"

        Dim comm = New MySqlCommand(qu, conn)
        If comm.ExecuteNonQuery > 0 Then
            reader = comm.ExecuteReader
            MsgBox(DateTimePicker1.Value & "   ..زمن الخروج")

        Else
            MsgBox("عذرآ تاكد من اعدادات الوقت")
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        textbox1.Clear()
        textbox2.Clear()
        textbox3.Clear()
        textbox4.Clear()
        CheckBox1.CheckState = CheckState.Unchecked
        ComboBox1.Text = Nothing

        flag.Items.Clear()
        flag.Items.Add("as admin")
        flag.Items.Add("as user")
        flag.Items.Add("as HR")
        flag.Items.Add("as M")
        flag.Items.Add("as HR_Fees")
        flag.Items.Add("as STD_Fees")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"

        If textbox1.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.textbox1, "الرجاء كتابة اسم المستخدم")
            Return
        ElseIf textbox2.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.textbox2, "الرجاء كتابة كلمة المرور")
            Return
        ElseIf textbox3.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.textbox3, "الرجاء كتابة إعادة كلمة المرور")
            Return
        ElseIf textbox4.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.textbox4, "الرجاء كتابة الرقم الوطنى")
        ElseIf flag.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.flag, "الرجاء اختر الصلاحية")


        Else

            ErrorProvider1.Clear()
            If textbox2.Text = textbox3.Text Then


                Try
                    conn.Open()
                    Dim query1 As String
                    query1 = " select* from academy.staff where id_national='" & textbox4.Text & "'"
                    com = New MySqlCommand(query1, conn)
                    adabter.SelectCommand = com
                    adabter.Fill(dtable)
                    If dtable.Rows.Count > 0 Then


                        Dim qyk0 As String = ""
                        Dim tbb0 As New DataTable

                        qyk0 = " select * from academy.login where username='" & textbox1.Text & "' and id_national='" & textbox4.Text & "'"
                        Dim com13 = New MySqlCommand(qyk0, conn)
                        adabter.SelectCommand = com13
                        adabter.Fill(tbb0)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If tbb0.Rows.Count > 0 Then

                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("؟..    هل تريد تعديل المرور(" & textbox1.Text & " )  هذا ألمستخدم موجود ", vbYesNo + vbExclamation, "تعديل ")
                            If Ans = vbNo Then

                                Exit Sub

                            Else

                                Dim qy As String
                                qy = " update academy.login set  username='" & textbox1.Text & "',password='" & textbox2.Text & "',flag='" & flag.Text & "' where username='" & textbox1.Text & "' and id_national='" & textbox4.Text & "' "

                                Dim commm = New MySqlCommand(qy, conn)

                                If commm.ExecuteNonQuery > 0 Then
                                    Dim qq1 As String = ""
                                    Dim de As String = "'" + flag.Text + "/" + textbox1.Text + "'"
                                    Dim mass As String = de & "لقد تم تعديل بيانات موظف "

                                    qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label13.Text & "','" & Label14.Text & "' )"

                                    com = New MySqlCommand(qq1, conn)

                                    MsgBox("تم التعديل")

                                    textbox1.Clear()
                                    textbox2.Clear()
                                    textbox3.Clear()
                                    textbox4.Clear()
                                    flag.Items.Clear()
                                    flag.Items.Add("as admin")
                                    flag.Items.Add("as user")
                                    flag.Items.Add("as HR")
                                    flag.Items.Add("as M")
                                    flag.Items.Add("as HR_Fees")
                                    flag.Items.Add("as STD_Fees")

                                Else
                                    MsgBox("لم يتم التعديل")

                                    textbox1.Clear()
                                    textbox2.Clear()
                                    textbox3.Clear()
                                    textbox4.Clear()
                                    flag.Items.Clear()
                                    flag.Items.Add("as admin")
                                    flag.Items.Add("as user")
                                    flag.Items.Add("as HR")
                                    flag.Items.Add("as M")
                                    flag.Items.Add("as HR_Fees")
                                    flag.Items.Add("as STD_Fees")

                                End If

                            End If

                        Else
                            com.Parameters.Clear()

                            ad = New MySqlDataAdapter
                            dta = New DataTable

                            Dim qu01 As String = " Insert Into academy.login(username,password,id_national,flag,staff_id) values('" & textbox1.Text & "','" & textbox2.Text & "','" & textbox4.Text & "','" & flag.Text & "','" & staf_id & "')"
                            com = New MySqlCommand(qu01, conn)
                            ad.SelectCommand = com
                            ad.Update(dta)

                            If com.ExecuteNonQuery > 0 Then

                                Dim qq1 As String = ""
                                Dim de As String = "'" + flag.Text + "/" + textbox1.Text + "'"
                                Dim mass As String = de & "لقد تم اضافة موظف "

                                qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label13.Text & "','" & Label14.Text & "' )"

                                com = New MySqlCommand(qq1, conn)

                                MsgBox("لقد قمت بتسجيل مستخدم جديد")

                                textbox1.Clear()
                                textbox2.Clear()
                                textbox3.Clear()
                                textbox4.Clear()
                                flag.Items.Clear()
                                flag.Items.Add("as admin")
                                flag.Items.Add("as user")
                                flag.Items.Add("as HR")
                                flag.Items.Add("as M")
                                flag.Items.Add("as HR_Fees")
                                flag.Items.Add("as STD_Fees")
                            Else
                                MsgBox("لم يتم التسجيل")

                                textbox1.Clear()
                                textbox2.Clear()
                                textbox3.Clear()
                                textbox4.Clear()
                                flag.Items.Clear()
                                flag.Items.Add("as admin")
                                flag.Items.Add("as user")
                                flag.Items.Add("as HR")
                                flag.Items.Add("as M")
                                flag.Items.Add("as HR_Fees")
                                flag.Items.Add("as STD_Fees")

                            End If
                        End If

                    Else
                            MsgBox("تأكد من هوية الموظف")

                    End If


                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()

                End Try
            Else
                MsgBox("كلمه المرور لاتتطابق")

            End If

        End If
    End Sub


    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        adabter = New MySqlDataAdapter
        '  bsourc = New BindingSource
        dtable = New DataTable
        'exp()


        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try

            ComboBox1.Items.Clear()
            conn.Open()
            Dim query As String
            query = " select* from academy.staff "
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)
            While reader.Read
                Dim sname = reader.GetString("name")
                ComboBox1.Items.Add(sname)

            End While




            Dim skinmanager As MaterialSkin.MaterialSkinManager = MaterialSkin.MaterialSkinManager.Instance


        skinmanager.Theme = MaterialSkinManager.Themes.DARK

        skinmanager.ColorScheme = New ColorScheme(Primary.Indigo400, Primary.Indigo300, Primary.Pink100, Accent.Cyan700, TextShade.WHITE)

        skinmanager.ROBOTO_MEDIUM_10 = New Font("Arabic Typesetting", 12)
        skinmanager.ROBOTO_MEDIUM_11 = New Font("Arabic Typesetting", 12)
        skinmanager.ROBOTO_MEDIUM_12 = New Font("Arabic Typesetting", 12)





        Me.textbox1.ForeColor = System.Drawing.Color.White
        Me.textbox1.Font = New Font("Arabic Typesetting", 18)


        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Font = New Font("Arabic Typesetting", 36)

        Me.textbox2.ForeColor = System.Drawing.Color.White
        Me.textbox2.Font = New Font("Arabic Typesetting", 18)

        Me.textbox3.ForeColor = System.Drawing.Color.White
        Me.textbox3.Font = New Font("Arabic Typesetting", 18)

        Me.textbox4.ForeColor = System.Drawing.Color.White
        Me.textbox4.Font = New Font("Arabic Typesetting", 18)


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try
    End Sub



    Private Sub التقويمالدراسىوالمنهجيةالمتبعهToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        admin.Label14.Text = Label14.Text
        admin.Label12.Text = Label12.Text
        admin.Label13.Text = Label13.Text
        admin.Show()
        Me.Close()
    End Sub

    Private Sub خروجToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub

        End If
        Me.Close()
        Form2.Show()
        Form2.textbox2.Clear()

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim no As New note
        no.ShowDialog()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            If textbox1.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox1, "الرجاء كتابة اسم المستخدم")
                Return
            ElseIf textbox2.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox2, "الرجاء كتابة كلمة المرور")
                Return
            ElseIf textbox3.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox3, "الرجاء كتابة إعادة كلمة المرور")
                Return
            ElseIf textbox4.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox4, "الرجاء كتابة الرقم الوطنى")
            ElseIf flag.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.flag, "الرجاء اختر الصلاحية")


            Else

                ErrorProvider1.Clear()
                If textbox2.Text = textbox3.Text Then


                    conn = New MySqlConnection
                    Dim con = New MySqlConnection
                    conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
                    Try
                        conn.Open()

                        Dim query As String
                        query = " Insert Into academy.login(username,password,id_national,flag) values('" & textbox1.Text & "','" & textbox2.Text & "','" & textbox4.Text & "','" & flag.Text & "')"
                        com = New MySqlCommand(query, conn)
                        reader = com.ExecuteReader
                        com.Parameters.Clear()
                        reader.Close()
                        MsgBox("لقد قمت بتسجيل مستخدم جديد")
                        textbox1.Clear()
                        textbox2.Clear()
                        textbox3.Clear()
                        textbox4.Clear()
                        flag.Items.Clear()
                        flag.Items.Add("as admin")
                        flag.Items.Add("as user")
                        flag.Items.Add("as HR")
                        flag.Items.Add("as M")
                        flag.Items.Add("as HR_Fees")
                        flag.Items.Add("as STD_Fees")

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conn.Dispose()

                    End Try
                Else
                    MsgBox("كلمه المرور لاتتطابق")
                End If
            End If

        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            If textbox1.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox1, "الرجاء كتابة اسم المستخدم")
                Return
            ElseIf textbox2.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox2, "الرجاء كتابة كلمة المرور")
                Return
            ElseIf textbox3.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox3, "الرجاء كتابة إعادة كلمة المرور")
                Return
            ElseIf textbox4.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox4, "الرجاء كتابة الرقم الوطنى")
            ElseIf flag.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.flag, "الرجاء اختر الصلاحية")


            Else

                ErrorProvider1.Clear()
                If textbox2.Text = textbox3.Text Then


                    conn = New MySqlConnection
                    Dim con = New MySqlConnection
                    conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
                    Try
                        conn.Open()

                        Dim query As String
                        query = " Insert Into academy.login(username,password,id_national,flag) values('" & textbox1.Text & "','" & textbox2.Text & "','" & textbox4.Text & "','" & flag.Text & "')"
                        com = New MySqlCommand(query, conn)
                        reader = com.ExecuteReader
                        com.Parameters.Clear()
                        reader.Close()
                        MsgBox("لقد قمت بتسجيل مستخدم جديد")
                        textbox1.Clear()
                        textbox2.Clear()
                        textbox3.Clear()
                        textbox4.Clear()
                        flag.Items.Clear()
                        flag.Items.Add("as admin")
                        flag.Items.Add("as user")
                        flag.Items.Add("as HR")
                        flag.Items.Add("as M")
                        flag.Items.Add("as HR_Fees")
                        flag.Items.Add("as STD_Fees")

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conn.Dispose()

                    End Try
                Else
                    MsgBox("كلمه المرور لاتتطابق")
                End If
            End If

        End If
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            If textbox1.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox1, "الرجاء كتابة اسم المستخدم")
                Return
            ElseIf textbox2.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox2, "الرجاء كتابة كلمة المرور")
                Return
            ElseIf textbox3.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox3, "الرجاء كتابة إعادة كلمة المرور")
                Return
            ElseIf textbox4.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox4, "الرجاء كتابة الرقم الوطنى")
            ElseIf flag.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.flag, "الرجاء اختر الصلاحية")


            Else

                ErrorProvider1.Clear()
                If textbox2.Text = textbox3.Text Then


                    conn = New MySqlConnection
                    Dim con = New MySqlConnection
                    conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
                    Try
                        conn.Open()

                        Dim query As String
                        query = " Insert Into academy.login(username,password,id_national,flag) values('" & textbox1.Text & "','" & textbox2.Text & "','" & textbox4.Text & "','" & flag.Text & "')"
                        com = New MySqlCommand(query, conn)
                        reader = com.ExecuteReader
                        com.Parameters.Clear()
                        reader.Close()
                        MsgBox("لقد قمت بتسجيل مستخدم جديد")
                        textbox1.Clear()
                        textbox2.Clear()
                        textbox3.Clear()
                        textbox4.Clear()
                        flag.Items.Clear()
                        flag.Items.Add("as admin")
                        flag.Items.Add("as user")
                        flag.Items.Add("as HR")
                        flag.Items.Add("as M")
                        flag.Items.Add("as HR_Fees")
                        flag.Items.Add("as STD_Fees")

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conn.Dispose()

                    End Try
                Else
                    MsgBox("كلمه المرور لاتتطابق")
                End If
            End If

        End If
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Asc(e.KeyChar) = Keys.Enter Then
            If textbox1.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox1, "الرجاء كتابة اسم المستخدم")
                Return
            ElseIf textbox2.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox2, "الرجاء كتابة كلمة المرور")
                Return
            ElseIf textbox3.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox3, "الرجاء كتابة إعادة كلمة المرور")
                Return
            ElseIf textbox4.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox4, "الرجاء كتابة الرقم الوطنى")
            ElseIf flag.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.flag, "الرجاء اختر الصلاحية")


            Else

                ErrorProvider1.Clear()
                If textbox2.Text = textbox3.Text Then


                    conn = New MySqlConnection
                    Dim con = New MySqlConnection
                    conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
                    Try
                        conn.Open()

                        Dim query As String
                        query = " Insert Into academy.login(username,password,id_national,flag) values('" & textbox1.Text & "','" & textbox2.Text & "','" & textbox4.Text & "','" & flag.Text & "')"
                        com = New MySqlCommand(query, conn)
                        reader = com.ExecuteReader
                        com.Parameters.Clear()
                        reader.Close()
                        MsgBox("لقد قمت بتسجيل مستخدم جديد")
                        textbox1.Clear()
                        textbox2.Clear()
                        textbox3.Clear()
                        textbox4.Clear()
                        flag.Items.Clear()
                        flag.Items.Add("as admin")
                        flag.Items.Add("as user")
                        flag.Items.Add("as HR")
                        flag.Items.Add("as M")
                        flag.Items.Add("as HR_Fees")
                        flag.Items.Add("as STD_Fees")

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conn.Dispose()

                    End Try
                Else
                    MsgBox("كلمه المرور لاتتطابق")
                End If
            End If

        End If
    End Sub


    Private Sub MaterialCheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If textbox2.UseSystemPasswordChar = True And textbox3.UseSystemPasswordChar = True Then

            textbox2.UseSystemPasswordChar = False
            textbox3.UseSystemPasswordChar = False
        Else
            textbox2.UseSystemPasswordChar = True
            textbox3.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub إدارةصلاحيهموظفToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles إدارةصلاحيهموظفToolStripMenuItem.Click
        HR_acount.Show()

        HR_acount.Label20.Text = Label14.Text
        HR_acount.Label24.Text = Label13.Text
        HR_acount.Label25.Text = Label12.Text

        Me.Close()

    End Sub

    Private Sub التحكمفىصرفياتالموظفينToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles التحكمفىصرفياتالموظفينToolStripMenuItem.Click
        Dim a As New Form8


        a.Label15.Text = Label14.Text
        a.Label4.Text = Label13.Text
        a.Label19.Text = Label12.Text
        a.ShowDialog()

    End Sub

    Private Sub متابعةحضورالموظفينمتابعةحضورالموظفينToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles متابعةحضورالموظفينمتابعةحضورالموظفينToolStripMenuItem.Click

        staff_atendes.Show()

        staff_atendes.Label15.Text = Label14.Text
        staff_atendes.Label16.Text = Label13.Text
        staff_atendes.Label13.Text = Label12.Text

        Me.Close()

    End Sub

    Private Sub اعداداتموToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles اعداداتموToolStripMenuItem.Click

        HR_add_staff.Show()

        HR_add_staff.Label16.Text = Label14.Text
        HR_add_staff.Label18.Text = Label13.Text
        HR_add_staff.Label19.Text = Label12.Text

        Me.Close()

    End Sub

    Private Sub خروجToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles خروجToolStripMenuItem.Click
        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub

        Else

            Me.Close()
            Form2.Show()
            Form2.textbox2.Clear()
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = Nothing Then

            textbox1.Enabled = False
            textbox2.Enabled = False
            textbox3.Enabled = False
            textbox4.Enabled = False
            CheckBox1.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = False
            flag.Enabled = False

            '''''''''''''''''
            '''
            textbox1.Clear()
            textbox2.Clear()
            textbox3.Clear()
            textbox4.Clear()
            CheckBox1.CheckState = CheckState.Unchecked
            ComboBox1.Text = Nothing

            flag.Items.Clear()
            flag.Items.Add("as admin")
            flag.Items.Add("as user")
            flag.Items.Add("as HR")
            flag.Items.Add("as M")
            flag.Items.Add("as HR_Fees")
            flag.Items.Add("as STD_Fees")


        Else
            adabter = New MySqlDataAdapter
            dtable = New DataTable
            Dim dtable1 = New DataTable


            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try

                conn.Open()

                Dim query As String

                query = " select* from academy.staff where name='" & Me.ComboBox1.Text & "'"

                com = New MySqlCommand(query, conn)

                adabter.SelectCommand = com

                adabter.Fill(dtable)

                If dtable.Rows.Count > 0 Then
                    textbox4.Text = dtable(0)(14)

                    Dim query01 As String

                    query01 = " select* from academy.staff where id_national='" & textbox4.Text & "'"

                    com = New MySqlCommand(query01, conn)

                    adabter.SelectCommand = com

                    adabter.Fill(dtable1)

                    If dtable1.Rows.Count > 0 Then
                        staf_id = dtable1(0)(1)

                    End If


                Else
                        textbox1.Clear()
                    textbox2.Clear()
                    textbox3.Clear()
                    textbox4.Clear()
                    CheckBox1.CheckState = CheckState.Unchecked
                    ComboBox1.Text = Nothing

                    flag.Items.Clear()
                    flag.Items.Add("as admin")
                    flag.Items.Add("as user")
                    flag.Items.Add("as HR")
                    flag.Items.Add("as M")
                    flag.Items.Add("as HR_Fees")
                    flag.Items.Add("as STD_Fees")

                    MsgBox("هنالك خطاء فى الرقم الوطنى او لا يتوفر")
                End If

                flag.Enabled = True
                textbox1.Enabled = True
                textbox2.Enabled = True
                textbox3.Enabled = True
                '        textbox4.Enabled = True

                CheckBox1.Enabled = True

                Button1.Enabled = True
                Button2.Enabled = True



            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()
            End Try


        End If

    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        If ComboBox1.Text = Nothing Then
            flag.Enabled = False
            textbox1.Enabled = False
            textbox2.Enabled = False
            textbox3.Enabled = False
            textbox4.Enabled = False
            CheckBox1.Enabled = False
            Button1.Enabled = False
            Button2.Enabled = False

            ''''''''''''''''''''''''''
            textbox1.Clear()
            textbox2.Clear()
            textbox3.Clear()
            textbox4.Clear()
            CheckBox1.CheckState = CheckState.Unchecked
            ComboBox1.Text = Nothing

            flag.Items.Clear()
            flag.Items.Add("as admin")
            flag.Items.Add("as user")
            flag.Items.Add("as HR")
            flag.Items.Add("as M")
            flag.Items.Add("as HR_Fees")
            flag.Items.Add("as STD_Fees")




        End If

    End Sub
End Class