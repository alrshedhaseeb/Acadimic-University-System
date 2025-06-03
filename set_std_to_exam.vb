Imports MySql.Data.MySqlClient

Public Class set_std_to_exam
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader

    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim dtable As DataTable
    Dim flag = 0
    Dim x As Integer = 0
    Dim y As Integer = 0
    Dim st As Integer = 0
    Dim l1 As Integer = 0
    Dim l2 As Integer = 0
    Dim l3 As Integer = 0
    Dim l4 As Integer = 0
    Dim l5 As Integer = 0
    Dim l6 As Integer = 0
    Dim l7 As Integer = 0
    Dim l8 As Integer = 0
    Dim l9 As Integer = 0
    Dim l10 As Integer = 0
    Dim l11 As Integer = 0
    Dim l12 As Integer = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub set_std_to_exam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        adabter = New MySqlDataAdapter
        bsourc = New BindingSource
        dtable = New DataTable



        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
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

    Private Sub خروجToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles خروجToolStripMenuItem.Click
        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub

        Else
            Button3.Enabled = False
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

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim adabter = New MySqlDataAdapter
        Dim bsourc = New BindingSource
        Dim dtable = New DataTable



        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
           
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        DataGridView2.Columns.Clear()

        Dim adapter = New MySqlDataAdapter
            Dim bsorc = New BindingSource
            Dim tb = New DataTable

            Dim conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            conn.Open()
        Try
            Dim tb1 As New DataTable
            Dim query1 As String
            query1 = " select * from academy.hall  order by No_hall Asc "
            com = New MySqlCommand(query1, conn)
            adabter.SelectCommand = com
            adabter.Fill(tb1)

            y = tb1.Rows.Count

            DataGridView2.DataSource = tb1

            Dim n_hall As String = ""
            Dim nu_hall As Integer = 0
            Dim r_set As Integer
            Dim ste As Integer = 0
            Dim f As Integer = 100

            ' Dim index As Integer

            Dim row As Integer = DataGridView1.Rows.Count
            Dim row1 As Integer = DataGridView2.Rows.Count
            ' Dim count As Integer = ListBox1.Items.Count
            'n_hall = ListBox2.SelectedIndex.ToString
            'nu_hall = ListBox1.SelectedIndex.ToString



            If x <= 100 And x > 0 Then
                If y >= 1 Then
                    ste = 1
                    y = 1
                Else
                    y = y - 1
                    MsgBox("not hall more than : 1")
                End If

            ElseIf x <= 200 Then
                If y >= 2 Then
                    ste = 2
                    y = 2
                Else
                    y = y - 1
                    MsgBox("not hall more than : 2")
                End If

            ElseIf x <= 300 And x > 200 Then
                If y >= 3 Then
                    ste = 3
                    y = 3
                Else

                    y = y - 1
                    MsgBox("not hall more than : 3")
                End If

            ElseIf x <= 400 And x > 300 Then
                If y >= 4 Then
                    ste = 4
                    y = 4
                Else
                    y = y - 1
                    MsgBox("not hall more than : 4")
                End If

            ElseIf x <= 500 And x > 400 Then
                If y >= 5 Then
                    ste = 5
                    y = 5
                Else
                    y = y - 1
                    MsgBox("not hall more than : 5")
                End If
            End If


            For i = 0 To row1 - 1 Step +1
                nu_hall = DataGridView2.Rows(i).Cells(2).Value
                n_hall = DataGridView2.Rows(i).Cells(1).Value

                ListBox1.Items.Add(nu_hall)
                ListBox2.Items.Add(n_hall)

            Next i

            If ste = 1 Then

                ListBox1.SelectedIndex = y - 1
                ListBox2.SelectedIndex = y - 1
                ListBox1.SelectedIndex = ListBox2.SelectedIndex
                ListBox2.SelectedIndex = ListBox1.SelectedIndex

                For j = 0 To x - 1 Step +1

                    DataGridView1.Rows(j).Cells(3).Value = ListBox1.SelectedItem.ToString
                    DataGridView1.Rows(j).Cells(4).Value = ListBox2.SelectedItem.ToString


                Next j

            ElseIf ste = 2 Then

                Dim j = 0


                For j = j To x - 1 Step +1

                    If j <= f Then

                        ListBox1.SelectedIndex = y - 2
                        ListBox2.SelectedIndex = y - 2
                        ListBox1.SelectedIndex = ListBox2.SelectedIndex
                        ListBox2.SelectedIndex = ListBox1.SelectedIndex

                        DataGridView1.Rows(j).Cells(3).Value = ListBox1.SelectedItem.ToString
                        DataGridView1.Rows(j).Cells(4).Value = ListBox2.SelectedItem.ToString

                        '  j = j + 1
                    ElseIf j <= f + f Then
                        'j = j + 1
                        ListBox1.SelectedIndex = y - 1
                        ListBox2.SelectedIndex = y - 1
                        ListBox1.SelectedIndex = ListBox2.SelectedIndex
                        ListBox2.SelectedIndex = ListBox1.SelectedIndex

                        DataGridView1.Rows(j).Cells(3).Value = ListBox1.SelectedItem.ToString
                        DataGridView1.Rows(j).Cells(4).Value = ListBox2.SelectedItem.ToString



                    End If

                Next j

            ElseIf ste = 3 Then

                Dim j = 0

                For j = j To x - 1 Step +1


                    If j < f Then

                        ListBox1.SelectedIndex = y - 3
                        ListBox2.SelectedIndex = y - 3
                        ListBox1.SelectedIndex = ListBox2.SelectedIndex
                        ListBox2.SelectedIndex = ListBox1.SelectedIndex

                        DataGridView1.Rows(j).Cells(4).Value = ListBox1.SelectedItem.ToString
                        DataGridView1.Rows(j).Cells(5).Value = ListBox2.SelectedItem.ToString

                        'j = j + 1
                    ElseIf j < f + f Then


                        ListBox1.SelectedIndex = y - 2
                        ListBox2.SelectedIndex = y - 2

                        ListBox1.SelectedIndex = ListBox2.SelectedIndex
                        ListBox2.SelectedIndex = ListBox1.SelectedIndex

                        DataGridView1.Rows(j).Cells(4).Value = ListBox1.SelectedItem.ToString
                        DataGridView1.Rows(j).Cells(5).Value = ListBox2.SelectedItem.ToString



                        'j = j + 1
                    ElseIf j < f + f + f Then


                        ListBox1.SelectedIndex = y - 1
                        ListBox2.SelectedIndex = y - 1

                        ListBox1.SelectedIndex = ListBox2.SelectedIndex
                        ListBox2.SelectedIndex = ListBox1.SelectedIndex

                        DataGridView1.Rows(j).Cells(4).Value = ListBox1.SelectedItem.ToString
                        DataGridView1.Rows(j).Cells(5).Value = ListBox2.SelectedItem.ToString



                        '                        j = j + 1
                    End If

                Next j

            ElseIf ste = 4 Then
                Dim j = 0

                For j = j To x - 1 Step +1


                    If j < f Then

                        ListBox1.SelectedIndex = y - 4
                        ListBox2.SelectedIndex = y - 4

                        ListBox1.SelectedIndex = ListBox2.SelectedIndex
                        ListBox2.SelectedIndex = ListBox1.SelectedIndex

                        DataGridView1.Rows(j).Cells(4).Value = ListBox1.SelectedItem.ToString
                        DataGridView1.Rows(j).Cells(5).Value = ListBox2.SelectedItem.ToString

                        ' j = j + 1
                    ElseIf j < f + f Then

                        ListBox1.SelectedIndex = y - 3
                        ListBox2.SelectedIndex = y - 3
                        ListBox1.SelectedIndex = ListBox2.SelectedIndex
                        ListBox2.SelectedIndex = ListBox1.SelectedIndex

                        DataGridView1.Rows(j).Cells(4).Value = ListBox1.SelectedItem.ToString
                        DataGridView1.Rows(j).Cells(5).Value = ListBox2.SelectedItem.ToString



                        '                        j = j + 1
                    ElseIf j < f + f + f Then


                        ListBox1.SelectedIndex = y - 2
                        ListBox2.SelectedIndex = y - 2
                        ListBox1.SelectedIndex = ListBox2.SelectedIndex
                        ListBox2.SelectedIndex = ListBox1.SelectedIndex

                        DataGridView1.Rows(j).Cells(4).Value = ListBox1.SelectedItem.ToString
                        DataGridView1.Rows(j).Cells(5).Value = ListBox2.SelectedItem.ToString



                        '                       j = j + 1

                    ElseIf j < f + f + f + f Then


                        ListBox1.SelectedIndex = y - 1
                        ListBox2.SelectedIndex = y - 1
                        ListBox1.SelectedIndex = ListBox2.SelectedIndex
                        ListBox2.SelectedIndex = ListBox1.SelectedIndex

                        DataGridView1.Rows(j).Cells(3).Value = ListBox1.SelectedItem.ToString
                        DataGridView1.Rows(j).Cells(4).Value = ListBox2.SelectedItem.ToString



                        'j = j + 1
                    End If


                Next j

            ElseIf ste = 5 Then
                Dim j = 0

                For j = j To x - 1 Step +1


                    If j < f Then


                        ListBox1.SelectedIndex = y - 5
                        ListBox2.SelectedIndex = y - 5
                        ListBox1.SelectedIndex = ListBox2.SelectedIndex
                        ListBox2.SelectedIndex = ListBox1.SelectedIndex

                        DataGridView1.Rows(j).Cells(3).Value = ListBox1.SelectedItem.ToString
                        DataGridView1.Rows(j).Cells(4).Value = ListBox2.SelectedItem.ToString

                        '                        j = j + 1
                    ElseIf j < f + f Then


                        ListBox1.SelectedIndex = y - 4
                        ListBox2.SelectedIndex = y - 4
                        ListBox1.SelectedIndex = ListBox2.SelectedIndex
                        ListBox2.SelectedIndex = ListBox1.SelectedIndex

                        DataGridView1.Rows(j).Cells(3).Value = ListBox1.SelectedItem.ToString
                        DataGridView1.Rows(j).Cells(4).Value = ListBox2.SelectedItem.ToString




                    ElseIf j < f + f + f Then


                        ListBox1.SelectedIndex = y - 3
                        ListBox2.SelectedIndex = y - 3
                        ListBox1.SelectedIndex = ListBox2.SelectedIndex
                        ListBox2.SelectedIndex = ListBox1.SelectedIndex

                        DataGridView1.Rows(j).Cells(3).Value = ListBox1.SelectedItem.ToString
                        DataGridView1.Rows(j).Cells(4).Value = ListBox2.SelectedItem.ToString



                    ElseIf j < f + f + f + f Then


                        ListBox1.SelectedIndex = y - 2
                        ListBox2.SelectedIndex = y - 2
                        ListBox1.SelectedIndex = ListBox2.SelectedIndex
                        ListBox2.SelectedIndex = ListBox1.SelectedIndex

                        DataGridView1.Rows(j).Cells(3).Value = ListBox1.SelectedItem.ToString
                        DataGridView1.Rows(j).Cells(4).Value = ListBox2.SelectedItem.ToString


                    ElseIf j < f + f + f + f + f Then


                        ListBox1.SelectedIndex = y - 1
                        ListBox2.SelectedIndex = y - 1
                        ListBox1.SelectedIndex = ListBox2.SelectedIndex
                        ListBox2.SelectedIndex = ListBox1.SelectedIndex

                        DataGridView1.Rows(j).Cells(3).Value = ListBox1.SelectedItem.ToString
                        DataGridView1.Rows(j).Cells(4).Value = ListBox2.SelectedItem.ToString


                    End If

                Next

                Button3.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()
        End Try

    End Sub

    Private Sub بياناتسجلالطالبToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form1.Show()
        Me.Close()

    End Sub

    Private Sub السجلالماليToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form3.Show()
        Me.Close()

    End Sub

    Private Sub النتيجةالنهائيهToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles النتيجةالنهائيهToolStripMenuItem.Click
        result.Show()
        Me.Close()

    End Sub

    Private Sub استعلامعنبياناتطالبToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles استعلامعنبياناتطالبToolStripMenuItem.Click
        record_academy.Show()
        Me.Close()

    End Sub

    Private Sub نافذةسدادالرسومToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        add_fees.Show()
        Me.Close()

    End Sub

    Private Sub ادخالنتيجهمقررToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ادخالنتيجهمقررToolStripMenuItem.Click
        set_res.Show()
        Me.Close()

    End Sub


    Private Sub جدولالفصلالدراسىToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles جدولالفصلالدراسىToolStripMenuItem.Click
        attendees.Show()
        Me.Close()
    End Sub

    Private Sub جدولالامتحاناتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles جدولالامتحاناتToolStripMenuItem.Click
        atendees_exam.Show()
        Me.Close()
    End Sub

    Private Sub جدولالحضوروالمتابعهToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles جدولالحضوروالمتابعهToolStripMenuItem.Click

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

    Private Sub التقاريرToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles التقاريرToolStripMenuItem.Click
        mol7.Label14.Text = Label16.Text
        mol7.Label13.Text = Label18.Text
        mol7.Label12.Text = Label19.Text
        mol7.Show()

        Me.Close()

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        flag = 1
        Button1.Enabled = True
        Panel5.Visible = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        ComboBox6.Enabled = True

        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        ComboBox6.Text = Nothing

        Button7.Enabled = False
        Panel6.Visible = False
        Button3.Enabled = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        flag = 2
        Button3.Enabled = False
        Button7.Enabled = True
        Panel6.Visible = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        ComboBox4.Enabled = True
        ComboBox5.Enabled = True
        ComboBox6.Enabled = True

        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        ComboBox6.Text = Nothing

        Button1.Enabled = False
        Panel5.Visible = False

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button2.Enabled = False
        Button1.Enabled = True
        Panel5.Visible = False

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        DataGridView1.Columns.Clear()
        DataGridView2.Columns.Clear()

        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
        ComboBox6.Enabled = False

        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        ComboBox6.Text = Nothing

        Button7.Enabled = True
        Panel6.Visible = False

        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub

        Else
            Button3.Enabled = False
            Me.Close()
            Form2.Show()
            Form2.TextBox2.Clear()
        End If

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        flag = 0

        Button3.Enabled = False
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        DataGridView1.Columns.Clear()
        DataGridView2.Columns.Clear()

        Button2.Enabled = False
        Button1.Enabled = True
        Panel5.Visible = False

        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        ComboBox4.Enabled = False
        ComboBox5.Enabled = False
        ComboBox6.Enabled = False

        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        ComboBox6.Text = Nothing

        Button7.Enabled = True
        Panel6.Visible = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Button2.Enabled = True

        DataGridView1.Columns.Clear()
        Dim adapter = New MySqlDataAdapter
        Dim bsorc = New BindingSource
        Dim table = New DataTable

        Dim conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            conn.Open()
            If flag = 1 Then

                Dim query As String
                query = " select id_std as'الرقم الجامعى',name_std as'اسم الطالب',semester as'الفصل الدراسى' from academy.std_info where colage='" & ComboBox5.Text & "' and department='" & ComboBox4.Text & "' and semester='" & ComboBox3.Text & "' and depart_certificate='" & ComboBox2.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "' order by id_std Asc "
                com = New MySqlCommand(query, conn)
                adapter.SelectCommand = com
                adapter.Fill(table)
                bsorc.DataSource = table
                x = table.Rows.Count

                If table.Rows.Count > 0 Then

                    Button2.Enabled = True


                    Dim set_exam As New DataGridViewTextBoxColumn() With {.HeaderText = " أسم القاعه", .Name = "exam", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                    Dim set_exam1 As New DataGridViewTextBoxColumn() With {.HeaderText = " رقم القاعه", .Name = "exam", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                    Dim set_attttendess As New DataGridViewTextBoxColumn() With {.HeaderText = "الحاله", .Name = "exam", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}

                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                    DataGridView1.DataSource = table

                    DataGridView1.Columns.Insert(3, set_exam1)
                    DataGridView1.Columns.Insert(4, set_exam)
                    DataGridView1.Columns.Insert(5, set_attttendess)

                    Try
                        Dim row01 As Integer = DataGridView1.Rows.Count

                        For i = 0 To row01 - 1 Step +1

                            Dim table10 = New DataTable
                            Dim query110 As String
                            query110 = " select * from academy.std_atendess where std_id='" & DataGridView1.Rows(i).Cells(0).Value & "'  and semester='" & ComboBox3.Text & "' and patch='" & ComboBox6.Text & "'  and lecture='" & ComboBox1.Text & "' and active='" & 0 & "'"
                            Dim com1 = New MySqlCommand(query110, conn)

                            adabter.SelectCommand = com1
                            adabter.Fill(table10)

                            If table10.Rows.Count > 0 Then

                                l1 = table10(0)(4)
                                l2 = table10(0)(5)
                                l3 = table10(0)(6)
                                l4 = table10(0)(7)
                                l5 = table10(0)(8)
                                l6 = table10(0)(9)
                                l7 = table10(0)(10)
                                l8 = table10(0)(11)
                                l9 = table10(0)(12)
                                l10 = table10(0)(13)
                                l11 = table10(0)(14)
                                l12 = table10(0)(15)

                                Dim r_l = 0

                                r_l = l1 + l2 + l3 + l4 + l5 + l6 + l7 + l8 + l9 + l10 + l11 + l12

                                If r_l >= 8 Then

                                    DataGridView1.Rows(i).Cells(5).Value = "يجلس"

                                Else
                                    DataGridView1.Rows(i).Cells(5).Value = " لا يجلس"



                                    '''''''''''''''''''''''''''''''''''''''''''' 'يتحول الى ملحق'''''''''''''


                                    ''''''''''code update mol7ag here''''''''''''''

                                    '''



                                End If

                            End If

                        Next

                    Catch ex As Exception

                        MsgBox(ex.Message)
                    Finally
                        conn.Dispose()

                    End Try


                End If


            ElseIf flag = 2 Then

                Dim query001 As String
                query001 = " select std_id as'الرقم الجامعى',name_std as'اسم الطالب',semester as'الفصل الدراسى' from academy.res_lecture where colage='" & ComboBox5.Text & "' and department='" & ComboBox2.Text & "' and lecture='" & ComboBox1.Text & "' and semester='" & ComboBox3.Text & "' and dep_name='" & ComboBox4.Text & "' and mol7ag='نعم' and set_exam='1' and patch='" & ComboBox6.Text & "' and active='" & 0 & "'"

                com = New MySqlCommand(query001, conn)

                adapter.SelectCommand = com

                adapter.Fill(table)

                bsorc.DataSource = table
                DataGridView1.Columns.Clear()

                If table.Rows.Count > 0 Then

                    x = table.Rows.Count


                    Dim set_exam As New DataGridViewTextBoxColumn() With {.HeaderText = " أسم القاعه", .Name = "exam", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                    Dim set_exam1 As New DataGridViewTextBoxColumn() With {.HeaderText = " رقم القاعه", .Name = "exam", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
                    Dim set_attttendess As New DataGridViewTextBoxColumn() With {.HeaderText = "الحاله", .Name = "exam", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}

                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill
                    DataGridView1.DataSource = table

                    DataGridView1.Columns.Insert(3, set_exam1)
                    DataGridView1.Columns.Insert(4, set_exam)
                    DataGridView1.Columns.Insert(5, set_attttendess)
                    Dim row1 As Integer = DataGridView1.Rows.Count

                    For i = 0 To row1 - 1 Step +1
                        DataGridView1.Rows(i).Cells(5).Value = "يجلس"
                    Next i


                End If

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        reji.Label14.Text = Label16.Text
        reji.Label13.Text = Label18.Text
        reji.Label12.Text = Label19.Text
        reji.Show()

        Me.Close()
    End Sub
End Class