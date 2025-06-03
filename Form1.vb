Imports System.Data.SqlClient
Imports MaterialSkin
Imports MySql.Data.MySqlClient
Public Class Form1
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim dtable As DataTable


    Dim gender As String
    Private Function vld(ByVal ParamArray ctl() As Object) As Boolean
        For i As Integer = 0 To UBound(ctl)

            If ctl(i).text = "" Then
                ErrorProvider1.SetError(ctl(i), ctl(i).tag)
                Return False
                Exit Function
            End If
        Next
        Return True
    End Function

    Public Function out(ByVal ctr() As Object)
        DateTimePicker2.Value = Date.Now
        Dim qu As String
        qu = " update academy.login set time_out='" & DateTimePicker2.Value & "' where username='" & Label22.Text & "'"

        Dim comm = New MySqlCommand(qu, conn)
        If comm.ExecuteNonQuery > 0 Then
            reader = comm.ExecuteReader
            MsgBox(DateTimePicker1.Value & "   ..زمن الخروج")

        Else
            MsgBox("عذرآ تاكد من اعدادات الوقت")
        End If
        Return ctr
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        adabter = New MySqlDataAdapter
        bsourc = New BindingSource
        dtable = New DataTable
        'exp()


        Dim skinmanager As MaterialSkin.MaterialSkinManager = MaterialSkin.MaterialSkinManager.Instance


        skinmanager.Theme = MaterialSkinManager.Themes.LIGHT

        skinmanager.ColorScheme = New ColorScheme(Primary.Cyan500, Primary.Indigo300, Primary.Pink100, Accent.Cyan700, TextShade.WHITE)



        TextBox1.Enabled = True
        TextBox1.Visible = True



        Me.TextBox1.ForeColor = System.Drawing.Color.BurlyWood
        Me.TextBox1.Font = New Font("Arabic Typesetting", 18)



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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim f_class As String = "الفصل الاول"
        Dim reji_pay As Double = 100

        Try

            If Id_stdTextBox.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.Id_stdTextBox, "إدخال الرقم الجامعى من ألتعليم العالى")
                Return
            ElseIf Name_stdTextBox.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.Name_stdTextBox, "إدخال اسم الطالب")
                Return
            ElseIf TextBox2.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.TextBox2, "إدخال الرقم الجامعى للطالب بالكلية ")
                Return
            ElseIf Nam_motherTextBox.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.Nam_motherTextBox, "إدخال اسم الوالدة")
                Return
            ElseIf ComboBox6.SelectedItem = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox6, "اختار الجنسية")
            ElseIf Birth_dayDateTimePicker.Checked = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.Birth_dayDateTimePicker, "ادخل تاريخ الميلاد")
            ElseIf National_idTextBox.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.National_idTextBox, "ادخل الرقم الوطنى")
            ElseIf gender = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.RadioButton1, "اختر ألنوع")
            ElseIf Certifcate_typeTextBox.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.Certifcate_typeTextBox, "ادخل اسم المدرسة الثانوية ")
            ElseIf ComboBox2.SelectedItem = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox2, "اختر النظام الدراسى")
            ElseIf ComboBox1.SelectedItem = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox1, "اختر المثاق العلمى")
            ElseIf ComboBox3.SelectedItem = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox3, "اختر نوع الشهادة")
            ElseIf School_degreTextBox.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.School_degreTextBox, "ادخل نسبة القبول")
            ElseIf DateTimePicker1.Checked = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.DateTimePicker1, "اختر تاريخ التخرج من المدرسة ")
            ElseIf ComboBox5.SelectedItem = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox5, " اختر اسم الكلية المراد الالتحاق بها")
            ElseIf ComboBox4.SelectedItem = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox4, "اختر اسم القسم المراد الالتحاق به")
            ElseIf ComboBox7.SelectedItem = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox7, "اختر الدرجة العلمية المراد نيلها")
            ElseIf Time_accept_univDateTimePicker.Checked = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.Time_accept_univDateTimePicker, "تاريخ القبول فى الجامعة")
            ElseIf DateTimePicker3.Checked = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.DateTimePicker3, "الدفعه")
            ElseIf ComboBox8.SelectedItem = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox8, "اختر فئة للتسجيل")
            ElseIf TextBox1.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.TextBox1, "الرسوم الدراسية")

            Else
                ErrorProvider1.Clear()

                conn = New MySqlConnection
                '   Dim con = New MySqlConnection
                conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
                conn.Open()
                If School_degreTextBox.Text < 50 Then
                    MsgBox(" عذرآ نتيجة هذا الطالب غير مطابقه للشروط والوائح")
                Else
                    Try
                        Dim ms As New System.IO.MemoryStream()
                        PictureBox3.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                        Dim bytImage() As Byte = ms.GetBuffer()
                        ms.Close()

                        Dim query As String
                        query = " Insert Into academy.std_info(name_std, id_std,id_std_h, colage, department, nationa_id, birth_day, name_mother, certifcate_type, time_accept_uni, gender, nationalti, persent_school,certificate_class,school_name,school_degre,end_date_school,depart_certificate,pay_fees,semester,patch,pic,active) values('" & Name_stdTextBox.Text & "','" & TextBox2.Text & "','" & Id_stdTextBox.Text & "','" & ComboBox5.Text & "','" & ComboBox4.Text & "','" & National_idTextBox.Text & "','" & Birth_dayDateTimePicker.Text & "','" & Nam_motherTextBox.Text & "','" & ComboBox3.Text & "','" & Time_accept_univDateTimePicker.Text & "','" & gender & "','" & ComboBox6.Text & "','" & ComboBox1.Text & "','" & ComboBox2.Text & "','" & Certifcate_typeTextBox.Text & "','" & School_degreTextBox.Text & "','" & DateTimePicker1.Text & "','" & ComboBox7.Text & "','" & TextBox1.Text & "','" & f_class & "','" & DateTimePicker3.Text & "',@pic,'" & 0 & "')"
                        com = New MySqlCommand(query, conn)
                        com.Parameters.AddWithValue("@pic", bytImage)


                        reader = com.ExecuteReader
                        com.Parameters.Clear()
                        reader.Close()
                        Dim qu As String

                        qu = " Insert Into academy.payment(std_id,pay_fees,price_rejisteration,semester,patch,active) values('" & TextBox2.Text & "','" & TextBox1.Text & "','" & reji_pay & "','" & f_class & "','" & DateTimePicker3.Text & "','" & 0 & "')"
                        Dim comm = New MySqlCommand(qu, conn)
                        Dim readerr = comm.ExecuteReader
                        comm.Parameters.Clear()
                        readerr.Close()


                        Dim qy2 As String
                        Dim tb As New DataTable

                        qy2 = " select* from academy.record_academy where semester ='" & f_class & "' and colage ='" & ComboBox5.Text & "' and depart_name='" & ComboBox4.Text & "' and depart_certificate='" & ComboBox7.Text & "'"
                        Dim cm = New MySqlCommand(qy2, conn)
                        adabter.SelectCommand = cm
                        adabter.Fill(tb)
                        reader = cm.ExecuteReader
                        Dim n As String = ""
                        While reader.Read

                            n = reader.GetString("lecture")
                            ListBox1.Items.Add(n)
                            MsgBox(n)

                        End While

                        reader.Close()

                        If tb.Rows.Count > 0 Then
                            MsgBox(tb.Rows.Count)


                            For Each b In ListBox1.Items

                                Dim q5 = " Insert Into academy.std_atendess(active,std_id,lecture,semester,lec1,lec2,lec3,lec4,lec5,lec6,lec7,lec8,lec9,lec10,lec11,lec12,patch) values('" & 0 & "','" & TextBox2.Text & "',  '" & b & "',  '" & f_class & "',  '" & 0 & "',  '" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "' ,'" & DateTimePicker3.Text & "')"
                                com = New MySqlCommand(q5, conn)
                                reader.Close()
                                reader = com.ExecuteReader

                            Next

                        End If

                        Dim qq1 As String = ""
                        Dim de As String = "'" + Name_stdTextBox.Text + "/" + TextBox2.Text + "/" + Id_stdTextBox.Text + "'"
                        Dim mass As String = de & "لقد تم اضافة طالب جديد "

                        qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label23.Text & "','" & Label22.Text & "' )"

                        com = New MySqlCommand(qq1, conn)
                        MsgBox("لقد تم اضافة طالب جديد")


                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                    '''''''''''''تهيئة '''''''''''''
                    Time_accept_univDateTimePicker.Value = Nothing
                    DateTimePicker3.Value = Nothing
                    TextBox2.Clear()

                    TextBox2.Clear()
                    Name_stdTextBox.Text = Nothing
                    Id_stdTextBox.Text = Nothing
                    ComboBox5.Text = "أختر كلية"
                    ComboBox4.Text = Nothing
                    National_idTextBox.Text = Nothing
                    Birth_dayDateTimePicker.Text = Nothing
                    Nam_motherTextBox.Text = Nothing
                    ComboBox3.Text = "أختر نوع ألشهادة"
                    Time_accept_univDateTimePicker.Text = Nothing
                    gender = Nothing
                    ComboBox6.Text = "أختر نوع الجنسيه"
                    Id_stdTextBox.Text = Nothing
                    ComboBox2.Text = "ألنظام الدراسى"
                    Certifcate_typeTextBox.Text = Nothing
                    School_degreTextBox.Text = Nothing
                    DateTimePicker1.Text = Nothing
                    ComboBox1.Text = "أختر المساق"
                    gender = Nothing
                    ComboBox7.Text = "أختر الدرجه العلميه"
                    ComboBox8.Text = ""
                    TextBox1.Clear()

                    '''''''''''''''''''''''''''''''''
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gender = "ذكر"
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gender = "أنثى"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Time_accept_univDateTimePicker.Value = Nothing
        DateTimePicker3.Value = Nothing
        TextBox2.Clear()
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        ErrorProvider1.Clear()
        Name_stdTextBox.Text = Nothing
        Id_stdTextBox.Text = Nothing
        ComboBox5.Text = "أختر كلية"
        ComboBox4.Text = Nothing
        National_idTextBox.Text = Nothing
        Birth_dayDateTimePicker.Text = Nothing
        Nam_motherTextBox.Text = Nothing
        ComboBox3.Text = "أختر نوع ألشهادة"
        Time_accept_univDateTimePicker.Text = Nothing
        gender = Nothing
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        ComboBox6.Text = "أختر نوع الجنسيه"
        Id_stdTextBox.Text = Nothing
        ComboBox2.Text = "ألنظام الدراسى"
        Certifcate_typeTextBox.Text = Nothing
        School_degreTextBox.Text = Nothing
        DateTimePicker1.Text = Nothing
        ComboBox1.Text = "أختر المساق"
    End Sub



    Private Sub السجلالماليToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles السجلالماليToolStripMenuItem.Click
        Form3.Label9.Text = Label22.Text
        Form3.Label13.Text = Label23.Text
        Form3.Label12.Text = Label18.Text
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub خروجToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles خروجToolStripMenuItem.Click
        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub
        Else

            DateTimePicker2.Value = Date.Now

            Me.Close()
            Form2.Show()
            Form2.textbox2.Clear()

        End If

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        DateTimePicker3.Format = DateTimePickerFormat.Custom
        DateTimePicker3.CustomFormat = "yyyy"
        Dim dt As String = DateTimePicker3.CustomFormat = "yyy"

        Me.TextBox2.Text = (Me.ComboBox4.Text + " " + DateTimePicker3.Text + "/ " + Me.Name_stdTextBox.Text + "/")
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
                ComboBox7.Items.Clear()

                Dim sname = reader.GetString("department")
                If sname = "بكالاريوس+دبلوم" Then
                    ComboBox7.Items.Add("بكالاريوس")
                    ComboBox7.Items.Add("دبلوم")
                Else
                    ComboBox7.Items.Add(sname)
                End If

            End While




        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged
        Dim adabter = New MySqlDataAdapter
        Dim bsourc = New BindingSource
        Dim dtable = New DataTable
        Dim table = New DataTable


        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try

            conn.Open()
            Dim query As String
            query = " select* from academy.dep_fees where colage='" & ComboBox5.Text & "' and dep_name='" & ComboBox4.Text & "'and department='" & ComboBox7.Text & "'"
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)

            While reader.Read
                Dim sname = reader.GetString("fees")
                Dim fees As Double

                com.Parameters.Clear()
                If ComboBox8.Text = "تسجيل عام" Then
                    fees = sname
                    TextBox1.Text = fees

                ElseIf ComboBox8.Text = "تسجيل خاص" Then
                    fees = sname
                    Dim f = fees / 30
                    fees = fees + f
                    TextBox1.Text = fees
                ElseIf ComboBox8.Text = "تسجيل ابناء عاملين" Then
                    fees = sname
                    Dim f = fees / 70
                    fees = fees - f
                    TextBox1.Text = fees
                Else
                    MsgBox("عذرآ يجب ان تختار فئة")
                End If

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub النتيجةالنهائيهToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        result.Label16.Text = Label22.Text
        result.Label18.Text = Label23.Text
        result.Label19.Text = Label18.Text
        result.Show()

        Me.Close()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim op As New OpenFileDialog
        op.Filter = "Choose image(*.jpg;*.png;*.Gif;)|*.jpg;*.png;*.Gif;"
        If op.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox3.Image = Image.FromFile(op.FileName)
        End If
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Dim no As New note
        no.ShowDialog()
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        mosgel.Label14.Text = Label22.Text
        mosgel.Label13.Text = Label23.Text
        mosgel.Label12.Text = Label18.Text
        mosgel.Show()

        Me.Close()

    End Sub

    Private Sub RadioButton22_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        gender = "ذكر"
    End Sub

    Private Sub RadioButton11_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        gender = "أنثى"
    End Sub

    Private Sub School_degreTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles School_degreTextBox.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub قـــبولطــالبمنالتعليمالعالىToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles قـــبولطــالبمنالتعليمالعالىToolStripMenuItem.Click
        tagmeed.Label4.Text = Label22.Text
        tagmeed.Label13.Text = Label23.Text
        tagmeed.Label12.Text = Label18.Text
        tagmeed.Show()
        Me.Close()

    End Sub
End Class
