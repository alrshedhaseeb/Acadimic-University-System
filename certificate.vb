Imports MySql.Data.MySqlClient
Public Class certificate

    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim dtable As DataTable
    Dim tb As DataTable
    Dim re As MySqlDataReader
    Dim flag As Integer = 0
    Dim flag_t As Integer = 0
    Dim flag_lang As Integer = 0
    Dim colage As String
    Dim department As String
    Dim degreed As String
    Dim gradee As String
    Dim res As Image

    Private Sub خروجToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles خروجToolStripMenuItem.Click
        Me.Close()

    End Sub


    Private Sub certificate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        If flag = 1 Then

            Dim adabter = New MySqlDataAdapter
            Dim bsourc = New BindingSource
            Dim dtable = New DataTable
            DataGridView1.Columns.Clear()


            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try

                DataGridView1.Columns.Clear()

                conn.Open()

                Dim query As String
                query = " select id_std_h as'الرقم الجامعى من التعليم العالى',id_std as'الرقم الجامعى',name_std as'اسم الطالب' from academy.std_info where colage='" & ComboBox5.Text & "' AND department='" & ComboBox4.Text & "' AND depart_certificate='" & ComboBox2.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "'"
                com = New MySqlCommand(query, conn)
                adabter.SelectCommand = com
                adabter.Fill(dtable)

                If dtable.Rows.Count > 0 Then
                    DataGridView1.DataSource = dtable

                Else
                    MsgBox("عذرآ لايوجد سجلات للطلاب")
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try





        Else
            MsgBox("عذرآ الرجاء تحديد نوع البحث عن الطالب")
            DataGridView1.Columns.Clear()


        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

        Try
            If CheckBox2.Checked = True Then
                CheckBox1.Checked = False

                CheckBox3.Enabled = True
                CheckBox4.Enabled = True
                CheckBox5.Enabled = True

                Label5.Visible = True
                Label6.Visible = True
                Label13.Visible = True
                Label17.Visible = True

                ComboBox2.Visible = True
                ComboBox4.Visible = True
                ComboBox5.Visible = True
                ComboBox6.Visible = True

                Button1.Visible = False
                Button1.Enabled = False

                TextBox1.Visible = False
                Label7.Visible = False

                flag = 1
            ElseIf CheckBox2.Checked = False And CheckBox1.Checked = False Then

                CheckBox3.Checked = False
                CheckBox4.Checked = False
                CheckBox5.Checked = False
                CheckBox6.Checked = False
                CheckBox7.Checked = False

                CheckBox3.Enabled = False
                CheckBox4.Enabled = False
                CheckBox5.Enabled = False
                CheckBox6.Enabled = False
                CheckBox7.Enabled = False

                Button2.Enabled = False
                Label5.Visible = True
                Label6.Visible = True
                Label13.Visible = True
                Label17.Visible = True

                ComboBox2.Visible = True
                ComboBox4.Visible = True
                ComboBox5.Visible = True
                ComboBox6.Visible = True

                TextBox1.Visible = False
                Label7.Visible = False

                flag = 0

                DataGridView1.Columns.Clear()

                TextBox1.Clear()

                ComboBox2.Items.Clear()
                ComboBox4.Items.Clear()
                ComboBox5.Text = Nothing
                ComboBox6.Text = Nothing

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Try

            If CheckBox1.Checked = True Then
                CheckBox2.Checked = False


                CheckBox3.Enabled = True
                CheckBox4.Enabled = True
                CheckBox5.Enabled = True

                flag = 2

                Label5.Visible = False
                Label6.Visible = False
                Label13.Visible = False
                Label17.Visible = False

                ComboBox2.Visible = False
                ComboBox4.Visible = False
                ComboBox5.Visible = False
                ComboBox6.Visible = False
                Button1.Visible = True

                TextBox1.Visible = True
                Label7.Visible = True

            ElseIf CheckBox2.Checked = False And CheckBox1.Checked = False Then

                CheckBox3.Checked = False
                CheckBox4.Checked = False
                CheckBox5.Checked = False
                CheckBox6.Checked = False
                CheckBox7.Checked = False

                CheckBox3.Enabled = False
                CheckBox4.Enabled = False
                CheckBox5.Enabled = False
                CheckBox6.Enabled = False
                CheckBox7.Enabled = False


                Label5.Visible = True
                Label6.Visible = True
                Label13.Visible = True
                Label17.Visible = True

                ComboBox2.Visible = True
                ComboBox4.Visible = True
                ComboBox5.Visible = True
                ComboBox6.Visible = True

                TextBox1.Visible = False
                Label7.Visible = False
                Button1.Visible = False
                Button1.Enabled = False


                flag = 0

                DataGridView1.Columns.Clear()

                TextBox1.Clear()

                ComboBox2.Items.Clear()
                ComboBox4.Items.Clear()
                ComboBox5.Text = Nothing
                ComboBox6.Text = Nothing

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False

            flag_t = 3

            CheckBox6.Enabled = True
            CheckBox7.Enabled = True
        ElseIf CheckBox3.Checked = False And CheckBox3.Checked = False And CheckBox3.Checked = False Then
            CheckBox6.Enabled = False
            CheckBox7.Enabled = False
            flag_t = 0
            DataGridView1.Columns.Clear()

        End If

    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            CheckBox3.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False

            flag_t = 4

            CheckBox6.Enabled = True
            CheckBox7.Enabled = True

        ElseIf CheckBox3.Checked = False And CheckBox3.Checked = False And CheckBox3.Checked = False Then
            CheckBox6.Enabled = False
            CheckBox7.Enabled = False
            flag_t = 0

            DataGridView1.Columns.Clear()

        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = True Then
            CheckBox4.Checked = False
            CheckBox3.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False

            flag_t = 5

        ElseIf CheckBox3.Checked = False And CheckBox3.Checked = False And CheckBox3.Checked = False Then
            CheckBox6.Enabled = False
            CheckBox7.Enabled = False
            flag_t = 0

            DataGridView1.Columns.Clear()

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If flag = 2 Then

            DataGridView1.Columns.Clear()

            Dim adabter = New MySqlDataAdapter
            Dim bsourc = New BindingSource
            Dim dtable = New DataTable


            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try


                conn.Open()
                tb = New DataTable

                Dim query0101 As String
                query0101 = " select * from academy.result_year where std_id='" & TextBox1.Text & "' and year='السنةالرابعه' or std_id='" & TextBox1.Text & "' and year='السنةالخامسه' and active='" & 0 & "'"

                Dim com = New MySqlCommand(query0101, conn)

                adabter.SelectCommand = com
                adabter.Fill(tb)


                Dim query0 As String
                query0 = " select id_std_h as'الرقم الجامعى من التعليم العالى',name_std as 'اسم الطالب',colage as'الكلية',department  as 'القسم',depart_certificate as 'الدرجة العلمية' from academy.std_info where id_std='" & TextBox1.Text & "' or id_std_h= '" & TextBox1.Text & "' and active='" & 0 & "'"

                com = New MySqlCommand(query0, conn)

                adabter.SelectCommand = com
                adabter.Fill(dtable)

                If dtable.Rows.Count > 0 Then
                    DataGridView1.DataSource = dtable

                    If tb.Rows.Count > 0 Then


                        If flag_t = 3 Then ''''''certify ''''''''

                            If flag_lang = 1 Then ''''''EN''''''

                                If DataGridView1.Rows(0).Cells(4).Value.ToString = "بكالاريوس" Then
                                    degreed = "B.SC."
                                ElseIf DataGridView1.Rows(0).Cells(4).Value.ToString = "دبلوم" Then
                                    degreed = "D.SC."
                                End If

                                If tb(0)(5) = "مقبول" Then
                                    gradee = "PASS"
                                ElseIf tb(0)(5) = "جيد" Then
                                    gradee = "Good"
                                ElseIf tb(0)(5) = "جيد جدآ" Then
                                    gradee = "Very Good"
                                ElseIf tb(0)(5) = "ممتاز" Then
                                    gradee = "Excelent"
                                Else
                                    MsgBox("رسوووب")
                                End If

                                If DataGridView1.Rows(0).Cells(2).Value.ToString = "علوم حاسوب" Then

                                    colage = "Computer of Scince and Tichnology"

                                ElseIf DataGridView1.Rows(0).Cells(2).Value.ToString = "نظم معلومات" Then

                                    colage = "Computer of Scince and Tichnology"

                                End If



                                If DataGridView1.Rows(0).Cells(3).Value.ToString = "تقنية معلومات" Then

                                    department = "In : Information Tichnology"

                                ElseIf DataGridView1.Rows(0).Cells(2).Value.ToString = "نظم معلومات" Then

                                    department = "In : Computer of Scince and Tichnology"

                                End If
                            Else '''''''AR''''''
                                gradee = ""
                                gradee = tb(0)(5)
                                degreed = DataGridView1.Rows(0).Cells(4).Value.ToString
                                colage = DataGridView1.Rows(0).Cells(2).Value.ToString
                                department = DataGridView1.Rows(0).Cells(3).Value.ToString

                            End If


                        ElseIf flag_t = 4 Then '''''''''efadha'''''''




                        ElseIf flag_t = 5 Then '''''''''''tfaseel''''''''''''''




                        End If

                    Else '''''''''not found grade from result year'''''
                        MsgBox("عذرآ هذا الطالب لم يتخرج بعد")
                    End If

                Else
                    MsgBox("عذرآ لايوجد سجلات للطلاب")
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try



        Else
            MsgBox("عذرآ الرجاء تحديد نوع البحث عن الطالب")


        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If Me.TextBox1.Text = Nothing Then

            Button1.Enabled = False

        Else

            Button1.Enabled = True



        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        flag = 0

        DataGridView1.Columns.Clear()

        TextBox1.Clear()

        ComboBox2.Items.Clear()
        ComboBox4.Items.Clear()
        ComboBox5.Text = Nothing
        ComboBox6.Text = Nothing

        CheckBox1.Checked = False
        CheckBox2.Checked = False

        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False

        DataGridView18.Columns.Clear()
        DataGridView10.Columns.Clear()
        DataGridView11.Columns.Clear()
        DataGridView12.Columns.Clear()
        DataGridView13.Columns.Clear()
        DataGridView14.Columns.Clear()
        DataGridView15.Columns.Clear()
        DataGridView16.Columns.Clear()
        DataGridView17.Columns.Clear()
        DataGridView18.Columns.Clear()
        DataGridView2.Columns.Clear()
        DataGridView3.Columns.Clear()
        DataGridView4.Columns.Clear()
        DataGridView5.Columns.Clear()
        DataGridView6.Columns.Clear()
        DataGridView7.Columns.Clear()
        DataGridView8.Columns.Clear()
        DataGridView9.Columns.Clear()
        DataGridView23.Columns.Clear()
        DataGridView24.Columns.Clear()
        DataGridView25.Columns.Clear()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If flag = 2 Then

            Try

                If flag_t = 3 Then
                    If flag_lang = 1 Then ''''''print_EN'''''certify''''

                        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                            PrintDocument1.Print()
                            PrintPreviewDialog1.Document = PrintDocument1
                            Dim qq1 As String = ""
                            Dim de As String = "'" + ComboBox5.Text + "'"
                            Dim mass As String = de & "لقد تم استخراج شهادة تخرانجليزى للطالب"

                            qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label18.Text & "','" & Label16.Text & "' )"

                            com = New MySqlCommand(qq1, conn)
                            'PrintPreviewDialog1.ShowDialog()
                        End If

                    Else ''''''print_AR'''''certify''''

                        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                            PrintDocument4.Print()
                            PrintPreviewDialog1.Document = PrintDocument1
                            'PrintPreviewDialog1.ShowDialog()
                            Dim qq1 As String = ""
                            Dim de As String = "'" + ComboBox5.Text + "'"
                            Dim mass As String = de & "لقد تم استخراج شهادة تخرج عربى للطالب"

                            qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label18.Text & "','" & Label16.Text & "' )"

                            com = New MySqlCommand(qq1, conn)
                        End If

                    End If

                ElseIf flag_t = 4 Then

                    If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                        PrintDocument2.Print()
                        PrintPreviewDialog1.Document = PrintDocument1
                        'PrintPreviewDialog1.ShowDialog()
                    End If

                ElseIf flag_t = 5 Then



                    If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                        PrintDocument3.Print()
                        PrintPreviewDialog1.Document = PrintDocument1
                        'PrintPreviewDialog1.ShowDialog()
                    End If

                End If


            Catch ex As Exception
                MsgBox(ex.Message)

            End Try


        ElseIf flag = 1 Then

            Try

                If flag_t = 3 Then
                    If flag_lang = 1 Then ''''''print_EN'''''certify''''

                        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                            PrintDocument1.Print()
                            PrintPreviewDialog1.Document = PrintDocument1
                            'PrintPreviewDialog1.ShowDialog()
                        End If

                    Else ''''''print_AR'''''certify''''

                        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

                            PrintDocument4.Print()
                            PrintPreviewDialog1.Document = PrintDocument1
                            'PrintPreviewDialog1.ShowDialog()
                        End If

                    End If

                ElseIf flag_t = 4 Then

                    If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                        PrintDocument2.Print()
                        PrintPreviewDialog1.Document = PrintDocument1
                        'PrintPreviewDialog1.ShowDialog()
                    End If

                ElseIf flag_t = 5 Then



                    If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                        PrintDocument3.Print()
                        PrintPreviewDialog1.Document = PrintDocument1
                        'PrintPreviewDialog1.ShowDialog()
                    End If

                End If


            Catch ex As Exception
                MsgBox(ex.Message)

            End Try


        End If

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        If flag = 2 Then

            Dim x As String = " بسم الله الرحمن الرحيم"
            Dim repuplic As String = " جمهورية السودان"
            Dim repuplic1 As String = " Republic of Sudan"
            Dim unv As String = " جامعة الصفا"
            Dim unv1 As String = " University of Alsafa Aviation college"

            Dim header_unv As String = "Faculty of " & colage
            Dim std_no As String = "Student No .................. "
            Dim id As String = DataGridView18.Rows(0).Cells(0).Value.ToString
            Dim typ As String = "Certificate"
            Dim a As String = "This is Certify That"
            Dim name As String = DataGridView18.Rows(0).Cells(3).Value.ToString
            Dim awarded As String = "has been awarded the degree of : "
            Dim degree As String = degreed
            Dim inn As String = "In : " & department
            Dim grade As String = "Withe grade : " & gradee

            Dim dat As String = "By The Academic Council On The " & Date.Now.ToString("dd") & " th .day of " & Date.Now.ToString("mm,yyy")


            Dim res As Image
            Dim newimgsize As New Size(100, 100)

            res = New Bitmap(PictureBox1.Image, newimgsize)

            '''''''''''''''''''''''''''



            e.Graphics.DrawString(x, New Font("Arabic Typesetting", 12, FontStyle.Regular), New SolidBrush(Color.Black), New Point(405, 60))
            e.Graphics.DrawString(repuplic, New Font("Arabic Typesetting", 16, FontStyle.Bold), New SolidBrush(Color.Black), New Point(400, 75))

            e.Graphics.DrawString(repuplic1, New Font("Arabic Typesetting", 16, FontStyle.Bold), New SolidBrush(Color.Black), New Point(385, 100))
            e.Graphics.DrawString(unv, New Font("Arabic Typesetting", 20, FontStyle.Bold), New SolidBrush(Color.Black), New Point(400, 120))

            e.Graphics.DrawString(unv1, New Font("Arabic Typesetting", 20, FontStyle.Bold), New SolidBrush(Color.Black), New Point(300, 150))

            e.Graphics.DrawString(std_no, New Font("Arabic Typesetting", 14, FontStyle.Italic), New SolidBrush(Color.Black), New Point(100, 180))
            e.Graphics.DrawString(id, New Font("Arabic Typesetting", 14, FontStyle.Regular), New SolidBrush(Color.Black), New Point(180, 177))

            e.Graphics.DrawString(header_unv, New Font("Arabic Typesetting", 18, FontStyle.Bold), New SolidBrush(Color.Black), New Point(280, 180))

            e.Graphics.DrawString(typ, New Font("Arabic Typesetting", 36, FontStyle.Bold), New SolidBrush(Color.Black), New Point(380, 270))
            e.Graphics.DrawString(a, New Font("Arabic Typesetting", 20, FontStyle.Italic), New SolidBrush(Color.Black), New Point(380, 350))

            e.Graphics.DrawString(name, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 400))
            e.Graphics.DrawString(awarded, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 450))

            e.Graphics.DrawString(degree, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 500))
            e.Graphics.DrawString(inn, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 550))

            e.Graphics.DrawString(grade, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 600))
            e.Graphics.DrawString(dat, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 650))

            e.Graphics.DrawImage(res, 690, 100)

        ElseIf flag = 1 Then


            Dim x As String = " بسم الله الرحمن الرحيم"
            Dim repuplic As String = " جمهورية السودان"
            Dim repuplic1 As String = " Republic of Sudan"
            Dim unv As String = " جامعة الصفا"
            Dim unv1 As String = " University of Alsafa Aviation college"

            Dim header_unv As String = "Faculty of " & colage
            Dim std_no As String = "Student No .................. "
            Dim id As String = DataGridView18.Rows(0).Cells(0).Value.ToString
            Dim typ As String = "Certificate"
            Dim a As String = "This is Certify That"
            Dim name As String = DataGridView18.Rows(0).Cells(3).Value.ToString
            Dim awarded As String = "has been awarded the degree of : "
            Dim degree As String = degreed
            Dim inn As String = "In : " & department
            Dim grade As String = "Withe grade : " & gradee

            Dim dat As String = "By The Academic Council On The " & Date.Now.ToString("dd") & " th .day of " & Date.Now.ToString("mm,yyy")


            Dim res As Image
            Dim newimgsize As New Size(100, 100)

            res = New Bitmap(PictureBox1.Image, newimgsize)

            '''''''''''''''''''''''''''



            e.Graphics.DrawString(x, New Font("Arabic Typesetting", 12, FontStyle.Regular), New SolidBrush(Color.Black), New Point(405, 60))
            e.Graphics.DrawString(repuplic, New Font("Arabic Typesetting", 16, FontStyle.Bold), New SolidBrush(Color.Black), New Point(400, 75))

            e.Graphics.DrawString(repuplic1, New Font("Arabic Typesetting", 16, FontStyle.Bold), New SolidBrush(Color.Black), New Point(385, 100))
            e.Graphics.DrawString(unv, New Font("Arabic Typesetting", 20, FontStyle.Bold), New SolidBrush(Color.Black), New Point(400, 120))

            e.Graphics.DrawString(unv1, New Font("Arabic Typesetting", 20, FontStyle.Bold), New SolidBrush(Color.Black), New Point(300, 150))

            e.Graphics.DrawString(std_no, New Font("Arabic Typesetting", 14, FontStyle.Italic), New SolidBrush(Color.Black), New Point(100, 180))
            e.Graphics.DrawString(id, New Font("Arabic Typesetting", 14, FontStyle.Regular), New SolidBrush(Color.Black), New Point(180, 177))

            e.Graphics.DrawString(header_unv, New Font("Arabic Typesetting", 18, FontStyle.Bold), New SolidBrush(Color.Black), New Point(280, 180))

            e.Graphics.DrawString(typ, New Font("Arabic Typesetting", 36, FontStyle.Bold), New SolidBrush(Color.Black), New Point(380, 270))
            e.Graphics.DrawString(a, New Font("Arabic Typesetting", 20, FontStyle.Italic), New SolidBrush(Color.Black), New Point(380, 350))

            e.Graphics.DrawString(name, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 400))
            e.Graphics.DrawString(awarded, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 450))

            e.Graphics.DrawString(degree, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 500))
            e.Graphics.DrawString(inn, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 550))

            e.Graphics.DrawString(grade, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 600))
            e.Graphics.DrawString(dat, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 650))

            e.Graphics.DrawImage(res, 690, 100)

        End If

    End Sub

    Private Sub PrintDocument2_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument2.PrintPage


    End Sub

    Private Sub PrintDocument3_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument3.PrintPage
        Dim x As String = " بسم الله الرحمن الرحيم"
        Dim repuplic As String = " جمهورية السودان"
        Dim repuplic1 As String = " Republic of Sudan"
        Dim unv As String = " جامعة الصفا"
        Dim unv1 As String = " University of Alsafa Aviation college"

        Dim header_unv As String = "Faculty of " & DataGridView1.Rows(0).Cells(2).Value.ToString & " and " & DataGridView1.Rows(0).Cells(3).Value.ToString
        Dim std_no As String = "Student No .................. "
        Dim id As String = DataGridView1.Rows(0).Cells(0).Value.ToString
        Dim typ As String = "إفـادة تخـرج"
        Dim a As String = "This is Certify That"
        Dim name As String = DataGridView1.Rows(0).Cells(1).Value.ToString
        Dim awarded As String = "has been awarded the degree of : "
        Dim degree As String = "B.SC."
        Dim inn As String = "In : " & DataGridView1.Rows(0).Cells(3).Value.ToString
        Dim grade As String = "Withe grade : " & DataGridView1.Rows(0).Cells(0).Value.ToString

        Dim dat As String = "By The Academic Council On The " & Date.Now.ToString("dd") & " th .day of " & Date.Now.ToString("mm,yyy")


        Dim res As Image
        Dim newimgsize As New Size(100, 100)

        res = New Bitmap(PictureBox1.Image, newimgsize)

        '''''''''''''''''''''''''''

        e.Graphics.DrawImage(res, 690, 100)


        e.Graphics.DrawString(x, New Font("Arabic Typesetting", 12, FontStyle.Regular), New SolidBrush(Color.Black), New Point(405, 60))
        e.Graphics.DrawString(repuplic, New Font("Arabic Typesetting", 16, FontStyle.Bold), New SolidBrush(Color.Black), New Point(400, 75))

        e.Graphics.DrawString(repuplic1, New Font("Arabic Typesetting", 16, FontStyle.Bold), New SolidBrush(Color.Black), New Point(385, 100))
        e.Graphics.DrawString(unv, New Font("Arabic Typesetting", 20, FontStyle.Bold), New SolidBrush(Color.Black), New Point(400, 120))

        e.Graphics.DrawString(unv1, New Font("Arabic Typesetting", 20, FontStyle.Bold), New SolidBrush(Color.Black), New Point(300, 150))

        e.Graphics.DrawString(std_no, New Font("Arabic Typesetting", 14, FontStyle.Italic), New SolidBrush(Color.Black), New Point(100, 180))
        e.Graphics.DrawString(id, New Font("Arabic Typesetting", 14, FontStyle.Regular), New SolidBrush(Color.Black), New Point(180, 177))

        e.Graphics.DrawString(header_unv, New Font("Arabic Typesetting", 18, FontStyle.Bold), New SolidBrush(Color.Black), New Point(280, 180))

        e.Graphics.DrawString(typ, New Font("Arabic Typesetting", 36, FontStyle.Bold), New SolidBrush(Color.Black), New Point(380, 270))
        e.Graphics.DrawString(a, New Font("Arabic Typesetting", 20, FontStyle.Italic), New SolidBrush(Color.Black), New Point(380, 350))

        e.Graphics.DrawString(name, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 400))
        e.Graphics.DrawString(awarded, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 450))

        e.Graphics.DrawString(degree, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 500))
        e.Graphics.DrawString(inn, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 550))

        e.Graphics.DrawString(grade, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 600))
        e.Graphics.DrawString(dat, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 650))


    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            CheckBox7.Checked = False
            flag_lang = 1
            ComboBox2.Items.Clear()
            ComboBox4.Items.Clear()

            ComboBox5.Text = Nothing
            ComboBox6.Text = Nothing

            ComboBox2.Enabled = True
            ComboBox5.Enabled = True
            ComboBox4.Enabled = True
            ComboBox6.Enabled = True
            Label7.Enabled = True
            TextBox1.Enabled = True

            DataGridView1.Columns.Clear()

        ElseIf CheckBox6.Checked = False And CheckBox7.Checked = False Then
            CheckBox6.Checked = False
            CheckBox7.Checked = False

            ComboBox2.Items.Clear()
            ComboBox4.Items.Clear()

            ComboBox5.Text = Nothing
            ComboBox6.Text = Nothing

            ComboBox2.Enabled = False
            ComboBox5.Enabled = False
            ComboBox4.Enabled = False
            ComboBox6.Enabled = False
            Label7.Enabled = False
            TextBox1.Enabled = False

            DataGridView1.Columns.Clear()

        End If

    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked = True Then
            CheckBox6.Checked = False
            flag_lang = 2
            ComboBox2.Items.Clear()
            ComboBox4.Items.Clear()

            ComboBox5.Text = Nothing
            ComboBox6.Text = Nothing

            ComboBox2.Enabled = True
            ComboBox5.Enabled = True
            ComboBox4.Enabled = True
            ComboBox6.Enabled = True
            Label7.Enabled = True
            TextBox1.Enabled = True

            DataGridView1.Columns.Clear()

        ElseIf CheckBox6.Checked = False And CheckBox7.Checked = False Then
            CheckBox6.Checked = False
            CheckBox7.Checked = False

            ComboBox2.Items.Clear()
            ComboBox4.Items.Clear()

            ComboBox5.Text = Nothing
            ComboBox6.Text = Nothing

            ComboBox2.Enabled = False
            ComboBox5.Enabled = False
            ComboBox4.Enabled = False
            ComboBox6.Enabled = False
            Label7.Enabled = False
            TextBox1.Enabled = False

            DataGridView1.Columns.Clear()

        End If

    End Sub

    Private Sub PrintDocument4_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument4.PrintPage
        Dim x As String = " بسم الله الرحمن الرحيم"
        Dim repuplic As String = " جمهورية السودان"
        Dim repuplic1 As String = " Republic of Sudan"
        Dim unv As String = " جامعة الصفا"
        Dim unv1 As String = " University of Alsafa Aviation college"

        Dim header_unv As String = "  قسم" & colage
        Dim std_no As String = "..............رقم الطالب"
        Dim id As String = DataGridView1.Rows(0).Cells(0).Value.ToString
        Dim typ As String = "شــهادة"
        Dim a As String = "لقد منحت الجامعة شهادة تخرج إلى"
        Dim name As String = DataGridView1.Rows(0).Cells(1).Value.ToString
        Dim awarded As String = ": لقد منح درجة فى"
        Dim degree As String = degreed
        Dim inn As String = "   : فى" & department
        Dim grade As String = "   :  ولقد نال تقدير " & gradee

        Dim dat As String = Date.Now.ToString("dd MM,yyy") & " من قبل لجنة الجامعة فى"


        Dim res As Image
        Dim newimgsize As New Size(100, 100)

        res = New Bitmap(PictureBox1.Image, newimgsize)

        '''''''''''''''''''''''''''



        e.Graphics.DrawString(x, New Font("Arabic Typesetting", 12, FontStyle.Regular), New SolidBrush(Color.Black), New Point(405, 60))
        e.Graphics.DrawString(repuplic, New Font("Arabic Typesetting", 16, FontStyle.Bold), New SolidBrush(Color.Black), New Point(400, 75))

        e.Graphics.DrawString(repuplic1, New Font("Arabic Typesetting", 16, FontStyle.Bold), New SolidBrush(Color.Black), New Point(385, 100))
        e.Graphics.DrawString(unv, New Font("Arabic Typesetting", 20, FontStyle.Bold), New SolidBrush(Color.Black), New Point(400, 120))

        e.Graphics.DrawString(unv1, New Font("Arabic Typesetting", 20, FontStyle.Bold), New SolidBrush(Color.Black), New Point(300, 150))

        e.Graphics.DrawString(std_no, New Font("Arabic Typesetting", 14, FontStyle.Italic), New SolidBrush(Color.Black), New Point(150, 180))
        e.Graphics.DrawString(id, New Font("Arabic Typesetting", 14, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 177))

        e.Graphics.DrawString(header_unv, New Font("Arabic Typesetting", 18, FontStyle.Regular), New SolidBrush(Color.Black), New Point(500, 180))

        e.Graphics.DrawString(typ, New Font("Arabic Typesetting", 36, FontStyle.Bold), New SolidBrush(Color.Black), New Point(380, 270))
        e.Graphics.DrawString(a, New Font("Arabic Typesetting", 20, FontStyle.Italic), New SolidBrush(Color.Black), New Point(390, 350))

        e.Graphics.DrawString(name, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(500, 400))
        e.Graphics.DrawString(awarded, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(500, 450))

        e.Graphics.DrawString(degree, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(500, 500))
        e.Graphics.DrawString(inn, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(500, 550))

        e.Graphics.DrawString(grade, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(500, 600))
        e.Graphics.DrawString(dat, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(500, 650))

        e.Graphics.DrawImage(res, 690, 100)

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim rep As String = ""
        Dim str As String = ""




        Dim adabter = New MySqlDataAdapter
        Dim bsourc = New BindingSource
        Dim dtable = New DataTable

        DataGridView18.Columns.Clear()
        DataGridView10.Columns.Clear()
        DataGridView11.Columns.Clear()
        DataGridView12.Columns.Clear()
        DataGridView13.Columns.Clear()
        DataGridView14.Columns.Clear()
        DataGridView15.Columns.Clear()
        DataGridView16.Columns.Clear()
        DataGridView17.Columns.Clear()
        DataGridView18.Columns.Clear()
        DataGridView2.Columns.Clear()
        DataGridView3.Columns.Clear()
        DataGridView4.Columns.Clear()
        DataGridView5.Columns.Clear()
        DataGridView6.Columns.Clear()
        DataGridView7.Columns.Clear()
        DataGridView8.Columns.Clear()
        DataGridView9.Columns.Clear()
        DataGridView23.Columns.Clear()
        DataGridView24.Columns.Clear()
        DataGridView25.Columns.Clear()

        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try


            conn.Open()
            tb = New DataTable

            Dim query0101 As String
            query0101 = " select * from academy.result_year where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and year='السنةالرابعه' or std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and year='السنةالخامسه'"

            Dim com = New MySqlCommand(query0101, conn)

            adabter.SelectCommand = com
            adabter.Fill(tb)


            Dim query0 As String
            query0 = " select id_std_h as'الرقم الجامعى من التعليم العالى',name_std  as'اسم الطالب',colage as'الكلية',department as'القسم',depart_certificate as'الدرجة العلمية' from academy.std_info where id_std='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' "

            com = New MySqlCommand(query0, conn)

            adabter.SelectCommand = com
            adabter.Fill(dtable)

            If dtable.Rows.Count > 0 Then
                DataGridView18.DataSource = dtable

                If tb.Rows.Count > 0 Then


                    If flag_t = 3 Then ''''''certify ''''''''


                        DataGridView2.Visible = False
                        DataGridView3.Visible = False
                        DataGridView9.Visible = False
                        DataGridView8.Visible = False
                        DataGridView6.Visible = False
                        DataGridView7.Visible = False
                        DataGridView4.Visible = False
                        DataGridView5.Visible = False
                        DataGridView10.Visible = False
                        DataGridView11.Visible = False
                        DataGridView12.Visible = False
                        DataGridView13.Visible = False
                        DataGridView14.Visible = False
                        DataGridView15.Visible = False
                        DataGridView16.Visible = False
                        DataGridView17.Visible = False
                        DataGridView22.Visible = False
                        DataGridView23.Visible = False
                        DataGridView24.Visible = False
                        DataGridView25.Visible = False

                        DataGridView18.Visible = True

                        If flag_lang = 1 Then ''''''EN''''''

                            If DataGridView18.Rows(0).Cells(4).Value.ToString = "بكالاريوس" Then
                                degreed = "B.SC."
                            ElseIf DataGridView18.Rows(0).Cells(4).Value.ToString = "دبلوم" Then
                                degreed = "D.SC."
                            End If

                            If tb(0)(5) = "مقبول" Then
                                gradee = "PASS"
                            ElseIf tb(0)(5) = "جيد" Then
                                gradee = "Good"
                            ElseIf tb(0)(5) = "جيد جدآ" Then
                                gradee = "Very Good"
                            ElseIf tb(0)(5) = "ممتاز" Then
                                gradee = "Excelent"
                            Else
                                MsgBox("رسوووب")
                            End If

                            If DataGridView18.Rows(0).Cells(2).Value.ToString = "علوم حاسوب" Then

                                colage = "Computer of Scince and Tichnology"

                            ElseIf DataGridView18.Rows(0).Cells(2).Value.ToString = "نظم معلومات" Then

                                colage = "Computer of Scince and Tichnology"

                            End If



                            If DataGridView18.Rows(0).Cells(3).Value.ToString = "تقنية معلومات" Then

                                department = "In : Information Tichnology"

                            ElseIf DataGridView18.Rows(0).Cells(2).Value.ToString = "نظم معلومات" Then

                                department = "In : Computer of Scince and Tichnology"

                            End If
                        Else '''''''AR''''''
                            gradee = ""
                            gradee = tb(0)(5)
                            degreed = DataGridView18.Rows(0).Cells(4).Value.ToString
                            colage = DataGridView18.Rows(0).Cells(2).Value.ToString
                            department = DataGridView18.Rows(0).Cells(3).Value.ToString

                        End If


                    ElseIf flag_t = 4 Then '''''''''efadha'''''''




                    ElseIf flag_t = 5 Then '''''''''''tfaseel''''''''''''''




                    End If

                Else '''''''''not found grade from result year'''''
                    MsgBox("عذرآ هذا الطالب لم يتخرج بعد")
                End If

            Else
                MsgBox("عذرآ لايوجد سجلات للطلاب")
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try






        If flag_t = 4 Then

            DataGridView2.Columns.Clear()
            DataGridView3.Columns.Clear()
            DataGridView9.Columns.Clear()
            DataGridView8.Columns.Clear()
            DataGridView6.Columns.Clear()
            DataGridView7.Columns.Clear()
            DataGridView4.Columns.Clear()
            DataGridView5.Columns.Clear()
            DataGridView10.Columns.Clear()
            DataGridView11.Columns.Clear()
            DataGridView12.Columns.Clear()
            DataGridView13.Columns.Clear()
            DataGridView14.Columns.Clear()
            DataGridView15.Columns.Clear()
            DataGridView16.Columns.Clear()
            DataGridView17.Columns.Clear()
            DataGridView22.Columns.Clear()
            DataGridView23.Columns.Clear()
            DataGridView24.Columns.Clear()
            DataGridView25.Columns.Clear()

            DataGridView2.Visible = True
            DataGridView3.Visible = True
            DataGridView9.Visible = True
            DataGridView8.Visible = True
            DataGridView6.Visible = True
            DataGridView7.Visible = True
            DataGridView4.Visible = True
            DataGridView5.Visible = True
            DataGridView10.Visible = True
            DataGridView11.Visible = True
            DataGridView12.Visible = True
            DataGridView13.Visible = True
            DataGridView14.Visible = True
            DataGridView15.Visible = True
            DataGridView16.Visible = True
            DataGridView17.Visible = True
            DataGridView22.Visible = True
            DataGridView23.Visible = True
            DataGridView24.Visible = True
            DataGridView25.Visible = True

            DataGridView18.Visible = False

            rep = ""

            adabter = New MySqlDataAdapter

            Try
                conn = New MySqlConnection
                conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"

                conn.Open()

                rep = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                rep = rep.Substring(rep.IndexOf("/R") + 1)

                'Dim wordArr As String() = rep.Split("/")
                'MsgBox(rep)

                If rep = "R1/R2/R3/R4/R5" Then
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R1") + 1)

                    Dim lastid2 As String = ""
                    lastid2 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid2 = lastid2.Substring(0, lastid2.LastIndexOf("/R2") + 0)

                    Dim lastid3 As String = ""
                    lastid3 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid3 = lastid3.Substring(0, lastid3.LastIndexOf("/R3") + 0)

                    Dim lastid4 As String = ""
                    lastid4 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid4 = lastid4.Substring(0, lastid4.LastIndexOf("/R4") + 0)


                    Dim lastid5 As String = ""
                    lastid5 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid5 = lastid5.Substring(0, lastid5.LastIndexOf("/R5") + 0)


                    Dim R1 = ""
                    R1 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R1 = R1.Substring(0, R1.LastIndexOf("/R2") + 0)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    lastid = R1


                    Dim R2 = ""
                    R2 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R2 = R2.Substring(0, R2.LastIndexOf("/R1") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R2 = R2 + "R1/R2"

                    Dim R3 = ""
                    R3 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R3 = R3.Substring(0, R3.LastIndexOf("/R1") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R3 = R3 + "R1/R2/R3"

                    Dim R4 = ""
                    R4 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R4 = R4.Substring(0, R4.LastIndexOf("/R1") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R4 = R4 + "R1/R2/R3/R4"

                    Dim R5 = ""
                    R5 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R5 = R5.Substring(0, R1.LastIndexOf("/R1") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R5 = R5 + "R1/R2/R3/R4/R5"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid2 & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid2 & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid3 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid3 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid4 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid4 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim tb1 = New DataTable

                    Dim query1 As String
                    query1 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R1 & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query1, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb1)


                    If tb1.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView4.DataSource = tb1
                    End If



                    Dim tb2 = New DataTable

                    Dim query2 As String
                    query2 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R1 & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query2, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb2)


                    If tb2.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView5.DataSource = tb2
                    End If
                    ''''''''''''''''''1'''''''''''''''''''''
                    '''


                    Dim tb03 = New DataTable

                    Dim query03 As String
                    query03 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query03, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb03)


                    If tb03.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView7.DataSource = tb03
                    End If


                    Dim tb04 = New DataTable

                    Dim query04 As String
                    query04 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query04, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb04)


                    If tb04.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView6.DataSource = tb04
                    End If

                    Dim tb05 = New DataTable
                    Dim query05 As String
                    query05 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query05, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb05)

                    If tb05.Rows.Count > 0 Then
                        DataGridView15.DataSource = tb05

                    End If



                    Dim tb06 = New DataTable

                    Dim query06 As String
                    query06 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query06, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb06)

                    If tb06.Rows.Count > 0 Then
                        DataGridView14.DataSource = tb06

                    End If



                    Dim tb08 = New DataTable

                    Dim query08 As String
                    query08 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query08, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb08)


                    If tb08.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView11.DataSource = tb08
                    End If



                    Dim tb07 = New DataTable

                    Dim query07 As String
                    query07 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query07, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb07)


                    If tb07.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView10.DataSource = tb07
                    End If

                    Dim tb09 = New DataTable

                    Dim query09 As String
                    query09 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query09, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb09)


                    If tb09.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView23.DataSource = tb09
                    End If



                    Dim tb010 = New DataTable

                    Dim query010 As String
                    query010 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query010, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb010)


                    If tb010.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView22.DataSource = tb010
                    End If



                ElseIf rep = "R1/R2" Then

                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R1") + 1)


                    Dim lastid2 As String = ""
                    lastid2 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid2 = lastid2.Substring(0, lastid2.LastIndexOf("/R2") + 0)




                    Dim R1 = ""
                    R1 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R1 = R1.Substring(0, R1.LastIndexOf("/R2") + 0)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)


                    Dim R2 = ""
                    R2 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R2 = R2.Substring(0, R2.LastIndexOf("/R1") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R2 = R2 + "R1/R2"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid2 & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid2 & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim tb1 = New DataTable

                    Dim query1 As String
                    query1 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R1 & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query1, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb1)


                    If tb1.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView4.DataSource = tb1
                    End If



                    Dim tb2 = New DataTable

                    Dim query2 As String
                    query2 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R1 & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query2, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb2)


                    If tb2.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView5.DataSource = tb2
                    End If
                    ''''''''''''''''''1'''''''''''''''''''''
                    '''


                    Dim tb03 = New DataTable

                    Dim query03 As String
                    query03 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query03, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb03)


                    If tb03.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView7.DataSource = tb03
                    End If


                    Dim tb04 = New DataTable

                    Dim query04 As String
                    query04 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query04, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb04)


                    If tb04.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView6.DataSource = tb04
                    End If



                ElseIf rep = "R1" Then

                    Dim R1 = ""
                    R1 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R1 = R1.Substring(0, R1.LastIndexOf("/R1") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R1 = R1 + "R1"



                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R1") + 1)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim tb1 = New DataTable

                    Dim query1 As String
                    query1 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R1 & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query1, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb1)


                    If tb1.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView4.DataSource = tb1
                    End If



                    Dim tb2 = New DataTable

                    Dim query2 As String
                    query2 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R1 & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query2, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb2)


                    If tb2.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView5.DataSource = tb2
                    End If
                    ''''''''''''''''''1'''''''''''''''''''''
                    '''



                ElseIf rep = "R1/R3" Then

                    Dim R1 = ""
                    R1 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R1 = R1.Substring(0, R1.LastIndexOf("/R3") + 0)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)


                    Dim R3 = ""
                    R3 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R3 = R3.Substring(0, R3.LastIndexOf("/R1") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R3 = R3 + "R1/R3"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R1") + 1)


                    Dim lastid1 As String = ""
                    lastid1 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid1 = lastid1.Substring(0, lastid1.LastIndexOf("/R3") + 0)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid1 & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid1 & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid1 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid1 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim tb1 = New DataTable

                    Dim query1 As String
                    query1 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R1 & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query1, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb1)


                    If tb1.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView4.DataSource = tb1
                    End If



                    Dim tb2 = New DataTable

                    Dim query2 As String
                    query2 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R1 & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query2, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb2)


                    If tb2.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView5.DataSource = tb2
                    End If
                    ''''''''''''''''''1'''''''''''''''''''''
                    '''

                    Dim tb05 = New DataTable
                    Dim query05 As String
                    query05 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query05, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb05)

                    If tb05.Rows.Count > 0 Then
                        DataGridView15.DataSource = tb05

                    End If



                    Dim tb06 = New DataTable

                    Dim query06 As String
                    query06 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query06, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb06)

                    If tb06.Rows.Count > 0 Then
                        DataGridView14.DataSource = tb06

                    End If


                ElseIf rep = "R1/R4" Then
                    Dim R1 = ""
                    R1 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R1 = R1.Substring(0, R1.LastIndexOf("/R4") + 0)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)



                    Dim R4 = ""
                    R4 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R4 = R4.Substring(0, R4.LastIndexOf("/R1") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R4 = R4 + "R1/R4"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R1") + 1)


                    Dim lastid4 As String = ""
                    lastid4 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid4 = lastid4.Substring(0, lastid4.LastIndexOf("/R4") + 0)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid4 & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid4 & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid4 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid4 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid4 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid4 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim tb1 = New DataTable

                    Dim query1 As String
                    query1 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R1 & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query1, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb1)


                    If tb1.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView4.DataSource = tb1
                    End If



                    Dim tb2 = New DataTable

                    Dim query2 As String
                    query2 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R1 & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query2, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb2)


                    If tb2.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView5.DataSource = tb2
                    End If
                    ''''''''''''''''''1'''''''''''''''''''''
                    '''



                    Dim tb08 = New DataTable

                    Dim query08 As String
                    query08 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query08, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb08)


                    If tb08.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView11.DataSource = tb08
                    End If



                    Dim tb07 = New DataTable

                    Dim query07 As String
                    query07 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query07, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb07)


                    If tb07.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView10.DataSource = tb07
                    End If


                ElseIf rep = "R1/R5" Then


                    Dim R1 = ""
                    R1 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R1 = R1.Substring(0, R1.LastIndexOf("/R5") + 0)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)


                    Dim R5 = ""
                    R5 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R5 = R5.Substring(0, R5.LastIndexOf("/R1") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R5 = R5 + "R1/R5"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R1") + 1)


                    Dim lastid5 As String = ""
                    lastid5 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid5 = lastid5.Substring(0, lastid5.LastIndexOf("/R5") + 0)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim tb1 = New DataTable

                    Dim query1 As String
                    query1 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R1 & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query1, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb1)


                    If tb1.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView4.DataSource = tb1
                    End If



                    Dim tb2 = New DataTable

                    Dim query2 As String
                    query2 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R1 & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query2, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb2)


                    If tb2.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView5.DataSource = tb2
                    End If
                    ''''''''''''''''''1'''''''''''''''''''''

                    Dim tb09 = New DataTable

                    Dim query09 As String
                    query09 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query09, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb09)


                    If tb09.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView23.DataSource = tb09
                    End If



                    Dim tb010 = New DataTable

                    Dim query010 As String
                    query010 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query010, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb010)


                    If tb010.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView22.DataSource = tb010
                    End If

                ElseIf rep = "R2/R3/R5" Then

                    Dim R2 = ""
                    R2 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R2 = R2.Substring(0, R2.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R2 = R2 + "R2"

                    Dim R3 = ""
                    R3 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R3 = R3.Substring(0, R3.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R3 = R3 + "R2/R3"

                    Dim R4 = ""
                    R4 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R4 = R4.Substring(0, R4.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R4 = R4 + "R2/R3/R4"

                    Dim R5 = ""
                    R5 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R5 = R5.Substring(0, R5.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R5 = R5 + "R2/R3/R5"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R2") + 1)


                    Dim lastid1 As String = ""
                    lastid1 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid1 = lastid1.Substring(0, lastid1.LastIndexOf("/R3") + 0)



                    Dim lastid3 As String = ""
                    lastid3 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid3 = lastid3.Substring(0, lastid3.LastIndexOf("/R5") + 0)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid1 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid1 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid3 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid3 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid3 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid3 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                    Dim tb03 = New DataTable

                    Dim query03 As String
                    query03 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query03, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb03)


                    If tb03.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView7.DataSource = tb03
                    End If


                    Dim tb04 = New DataTable

                    Dim query04 As String
                    query04 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query04, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb04)


                    If tb04.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView6.DataSource = tb04
                    End If

                    Dim tb05 = New DataTable
                    Dim query05 As String
                    query05 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query05, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb05)

                    If tb05.Rows.Count > 0 Then
                        DataGridView15.DataSource = tb05

                    End If



                    Dim tb06 = New DataTable

                    Dim query06 As String
                    query06 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query06, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb06)

                    If tb06.Rows.Count > 0 Then
                        DataGridView14.DataSource = tb06

                    End If



                    Dim tb08 = New DataTable

                    Dim query08 As String
                    query08 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query08, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb08)


                    If tb08.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView11.DataSource = tb08
                    End If



                    Dim tb07 = New DataTable

                    Dim query07 As String
                    query07 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query07, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb07)


                    If tb07.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView10.DataSource = tb07
                    End If

                    Dim tb09 = New DataTable

                    Dim query09 As String
                    query09 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query09, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb09)


                    If tb09.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView23.DataSource = tb09
                    End If



                    Dim tb010 = New DataTable

                    Dim query010 As String
                    query010 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query010, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb010)


                    If tb010.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView22.DataSource = tb010
                    End If


                ElseIf rep = "R2/R4/R5" Then

                    Dim R2 = ""
                    R2 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R2 = R2.Substring(0, R2.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R2 = R2 + "R2"

                    Dim R3 = ""
                    R3 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R3 = R3.Substring(0, R3.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R3 = R3 + "R2/R3"

                    Dim R4 = ""
                    R4 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R4 = R4.Substring(0, R4.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R4 = R4 + "R2/R4"

                    Dim R5 = ""
                    R5 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R5 = R5.Substring(0, R5.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R5 = R5 + "R2/R4/R5"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R2") + 1)



                    Dim lastid2 As String = ""
                    lastid2 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid2 = lastid2.Substring(0, lastid2.LastIndexOf("/R4") + 0)


                    Dim lastid3 As String = ""
                    lastid3 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid3 = lastid3.Substring(0, lastid3.LastIndexOf("/R5") + 0)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid2 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid2 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid2 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid2 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid3 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid3 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                    Dim tb03 = New DataTable

                    Dim query03 As String
                    query03 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query03, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb03)


                    If tb03.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView7.DataSource = tb03
                    End If


                    Dim tb04 = New DataTable

                    Dim query04 As String
                    query04 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query04, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb04)


                    If tb04.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView6.DataSource = tb04
                    End If

                    Dim tb05 = New DataTable
                    Dim query05 As String
                    query05 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query05, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb05)

                    If tb05.Rows.Count > 0 Then
                        DataGridView15.DataSource = tb05


                    End If



                    Dim tb06 = New DataTable

                    Dim query06 As String
                    query06 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query06, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb06)

                    If tb06.Rows.Count > 0 Then
                        DataGridView14.DataSource = tb06


                    End If



                    Dim tb08 = New DataTable

                    Dim query08 As String
                    query08 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query08, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb08)


                    If tb08.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView11.DataSource = tb08
                    End If



                    Dim tb07 = New DataTable

                    Dim query07 As String
                    query07 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query07, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb07)


                    If tb07.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView10.DataSource = tb07
                    End If

                    Dim tb09 = New DataTable

                    Dim query09 As String
                    query09 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query09, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb09)


                    If tb09.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView23.DataSource = tb09
                    End If



                    Dim tb010 = New DataTable

                    Dim query010 As String
                    query010 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query010, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb010)


                    If tb010.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView22.DataSource = tb010
                    End If



                    '''''''''''''''''''''R2'''''''''''''
                ElseIf rep = "R2/R3/R4/R5" Then

                    Dim R2 = ""
                    R2 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R2 = R2.Substring(0, R2.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R2 = R2 + "R2"

                    Dim R3 = ""
                    R3 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R3 = R3.Substring(0, R3.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R3 = R3 + "R2/R3"

                    Dim R4 = ""
                    R4 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R4 = R4.Substring(0, R4.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R4 = R4 + "R2/R3/R4"

                    Dim R5 = ""
                    R5 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R5 = R5.Substring(0, R5.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R5 = R5 + "R2/R3/R4/R5"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R2") + 1)


                    Dim lastid1 As String = ""
                    lastid1 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid1 = lastid1.Substring(0, lastid1.LastIndexOf("/R3") + 0)


                    Dim lastid2 As String = ""
                    lastid2 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid2 = lastid2.Substring(0, lastid2.LastIndexOf("/R4") + 0)


                    Dim lastid3 As String = ""
                    lastid3 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid3 = lastid3.Substring(0, lastid3.LastIndexOf("/R5") + 0)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid1 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid1 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid2 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid2 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid3 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid3 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                    Dim tb03 = New DataTable

                    Dim query03 As String
                    query03 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query03, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb03)


                    If tb03.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView7.DataSource = tb03
                    End If


                    Dim tb04 = New DataTable

                    Dim query04 As String
                    query04 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query04, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb04)


                    If tb04.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView6.DataSource = tb04
                    End If

                    Dim tb05 = New DataTable
                    Dim query05 As String
                    query05 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query05, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb05)

                    If tb05.Rows.Count > 0 Then
                        DataGridView15.DataSource = tb05


                    End If



                    Dim tb06 = New DataTable

                    Dim query06 As String
                    query06 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query06, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb06)

                    If tb06.Rows.Count > 0 Then
                        DataGridView14.DataSource = tb06


                    End If



                    Dim tb08 = New DataTable

                    Dim query08 As String
                    query08 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query08, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb08)


                    If tb08.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView11.DataSource = tb08
                    End If



                    Dim tb07 = New DataTable

                    Dim query07 As String
                    query07 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query07, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb07)


                    If tb07.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView10.DataSource = tb07
                    End If

                    Dim tb09 = New DataTable

                    Dim query09 As String
                    query09 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query09, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb09)


                    If tb09.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView23.DataSource = tb09
                    End If



                    Dim tb010 = New DataTable

                    Dim query010 As String
                    query010 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query010, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb010)


                    If tb010.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView22.DataSource = tb010
                    End If


                ElseIf rep = "R2/R3" Then

                    Dim R2 = ""
                    R2 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R2 = R2.Substring(0, R2.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R2 = R2 + "R2"

                    Dim R3 = ""
                    R3 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R3 = R3.Substring(0, R3.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R3 = R3 + "R2/R3"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R2") + 0)


                    Dim lastid1 As String = ""
                    lastid1 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid1 = lastid1.Substring(0, lastid1.LastIndexOf("/R3") + 0)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid1 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid1 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb03 = New DataTable

                    Dim query03 As String
                    query03 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query03, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb03)


                    If tb03.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView7.DataSource = tb03
                    End If


                    Dim tb04 = New DataTable

                    Dim query04 As String
                    query04 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query04, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb04)


                    If tb04.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView6.DataSource = tb04
                    End If

                    Dim tb05 = New DataTable
                    Dim query05 As String
                    query05 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query05, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb05)

                    If tb05.Rows.Count > 0 Then
                        DataGridView15.DataSource = tb05


                    End If



                    Dim tb06 = New DataTable

                    Dim query06 As String
                    query06 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query06, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb06)

                    If tb06.Rows.Count > 0 Then
                        DataGridView14.DataSource = tb06


                    End If


                ElseIf rep = "R2/R4" Then

                    Dim R2 = ""
                    R2 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R2 = R2.Substring(0, R2.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R2 = R2 + "R2"


                    Dim R4 = ""
                    R4 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R4 = R4.Substring(0, R4.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R4 = R4 + "R2/R4"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R2") + 1)


                    Dim lastid4 As String = ""
                    lastid4 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid4 = lastid4.Substring(0, lastid4.LastIndexOf("/R4") + 0)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid4 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid4 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid4 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid4 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim tb03 = New DataTable

                    Dim query03 As String
                    query03 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query03, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb03)


                    If tb03.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView7.DataSource = tb03
                    End If


                    Dim tb04 = New DataTable

                    Dim query04 As String
                    query04 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query04, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb04)


                    If tb04.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView6.DataSource = tb04
                    End If




                    Dim tb08 = New DataTable

                    Dim query08 As String
                    query08 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query08, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb08)


                    If tb08.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView11.DataSource = tb08
                    End If



                    Dim tb07 = New DataTable

                    Dim query07 As String
                    query07 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query07, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb07)


                    If tb07.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView10.DataSource = tb07
                    End If

                ElseIf rep = "R2/R5" Then

                    Dim R2 = ""
                    R2 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R2 = R2.Substring(0, R2.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R2 = R2 + "R2"


                    Dim R5 = ""
                    R5 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R5 = R5.Substring(0, R5.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R5 = R5 + "R2/R5"

                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R2") + 1)


                    Dim lastid5 As String = ""
                    lastid5 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid5 = lastid5.Substring(0, lastid5.LastIndexOf("/R5") + 0)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid5 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb03 = New DataTable

                    Dim query03 As String
                    query03 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query03, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb03)


                    If tb03.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView7.DataSource = tb03
                    End If


                    Dim tb04 = New DataTable

                    Dim query04 As String
                    query04 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query04, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb04)


                    If tb04.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView6.DataSource = tb04
                    End If

                    Dim tb09 = New DataTable

                    Dim query09 As String
                    query09 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query09, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb09)


                    If tb09.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView23.DataSource = tb09
                    End If



                    Dim tb010 = New DataTable

                    Dim query010 As String
                    query010 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query010, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb010)


                    If tb010.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView22.DataSource = tb010
                    End If


                ElseIf rep = "R2" Then


                    Dim R2 = ""
                    R2 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R2 = R2.Substring(0, R2.LastIndexOf("/R2") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R2 = R2 + "R2"

                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R2") + 1)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                    Dim tb03 = New DataTable

                    Dim query03 As String
                    query03 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query03, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb03)


                    If tb03.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView7.DataSource = tb03
                    End If


                    Dim tb04 = New DataTable

                    Dim query04 As String
                    query04 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R2 & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query04, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb04)


                    If tb04.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView6.DataSource = tb04
                    End If



                    '''''''''''''''''''R3'''''''''''''''''''''''
                ElseIf rep = "R3/R4" Then
                    Dim R3 = ""
                    R3 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R3 = R3.Substring(0, R3.LastIndexOf("/R3") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R3 = R3 + "R3"

                    Dim R4 = ""
                    R4 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R4 = R4.Substring(0, R4.LastIndexOf("/R3") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R4 = R4 + "R3/R4"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R3") + 1)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim tb05 = New DataTable
                    Dim query05 As String
                    query05 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query05, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb05)

                    If tb05.Rows.Count > 0 Then
                        DataGridView15.DataSource = tb05


                    End If



                    Dim tb06 = New DataTable

                    Dim query06 As String
                    query06 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query06, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb06)

                    If tb06.Rows.Count > 0 Then
                        DataGridView14.DataSource = tb06


                    End If



                    Dim tb08 = New DataTable

                    Dim query08 As String
                    query08 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query08, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb08)


                    If tb08.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView11.DataSource = tb08
                    End If



                    Dim tb07 = New DataTable

                    Dim query07 As String
                    query07 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query07, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb07)


                    If tb07.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView10.DataSource = tb07
                    End If

                ElseIf rep = "R3/R5" Then


                    Dim R3 = ""
                    R3 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R3 = R3.Substring(0, R3.LastIndexOf("/R3") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R3 = R3 + "R3"


                    Dim R5 = ""
                    R5 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R5 = R5.Substring(0, R5.LastIndexOf("/R3") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R5 = R5 + "R3/R5"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R3") + 1)


                    Dim lastid3 As String = ""
                    lastid3 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid3 = lastid3.Substring(0, lastid3.LastIndexOf("/R5") + 0)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid3 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid3 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid3 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid3 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim tb05 = New DataTable
                    Dim query05 As String
                    query05 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query05, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb05)

                    If tb05.Rows.Count > 0 Then
                        DataGridView15.DataSource = tb05


                    End If



                    Dim tb06 = New DataTable

                    Dim query06 As String
                    query06 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query06, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb06)

                    If tb06.Rows.Count > 0 Then
                        DataGridView14.DataSource = tb06


                    End If

                    Dim tb09 = New DataTable

                    Dim query09 As String
                    query09 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query09, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb09)


                    If tb09.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView23.DataSource = tb09
                    End If



                    Dim tb010 = New DataTable

                    Dim query010 As String
                    query010 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query010, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb010)


                    If tb010.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView22.DataSource = tb010
                    End If


                ElseIf rep = "R3" Then


                    Dim R3 = ""
                    R3 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R3 = R3.Substring(0, R3.LastIndexOf("/R3") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R3 = R3 + "R3"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R3") + 1)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim tb05 = New DataTable
                    Dim query05 As String
                    query05 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query05, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb05)

                    If tb05.Rows.Count > 0 Then
                        DataGridView15.DataSource = tb05


                    End If



                    Dim tb06 = New DataTable

                    Dim query06 As String
                    query06 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R3 & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query06, conn)
                    adabter = New MySqlDataAdapter
                    adabter.SelectCommand = com
                    adabter.Fill(tb06)

                    If tb06.Rows.Count > 0 Then
                        DataGridView14.DataSource = tb06


                    End If

                    ''''''''''''''''''R4''''''''''''''''''''''
                ElseIf rep = "R4/R5" Then
                    Dim R4 = ""
                    R4 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R4 = R4.Substring(0, R4.LastIndexOf("/R4") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R4 = R4 + "R4"


                    Dim R5 = ""
                    R5 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R5 = R5.Substring(0, R5.LastIndexOf("/R4") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R5 = R5 + "R4/R5"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R4") + 1)


                    Dim lastid4 As String = ""
                    lastid4 = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid4 = lastid4.Substring(0, lastid4.LastIndexOf("/R5") + 0)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid4 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid4 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim tb08 = New DataTable

                    Dim query08 As String
                    query08 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query08, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb08)


                    If tb08.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView11.DataSource = tb08
                    End If



                    Dim tb07 = New DataTable

                    Dim query07 As String
                    query07 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query07, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb07)


                    If tb07.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView10.DataSource = tb07
                    End If

                    Dim tb09 = New DataTable

                    Dim query09 As String
                    query09 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query09, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb09)


                    If tb09.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView23.DataSource = tb09
                    End If



                    Dim tb010 = New DataTable

                    Dim query010 As String
                    query010 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query010, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb010)


                    If tb010.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView22.DataSource = tb010
                    End If


                ElseIf rep = "R4" Then

                    Dim R4 = ""
                    R4 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R4 = R4.Substring(0, R4.LastIndexOf("/R4") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R4 = R4 + "R4"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R4") + 1)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb08 = New DataTable

                    Dim query08 As String
                    query08 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query08, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb08)


                    If tb08.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView11.DataSource = tb08
                    End If



                    Dim tb07 = New DataTable

                    Dim query07 As String
                    query07 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R4 & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query07, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb07)


                    If tb07.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView10.DataSource = tb07
                    End If




                    ''''''''''''''''''R5''''''''''''''''
                ElseIf rep = "R5" Then

                    Dim R5 = ""
                    R5 = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
                    R5 = R5.Substring(0, R5.LastIndexOf("/R5") + 1)
                    'R1 = R1.Substring(R1.IndexOf("/R1") + 1)
                    R5 = R5 + "R5"


                    '''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim lastid As String = ""
                    lastid = DataGridView1.SelectedRows(0).Cells(1).Value

                    lastid = lastid.Substring(0, lastid.LastIndexOf("/R5") + 1)


                    '''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & lastid & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim tb09 = New DataTable

                    Dim query09 As String
                    query09 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query09, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb09)


                    If tb09.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView23.DataSource = tb09
                    End If



                    Dim tb010 = New DataTable

                    Dim query010 As String
                    query010 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & R5 & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query010, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb010)


                    If tb010.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView22.DataSource = tb010
                    End If



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Else


                    '''''''''''''''''''''''''''''''''''''''Else''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    Dim tb001 = New DataTable

                    Dim query001 As String
                    query001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الاول'"

                    com = New MySqlCommand(query001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb001)


                    If tb001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView2.DataSource = tb001
                    End If



                    Dim tb002 = New DataTable

                    Dim query002 As String
                    query002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الثانى'"

                    com = New MySqlCommand(query002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb002)


                    If tb002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView3.DataSource = tb002
                    End If



                    Dim tb0001 = New DataTable

                    Dim query0001 As String
                    query0001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الثالث'"

                    com = New MySqlCommand(query0001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0001)


                    If tb0001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView9.DataSource = tb0001
                    End If



                    Dim tb0002 = New DataTable

                    Dim query0002 As String
                    query0002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الرابع'"

                    com = New MySqlCommand(query0002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0002)


                    If tb0002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView8.DataSource = tb0002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb00001 = New DataTable

                    Dim query00001 As String
                    query00001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الخامس'"

                    com = New MySqlCommand(query00001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00001)


                    If tb00001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView17.DataSource = tb00001
                    End If



                    Dim tb00002 = New DataTable

                    Dim query00002 As String
                    query00002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل السادس'"

                    com = New MySqlCommand(query00002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb00002)


                    If tb00002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView16.DataSource = tb00002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb000001 = New DataTable

                    Dim query000001 As String
                    query000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل السابع'"

                    com = New MySqlCommand(query000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000001)


                    If tb000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView13.DataSource = tb000001
                    End If



                    Dim tb000002 = New DataTable

                    Dim query000002 As String
                    query000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل الثامن'"

                    com = New MySqlCommand(query000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb000002)


                    If tb000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView12.DataSource = tb000002
                    End If


                    ''''''''''''''''''''''''''''''''''''''''

                    Dim tb0000001 = New DataTable

                    Dim query0000001 As String
                    query0000001 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل التاسع'"

                    com = New MySqlCommand(query0000001, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000001)


                    If tb0000001.Rows.Count > 0 Then
                        '  MsgBox("001")
                        DataGridView25.DataSource = tb0000001
                    End If



                    Dim tb0000002 = New DataTable

                    Dim query0000002 As String
                    query0000002 = " select lecture as'المقرر',grade as 'التقدير',semester as'الفصل الدراسى' from academy.res_lecture where std_id='" & DataGridView1.SelectedRows(0).Cells(1).Value & "' and semester='الفصل العاشر'"

                    com = New MySqlCommand(query0000002, conn)
                    adabter = New MySqlDataAdapter

                    adabter.SelectCommand = com
                    adabter.Fill(tb0000002)


                    If tb0000002.Rows.Count > 0 Then
                        ' MsgBox("001")
                        DataGridView24.DataSource = tb0000002
                    End If



                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()
            End Try

        End If



    End Sub

End Class