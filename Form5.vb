Imports MySql.Data.MySqlClient
Public Class Form5
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim readerr As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim dtable As DataTable
    Dim dtableee As DataTable
    Dim f = "0"

    Private Sub بياناتسجلالطالبToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form4.Label14.Text = Label14.Text
        Form4.Label12.Text = Label12.Text
        Form4.Label13.Text = Label15.Text
        Form4.Show()
        Me.Close()

    End Sub

    Private Sub التقويمالدراسىوالمنهجيةالمتبعهToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        admin.Label14.Text = Label14.Text
        admin.Label12.Text = Label12.Text
        admin.Label13.Text = Label15.Text
        admin.Show()
        Me.Close()

    End Sub

    Private Sub record_academy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If f = "1" Then
            If TextBox3.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.TextBox3, "please")
                Return
            ElseIf colagebox.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.colagebox, "plemase")
                Return
            ElseIf depbox.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.depbox, "plemase")
                Return
            ElseIf ComboBox3.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox3, "plemase")
            ElseIf ComboBox4.Text = Nothing Then
                Me.ErrorProvider1.Clear()
                Me.ErrorProvider1.SetError(Me.ComboBox4, "plemase")

            Else
                ErrorProvider1.Clear()
            End If
        Else
            ErrorProvider1.Clear()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ComboBox4.Text = "اختر فصل "
        DataGridView1.Columns.Clear()
        DataGridView2.Columns.Clear()
        ListBox1.Items.Clear()
        conn = New MySqlConnection
        adabter = New MySqlDataAdapter
        Dim adabterr = New MySqlDataAdapter
        bsourc = New BindingSource
        dtable = New DataTable
        Dim table = New DataTable

        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try

            conn.Open()
            Dim query As String
            query = " SELECT * FROM academy.std_info where id_std='" & TextBox3.Text & "'"
            com = New MySqlCommand(query, conn)
            adabter.SelectCommand = com
            adabter.Fill(dtable)
            depbox.Text = dtable(0)(4)
            colagebox.Text = dtable(0)(3)
            ComboBox3.Text = dtable(0)(17)


            adabter.Update(dtable)
            'ComboBox4.Items.Clear()



            Dim qu As String
            qu = " select* from academy.depart_colage where colage='" & colagebox.Text & "' and dep_name='" & depbox.Text & "'"
            Dim comm = New MySqlCommand(qu, conn)
            readerr = comm.ExecuteReader
            adabterr.Update(table)
            f = "1"
            While readerr.Read
                Dim sname = readerr.GetString("dep_name")
                'TextBox7.Text = sname

                'TextBox7.Text = dtable(0)(1)
                'TextBox7.Text = dtable(0)(2)
                'TextBox9.Text = dtable(0)(29)

                comm.Parameters.Clear()
                ' Dim sname As String

                If depbox.Text = sname And ComboBox3.Text = "بكالاريوس" Then
                    ComboBox4.Items.Clear()
                    ComboBox4.Items.Add("الفصل الاول")
                    ComboBox4.Items.Add("الفصل الثانى")
                    ComboBox4.Items.Add("الفصل الثالث")
                    ComboBox4.Items.Add("الفصل الرابع")
                    ComboBox4.Items.Add("الفصل الخامس")
                    ComboBox4.Items.Add("الفصل السادس")
                    ComboBox4.Items.Add("الفصل السابع")
                    ComboBox4.Items.Add("الفصل الثامن")
                ElseIf depbox.Text = sname And ComboBox3.Text = "دبلوم" Then
                    ComboBox4.Items.Clear()
                    ComboBox4.Items.Add("الفصل الاول")
                    ComboBox4.Items.Add("الفصل الثانى")
                    ComboBox4.Items.Add("الفصل الثالث")
                    ComboBox4.Items.Add("الفصل الرابع")
                    ComboBox4.Items.Add("الفصل الخامس")
                    ComboBox4.Items.Add("الفصل السادس")

                ElseIf depbox.Text = "it" And ComboBox3.Text = "ماجستير" Or depbox.Text = "it2" And ComboBox3.Text = "ماجستير" Or depbox.Text = "it3" And ComboBox3.Text = "ماجستير" Then
                    ComboBox4.Items.Clear()
                    ComboBox4.Items.Add("الفصل الاول")
                    ComboBox4.Items.Add("الفصل الثانى")
                    ComboBox4.Items.Add("الفصل الثالث")
                    ComboBox4.Items.Add("الفصل الرابع")
                End If
            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim adapter = New MySqlDataAdapter
        Dim bsorc = New BindingSource
        Dim table = New DataTable
        Dim tablee = New DataTable
        Dim conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"

        Try
            conn.Open()
            Dim query1 As String
            query1 = " select * from academy.res_lecture where colage='" & colagebox.Text & "' and dep_name='" & depbox.Text & "' and semester='" & ComboBox4.Text & "' and department='" & ComboBox3.Text & "' and std_id='" & TextBox3.Text & "' and mol7ag='نعم'"
            com = New MySqlCommand(query1, conn)
            reader = com.ExecuteReader
            Dim mol As String
            While reader.Read
                mol = reader.GetString("lecture")
                ListBox1.Items.Add(mol)

            End While
            reader.Close()
            Dim query As String
            query = " select std_id,name_std,lecture,total_degre_exam,grade from academy.res_lecture where colage='" & colagebox.Text & "' and dep_name='" & depbox.Text & "' and semester='" & ComboBox4.Text & "' and department='" & ComboBox3.Text & "' and std_id='" & TextBox3.Text & "'"
            com = New MySqlCommand(query, conn)
            adapter.SelectCommand = com
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

            adapter.Fill(table)
            bsorc.DataSource = table
            DataGridView2.DataSource = table
            reader = com.ExecuteReader
            adabter.Update(dtable)
            reader.Close()
            com.Parameters.Clear()
            readerr.Close()
            Dim qu As String
            qu = " select std_id,semester,res_degre,grade,res_char from academy.result where  std_id='" & TextBox3.Text & "' and semester='" & ComboBox4.Text & "'"
            Dim comm = New MySqlCommand(qu, conn)
            adabter.SelectCommand = comm
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

            adabter.Fill(tablee)
            bsorc.DataSource = tablee
            DataGridView1.DataSource = tablee
            readerr = comm.ExecuteReader
            adabter.Update(tablee)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try




    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim no As New note
        no.ShowDialog()
    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            ComboBox4.Text = "اختر فصل "
            DataGridView1.Columns.Clear()
            DataGridView2.Columns.Clear()
            ListBox1.Items.Clear()
            conn = New MySqlConnection
            adabter = New MySqlDataAdapter
            Dim adabterr = New MySqlDataAdapter
            bsourc = New BindingSource
            dtable = New DataTable
            Dim table = New DataTable

            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try

                conn.Open()
                Dim query As String
                query = " SELECT * FROM academy.std_info where id_std='" & TextBox3.Text & "'"
                com = New MySqlCommand(query, conn)
                adabter.SelectCommand = com
                adabter.Fill(dtable)
                depbox.Text = dtable(0)(4)
                colagebox.Text = dtable(0)(3)
                ComboBox3.Text = dtable(0)(17)


                adabter.Update(dtable)
                'ComboBox4.Items.Clear()



                Dim qu As String
                qu = " select* from academy.depart_colage where colage='" & colagebox.Text & "' and dep_name='" & depbox.Text & "'"
                Dim comm = New MySqlCommand(qu, conn)
                readerr = comm.ExecuteReader
                adabterr.Update(table)
                f = "1"
                While readerr.Read
                    Dim sname = readerr.GetString("dep_name")
                    'TextBox7.Text = sname

                    'TextBox7.Text = dtable(0)(1)
                    'TextBox7.Text = dtable(0)(2)
                    'TextBox9.Text = dtable(0)(29)

                    comm.Parameters.Clear()
                    ' Dim sname As String

                    If depbox.Text = sname And ComboBox3.Text = "بكالاريوس" Then
                        ComboBox4.Items.Clear()
                        ComboBox4.Items.Add("الفصل الاول")
                        ComboBox4.Items.Add("الفصل الثانى")
                        ComboBox4.Items.Add("الفصل الثالث")
                        ComboBox4.Items.Add("الفصل الرابع")
                        ComboBox4.Items.Add("الفصل الخامس")
                        ComboBox4.Items.Add("الفصل السادس")
                        ComboBox4.Items.Add("الفصل السابع")
                        ComboBox4.Items.Add("الفصل الثامن")
                    ElseIf depbox.Text = sname And ComboBox3.Text = "دبلوم" Then
                        ComboBox4.Items.Clear()
                        ComboBox4.Items.Add("الفصل الاول")
                        ComboBox4.Items.Add("الفصل الثانى")
                        ComboBox4.Items.Add("الفصل الثالث")
                        ComboBox4.Items.Add("الفصل الرابع")
                        ComboBox4.Items.Add("الفصل الخامس")
                        ComboBox4.Items.Add("الفصل السادس")

                    ElseIf depbox.Text = "it" And ComboBox3.Text = "ماجستير" Or depbox.Text = "it2" And ComboBox3.Text = "ماجستير" Or depbox.Text = "it3" And ComboBox3.Text = "ماجستير" Then
                        ComboBox4.Items.Clear()
                        ComboBox4.Items.Add("الفصل الاول")
                        ComboBox4.Items.Add("الفصل الثانى")
                        ComboBox4.Items.Add("الفصل الثالث")
                        ComboBox4.Items.Add("الفصل الرابع")
                    End If
                End While

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try

        End If
    End Sub

    Private Sub التقويمالدراسىوالمنهجيةالمتبعهToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles التقويمالدراسىوالمنهجيةالمتبعهToolStripMenuItem.Click
        admin.Label14.Text = Label14.Text
        admin.Label12.Text = Label15.Text
        admin.Label13.Text = Label12.Text
        admin.Show()
        Me.Close()
    End Sub

    Private Sub خروجToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles خروجToolStripMenuItem1.Click
        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub

        End If
        Me.Close()
        Form2.Show()
        Form2.textbox2.Clear()

    End Sub
End Class