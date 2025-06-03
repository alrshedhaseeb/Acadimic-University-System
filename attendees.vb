Imports MySql.Data.MySqlClient

Public Class attendees

    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim dtable As DataTable
    Dim re As MySqlDataReader

    Dim MyCommand1 As New MySql.Data.MySqlClient.MySqlCommand
    Dim Myadapter As New MySql.Data.MySqlClient.MySqlDataAdapter
    Dim MyBuilder As MySql.Data.MySqlClient.MySqlCommandBuilder

    Dim tb As New DataTable
    Dim MyDataset As New DataSet1


    Dim check1 As String = "0"
    Dim check2 As String = "0"
    Dim check3 As String = "0"
    Dim check4 As String = "0"
    Dim check5 As String = "0"
    Dim check6 As String = "0"
    Dim check7 As String = "0"
    Dim check8 As String = "0"
    Dim check9 As String = "0"
    Dim check10 As String = "0"
    Dim check11 As String = "0"
    Dim check12 As String = "0"

    Dim chk As New DataGridViewCheckBoxColumn() With {.headertext = "select", .Name = "chk", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells, .FlatStyle = FlatStyle.Flat, .ThreeState = True}
 
    Dim lec1 As New DataGridViewCheckBoxColumn() With {.HeaderText = "المحاضره 1", .Name = "lec1", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
    Dim lec2 As New DataGridViewCheckBoxColumn() With {.HeaderText = "المحاضره 2", .Name = "lec2", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
    Dim lec3 As New DataGridViewCheckBoxColumn() With {.HeaderText = "المحاضره 3", .Name = "lec3", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
    Dim lec4 As New DataGridViewCheckBoxColumn() With {.HeaderText = "المحاضره 4", .Name = "lec4", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
    Dim lec5 As New DataGridViewCheckBoxColumn() With {.HeaderText = "المحاضره 5", .Name = "lec5", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
    Dim lec6 As New DataGridViewCheckBoxColumn() With {.HeaderText = "المحاضره 6", .Name = "lec6", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
    Dim lec7 As New DataGridViewCheckBoxColumn() With {.HeaderText = "المحاضره 7", .Name = "lec7", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
    Dim lec8 As New DataGridViewCheckBoxColumn() With {.HeaderText = "المحاضره 8", .Name = "lec8", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
    Dim lec9 As New DataGridViewCheckBoxColumn() With {.HeaderText = "المحاضره 9", .Name = "lec9", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
    Dim lec10 As New DataGridViewCheckBoxColumn() With {.HeaderText = "المحاضره 10", .Name = "lec10", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
    Dim lec11 As New DataGridViewCheckBoxColumn() With {.HeaderText = "المحاضره 11", .Name = "lec11", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
    Dim lec12 As New DataGridViewCheckBoxColumn() With {.HeaderText = "المحاضره 21", .Name = "lec12", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}


    Private Sub attendees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
            query = " select* from academy.record_academy where  depart_name='" & ComboBox4.Text & "' AND semester='" & ComboBox3.Text & "'and depart_certificate='" & ComboBox2.Text & "' "
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

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim minNum As Integer = 2018
        Dim maxNum As Integer = 2050
        ComboBox6.Items.AddRange(Enumerable.Range(minNum, maxNum - minNum + 1).Select(Function(s) s.ToString()).ToArray())

    End Sub

    Private Sub خروجToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles خروجToolStripMenuItem.Click
        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub

        End If
        Me.Close()
        Form2.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ListBox1.Items.Clear()
        Dim adapter = New MySqlDataAdapter
        Dim bsorc = New BindingSource
        Dim table = New DataTable

        Dim conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            conn.Open()
            DataGridView1.Columns.Clear()

            Dim query As String
            query = " select id_std,name_std from academy.std_info where colage='" & ComboBox5.Text & "' and department='" & ComboBox4.Text & "' and semester='" & ComboBox3.Text & "' and depart_certificate='" & ComboBox2.Text & "' and pattch='" & ComboBox6.Text & "' ORDER BY id_std ASC"
            com = New MySqlCommand(query, conn)
            adapter.SelectCommand = com
            adapter.Fill(table)
            bsorc.DataSource = table
            reader = com.ExecuteReader
            adabter.Update(table)
            Label10.Text = table.Rows.Count
            ' Dim combo As New DataGridViewComboBoxColumn() With {.HeaderText = "lecture"}
            ' combo.Items.Add(ComboBox1.Text)
            ' Dim text As New DataGridViewTextBoxColumn() With {.HeaderText = "attendees", .Name = "text", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

            DataGridView1.Columns.Insert(0, chk)
            DataGridView1.DataSource = table


            DataGridView1.Columns.Insert(3, lec1)

            DataGridView1.Columns.Insert(4, lec2)
            DataGridView1.Columns.Insert(5, lec3)
            DataGridView1.Columns.Insert(6, lec4)
            DataGridView1.Columns.Insert(7, lec5)
            DataGridView1.Columns.Insert(8, lec6)
            DataGridView1.Columns.Insert(9, lec7)
            DataGridView1.Columns.Insert(10, lec8)
            DataGridView1.Columns.Insert(11, lec9)
            DataGridView1.Columns.Insert(12, lec10)
            DataGridView1.Columns.Insert(13, lec11)
            DataGridView1.Columns.Insert(14, lec12)

            reader.Close()
            com.Parameters.Clear()

            Dim le1 As String = ""
            Dim le2 As String = ""
            Dim le3 As String = ""
            Dim le4 As String = ""
            Dim le5 As String = ""
            Dim le6 As String = ""
            Dim le7 As String = ""
            Dim le8 As String = ""
            Dim le9 As String = ""
            Dim le10 As String = ""
            Dim le11 As String = ""
            Dim le12 As String = ""


            Dim tb As New DataTable
            Dim bc As New BindingSource
            Dim ad As New MySqlDataAdapter

            Dim row As Integer = DataGridView1.Rows.Count

            For i = 0 To row - 1 Step +1
                ' Dim re As New MySqlDataReader
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim q1 As String
                q1 = " select * from academy.std_atendess where std_id='" & DataGridView1.Rows(i).Cells(1).Value & "'  and lecture='" & ComboBox1.Text & "'"
                Dim com1 = New MySqlCommand(q1, conn)
                ad.SelectCommand = com1
                ad.Fill(tb)
                ' MsgBox(tb.Rows.Count)

                If tb.Rows.Count > 0 Then

                    le1 = tb(i)(4)
                    ListBox1.Items.Add(i)
                    Label3.Text = le1
                    If le1 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(3).Value = False And le1 = "1" Then
                            DataGridView1.Rows(i).Cells(3).Value = True
                        End If
                    Else
                        DataGridView1.Rows(i).Cells(3).Value = False

                    End If




                    le2 = tb(i)(5)
                    ListBox1.Items.Add(i)
                    Label10.Text = le2
                    If le2 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(4).Value = False And le2 = "1" Then
                            DataGridView1.Rows(i).Cells(4).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(4).Value = False
                    End If

                    le3 = tb(i)(6)
                    ListBox1.Items.Add(i)
                    Label10.Text = le3
                    If le3 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(5).Value = False And le3 = "1" Then
                            DataGridView1.Rows(i).Cells(5).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(5).Value = False

                    End If

                    le4 = tb(i)(7)
                    ListBox1.Items.Add(i)
                    Label10.Text = le4
                    If le4 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(6).Value = False And le4 = "1" Then
                            DataGridView1.Rows(i).Cells(6).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(6).Value = False

                    End If


                    le5 = tb(i)(8)
                    ListBox1.Items.Add(i)
                    Label10.Text = le5
                    If le5 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(7).Value = False And le5 = "1" Then
                            DataGridView1.Rows(i).Cells(7).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(7).Value = False

                    End If

                    le6 = tb(i)(9)
                    ListBox1.Items.Add(i)
                    Label10.Text = le6
                    If le6 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(8).Value = False And le6 = "1" Then
                            DataGridView1.Rows(i).Cells(8).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(8).Value = False

                    End If

                    le7 = tb(i)(10)
                    ListBox1.Items.Add(i)
                    Label10.Text = le7
                    If le7 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(9).Value = False And le7 = "1" Then
                            DataGridView1.Rows(i).Cells(9).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(9).Value = False

                    End If

                    le8 = tb(i)(11)
                    ListBox1.Items.Add(i)
                    Label10.Text = le8
                    If le8 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(10).Value = False And le8 = "1" Then
                            DataGridView1.Rows(i).Cells(10).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(10).Value = False

                    End If
                    le9 = tb(i)(12)
                    ListBox1.Items.Add(i)
                    Label10.Text = le9
                    If le9 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(11).Value = False And le9 = "1" Then
                            DataGridView1.Rows(i).Cells(11).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(11).Value = False

                    End If
                    le10 = tb(i)(13)
                    ListBox1.Items.Add(i)
                    Label10.Text = le10
                    If le10 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(12).Value = False And le10 = "1" Then
                            DataGridView1.Rows(i).Cells(12).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(12).Value = False

                    End If

                    le11 = tb(i)(14)
                    ListBox1.Items.Add(i)
                    Label10.Text = le11
                    If le11 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(13).Value = False And le11 = "1" Then
                            DataGridView1.Rows(i).Cells(13).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(13).Value = False

                    End If

                    le12 = tb(i)(15)
                    ListBox1.Items.Add(i)
                    Label10.Text = le12
                    If le12 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(14).Value = False And le12 = "1" Then
                            DataGridView1.Rows(i).Cells(14).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(14).Value = False


                    End If
                Else
                    DataGridView1.EndEdit()
                    'com1.Parameters.Clear()
                    're.Close()
                End If
                reader.Close()
                com.Parameters.Clear()
            Next i
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ListBox1.Items.Clear()
        Dim adapter = New MySqlDataAdapter
        Dim bsorc = New BindingSource
        Dim table = New DataTable

        Dim conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            conn.Open()
            DataGridView1.Columns.Clear()

            Dim query As String
            query = " select id_std as 'الرقم الجامعى',name_std as 'اسم الطالب' from academy.std_info where colage='" & ComboBox5.Text & "' and department='" & ComboBox4.Text & "' and semester='" & ComboBox3.Text & "' and depart_certificate='" & ComboBox2.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "' ORDER BY id_std ASC"
            com = New MySqlCommand(query, conn)
            adapter.SelectCommand = com
            adapter.Fill(table)
            bsorc.DataSource = table
            reader = com.ExecuteReader
            adabter.Update(table)
            Label10.Text = table.Rows.Count

            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

            DataGridView1.Columns.Insert(0, chk)
            DataGridView1.DataSource = table


            DataGridView1.Columns.Insert(3, lec1)

            DataGridView1.Columns.Insert(4, lec2)
            DataGridView1.Columns.Insert(5, lec3)
            DataGridView1.Columns.Insert(6, lec4)
            DataGridView1.Columns.Insert(7, lec5)
            DataGridView1.Columns.Insert(8, lec6)
            DataGridView1.Columns.Insert(9, lec7)
            DataGridView1.Columns.Insert(10, lec8)
            DataGridView1.Columns.Insert(11, lec9)
            DataGridView1.Columns.Insert(12, lec10)
            DataGridView1.Columns.Insert(13, lec11)
            DataGridView1.Columns.Insert(14, lec12)

            reader.Close()
            com.Parameters.Clear()

            Dim le1 As String = ""
            Dim le2 As String = ""
            Dim le3 As String = ""
            Dim le4 As String = ""
            Dim le5 As String = ""
            Dim le6 As String = ""
            Dim le7 As String = ""
            Dim le8 As String = ""
            Dim le9 As String = ""
            Dim le10 As String = ""
            Dim le11 As String = ""
            Dim le12 As String = ""


            Dim tb As New DataTable
            Dim bc As New BindingSource
            Dim ad As New MySqlDataAdapter

            Dim row As Integer = DataGridView1.Rows.Count

            For i = 0 To row - 1 Step +1
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim q1 As String
                q1 = " select * from academy.std_atendess where std_id='" & DataGridView1.Rows(i).Cells(1).Value & "'  and lecture='" & ComboBox1.Text & "' and active='" & 0 & "'"
                Dim com1 = New MySqlCommand(q1, conn)
                ad.SelectCommand = com1
                ad.Fill(tb)

                If tb.Rows.Count > 0 Then

                    le1 = tb(i)(4)
                    ListBox1.Items.Add(i)
                    Label3.Text = le1
                    If le1 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(3).Value = False And le1 = "1" Then
                            DataGridView1.Rows(i).Cells(3).Value = True
                        End If
                    Else
                        DataGridView1.Rows(i).Cells(3).Value = False

                    End If




                    le2 = tb(i)(5)
                    ListBox1.Items.Add(i)
                    Label10.Text = le2
                    If le2 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(4).Value = False And le2 = "1" Then
                            DataGridView1.Rows(i).Cells(4).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(4).Value = False
                    End If

                    le3 = tb(i)(6)
                    ListBox1.Items.Add(i)
                    Label10.Text = le3
                    If le3 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(5).Value = False And le3 = "1" Then
                            DataGridView1.Rows(i).Cells(5).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(5).Value = False

                    End If

                    le4 = tb(i)(7)
                    ListBox1.Items.Add(i)
                    Label10.Text = le4
                    If le4 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(6).Value = False And le4 = "1" Then
                            DataGridView1.Rows(i).Cells(6).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(6).Value = False

                    End If


                    le5 = tb(i)(8)
                    ListBox1.Items.Add(i)
                    Label10.Text = le5
                    If le5 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(7).Value = False And le5 = "1" Then
                            DataGridView1.Rows(i).Cells(7).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(7).Value = False

                    End If

                    le6 = tb(i)(9)
                    ListBox1.Items.Add(i)
                    Label10.Text = le6
                    If le6 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(8).Value = False And le6 = "1" Then
                            DataGridView1.Rows(i).Cells(8).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(8).Value = False

                    End If

                    le7 = tb(i)(10)
                    ListBox1.Items.Add(i)
                    Label10.Text = le7
                    If le7 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(9).Value = False And le7 = "1" Then
                            DataGridView1.Rows(i).Cells(9).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(9).Value = False

                    End If

                    le8 = tb(i)(11)
                    ListBox1.Items.Add(i)
                    Label10.Text = le8
                    If le8 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(10).Value = False And le8 = "1" Then
                            DataGridView1.Rows(i).Cells(10).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(10).Value = False

                    End If
                    le9 = tb(i)(12)
                    ListBox1.Items.Add(i)
                    Label10.Text = le9
                    If le9 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(11).Value = False And le9 = "1" Then
                            DataGridView1.Rows(i).Cells(11).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(11).Value = False

                    End If
                    le10 = tb(i)(13)
                    ListBox1.Items.Add(i)
                    Label10.Text = le10
                    If le10 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(12).Value = False And le10 = "1" Then
                            DataGridView1.Rows(i).Cells(12).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(12).Value = False

                    End If

                    le11 = tb(i)(14)
                    ListBox1.Items.Add(i)
                    Label10.Text = le11
                    If le11 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(13).Value = False And le11 = "1" Then
                            DataGridView1.Rows(i).Cells(13).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(13).Value = False

                    End If

                    le12 = tb(i)(15)
                    ListBox1.Items.Add(i)
                    Label10.Text = le12
                    If le12 = "1" Then
                        'ad.Fill(tb)
                        If DataGridView1.Rows(i).Cells(14).Value = False And le12 = "1" Then
                            DataGridView1.Rows(i).Cells(14).Value = True

                        End If
                    Else
                        DataGridView1.Rows(i).Cells(14).Value = False


                    End If
                Else
                    DataGridView1.EndEdit()
                    'com1.Parameters.Clear()
                    're.Close()
                End If
                reader.Close()
                com.Parameters.Clear()
            Next i
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '  DataGridView1.Columns.Clear()
        If ComboBox5.SelectedItem = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox5, "please")
            Return
        ElseIf ComboBox4.SelectedItem = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox4, "plemase")
            Return
        ElseIf ComboBox2.SelectedItem = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox2, "plemase")
            Return
        ElseIf ComboBox3.SelectedItem = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox3, "plemase")
        ElseIf ComboBox1.SelectedItem = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox1, "plemase")

        Else
            ErrorProvider1.Clear()
            Try

                '   MyCommand1.Parameters.Clear()

                Dim row As Integer = DataGridView1.Rows.Count
                For i = 0 To row - 1 Step +1

                    Dim check1 As Boolean = DataGridView1.Rows(i).Cells(3).Value
                    Dim check2 As Boolean = DataGridView1.Rows(i).Cells(4).Value
                    Dim check3 As Boolean = DataGridView1.Rows(i).Cells(5).Value
                    Dim check4 As Boolean = DataGridView1.Rows(i).Cells(6).Value
                    Dim check5 As Boolean = DataGridView1.Rows(i).Cells(7).Value
                    Dim check6 As Boolean = DataGridView1.Rows(i).Cells(8).Value
                    Dim check7 As Boolean = DataGridView1.Rows(i).Cells(9).Value
                    Dim check8 As Boolean = DataGridView1.Rows(i).Cells(10).Value
                    Dim check9 As Boolean = DataGridView1.Rows(i).Cells(11).Value
                    Dim check10 As Boolean = DataGridView1.Rows(i).Cells(12).Value
                    Dim check11 As Boolean = DataGridView1.Rows(i).Cells(13).Value
                    Dim check12 As Boolean = DataGridView1.Rows(i).Cells(14).Value

                    Dim ch1 As String
                    Dim ch2 As String
                    Dim ch3 As String
                    Dim ch4 As String
                    Dim ch5 As String
                    Dim ch6 As String
                    Dim ch7 As String
                    Dim ch8 As String
                    Dim ch9 As String
                    Dim ch10 As String
                    Dim ch11 As String
                    Dim ch12 As String


                    '  Dim qq As String

                    If check1 = True Then
                        ch1 = "1"
                    Else
                        ch1 = "0"
                    End If

                    If check2 = True Then
                        ch2 = "1"
                    Else
                        ch2 = "0"
                    End If

                    If check3 = True Then
                        ch3 = "1"
                    Else
                        ch3 = "0"
                    End If

                    If check4 = True Then
                        ch4 = "1"
                    Else
                        ch4 = "0"
                    End If

                    If check5 = True Then
                        ch5 = "1"
                    Else
                        ch5 = "0"
                    End If

                    If check6 = True Then
                        ch6 = "1"
                    Else
                        ch6 = "0"
                    End If

                    If check7 = True Then
                        ch7 = "1"
                    Else
                        ch7 = "0"
                    End If

                    If check8 = True Then
                        ch8 = "1"
                    Else
                        ch8 = "0"
                    End If

                    If check9 = True Then
                        ch9 = "1"
                    Else
                        ch9 = "0"
                    End If

                    If check10 = True Then
                        ch10 = "1"
                    Else
                        ch10 = "0"
                    End If

                    If check11 = True Then
                        ch11 = "1"
                    Else
                        ch11 = "0"
                    End If

                    If check12 = True Then
                        ch12 = "1"
                    Else
                        ch12 = "0"
                    End If

                    Dim qyn As String
                    qyn = " update academy.std_atendess set  lec1 ='" & ch1 & "',lec2 ='" & ch2 & "',lec3 ='" & ch3 & "',lec4 ='" & ch4 & "',lec5 ='" & ch5 & "',lec6 ='" & ch6 & "',lec7 ='" & ch7 & "',lec8 ='" & ch8 & "',lec9 ='" & ch9 & "',lec10 ='" & ch10 & "',lec11 ='" & ch11 & "',lec12 ='" & ch12 & "'  where std_id='" & DataGridView1.Rows(i).Cells(1).Value & "' and lecture='" & ComboBox1.Text & "' and patch='" & ComboBox6.Text & "' and active='" & 0 & "'"

                    MyCommand1 = New MySqlCommand(qyn, conn)

                    Myadapter.SelectCommand = MyCommand1

                    MyBuilder = New MySql.Data.MySqlClient.MySqlCommandBuilder(Myadapter)
                    Myadapter.Fill(tb)
                Next
                Dim qq1 As String = ""
                Dim de As String = "'" + ComboBox1.Text + "/" + ComboBox3.Text + "/" + ComboBox6.Text + "/" + ComboBox2.Text + "/" + ComboBox4.Text + "/" + ComboBox5.Text + "'"
                Dim mass As String = de & "لقد تم تعديل حضور الفصل الدراسى للطلاب"

                qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label18.Text & "','" & Label16.Text & "' )"

                com = New MySqlCommand(qq1, conn)
                MsgBox("تم تعديل الحضور")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try





        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label30.Click, Label3.Click

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim no As New note
        no.ShowDialog()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        ComboBox5.Text = Nothing
        DataGridView1.Columns.Clear()
    End Sub

    Private Sub بياناتسجلالطالبToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub السجلالماليToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        Form3.Show()

    End Sub

    Private Sub إجلاسالطلابللامتحانToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles إجلاسالطلابللامتحانToolStripMenuItem.Click
        Me.Close()
        set_std_to_exam.Show()

    End Sub


    Private Sub جدولالحضوروالمتابعهToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles جدولالحضوروالمتابعهToolStripMenuItem.Click
        Me.Close()
        set_res.Show()

    End Sub

    Private Sub النتيجةالنهائيهToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles النتيجةالنهائيهToolStripMenuItem.Click
        Me.Close()
        result.Show()
    End Sub

    Private Sub استعلامعنبياناتطالبToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles استعلامعنبياناتطالبToolStripMenuItem.Click
        Me.Close()
        record_academy.Show()

    End Sub

    Private Sub نافذةسدادالرسومToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
        add_fees.Show()

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

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        reji.Label14.Text = Label16.Text
        reji.Label13.Text = Label18.Text
        reji.Label12.Text = Label19.Text
        reji.Show()

        Me.Close()

    End Sub
End Class