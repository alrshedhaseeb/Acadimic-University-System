Imports MySql.Data.MySqlClient

Public Class result



    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim dtable As DataTable
    Dim MyCommand1 As New MySql.Data.MySqlClient.MySqlCommand
    Dim Myadapter As New MySql.Data.MySqlClient.MySqlDataAdapter
    Dim MyBuilder As MySql.Data.MySqlClient.MySqlCommandBuilder

    Dim fees As Double = 0
    Dim p_now As Double = 0
    Dim total_pay As Double = 0

    Dim flag As Integer = 0
    Dim mol7ag As String = ""
    Dim le As String = ""
    Dim nex As Boolean = True
    Dim set_exam = 0
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

    Private Sub result_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        DataGridView1.Columns.Clear()
        DataGridView4.Columns.Clear()
        DataGridView3.Columns.Clear()

        If ComboBox3.Text = Nothing Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If

        Dim le As Integer = 0
        Dim le1 As Integer = 0

        If flag = 1 Then

            Dim adapter = New MySqlDataAdapter
            Dim bsorc = New BindingSource
            Dim table = New DataTable
            Dim t As New DataTable
            Dim tb As New DataTable
            Dim t05 As New DataTable
            Dim bc As New BindingSource
            Dim ad As New MySqlDataAdapter



            If ComboBox5.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox5, "please")
                Return
            ElseIf ComboBox4.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox4, "plemase")
                Return
            ElseIf ComboBox2.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox2, "plemase")
                Return
            ElseIf ComboBox3.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox3, "plemase")

            Else
                ErrorProvider1.Clear()

                Dim conn = New MySqlConnection
                conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
                Try
                    conn.Open()

                    DataGridView1.Columns.Clear()

                    Dim query As String
                    query = " select id_std as'الرقم االجامعى',name_std as'اسم الطالب' from academy.std_info where colage='" & ComboBox5.Text & "' and department='" & ComboBox4.Text & "' and semester='" & ComboBox3.Text & "' and depart_certificate='" & ComboBox2.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "' "
                    com = New MySqlCommand(query, conn)

                    adapter.SelectCommand = com
                    adapter.Fill(table)

                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                    DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders

                    Dim persentage As New DataGridViewTextBoxColumn() With {.HeaderText = "النسبة", .Name = "text", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                    Dim Grade As New DataGridViewTextBoxColumn() With {.HeaderText = "التقدير", .Name = "text", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                    Dim result As New DataGridViewTextBoxColumn() With {.HeaderText = "النتيجه", .Name = "text", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                    Dim mol7g As New DataGridViewTextBoxColumn() With {.HeaderText = "الحاله", .Name = "text", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}

                    DataGridView1.DataSource = table

                    DataGridView1.Columns.Insert(2, persentage)
                    DataGridView1.Columns.Insert(3, Grade)
                    DataGridView1.Columns.Insert(4, result)
                    DataGridView1.Columns.Insert(5, mol7g)

                    reader.Close()
                    com.Parameters.Clear()

                    Dim sum As Double
                    Dim total As Double



                    Dim row As Integer = DataGridView1.Rows.Count
                    For i = 0 To row - 1 Step +1


                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''select count of lecture''''''''''''''''''''''''''


                        Dim quer1 As String
                        quer1 = " select * from academy.record_academy where colage='" & ComboBox5.Text & "' and depart_name='" & ComboBox4.Text & "' and semester='" & ComboBox3.Text & "' and depart_certificate='" & ComboBox2.Text & "'"

                        Dim com = New MySqlCommand(quer1, conn)
                        adapter.SelectCommand = com
                        adapter.Fill(t05)

                        If t05.Rows.Count > 1 Then

                            le = 0
                            le = t05.Rows.Count



                        Else

                            MsgBox("عذرآ هنالك خطاء : لاتوجد مقررات فى سجل الجامعة")
                            '''''''''''''''''''''''enable false '''''''''''''''''



                            GroupBox6.Visible = False
                            Button6.Visible = False
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


                            DataGridView1.Columns.Clear()
                            DataGridView2.Columns.Clear()
                            DataGridView3.Columns.Clear()
                            DataGridView4.Columns.Clear()


                            flag = 0

                            Panel4.Visible = False
                            Panel5.Visible = False
                            Panel6.Visible = False

                            ErrorProvider1.Clear()
                            ListBox1.Items.Clear()
                            ListBox2.Items.Clear()
                            ListBox3.Items.Clear()
                            ListBox4.Items.Clear()

                            Button1.Enabled = True

                        End If



                        ''''''''''''''''''''''''''''''''''''''''''''''''''''std lect set count '''''




                        Dim q11 As String = ""
                        q11 = " select std_id as'الرقم الجامعى',lecture as'المقرر',total_degre_exam as'الدرجة' from academy.res_lecture where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and flag='1' and active='" & 0 & "'"

                        com = New MySqlCommand(q11, conn)

                            adabter.SelectCommand = com
                            adabter.Fill(t)


                        DataGridView2.DataSource = t

                        le1 = t.Rows.Count

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        If t.Rows.Count > 0 Then


                            If le = le1 Then

                                Dim q1 As String
                                q1 = " select * from academy.res_lecture where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and flag='" & flag & "' and semester='" & ComboBox3.Text & "' and active='" & 0 & "'"
                                com = New MySqlCommand(q1, conn)

                                reader = com.ExecuteReader
                                adabter.Update(tb)

                                ListBox1.Items.Clear()

                                Dim persen As String = ""
                                Dim mol7ag As String = ""
                                Dim lec As String = ""


                                While reader.Read

                                    persen = reader.GetFloat("total_degre_exam")
                                    lec = reader.GetString("lecture")

                                    sum = sum + persen

                                    Dim gr As String = ""

                                    DataGridView1.Rows(i).Cells(2).Value = Val(sum) / 100

                                    If DataGridView1.Rows(i).Cells(2).Value >= 3.8 Then
                                        gr = "ممتاز"
                                    ElseIf DataGridView1.Rows(i).Cells(2).Value >= 3.5 Then
                                        gr = "جيد جدآ"

                                    ElseIf DataGridView1.Rows(i).Cells(2).Value >= 2.7 Then
                                        gr = "جيد"
                                    ElseIf DataGridView1.Rows(i).Cells(2).Value >= 2 And DataGridView1.Rows(i).Cells(2).Value < 2.7 Then
                                        gr = "مقبول"

                                    ElseIf DataGridView1.Rows(i).Cells(2).Value < 2 Then
                                        gr = "ضعيف"
                                    End If

                                    DataGridView1.Rows(i).Cells(3).Value = gr
                                    If DataGridView1.Rows(i).Cells(3).Value = "ممتاز" Then
                                        DataGridView1.Rows(i).Cells(4).Value = "نجاح"
                                    ElseIf DataGridView1.Rows(i).Cells(3).Value = "جيد جدآ" Then
                                        DataGridView1.Rows(i).Cells(4).Value = "نجاح"
                                    ElseIf DataGridView1.Rows(i).Cells(3).Value = "جيد" Then
                                        DataGridView1.Rows(i).Cells(4).Value = "نجاح"
                                    ElseIf DataGridView1.Rows(i).Cells(3).Value = "مقبول" Then
                                        DataGridView1.Rows(i).Cells(4).Value = "نجاح"
                                    ElseIf DataGridView1.Rows(i).Cells(3).Value = "ضعيف" Then
                                        DataGridView1.Rows(i).Cells(4).Value = "رسوب"
                                    End If


                                End While

                                reader.Close()
                                com.Parameters.Clear()

                                total = sum
                                sum = 0

                                ListBox1.Items.Clear()
                                ListBox2.Items.Clear()
                                ListBox3.Items.Clear()
                                ListBox4.Items.Clear()

                                Dim row1 As Integer = DataGridView2.Rows.Count
                                For j = 0 To row1 - 1

                                    If DataGridView2.Rows(j).Cells(2).Value < 50 Then
                                        ListBox4.Items.Add("نعم")
                                    ElseIf DataGridView2.Rows(j).Cells(2).Value >= 50 Then
                                        ListBox4.Items.Add("لا")
                                    End If

                                Next j

                                For Each b In ListBox4.Items

                                    If b = "نعم" Then
                                        DataGridView1.Rows(i).Cells(5).Value = "ملاحق"
                                        Exit For
                                    Else
                                        DataGridView1.Rows(i).Cells(5).Value = "ينقل"
                                    End If

                                Next b

                                '''''''''''''''''''''''''''''''''''''''''end if ''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            Else
                                MsgBox("عذرآ لم يتم الجلوس لجميع الامتحانات")

                                GroupBox6.Visible = False
                                Button6.Visible = False
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


                                DataGridView1.Columns.Clear()
                                DataGridView2.Columns.Clear()
                                DataGridView3.Columns.Clear()
                                DataGridView4.Columns.Clear()


                                flag = 0

                                Button1.Enabled = True
                                Panel4.Visible = False
                                Panel5.Visible = False
                                Panel6.Visible = False

                                ErrorProvider1.Clear()
                                ListBox1.Items.Clear()
                                ListBox2.Items.Clear()
                                ListBox3.Items.Clear()
                                ListBox4.Items.Clear()


                                Exit Sub


                            End If
                        End If

                    Next i

                    ListBox1.Items.Add(total)

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()

                End Try

            End If


        ElseIf flag = 2 Then


            Dim adapter = New MySqlDataAdapter
            Dim bsorc = New BindingSource
            Dim table = New DataTable

            Dim tb As New DataTable
            Dim bc As New BindingSource
            Dim ad As New MySqlDataAdapter


            If ComboBox5.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox5, "please")
                Return
            ElseIf ComboBox4.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox4, "plemase")
                Return
            ElseIf ComboBox2.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox2, "plemase")
                Return
            ElseIf ComboBox3.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox3, "plemase")

            Else
                ErrorProvider1.Clear()

                Dim conn = New MySqlConnection
                conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
                Try
                    conn.Open()
                    DataGridView1.Columns.Clear()
                    Dim query As String
                    query = " select std_id as'الرقم الجامعى',name_std as'اسم الطالب' from academy.res_lecture where colage='" & ComboBox5.Text & "' and dep_name='" & ComboBox4.Text & "' and semester='" & ComboBox3.Text & "' and department='" & ComboBox2.Text & "' and patch='" & ComboBox6.Text & "' and flag='1' and set_mol='1' and active='" & 0 & "'"
                    com = New MySqlCommand(query, conn)
                    adapter.SelectCommand = com
                    adapter.Fill(table)
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                    DataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders

                    Dim persentage As New DataGridViewTextBoxColumn() With {.HeaderText = "النسبة", .Name = "text", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                    Dim Grade As New DataGridViewTextBoxColumn() With {.HeaderText = "التقدير", .Name = "text", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                    Dim result As New DataGridViewTextBoxColumn() With {.HeaderText = "النتيجه", .Name = "text", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                    Dim mol7g As New DataGridViewTextBoxColumn() With {.HeaderText = "الحاله", .Name = "text", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}

                    '        bsorc.DataSource = table
                    DataGridView1.DataSource = table

                    DataGridView1.Columns.Insert(2, persentage)
                    DataGridView1.Columns.Insert(3, Grade)
                    DataGridView1.Columns.Insert(4, result)
                    DataGridView1.Columns.Insert(5, mol7g)

                    reader.Close()
                    com.Parameters.Clear()
                    Dim sum As Double
                    Dim total As Double


                    Dim row As Integer = DataGridView1.Rows.Count
                    For i = 0 To row - 1 Step +1


                        Dim q1 As String
                        q1 = " select * from academy.res_lecture where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and flag='1'  and semester='" & ComboBox3.Text & "' and active='" & 0 & "'"

                        com = New MySqlCommand(q1, conn)
                        reader = com.ExecuteReader
                        adabter.Update(tb)

                        ListBox1.Items.Clear()

                        Dim persen As String = ""
                        Dim mol7ag As String = ""
                        Dim lec As String = ""

                        While reader.Read

                            persen = reader.GetFloat("total_degre_exam")
                            lec = reader.GetString("lecture")

                            sum = sum + persen

                            Dim gr As String = ""

                            DataGridView1.Rows(i).Cells(2).Value = Val(sum) / 100

                            If DataGridView1.Rows(i).Cells(2).Value >= 3.8 Then
                                gr = "ممتاز"
                            ElseIf DataGridView1.Rows(i).Cells(2).Value >= 3.5 Then
                                gr = "جيد جدآ"

                            ElseIf DataGridView1.Rows(i).Cells(2).Value >= 2.7 Then
                                gr = "جيد"
                            ElseIf DataGridView1.Rows(i).Cells(2).Value >= 2 And DataGridView1.Rows(i).Cells(2).Value <= 2.6 Then
                                gr = "مقبول"

                            ElseIf DataGridView1.Rows(i).Cells(2).Value < 2 Then
                                gr = "ضعيف"
                            End If


                            DataGridView1.Rows(i).Cells(3).Value = gr
                            If DataGridView1.Rows(i).Cells(3).Value = "ممتاز" Then
                                DataGridView1.Rows(i).Cells(4).Value = "نجاح"
                            ElseIf DataGridView1.Rows(i).Cells(3).Value = "جيد جدآ" Then
                                DataGridView1.Rows(i).Cells(4).Value = "نجاح"
                            ElseIf DataGridView1.Rows(i).Cells(3).Value = "جيد" Then
                                DataGridView1.Rows(i).Cells(4).Value = "نجاح"
                            ElseIf DataGridView1.Rows(i).Cells(3).Value = "مقبول" Then
                                DataGridView1.Rows(i).Cells(4).Value = "نجاح"
                            ElseIf DataGridView1.Rows(i).Cells(3).Value = "ضعيف" Then
                                DataGridView1.Rows(i).Cells(4).Value = "رسوب"
                            End If


                        End While

                        reader.Close()
                        com.Parameters.Clear()

                        total = sum
                        sum = 0

                        Dim t As New DataTable

                        Dim q11 As String
                        q11 = " select std_id as'الرقم الجامعى',lecture as'المقرر',total_degre_exam as'الدرجة' from academy.res_lecture where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and flag='1' and active='" & 0 & "'"
                        com = New MySqlCommand(q11, conn)

                        adabter.SelectCommand = com
                        adabter.Fill(t)

                        DataGridView2.DataSource = t


                        ListBox1.Items.Clear()
                        ListBox2.Items.Clear()
                        ListBox3.Items.Clear()
                        ListBox4.Items.Clear()

                        Dim row1 As Integer = DataGridView2.Rows.Count
                        For j = 0 To row1 - 1

                            If DataGridView2.Rows(j).Cells(2).Value < 50 Then
                                ListBox4.Items.Add("نعم")
                            ElseIf DataGridView2.Rows(j).Cells(2).Value >= 50 Then
                                ListBox4.Items.Add("لا")
                            End If

                        Next j

                        For Each b In ListBox4.Items

                            If b = "نعم" Then
                                DataGridView1.Rows(i).Cells(5).Value = "ملاحق"
                                Exit For
                            Else
                                DataGridView1.Rows(i).Cells(5).Value = "ينقل"
                            End If

                        Next b

                    Next i

                    ListBox1.Items.Add(total)

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()

                End Try

            End If
        End If
    End Sub

    Private Sub خروجToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles خروجToolStripMenuItem.Click
        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub

        End If
        Me.Close()
        Form2.Show()
        Form2.TextBox2.Clear()

    End Sub

    Private Sub ادخالنتيجهمقررToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ادخالنتيجهمقررToolStripMenuItem.Click
        set_res.Label16.Text = Label16.Text
        set_res.Label18.Text = Label18.Text
        set_res.Label19.Text = Label19.Text
        set_res.Show()

        Me.Close()
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


    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim no As New note
        no.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If flag = 1 Then

            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"

            Try

                conn.Open()

                Dim row As Integer = DataGridView1.Rows.Count
                Dim persen As String = ""
                Dim lec As String = ""

                adabter = New MySqlDataAdapter

                For i = 0 To row - 1 Step +1
                    If DataGridView1.Rows(i).Cells(0).Value = Nothing Or DataGridView1.Rows(i).Cells(1).Value = Nothing Or DataGridView1.Rows(i).Cells(2).Value = Nothing Or DataGridView1.Rows(i).Cells(3).Value = Nothing Or DataGridView1.Rows(i).Cells(4).Value = Nothing Or DataGridView1.Rows(i).Cells(5).Value = Nothing Then
                        MsgBox("عذرأ هنالك خطاء فى ادخال نتائج المقررات عليك ادخال نتائج المقررات أولآ", vbOKOnly + vbExclamation, "خطاء ")
                        Exit For
                        '                    Exit Sub
                    Else

                        Dim tbb As New DataTable

                        Dim qyk As String
                        qyk = " select * from academy.result where  std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "'"
                        com = New MySqlCommand(qyk, conn)
                        adabter.SelectCommand = com
                        adabter.Fill(tbb)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        If tbb.Rows.Count > 0 Then

                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("؟..   " & DataGridView1.Rows(i).Cells(0).Value & "   لقد تمت إضافه نتيجه هذا الطالب مسبقآ هل تريد تعديل بيانات هذا الطالب", vbYesNo + vbExclamation, "تعديل ")
                            If Ans = vbNo Then

                                '  Exit Sub
                                Continue For
                            Else

                                Try

                                    Dim qq As String
                                    qq = " update academy.result set res_degre='" & DataGridView1.Rows(i).Cells(2).Value & "',res_char='" & DataGridView1.Rows(i).Cells(4).Value & "',grade='" & DataGridView1.Rows(i).Cells(3).Value & "',department='" & ComboBox2.Text & "',dep_name='" & ComboBox4.Text & "',colage='" & ComboBox5.Text & "' where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "'"

                                    com = New MySqlCommand(qq, conn)

                                    If com.ExecuteNonQuery > 0 Then

                                        Dim t As New DataTable
                                        Dim q11 As String
                                        q11 = " select std_id,lecture,total_degre_exam from academy.res_lecture where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "' and flag='1' and active='" & 0 & "'"

                                        com = New MySqlCommand(q11, conn)

                                        adabter.SelectCommand = com
                                        adabter.Fill(t)

                                        DataGridView2.DataSource = t


                                        ListBox1.Items.Clear()
                                        ListBox2.Items.Clear()

                                        Dim row1 As Integer = DataGridView2.Rows.Count

                                        For j = 0 To row1 - 1

                                            lec = ""
                                            mol7ag = ""

                                            If DataGridView2.Rows(j).Cells(2).Value < 50 Then

                                                mol7ag = "نعم"
                                                set_exam = 1

                                            ElseIf DataGridView2.Rows(j).Cells(2).Value >= 50 Then

                                                mol7ag = "لا"
                                                set_exam = 0

                                            End If


                                            Dim q111 = " update academy.res_lecture set mol7ag='" & mol7ag & "',set_exam='" & set_exam & "' where std_id='" & DataGridView2.Rows(i).Cells(0).Value & "' and lecture='" & DataGridView2.Rows(j).Cells(1).Value & "' and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "' and flag='1'"

                                            Dim com002 = New MySqlCommand(q111, conn)

                                            If com002.ExecuteNonQuery > 0 Then
                                                MsgBox(DataGridView1.Rows(i).Cells(1).Value & " ::   اسم الطالب   " & DataGridView1.Rows(i).Cells(0).Value & " ::  الرقم الجامعى" & "  ::   تم تعديل نتيجة الطالب    ")
                                            End If

                                        Next j

                                        ''''''''''''''''''''''''''''''''''


                                        Dim qq1 As String = ""
                                        Dim mass As String = "تم تعديل نتيجة الطلاب للفصل الدراسى "
                                        qq1 = " Insert Into academy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label18.Text & "','" & Label16.Text & "' )"

                                        com = New MySqlCommand(qq1, conn)

                                        '''
                                        ''''''''''''''''''''''''''''''update to next leave''''''''''''''''
                                        If DataGridView1.Rows(i).Cells(5).Value = "ينقل" Then

                                            If ComboBox3.Text = "الفصل الاول" Or ComboBox3.Text = "الفصل الثالث" Or ComboBox3.Text = "الفصل الخامس" Or ComboBox3.Text = "الفصل السابع" Then

                                                Dim sem As String = ""

                                                If ComboBox3.Text = "الفصل الاول" Then
                                                    sem = "الفصل الثانى"
                                                ElseIf ComboBox3.Text = "الفصل الثالث" Then
                                                    sem = "الفصل الرابع"
                                                ElseIf ComboBox3.Text = "الفصل الخامس" Then
                                                    sem = "الفصل السادس"
                                                ElseIf ComboBox3.Text = "الفصل السابع" Then
                                                    sem = "الفصل الثامن"
                                                End If

                                                Dim qy2 As String
                                                Dim tbb02 As New DataTable

                                                qy2 = " select* from academy.record_academy where semester ='" & sem & "' and colage ='" & ComboBox5.Text & "' and depart_name='" & ComboBox4.Text & "' and depart_certificate='" & ComboBox2.Text & "'"
                                                Dim cm1 = New MySqlCommand(qy2, conn)
                                                adabter.SelectCommand = cm1
                                                adabter.Fill(tbb02)
                                                reader = cm1.ExecuteReader
                                                Dim n As String = ""
                                                ListBox4.Items.Clear()

                                                While reader.Read

                                                    n = reader.GetString("lecture")
                                                    ListBox4.Items.Add(n)

                                                End While

                                                reader.Close()

                                                If tbb02.Rows.Count > 0 Then
                                                    MsgBox(tbb02.Rows.Count)

                                                    For Each b In ListBox4.Items


                                                        Dim q5 = " Insert Into academy.std_atendess(std_id,lecture,semester,lec1,lec2,lec3,lec4,lec5,lec6,lec7,lec8,lec9,lec10,lec11,lec12,patch,active) values('" & DataGridView1.Rows(i).Cells(0).Value & "',  '" & b & "',  '" & sem & "',  '" & 0 & "',  '" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & ComboBox6.Text & "','" & 0 & "' )"
                                                        com = New MySqlCommand(q5, conn)
                                                        reader = com.ExecuteReader
                                                        reader.Close()
                                                    Next

                                                End If

                                                Dim tbbb02 As New DataTable
                                                Dim qqyk = " select * from academy.payment where  std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "'"
                                                com = New MySqlCommand(qqyk, conn)
                                                adabter.SelectCommand = com
                                                adabter.Fill(tbbb02)
                                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                                If tbbb02.Rows.Count > 0 Then

                                                    If IsDBNull(tbbb02(0)(3)) Then
                                                        fees = tbbb02(0)(3)

                                                    ElseIf IsDBNull(tbbb02(0)(4)) Then
                                                        p_now = fees
                                                    Else

                                                        fees = tbbb02(0)(3)
                                                        p_now = tbbb02(0)(4)
                                                        total_pay = fees - p_now
                                                    End If

                                                    Dim q12 = " Insert Into academy.payment(std_id,semester,pay_fees,pay_now,total_pay,patch,active) values('" & DataGridView1.Rows(i).Cells(0).Value & "',  '" & sem & "',  '" & fees & "',  '" & p_now & "','" & total_pay & "','" & ComboBox6.Text & "' ,'" & 0 & "')"
                                                    com = New MySqlCommand(q12, conn)
                                                    reader = com.ExecuteReader
                                                    reader.Close()
                                                    ''''''''''''''''''''''''''''''''''' ''''''''''''''''''''''''''''''''''''''''''''
                                                    Dim query = " update academy.std_info set semester='" & sem & "' where id_std='" & DataGridView1.Rows(i).Cells(0).Value & "' and patch='" & ComboBox6.Text & "'"
                                                    com = New MySqlCommand(query, conn)
                                                    reader = com.ExecuteReader
                                                    reader.Close()
                                                    If com.ExecuteNonQuery > 0 Then

                                                        MsgBox("لقد تم تسجبل هذا الطالب فى الفصل الدراسى " & DataGridView1.Rows(i).Cells(1).Value)

                                                    Else
                                                        MsgBox("لم يتم تسجيل الطالب")
                                                        conn.Dispose()

                                                    End If
                                                Else
                                                    MsgBox("fees null")

                                                End If
                                            Else
                                                MsgBox("sem")
                                            End If

                                        Else

                                            If ComboBox3.Text = "الفصل الاول" Or ComboBox3.Text = "الفصل الثالث" Or ComboBox3.Text = "الفصل الخامس" Or ComboBox3.Text = "الفصل السابع" Then
                                                Dim sem As String = ""

                                                If ComboBox3.Text = "الفصل الاول" Then
                                                    sem = "الفصل الثانى"
                                                ElseIf ComboBox3.Text = "الفصل الثالث" Then
                                                    sem = "الفصل الرابع"
                                                ElseIf ComboBox3.Text = "الفصل الخامس" Then
                                                    sem = "الفصل السادس"
                                                ElseIf ComboBox3.Text = "الفصل السابع" Then
                                                    sem = "الفصل الثامن"
                                                End If

                                                Dim qy2 As String
                                                Dim tbb02 As New DataTable

                                                qy2 = " select* from academy.record_academy where semester ='" & sem & "' and colage ='" & ComboBox5.Text & "' and depart_name='" & ComboBox4.Text & "' and depart_certificate='" & ComboBox2.Text & "'"
                                                Dim cm1 = New MySqlCommand(qy2, conn)
                                                adabter.SelectCommand = cm1
                                                adabter.Fill(tbb02)
                                                reader = cm1.ExecuteReader
                                                Dim n As String = ""
                                                ListBox4.Items.Clear()

                                                While reader.Read

                                                    n = reader.GetString("lecture")
                                                    ListBox4.Items.Add(n)

                                                End While

                                                reader.Close()

                                                If tbb02.Rows.Count > 0 Then
                                                    MsgBox(tbb02.Rows.Count)

                                                    For Each b In ListBox4.Items


                                                        Dim q5 = " Insert Into academy.std_atendess(std_id,lecture,semester,lec1,lec2,lec3,lec4,lec5,lec6,lec7,lec8,lec9,lec10,lec11,lec12,patch,active) values('" & DataGridView1.Rows(i).Cells(0).Value & "',  '" & b & "',  '" & sem & "',  '" & 0 & "',  '" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & ComboBox6.Text & "' ,'" & 0 & "')"
                                                        com = New MySqlCommand(q5, conn)
                                                        reader = com.ExecuteReader
                                                        reader.Close()
                                                    Next

                                                End If

                                                Dim tbbb02 As New DataTable
                                                Dim qqyk = " select * from academy.payment where  std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "'"
                                                com = New MySqlCommand(qqyk, conn)
                                                adabter.SelectCommand = com
                                                adabter.Fill(tbbb02)
                                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                                If tbbb02.Rows.Count > 0 Then


                                                    If IsDBNull(tbbb02(0)(3)) Then
                                                        fees = tbbb02(0)(3)

                                                    ElseIf IsDBNull(tbbb02(0)(4)) Then
                                                        p_now = fees
                                                    Else

                                                        fees = tbbb02(0)(3)
                                                        p_now = tbbb02(0)(4)
                                                        total_pay = fees - p_now
                                                    End If

                                                    Dim q12 = " Insert Into academy.payment(std_id,semester,pay_fees,pay_now,total_pay,patch,active) values('" & DataGridView1.Rows(i).Cells(0).Value & "',  '" & sem & "',  '" & fees & "',  '" & p_now & "','" & total_pay & "','" & ComboBox6.Text & "','" & 0 & "' )"
                                                    com = New MySqlCommand(q12, conn)
                                                    reader = com.ExecuteReader
                                                    reader.Close()
                                                    ''''''''''''''''''''''''''''''''''' ''''''''''''''''''''''''''''''''''''''''''''
                                                    Dim query = " update academy.std_info set semester='" & sem & "' where id_std='" & DataGridView1.Rows(i).Cells(0).Value & "' and patch='" & ComboBox6.Text & "'"
                                                    com = New MySqlCommand(query, conn)
                                                    reader = com.ExecuteReader
                                                    reader.Close()
                                                    If com.ExecuteNonQuery > 0 Then

                                                        MsgBox("لقد تم تسجبل هذا الطالب فى الفصل الدراسى " & DataGridView1.Rows(i).Cells(1).Value)

                                                    Else
                                                        MsgBox("لم يتم تسجيل الطالب")
                                                        conn.Dispose()

                                                    End If
                                                Else
                                                    MsgBox("fees null")

                                                End If

                                            Else
                                                MsgBox("2")
                                            End If

                                        End If

                                    End If
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try

                            End If

                        Else
                            Try
                                reader.Close()
                                com.Parameters.Clear()

                                Dim qq As String = ""

                                '                qq = " update academy.result set res_degre='" & DataGridView1.Rows(i).Cells(2).Value & "',res_char='" & DataGridView1.Rows(i).Cells(4).Value & "',grade='" & DataGridView1.Rows(i).Cells(3).Value & "',semester='" & ComboBox3.Text & "' where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "'"
                                qq = " Insert Into academy.result (res_degre,res_char,grade,semester, std_id,department,dep_name,colage,patch,active)values('" & DataGridView1.Rows(i).Cells(2).Value & "','" & DataGridView1.Rows(i).Cells(4).Value & "','" & DataGridView1.Rows(i).Cells(3).Value & "','" & ComboBox3.Text & "' ,'" & DataGridView1.Rows(i).Cells(0).Value & "','" & ComboBox2.Text & "','" & ComboBox4.Text & "','" & ComboBox5.Text & "','" & ComboBox6.Text & "','" & 0 & "')"

                                com = New MySqlCommand(qq, conn)
                                If com.ExecuteNonQuery > 0 Then
                                    'Dim tb As DataTable
                                    Dim q1 As String
                                    Dim ttt As New DataTable
                                    q1 = " select std_id,lecture,total_degre_exam from academy.res_lecture where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "' and flag='1' and active='" & 0 & "'"
                                    com = New MySqlCommand(q1, conn)
                                    adabter.SelectCommand = com
                                    adabter.Fill(ttt)
                                    DataGridView2.DataSource = ttt

                                    Dim row1 As Integer = DataGridView2.Rows.Count
                                    For j = 0 To row1 - 1
                                        lec = ""
                                        mol7ag = ""

                                        If DataGridView2.Rows(j).Cells(2).Value < 50 Then
                                            mol7ag = "نعم"
                                            set_exam = 1
                                        ElseIf DataGridView2.Rows(j).Cells(2).Value >= 50 Then
                                            mol7ag = "لا"
                                            set_exam = 0
                                        End If

                                        Dim q111 = " update academy.res_lecture set set_exam='" & set_exam & "',mol7ag='" & mol7ag & "' where std_id='" & DataGridView2.Rows(i).Cells(0).Value & "' and lecture='" & DataGridView2.Rows(j).Cells(1).Value & "' and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "' and flag='1'"
                                        Dim tb As New DataTable
                                        com = New MySqlCommand(q111, conn)
                                        adabter.SelectCommand = com
                                        adabter.Fill(tb)
                                        If com.ExecuteNonQuery > 0 Then
                                            MsgBox(DataGridView1.Rows(i).Cells(1).Value & " ::   اسم الطالب   " & DataGridView1.Rows(i).Cells(0).Value & " ::  الرقم الجامعى" & "  ::   تم تعديل نتيجة الطالب    ")
                                        End If

                                    Next j

                                    '''''''''''''''''''''''''''''''''''''''''''''''

                                    Dim qq1 As String = ""
                                    Dim mass As String = "تم تاكيد نتيجة الطلاب للفصل الدراسى "
                                    qq1 = " Insert Into academy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label18.Text & "','" & Label16.Text & "' )"

                                    com = New MySqlCommand(qq1, conn)

                                    '''

                                    ''''''''''''''''''''''''''''''update to next leave''''''''''''''''
                                    If DataGridView1.Rows(i).Cells(5).Value = "ينقل" Then
                                        If ComboBox3.Text = "الفصل الاول" Or ComboBox3.Text = "الفصل الثالث" Or ComboBox3.Text = "الفصل الخامس" Or ComboBox3.Text = "الفصل السابع" Then
                                            Dim sem As String = ""

                                            If ComboBox3.Text = "الفصل الاول" Then
                                                sem = "الفصل الثانى"
                                            ElseIf ComboBox3.Text = "الفصل الثالث" Then
                                                sem = "الفصل الرابع"
                                            ElseIf ComboBox3.Text = "الفصل الخامس" Then
                                                sem = "الفصل السادس"
                                            ElseIf ComboBox3.Text = "الفصل السابع" Then
                                                sem = "الفصل الثامن"
                                            End If

                                            Dim qy2 As String
                                            Dim tbb02 As New DataTable

                                            qy2 = " select* from academy.record_academy where semester ='" & sem & "' and colage ='" & ComboBox5.Text & "' and depart_name='" & ComboBox4.Text & "' and depart_certificate='" & ComboBox2.Text & "'"
                                            Dim cm1 = New MySqlCommand(qy2, conn)
                                            adabter.SelectCommand = cm1
                                            adabter.Fill(tbb02)
                                            reader = cm1.ExecuteReader
                                            Dim n As String = ""
                                            ListBox4.Items.Clear()

                                            While reader.Read

                                                n = reader.GetString("lecture")
                                                ListBox4.Items.Add(n)

                                            End While

                                            reader.Close()

                                            If tbb02.Rows.Count > 0 Then
                                                MsgBox(tbb02.Rows.Count)

                                                For Each b In ListBox4.Items


                                                    Dim q5 = " Insert Into academy.std_atendess(std_id,lecture,semester,lec1,lec2,lec3,lec4,lec5,lec6,lec7,lec8,lec9,lec10,lec11,lec12,patch,active) values('" & DataGridView1.Rows(i).Cells(0).Value & "',  '" & b & "',  '" & sem & "',  '" & 0 & "',  '" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "' ,'" & ComboBox6.Text & "','" & 0 & "')"
                                                    com = New MySqlCommand(q5, conn)
                                                    reader = com.ExecuteReader
                                                    reader.Close()
                                                Next

                                            End If

                                            Dim tbbb02 As New DataTable
                                            Dim qqyk = " select * from academy.payment where  std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "'"
                                            com = New MySqlCommand(qqyk, conn)
                                            adabter.SelectCommand = com
                                            adabter.Fill(tbbb02)
                                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                            If tbbb02.Rows.Count > 0 Then


                                                If IsDBNull(tbbb02(0)(3)) Then
                                                    fees = tbbb02(0)(3)

                                                ElseIf IsDBNull(tbbb02(0)(4)) Then
                                                    p_now = fees
                                                Else

                                                    fees = tbbb02(0)(3)
                                                    p_now = tbbb02(0)(4)
                                                    total_pay = fees - p_now
                                                End If


                                                Dim q12 = " Insert Into academy.payment(std_id,semester,pay_fees,pay_now,total_pay,patch,active) values('" & DataGridView1.Rows(i).Cells(0).Value & "',  '" & sem & "',  '" & fees & "',  '" & p_now & "','" & total_pay & "' ,'" & ComboBox6.Text & "','" & 0 & "')"
                                                com = New MySqlCommand(q12, conn)
                                                reader = com.ExecuteReader
                                                reader.Close()
                                                ''''''''''''''''''''''''''''''''''' ''''''''''''''''''''''''''''''''''''''''''''
                                                Dim query = " update academy.std_info set semester='" & sem & "' where id_std='" & DataGridView1.Rows(i).Cells(0).Value & "' and patch='" & ComboBox6.Text & "'"
                                                com = New MySqlCommand(query, conn)
                                                reader = com.ExecuteReader
                                                reader.Close()
                                                If com.ExecuteNonQuery > 0 Then

                                                    MsgBox("لقد تم تسجبل هذا الطالب فى الفصل الدراسى " & DataGridView1.Rows(i).Cells(1).Value)

                                                Else
                                                    MsgBox("لم يتم تسجيل الطالب")
                                                    conn.Dispose()

                                                End If
                                            Else
                                                MsgBox("fees null")

                                            End If
                                        Else
                                            MsgBox("2")
                                        End If

                                    Else

                                        If ComboBox3.Text = "الفصل الاول" Or ComboBox3.Text = "الفصل الثالث" Or ComboBox3.Text = "الفصل الخامس" Or ComboBox3.Text = "الفصل السابع" Then
                                            Dim sem As String = ""

                                            If ComboBox3.Text = "الفصل الاول" Then
                                                sem = "الفصل الثانى"
                                            ElseIf ComboBox3.Text = "الفصل الثالث" Then
                                                sem = "الفصل الرابع"
                                            ElseIf ComboBox3.Text = "الفصل الخامس" Then
                                                sem = "الفصل السادس"
                                            ElseIf ComboBox3.Text = "الفصل السابع" Then
                                                sem = "الفصل الثامن"
                                            End If

                                            Dim qy2 As String
                                            Dim tbb02 As New DataTable

                                            qy2 = " select* from academy.record_academy where semester ='" & sem & "' and colage ='" & ComboBox5.Text & "' and depart_name='" & ComboBox4.Text & "' and depart_certificate='" & ComboBox2.Text & "' "
                                            Dim cm1 = New MySqlCommand(qy2, conn)
                                            adabter.SelectCommand = cm1
                                            adabter.Fill(tbb02)
                                            reader = cm1.ExecuteReader
                                            Dim n As String = ""
                                            ListBox4.Items.Clear()

                                            While reader.Read

                                                n = reader.GetString("lecture")
                                                ListBox4.Items.Add(n)

                                            End While

                                            reader.Close()

                                            If tbb02.Rows.Count > 0 Then
                                                MsgBox(tbb02.Rows.Count)

                                                For Each b In ListBox4.Items


                                                    Dim q5 = " Insert Into academy.std_atendess(std_id,lecture,semester,lec1,lec2,lec3,lec4,lec5,lec6,lec7,lec8,lec9,lec10,lec11,lec12,patch,active) values('" & DataGridView1.Rows(i).Cells(0).Value & "',  '" & b & "',  '" & sem & "',  '" & 0 & "',  '" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "','" & 0 & "' ,'" & ComboBox6.Text & "','" & 0 & "')"
                                                    com = New MySqlCommand(q5, conn)
                                                    reader = com.ExecuteReader
                                                    reader.Close()
                                                Next

                                            End If

                                            Dim tbbb02 As New DataTable
                                            Dim qqyk = " select * from academy.payment where  std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "'"
                                            com = New MySqlCommand(qqyk, conn)
                                            adabter.SelectCommand = com
                                            adabter.Fill(tbbb02)
                                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                            If tbbb02.Rows.Count > 0 Then


                                                If IsDBNull(tbbb02(0)(3)) Then
                                                    fees = tbbb02(0)(3)

                                                ElseIf IsDBNull(tbbb02(0)(4)) Then
                                                    p_now = fees
                                                Else

                                                    fees = tbbb02(0)(3)
                                                    p_now = tbbb02(0)(4)
                                                    total_pay = fees - p_now
                                                End If

                                                Dim q12 = " Insert Into academy.payment(std_id,semester,pay_fees,pay_now,total_pay,patch,active) values('" & DataGridView1.Rows(i).Cells(0).Value & "',  '" & sem & "',  '" & fees & "',  '" & p_now & "','" & total_pay & "' ,'" & ComboBox6.Text & "','" & 0 & "')"
                                                com = New MySqlCommand(q12, conn)
                                                reader = com.ExecuteReader
                                                reader.Close()
                                                ''''''''''''''''''''''''''''''''''' ''''''''''''''''''''''''''''''''''''''''''''
                                                Dim query = " update academy.std_info set semester='" & sem & "' where id_std='" & DataGridView1.Rows(i).Cells(0).Value & "' and patch='" & ComboBox6.Text & "'"
                                                com = New MySqlCommand(query, conn)
                                                reader = com.ExecuteReader
                                                reader.Close()
                                                If com.ExecuteNonQuery > 0 Then

                                                    MsgBox("لقد تم تسجبل هذا الطالب فى الفصل الدراسى " & DataGridView1.Rows(i).Cells(1).Value)

                                                Else
                                                    MsgBox("لم يتم تسجيل الطالب")
                                                    conn.Dispose()

                                                End If
                                            Else
                                                MsgBox("fees null")

                                            End If
                                        Else
                                            MsgBox("2")
                                        End If

                                    End If

                                Else
                                    MsgBox("لم بتم التعديل")
                                End If

                            Catch ex As Exception
                                MsgBox(ex.Message)
                            End Try

                            MsgBox(DataGridView1.Rows(i).Cells(1).Value & " ::   اسم الطالب   " & DataGridView1.Rows(i).Cells(0).Value & " ::  الرقم الجامعى" & "  ::   تم ادخال نتيجة الطالب    ")

                            '   reader.Close()
                            mol7ag = ""
                        End If
                    End If
                    ' reader.Close()
                    'com.Parameters.Clear()
                Next i

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try





        ElseIf flag = 2 Then

            reader.Close()
            com.Parameters.Clear()





            conn = New MySqlConnection
                    conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"

            Try

                conn.Open()

                Dim row As Integer = DataGridView1.Rows.Count

                adabter = New MySqlDataAdapter

                For i = 0 To row - 1 Step +1

                    If DataGridView1.Rows(i).Cells(0).Value = Nothing Or DataGridView1.Rows(i).Cells(1).Value = Nothing Or DataGridView1.Rows(i).Cells(2).Value = Nothing Or DataGridView1.Rows(i).Cells(3).Value = Nothing Or DataGridView1.Rows(i).Cells(4).Value = Nothing Or DataGridView1.Rows(i).Cells(5).Value = Nothing Then
                        MsgBox("عذرأ هنالك خطاء فى ادخال نتائج المقررات عليك ادخال نتائج المقررات أولآ", vbOKOnly + vbExclamation, "خطاء ")
                        Exit For

                    Else

                        ' DataGridView1.Columns.Clear()
                        'DataGridView4.Columns.Clear()
                        'DataGridView3.Columns.Clear()

                        Dim tbb As New DataTable

                        Dim qyk As String
                        qyk = " select * from academy.result where  std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "'"

                        com = New MySqlCommand(qyk, conn)

                        adabter.SelectCommand = com
                        adabter.Fill(tbb)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        If tbb.Rows.Count > 0 Then
                            com.Parameters.Clear()

                            Dim qq As String
                            qq = " update academy.result set res_degre='" & DataGridView1.Rows(i).Cells(2).Value & "',res_char='" & DataGridView1.Rows(i).Cells(4).Value & "',grade='" & DataGridView1.Rows(i).Cells(3).Value & "',department='" & ComboBox2.Text & "',dep_name='" & ComboBox4.Text & "',colage='" & ComboBox5.Text & "' where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "'"

                            com = New MySqlCommand(qq, conn)

                            If com.ExecuteNonQuery > 0 Then
                                com.Parameters.Clear()

                                Dim q As String
                                q = " update academy.res_lecture set set_mol='0' , set_exam=1  where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "' and set_mol='1'"

                                com = New MySqlCommand(q, conn)

                                If com.ExecuteNonQuery > 0 Then
                                    com.Parameters.Clear()
                                    '''''''''''''''''''''''''''''''''''''''''''''''

                                    Dim qq1 As String = ""
                                    Dim mass As String = "تم تعديل نتيجة الملاحق  للفصل الدراسى "
                                    qq1 = " Insert Into academy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label18.Text & "','" & Label16.Text & "' )"

                                    com = New MySqlCommand(qq1, conn)

                                    MsgBox("تم تعديل نتيجة الملاحق")

                                Else

                                    MsgBox("لم يتم")

                                End If



                            Else

                                MsgBox("لم يتم")

                            End If

                        Else

                            reader.Close()

                            Dim q1q As String = ""

                            q1q = " Insert Into academy.result (res_degre,res_char,grade,semester, std_id,department,dep_name,colage,patch,active)values('" & DataGridView1.Rows(i).Cells(2).Value & "','" & DataGridView1.Rows(i).Cells(4).Value & "','" & DataGridView1.Rows(i).Cells(3).Value & "','" & ComboBox3.Text & "' ,'" & DataGridView1.Rows(i).Cells(0).Value & "','" & ComboBox2.Text & "','" & ComboBox4.Text & "','" & ComboBox5.Text & "','" & ComboBox6.Text & "','" & 0 & "')"

                            com = New MySqlCommand(q1q, conn)

                            If com.ExecuteNonQuery > 0 Then
                                com.Parameters.Clear()

                                Dim q1 As String
                                q1 = " update academy.res_lecture set set_mol='0' , set_exam=1 where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "' and set_mol='1'"

                                com = New MySqlCommand(q1, conn)

                                If com.ExecuteNonQuery > 0 Then
                                    com.Parameters.Clear()
                                    '''''''''''''''''''''''''''''''''''''''''''''''

                                    Dim qq1 As String = ""
                                    Dim mass As String = "تم تاكيد نتيجة الملاحق  للفصل الدراسى "
                                    qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label18.Text & "','" & Label16.Text & "' )"

                                    com = New MySqlCommand(qq1, conn)

                                    MsgBox("تم التعديل ")

                                Else

                                    MsgBox("لم يتم")

                                End If

                                MsgBox("تم ادخال نتيجة الملاحق")

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

    Private Sub إجلاسالطلابللامتحانToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles إجلاسالطلابللامتحانToolStripMenuItem.Click
        set_std_to_exam.Show()
        Me.Close()

    End Sub

    Private Sub جدولالحضوروالمتابعهToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles جدولالحضوروالمتابعهToolStripMenuItem.Click
        Me.Close()
        attendees.Show()

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If flag = 1 Then

            Dim index As Integer = 0

            index = e.RowIndex

            Dim selecterow As DataGridViewRow
            selecterow = DataGridView1.Rows(index)

            Dim adapter = New MySqlDataAdapter
            Dim bsorc = New BindingSource
            Dim table = New DataTable

            Dim conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"



            Try
                conn.Open()

                DataGridView2.Columns.Clear()
                DataGridView3.Columns.Clear()

                adapter = New MySqlDataAdapter

                Dim ttt1 As New DataTable

                Dim query101 As String
                query101 = " select std_id as'الرقم الجامعى',lecture as'المقرر',degre as'درجة الامتحان',degre_metarm as'درجة نصف الفصل',total_degre_exam as'الدرجة الكامله للطالب',grade as'التقدير' from academy.res_lecture where std_id='" & DataGridView1.Rows(index).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' and flag='" & flag & "' "

                com = New MySqlCommand(query101, conn)
                adapter.SelectCommand = com

                adapter.Fill(ttt1)

                DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                DataGridView3.DataSource = ttt1

                Dim exam As New DataGridViewTextBoxColumn() With {.HeaderText = "ملاحق", .Name = "exam", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}

                DataGridView3.Columns.Insert(6, exam)

                Dim row As Integer = DataGridView3.Rows.Count

                For i = 0 To row - 1 Step +1

                    If DataGridView3.Rows(i).Cells(4).Value < 50 Then
                        DataGridView3.Rows(i).Cells(6).Value = "نعم"
                    Else
                        DataGridView3.Rows(i).Cells(6).Value = "لا"
                    End If

                Next i


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()
            End Try

        ElseIf flag = 2 Then

            Dim index As Integer = 0

            index = e.RowIndex

            Dim selecterow As DataGridViewRow

            selecterow = DataGridView1.Rows(index)

            Dim adapter = New MySqlDataAdapter
            Dim bsorc = New BindingSource
            Dim table = New DataTable

            Dim conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"



            Try
                conn.Open()

                DataGridView2.Columns.Clear()
                DataGridView3.Columns.Clear()

                adapter = New MySqlDataAdapter

                Dim ttt1 As New DataTable

                Dim query101 As String
                query101 = " select std_id,lecture,degre,degre_metarm,total_degre_exam,grade from academy.res_lecture where std_id='" & DataGridView1.Rows(index).Cells(0).Value & "' and semester='" & ComboBox3.Text & "' "

                com = New MySqlCommand(query101, conn)
                adapter.SelectCommand = com

                adapter.Fill(ttt1)

                DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                DataGridView3.DataSource = ttt1

                Dim exam As New DataGridViewTextBoxColumn() With {.HeaderText = "ملاحق", .Name = "exam", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}

                DataGridView3.Columns.Insert(6, exam)

                Dim row As Integer = DataGridView3.Rows.Count
                For i = 0 To row - 1 Step +1
                    If DataGridView3.Rows(i).Cells(4).Value < 50 Then
                        DataGridView3.Rows(i).Cells(6).Value = "نعم"
                    Else
                        DataGridView3.Rows(i).Cells(6).Value = "لا"
                    End If

                Next i



            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()
            End Try

        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        GroupBox4.Text = "بيانات الطالب "
        GroupBox5.Text = "معدل الفصل الدراسي "

        GroupBox6.Visible = False
        Button6.Visible = False
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

        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        ComboBox6.Enabled = True

        DataGridView1.Columns.Clear()
        DataGridView2.Columns.Clear()
        DataGridView3.Columns.Clear()
        DataGridView4.Columns.Clear()
        Label4.Visible = False
        ComboBox1.Visible = False
        Label9.Visible = True
        ComboBox3.Visible = True

        flag = 1
        Panel4.Visible = True
        Panel5.Visible = False
        Panel6.Visible = False

        ErrorProvider1.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        GroupBox4.Text = "بيانات الطالب "
        GroupBox5.Text = "معدل الفصل الدراسي "

        GroupBox6.Visible = False
        Button6.Visible = False

        ComboBox1.Items.Clear()

        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing

        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False

        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        ComboBox6.Text = Nothing
        ComboBox6.Enabled = True

        DataGridView1.Columns.Clear()
        DataGridView2.Columns.Clear()
        DataGridView3.Columns.Clear()
        DataGridView4.Columns.Clear()

        Label4.Visible = False
        ComboBox1.Visible = False
        Label9.Visible = True
        ComboBox3.Visible = True

        flag = 2
        Panel5.Visible = True
        Panel4.Visible = False
        Panel6.Visible = False

        ErrorProvider1.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button6.Visible = True
        DataGridView1.Columns.Clear()
        DataGridView2.Columns.Clear()
        DataGridView3.Columns.Clear()
        DataGridView4.Columns.Clear()

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

        flag = 0

        Panel4.Visible = False
        Panel5.Visible = False
        Panel6.Visible = False
        GroupBox6.Visible = False

        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub

        End If
        Me.Close()
        Form2.Show()
        Form2.TextBox2.Clear()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        GroupBox6.Text = "نتيجه السمستر "
        GroupBox4.Text = "نتيجه السمستر "
        GroupBox5.Text = "نتيجه السنة "

        ComboBox1.Items.Clear()

        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing

        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False

        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        ComboBox6.Text = Nothing
        ComboBox6.Enabled = True

        DataGridView1.Columns.Clear()
        DataGridView2.Columns.Clear()
        DataGridView3.Columns.Clear()
        DataGridView4.Columns.Clear()

        GroupBox6.Visible = True

        Label9.Visible = False
        ComboBox3.Visible = False
        Label4.Visible = True
        ComboBox1.Visible = True

        flag = 3

        Panel6.Visible = True
        Panel5.Visible = False
        Panel4.Visible = False

        ErrorProvider1.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        DataGridView1.Columns.Clear()
        DataGridView2.Columns.Clear()
        DataGridView3.Columns.Clear()
        DataGridView4.Columns.Clear()



        If flag = 3 Then
            '  MsgBox("1")
            Dim sem1 As String = ""
            Dim sem2 As String = ""



            If ComboBox1.Text = "السنةالاولي" Then
                sem1 = "الفصل الاول"
                sem2 = "الفصل الثانى"
                ' MsgBox(sem1)
                'MsgBox(sem2)
            ElseIf ComboBox1.Text = "السنةالثانية" Then
                sem1 = "الفصل الثالث"
                sem2 = "الفصل الرابع"

            ElseIf ComboBox1.Text = "السنةالثالثة" Then
                sem1 = "الفصل الخامس"
                sem2 = "الفصل السادس"

            ElseIf ComboBox1.Text = "السنةالرابعة" Then
                sem1 = "الفصل السابع"
                sem2 = "الفصل الثامن"

            ElseIf ComboBox1.Text = "السنةالخامسة" Then
                sem1 = ""
                sem2 = ""

            End If

            GroupBox6.Text = sem2
            GroupBox4.Text = sem1
            GroupBox5.Text = "نتيجة " & ComboBox1.Text



            com = New MySqlCommand
            adabter = New MySqlDataAdapter
            Dim tablee As New DataTable

            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try

                conn.Open()


                MsgBox(sem1)
                MsgBox(sem2)
                DataGridView1.Columns.Clear()
                DataGridView3.Columns.Clear()
                DataGridView4.Columns.Clear()

                Dim query As String
                query = " select std_id as'الرقم الجامعى',res_degre as'الدرجة',grade as'التقدير',res_char as'النتيجة' from academy.result where colage='" & ComboBox5.Text & "' and dep_name='" & ComboBox4.Text & "' and semester='" & sem1 & "' and department='" & ComboBox2.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "' ORDER BY std_id ASC"

                com = New MySqlCommand(query, conn)
                adabter.SelectCommand = com
                adabter.Fill(tablee)
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

                DataGridView1.DataSource = tablee

                Dim tt As New DataTable
                Dim query1 As String
                query1 = " select std_id as'الرقم الجامعى',res_degre as'الدرجة',grade as'التقدير',res_char as'النتيجة' from academy.result where colage='" & ComboBox5.Text & "' and dep_name='" & ComboBox4.Text & "' and semester='" & sem2 & "' and department='" & ComboBox2.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "' ORDER BY std_id ASC"

                com = New MySqlCommand(query1, conn)
                adabter.SelectCommand = com
                adabter.Fill(tt)
                DataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

                DataGridView4.DataSource = tt

                '''''''''''''''''''''''''''''''''''''''' set result years '''''''''''''''''
                Dim t1 As New DataTable

                DataGridView3.Columns.Clear()

                Dim query2 As String
                query2 = " select id_std as'الرقم الجامعى',name_std as'اسم الطالب' from academy.std_info where colage='" & ComboBox5.Text & "' and department='" & ComboBox4.Text & "' and semester='" & sem2 & "' and depart_certificate='" & ComboBox2.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "' ORDER BY id_std ASC"
                com = New MySqlCommand(query2, conn)
                adabter.SelectCommand = com
                adabter.Fill(t1)
                DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                DataGridView3.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders

                Dim persentage As New DataGridViewTextBoxColumn() With {.HeaderText = "النسبة", .Name = "text", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                Dim Grade As New DataGridViewTextBoxColumn() With {.HeaderText = "التقدير", .Name = "text", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                Dim result As New DataGridViewTextBoxColumn() With {.HeaderText = "النتيجه", .Name = "text", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                Dim mol7g As New DataGridViewTextBoxColumn() With {.HeaderText = "الحاله", .Name = "text", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}

                DataGridView3.DataSource = t1

                DataGridView3.Columns.Insert(2, persentage)
                DataGridView3.Columns.Insert(3, Grade)
                DataGridView3.Columns.Insert(4, result)
                DataGridView3.Columns.Insert(5, mol7g)


                Dim row1 As Integer = DataGridView3.Rows.Count
                For ii = 0 To row1 - 1 Step +1
                    Dim s As Double = (DataGridView1.Rows(ii).Cells(1).Value + DataGridView4.Rows(ii).Cells(1).Value) / 1.5
                    ListBox1.Items.Add(s)
                    DataGridView3.Rows(ii).Cells(2).Value = s

                    Dim gr As String = ""

                    If s >= 3.8 Then
                        gr = "ممتاز"
                    ElseIf s >= 3.5 Then
                        gr = "جيد جدآ"

                    ElseIf s >= 2.7 Then
                        gr = "جيد"
                    ElseIf s >= 2 And s < 2.7 Then
                        gr = "مقبول"

                    ElseIf s < 2 Then
                        gr = "ضعيف"
                    End If

                    DataGridView3.Rows(ii).Cells(3).Value = gr

                    If DataGridView3.Rows(ii).Cells(3).Value = "ممتاز" Then
                        DataGridView3.Rows(ii).Cells(4).Value = "نجاح"
                    ElseIf DataGridView3.Rows(ii).Cells(3).Value = "جيد جدآ" Then
                        DataGridView3.Rows(ii).Cells(4).Value = "نجاح"
                    ElseIf DataGridView3.Rows(ii).Cells(3).Value = "جيد" Then
                        DataGridView3.Rows(ii).Cells(4).Value = "نجاح"
                    ElseIf DataGridView3.Rows(ii).Cells(3).Value = "مقبول" Then
                        DataGridView3.Rows(ii).Cells(4).Value = "نجاح"
                    ElseIf DataGridView3.Rows(ii).Cells(3).Value = "ضعيف" Then
                        DataGridView3.Rows(ii).Cells(4).Value = "إعادة"
                    End If
                    If DataGridView3.Rows(ii).Cells(4).Value = "نجاح" Then
                        DataGridView3.Rows(ii).Cells(5).Value = "ينقل"
                    ElseIf DataGridView3.Rows(ii).Cells(4).Value = "إعادة" Then
                        DataGridView3.Rows(ii).Cells(5).Value = "إعادة"
                    End If

                Next ii
                Button6.Visible = True


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try




        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If flag = 3 Then
            Dim sem1 As String = ""
            Dim sem2 As String = ""



            If ComboBox1.Text = "السنةالاولي" Then
                sem1 = "الفصل الاول"
                sem2 = "الفصل الثانى"
                ' MsgBox(sem1)
                'MsgBox(sem2)
            ElseIf ComboBox1.Text = "السنةالثانية" Then
                sem1 = "الفصل الثالث"
                sem2 = "الفصل الرابع"

            ElseIf ComboBox1.Text = "السنةالثالثة" Then
                sem1 = "الفصل الخامس"
                sem2 = "الفصل السادس"

            ElseIf ComboBox1.Text = "السنةالرابعة" Then
                sem1 = "الفصل السابع"
                sem2 = "الفصل الثامن"

            ElseIf ComboBox1.Text = "السنةالخامسة" Then
                sem1 = ""
                sem2 = ""

            End If

            Dim ro As Integer = DataGridView3.Rows.Count
            For n01 = 0 To ro - 1 Step +1
                If DataGridView1.Rows(n01).Cells(0).Value = Nothing Or DataGridView1.Rows(n01).Cells(1).Value = Nothing Or DataGridView1.Rows(n01).Cells(2).Value = Nothing Or DataGridView1.Rows(n01).Cells(3).Value = Nothing Then
                    MsgBox("عذرأ هنالك خطاء فى ادخال نتائج " & sem1, vbOKOnly + vbExclamation, "خطاء ")
                    Exit For
                ElseIf DataGridView4.Rows(n01).Cells(0).Value = Nothing Or DataGridView4.Rows(n01).Cells(1).Value = Nothing Or DataGridView4.Rows(n01).Cells(2).Value = Nothing Or DataGridView4.Rows(n01).Cells(3).Value = Nothing Then
                    MsgBox("عذرأ هنالك خطاء فى ادخال نتائج " & sem2, vbOKOnly + vbExclamation, "خطاء ")
                    Exit For
                ElseIf DataGridView3.Rows(n01).Cells(0).Value = Nothing Or DataGridView3.Rows(n01).Cells(1).Value = Nothing Or DataGridView3.Rows(n01).Cells(2).Value = Nothing Or DataGridView3.Rows(n01).Cells(3).Value = Nothing Or DataGridView3.Rows(n01).Cells(4).Value = Nothing Or DataGridView3.Rows(n01).Cells(5).Value = Nothing Then
                    MsgBox("عذرأ هنالك خطاء فى معالجة نتيجة " & DataGridView3.Rows(n01).Cells(0).Value, vbOKOnly + vbExclamation, "خطاء ")
                    Exit For

                Else



                    conn = New MySqlConnection
                    conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
                    Try


                        conn.Open()
                        Dim qyk As String
                        Dim tbb As New DataTable
                        qyk = " select * from academy.result_year where  std_id='" & DataGridView3.Rows(n01).Cells(0).Value & "' and year='" & ComboBox1.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "'"
                        com = New MySqlCommand(qyk, conn)
                        adabter.SelectCommand = com
                        adabter.Fill(tbb)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        If tbb.Rows.Count > 0 Then
                            MsgBox(tbb.Rows.Count)

                            Dim Ans As MsgBoxResult
                            Ans = MsgBox("؟..   " & DataGridView3.Rows(n01).Cells(0).Value & "   لقد تمت إضافه نتيجه هذا الطالب مسبقآ هل تريد تعديل بيانات هذا الطالب", vbYesNo + vbExclamation, "تعديل ")
                            If Ans = vbNo Then

                                ' Exit Sub
                                Continue For
                            Else
                                Try
                                    Dim qq As String
                                    qq = " update academy.result_year set result='" & DataGridView3.Rows(n01).Cells(5).Value & "',res_degre='" & DataGridView3.Rows(n01).Cells(2).Value & "',res_char='" & DataGridView3.Rows(n01).Cells(4).Value & "',grade='" & DataGridView3.Rows(n01).Cells(3).Value & "',department='" & ComboBox2.Text & "',dep_name='" & ComboBox4.Text & "',colage='" & ComboBox5.Text & "' where std_id='" & DataGridView3.Rows(n01).Cells(0).Value & "' and year='" & ComboBox1.Text & "' and patch='" & ComboBox6.Text & "' "

                                    com = New MySqlCommand(qq, conn)

                                    If com.ExecuteNonQuery > 0 Then
                                        '''''''''''''''''''''''''''''''''''''''''''''''

                                        Dim qq1 As String = ""
                                        Dim mass As String = "تم تعديل النتيجة النهائيه للسنة الدراسية "
                                        qq1 = " Insert Into academy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label18.Text & "','" & Label16.Text & "' )"

                                        com = New MySqlCommand(qq1, conn)

                                        MsgBox("تم التعديل")
                                    Else
                                        MsgBox("لم يتم التعديل ")


                                    End If
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                Finally
                                    conn.Dispose()

                                End Try

                            End If

                        Else

                            Dim qq As String = ""

                            '                qq = " update academy.result set res_degre='" & DataGridView1.Rows(i).Cells(2).Value & "',res_char='" & DataGridView1.Rows(i).Cells(4).Value & "',grade='" & DataGridView1.Rows(i).Cells(3).Value & "',semester='" & ComboBox3.Text & "' where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "'"
                            qq = " Insert Into academy.result_year (res_degre,res_char,grade,year, std_id,department,dep_name,colage,result,patch,active)values('" & DataGridView3.Rows(n01).Cells(2).Value & "','" & DataGridView3.Rows(n01).Cells(4).Value & "','" & DataGridView3.Rows(n01).Cells(3).Value & "','" & ComboBox1.Text & "' ,'" & DataGridView3.Rows(n01).Cells(0).Value & "','" & ComboBox2.Text & "','" & ComboBox4.Text & "','" & ComboBox5.Text & "','" & DataGridView3.Rows(n01).Cells(5).Value & "','" & ComboBox6.Text & "','" & 0 & "')"

                            com = New MySqlCommand(qq, conn)

                            If com.ExecuteNonQuery > 0 Then
                                '''''''''''''''''''''''''''''''''''''''''''''''

                                Dim qq1 As String = ""
                                Dim mass As String = "تم تاكيد النتيجة النهائيه للسنة الدراسية "
                                qq1 = " Insert Into academy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label18.Text & "','" & Label16.Text & "' )"

                                com = New MySqlCommand(qq1, conn)

                                MsgBox("تم الادخال ")
                            Else
                                MsgBox("لم يتم الادخال ")


                            End If

                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conn.Dispose()

                    End Try

                End If

            Next n01
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
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        reji.Label14.Text = Label6.Text
        reji.Label13.Text = Label18.Text
        reji.Label12.Text = Label19.Text
        reji.Show()

        Me.Close()
    End Sub
End Class