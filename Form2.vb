
Imports MaterialSkin
Imports MaterialSkin.Controls
Imports MySql.Data.MySqlClient
Imports System.Windows
Imports System

Public Class Form2
    Public ReadOnly vb As MaterialForm
    Dim com As MySqlCommand
    Dim conn As MySqlConnection
    Dim reader As MySqlDataReader
    Dim m_x
    Dim m_y
    Dim a
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        splash.Close()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim u As String = String.Empty
        Dim p As String = String.Empty
        Dim s As String = ""
        If textbox1.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.textbox1, "أدخل أسم المستخدم")
            Return
        ElseIf textbox2.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.textbox2, "أدخل كلمة المرور")
            Return
        Else
            Me.ErrorProvider1.Clear()
            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try
                conn.Open()
                Dim q As String
                q = " select * from academy.login where username='" & textbox1.Text & "' and password='" & textbox2.Text & "'"
                Dim co = New MySqlCommand(q, conn)
                Dim ad As New MySqlDataAdapter(co)
                Dim tabler As New DataTable()


                ad.Fill(tabler)
                If tabler.Rows.Count > 0 Then
                    flag.Text = tabler(0)(7)
                    u = tabler(0)(1)
                    p = tabler(0)(2)
                    process.TextBox1.Clear()
                    process.TextBox2.Clear()
                    process.TextBox1.Text = u
                    process.TextBox2.Text = p
                Else
                    MsgBox("الرجاء التاكد من هوبة المستخدم")
                End If


                Dim query As String
                query = " select password,username,id_national from academy.login where username='" & textbox1.Text & "' and password='" & textbox2.Text & "' and flag='" & flag.Text & "'"
                com = New MySqlCommand(query, conn)
                com.Parameters.Add("username", MySqlDbType.VarChar).Value = textbox1.Text
                com.Parameters.Add("password", MySqlDbType.VarChar).Value = textbox2.Text
                Dim adapter As New MySqlDataAdapter(com)
                Dim table As New DataTable()


                adapter.Fill(table)

                If table.Rows.Count > 0 Then
                    DateTimePicker1.Value = Date.Now
                    Dim qu As String
                    qu = " update academy.login set time_login='" & DateTimePicker1.Value & "' where username='" & textbox1.Text & "'"
                    Dim comm = New MySqlCommand(qu, conn)
                    If comm.ExecuteNonQuery > 0 Then
                        reader = com.ExecuteReader

                        '  MsgBox(DateTimePicker1.Value & "   ..زمن الدخول")

                    Else
                        MsgBox("عذرآ تاكد من اعدادات الوقت")
                    End If


                    If flag.Text = "as admin" Then

                        admin.Label14.Text = textbox1.Text
                        admin.Label12.Text = DateTimePicker1.Value
                        admin.Label13.Text = flag.Text
                        '    Form4.Label14.Text = textbox1.Text
                        '   Form4.Label12.Text = DateTimePicker1.Value
                        '  Form4.Label13.Text = flag.Text
                        ' Form5.Label14.Text = textbox1.Text
                        'Form5.Label12.Text = DateTimePicker1.Value
                        'Form5.Label15.Text = flag.Text

                        Me.Hide()
                        process.Show()

                    ElseIf flag.Text = "as admiston" And u = textbox1.Text And p = textbox2.Text Then
                        PictureBox2.Visible = False
                        PictureBox4.Visible = False
                        PictureBox3.Visible = True

                        '  MsgBox(TextBox1.Text & "    ..مرحبآ")
                        reji.Label14.Text = textbox1.Text
                        reji.Label13.Text = flag.Text
                        reji.Label12.Text = DateTimePicker1.Value

                        Me.Hide()
                        process.Show()

                    ElseIf flag.Text = "as HR" And u = textbox1.Text And p = textbox2.Text Then
                        PictureBox2.Visible = False
                        PictureBox4.Visible = False
                        PictureBox3.Visible = True

                        ' MsgBox(TextBox1.Text & "     ..مرحبآ ")
                        'MessageBox.Show("Okay! We'll play with " & txtNumSticks.Text & "sticks!")
                        Me.Hide()
                        process.Show()

                        HR_add_staff.Label16.Text = textbox1.Text
                        HR_add_staff.Label19.Text = DateTimePicker1.Value
                        HR_add_staff.Label18.Text = flag.Text

                    ElseIf flag.Text = "as Maktba" And u = textbox1.Text And p = textbox2.Text Then
                        PictureBox2.Visible = False
                        PictureBox4.Visible = False
                        PictureBox3.Visible = True

                        '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                        Me.Hide()
                        process.Show()

                        main_book.Label16.Text = textbox1.Text
                        main_book.Label19.Text = DateTimePicker1.Value
                        main_book.Label18.Text = flag.Text

                    ElseIf flag.Text = "as HR_Fees" And u = textbox1.Text And p = textbox2.Text Then
                        PictureBox2.Visible = False
                        PictureBox4.Visible = False
                        PictureBox3.Visible = True

                        MsgBox(textbox1.Text & "     ..مرحبآ ")
                        'MessageBox.Show("Okay! We'll play with " & txtNumSticks.Text & "sticks!")
                        Me.Hide()
                        process.Show()

                        HR_fees.Label15.Text = textbox1.Text
                        HR_fees.Label16.Text = DateTimePicker1.Value
                        HR_fees.Label13.Text = flag.Text

                    ElseIf flag.Text = "as STD_Fees" And u = textbox1.Text And p = textbox2.Text Then
                        PictureBox2.Visible = False
                        PictureBox4.Visible = False
                        PictureBox3.Visible = True

                        '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                        Me.Hide()
                        process.Show()

                        add_fees.Label15.Text = textbox1.Text
                        add_fees.Label13.Text = DateTimePicker1.Value
                        add_fees.Label16.Text = flag.Text

                    ElseIf flag.Text = "as clinc" And u = textbox1.Text And p = textbox2.Text Then
                        PictureBox2.Visible = False
                        PictureBox4.Visible = False
                        PictureBox3.Visible = True

                        '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                        Me.Hide()
                        process.Show()

                        clinic.Label16.Text = textbox1.Text
                        clinic.Label18.Text = DateTimePicker1.Value
                        clinic.Label19.Text = flag.Text

                    ElseIf flag.Text = "as IdCard" And u = textbox1.Text And p = textbox2.Text Then
                        PictureBox2.Visible = False
                        PictureBox4.Visible = False
                        PictureBox3.Visible = True

                        '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                        Me.Hide()
                        process.Show()

                    ElseIf flag.Text = "as mosgel" And u = textbox1.Text And p = textbox2.Text Then
                        PictureBox2.Visible = False
                        PictureBox4.Visible = False
                        PictureBox3.Visible = True

                        '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                        Me.Hide()
                        process.Show()

                    ElseIf flag.Text = "as control" And u = textbox1.Text And p = textbox2.Text Then
                        PictureBox2.Visible = False
                        PictureBox4.Visible = False
                        PictureBox3.Visible = True

                        '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                        Me.Hide()
                        process.Show()

                    Else


                        PictureBox2.Visible = False
                        PictureBox3.Visible = False
                        PictureBox4.Visible = True
                        MsgBox("عذرآ ليس لديك الصلاحيه ")


                    End If
                End If



            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try
        End If


    End Sub



    Protected ReadOnly Property Forms(vb As Form2) As MaterialForm
        Get
            Throw New NotImplementedException()
        End Get
    End Property
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim skinmanager As MaterialSkin.MaterialSkinManager = MaterialSkin.MaterialSkinManager.Instance


        skinmanager.Theme = MaterialSkinManager.Themes.DARK

        skinmanager.ColorScheme = New ColorScheme(Primary.Cyan900, Primary.Indigo300, Primary.Pink100, Accent.Cyan700, TextShade.WHITE)

        skinmanager.ROBOTO_MEDIUM_10 = New Font("Arabic Typesetting", 12)
        skinmanager.ROBOTO_MEDIUM_11 = New Font("Arabic Typesetting", 12)
        skinmanager.ROBOTO_MEDIUM_12 = New Font("Arabic Typesetting", 12)



        textbox1.Enabled = True
        textbox1.Visible = True

        textbox2.Enabled = True
        textbox2.Visible = True


        Me.textbox1.ForeColor = System.Drawing.Color.White
        Me.textbox1.Font = New Font("Arabic Typesetting", 18)

        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Font = New Font("Arabic Typesetting", 24)

        Me.textbox2.ForeColor = System.Drawing.Color.White
        Me.textbox2.Font = New Font("Arabic Typesetting", 18)





        'skinmanager.AddFormToManage(Forms(Me))
        PictureBox2.Visible = True
        PictureBox3.Visible = False
        PictureBox4.Visible = False

    End Sub



    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

        If Me.textbox2.UseSystemPasswordChar = True Then
            Me.textbox2.UseSystemPasswordChar = False
        Else
            Me.textbox2.UseSystemPasswordChar = True

        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Close()
        splash.Close()
    End Sub

    Private Sub textbox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textbox1.KeyPress

        If Asc(e.KeyChar) = Keys.Enter Then

            Dim u As String = String.Empty
            Dim p As String = String.Empty
            Dim s As String = ""
            If textbox1.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox1, "أدخل أسم المستخدم")
                Return
            ElseIf textbox2.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox2, "أدخل كلمة المرور")
                Return
            Else
                Me.ErrorProvider1.Clear()
                conn = New MySqlConnection
                conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
                Try
                    conn.Open()
                    Dim q As String
                    q = " select * from academy.login where username='" & textbox1.Text & "' and password='" & textbox2.Text & "'"
                    Dim co = New MySqlCommand(q, conn)
                    Dim ad As New MySqlDataAdapter(co)
                    Dim tabler As New DataTable()


                    ad.Fill(tabler)
                    If tabler.Rows.Count > 0 Then
                        flag.Text = tabler(0)(7)
                        u = tabler(0)(1)
                        p = tabler(0)(2)
                        process.TextBox1.Clear()
                        process.TextBox2.Clear()
                        process.TextBox1.Text = u
                        process.TextBox2.Text = p
                    Else
                        MsgBox("الرجاء التاكد من هوبة المستخدم")
                    End If


                    Dim query As String
                    query = " select password,username,id_national from academy.login where username='" & textbox1.Text & "' and password='" & textbox2.Text & "' and flag='" & flag.Text & "'"
                    com = New MySqlCommand(query, conn)
                    com.Parameters.Add("username", MySqlDbType.VarChar).Value = textbox1.Text
                    com.Parameters.Add("password", MySqlDbType.VarChar).Value = textbox2.Text
                    Dim adapter As New MySqlDataAdapter(com)
                    Dim table As New DataTable()


                    adapter.Fill(table)

                    If table.Rows.Count > 0 Then
                        DateTimePicker1.Value = Date.Now
                        Dim qu As String
                        qu = " update academy.login set time_login='" & DateTimePicker1.Value & "' where username='" & textbox1.Text & "'"
                        Dim comm = New MySqlCommand(qu, conn)
                        If comm.ExecuteNonQuery > 0 Then
                            reader = com.ExecuteReader

                            '  MsgBox(DateTimePicker1.Value & "   ..زمن الدخول")

                        Else
                            MsgBox("عذرآ تاكد من اعدادات الوقت")
                        End If


                        If flag.Text = "as admin" Then

                            admin.Label14.Text = textbox1.Text
                            admin.Label12.Text = DateTimePicker1.Value
                            admin.Label13.Text = flag.Text
                            '    Form4.Label14.Text = textbox1.Text
                            '   Form4.Label12.Text = DateTimePicker1.Value
                            '  Form4.Label13.Text = flag.Text
                            ' Form5.Label14.Text = textbox1.Text
                            'Form5.Label12.Text = DateTimePicker1.Value
                            'Form5.Label15.Text = flag.Text

                            Me.Hide()
                            process.Show()

                        ElseIf flag.Text = "as admiston" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            '  MsgBox(TextBox1.Text & "    ..مرحبآ")
                            reji.Label14.Text = textbox1.Text
                            reji.Label13.Text = flag.Text
                            reji.Label12.Text = DateTimePicker1.Value

                            Me.Hide()
                            process.Show()

                        ElseIf flag.Text = "as HR" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            ' MsgBox(TextBox1.Text & "     ..مرحبآ ")
                            'MessageBox.Show("Okay! We'll play with " & txtNumSticks.Text & "sticks!")
                            Me.Hide()
                            process.Show()

                            HR_add_staff.Label16.Text = textbox1.Text
                            HR_add_staff.Label19.Text = DateTimePicker1.Value
                            HR_add_staff.Label18.Text = flag.Text

                        ElseIf flag.Text = "as Maktba" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                            Me.Hide()
                            process.Show()

                            main_book.Label16.Text = textbox1.Text
                            main_book.Label19.Text = DateTimePicker1.Value
                            main_book.Label18.Text = flag.Text

                        ElseIf flag.Text = "as HR_Fees" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            MsgBox(textbox1.Text & "     ..مرحبآ ")
                            'MessageBox.Show("Okay! We'll play with " & txtNumSticks.Text & "sticks!")
                            Me.Hide()
                            process.Show()

                            HR_fees.Label15.Text = textbox1.Text
                            HR_fees.Label16.Text = DateTimePicker1.Value
                            HR_fees.Label13.Text = flag.Text

                        ElseIf flag.Text = "as STD_Fees" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                            Me.Hide()
                            process.Show()

                            add_fees.Label15.Text = textbox1.Text
                            add_fees.Label13.Text = DateTimePicker1.Value
                            add_fees.Label16.Text = flag.Text

                        ElseIf flag.Text = "as clinc" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                            Me.Hide()
                            process.Show()

                            clinic.Label16.Text = textbox1.Text
                            clinic.Label18.Text = DateTimePicker1.Value
                            clinic.Label19.Text = flag.Text

                        ElseIf flag.Text = "as IdCard" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                            Me.Hide()
                            process.Show()

                        ElseIf flag.Text = "as mosgel" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                            Me.Hide()
                            process.Show()

                        ElseIf flag.Text = "as control" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                            Me.Hide()
                            process.Show()

                        Else


                            PictureBox2.Visible = False
                            PictureBox3.Visible = False
                            PictureBox4.Visible = True
                            MsgBox("عذرآ ليس لديك الصلاحيه ")


                        End If
                    End If



                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()

                End Try
            End If


        End If

    End Sub

    Private Sub textbox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textbox2.KeyPress

        If Asc(e.KeyChar) = Keys.Enter Then

            Dim u As String = String.Empty
            Dim p As String = String.Empty
            Dim s As String = ""
            If textbox1.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox1, "أدخل أسم المستخدم")
                Return
            ElseIf textbox2.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.textbox2, "أدخل كلمة المرور")
                Return
            Else
                Me.ErrorProvider1.Clear()
                conn = New MySqlConnection
                conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
                Try
                    conn.Open()
                    Dim q As String
                    q = " select * from academy.login where username='" & textbox1.Text & "' and password='" & textbox2.Text & "'"
                    Dim co = New MySqlCommand(q, conn)
                    Dim ad As New MySqlDataAdapter(co)
                    Dim tabler As New DataTable()


                    ad.Fill(tabler)
                    If tabler.Rows.Count > 0 Then
                        flag.Text = tabler(0)(7)
                        u = tabler(0)(1)
                        p = tabler(0)(2)
                        process.TextBox1.Clear()
                        process.TextBox2.Clear()
                        process.TextBox1.Text = u
                        process.TextBox2.Text = p
                    Else
                        MsgBox("الرجاء التاكد من هوبة المستخدم")
                    End If


                    Dim query As String
                    query = " select password,username,id_national from academy.login where username='" & textbox1.Text & "' and password='" & textbox2.Text & "' and flag='" & flag.Text & "'"
                    com = New MySqlCommand(query, conn)
                    com.Parameters.Add("username", MySqlDbType.VarChar).Value = textbox1.Text
                    com.Parameters.Add("password", MySqlDbType.VarChar).Value = textbox2.Text
                    Dim adapter As New MySqlDataAdapter(com)
                    Dim table As New DataTable()


                    adapter.Fill(table)

                    If table.Rows.Count > 0 Then
                        DateTimePicker1.Value = Date.Now
                        Dim qu As String
                        qu = " update academy.login set time_login='" & DateTimePicker1.Value & "' where username='" & textbox1.Text & "'"
                        Dim comm = New MySqlCommand(qu, conn)
                        If comm.ExecuteNonQuery > 0 Then
                            reader = com.ExecuteReader

                            '  MsgBox(DateTimePicker1.Value & "   ..زمن الدخول")

                        Else
                            MsgBox("عذرآ تاكد من اعدادات الوقت")
                        End If



                        If flag.Text = "as admin" Then

                            admin.Label14.Text = textbox1.Text
                            admin.Label12.Text = DateTimePicker1.Value
                            admin.Label13.Text = flag.Text
                            '    Form4.Label14.Text = textbox1.Text
                            '   Form4.Label12.Text = DateTimePicker1.Value
                            '  Form4.Label13.Text = flag.Text
                            ' Form5.Label14.Text = textbox1.Text
                            'Form5.Label12.Text = DateTimePicker1.Value
                            'Form5.Label15.Text = flag.Text

                            Me.Hide()
                            process.Show()

                        ElseIf flag.Text = "as admiston" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            '  MsgBox(TextBox1.Text & "    ..مرحبآ")
                            reji.Label14.Text = textbox1.Text
                            reji.Label13.Text = flag.Text
                            reji.Label12.Text = DateTimePicker1.Value

                            Me.Hide()
                            process.Show()

                        ElseIf flag.Text = "as HR" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            ' MsgBox(TextBox1.Text & "     ..مرحبآ ")
                            'MessageBox.Show("Okay! We'll play with " & txtNumSticks.Text & "sticks!")
                            Me.Hide()
                            process.Show()

                            HR_add_staff.Label16.Text = textbox1.Text
                            HR_add_staff.Label19.Text = DateTimePicker1.Value
                            HR_add_staff.Label18.Text = flag.Text

                        ElseIf flag.Text = "as Maktba" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                            Me.Hide()
                            process.Show()

                            main_book.Label16.Text = textbox1.Text
                            main_book.Label19.Text = DateTimePicker1.Value
                            main_book.Label18.Text = flag.Text

                        ElseIf flag.Text = "as HR_Fees" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            MsgBox(textbox1.Text & "     ..مرحبآ ")
                            'MessageBox.Show("Okay! We'll play with " & txtNumSticks.Text & "sticks!")
                            Me.Hide()
                            process.Show()

                            HR_fees.Label15.Text = textbox1.Text
                            HR_fees.Label16.Text = DateTimePicker1.Value
                            HR_fees.Label13.Text = flag.Text

                        ElseIf flag.Text = "as STD_Fees" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                            Me.Hide()
                            process.Show()

                            add_fees.Label15.Text = textbox1.Text
                            add_fees.Label13.Text = DateTimePicker1.Value
                            add_fees.Label16.Text = flag.Text

                        ElseIf flag.Text = "as clinc" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                            Me.Hide()
                            process.Show()

                            clinic.Label16.Text = textbox1.Text
                            clinic.Label18.Text = DateTimePicker1.Value
                            clinic.Label19.Text = flag.Text

                        ElseIf flag.Text = "as IdCard" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                            Me.Hide()
                            process.Show()

                        ElseIf flag.Text = "as mosgel" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                            Me.Hide()
                            process.Show()

                        ElseIf flag.Text = "as control" And u = textbox1.Text And p = textbox2.Text Then
                            PictureBox2.Visible = False
                            PictureBox4.Visible = False
                            PictureBox3.Visible = True

                            '  MsgBox(TextBox1.Text & "     ..مرحبآ ")
                            Me.Hide()
                            process.Show()

                        Else


                            PictureBox2.Visible = False
                            PictureBox3.Visible = False
                            PictureBox4.Visible = True
                            MsgBox("عذرآ ليس لديك الصلاحيه ")


                        End If
                    End If



                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()

                End Try
            End If


        End If

    End Sub

    Private Sub MenuStrip1_MouseMove(sender As Object, e As MouseEventArgs) Handles MenuStrip1.MouseMove
        If a Then
            Me.Top = Windows.Forms.Cursor.Position.Y - m_y
            Me.Left = Windows.Forms.Cursor.Position.X - m_x

        End If

    End Sub

    Private Sub MenuStrip1_MouseDown(sender As Object, e As MouseEventArgs) Handles MenuStrip1.MouseDown
        a = True
        m_x = Windows.Forms.Cursor.Position.X - Me.Left
        m_y = Windows.Forms.Cursor.Position.Y - Me.Top

    End Sub

    Private Sub MenuStrip1_MouseUp(sender As Object, e As MouseEventArgs) Handles MenuStrip1.MouseUp
        a = False
    End Sub

End Class