Imports MySql.Data.MySqlClient
Public Class record_academy
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim readerr As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim dtable As DataTable
    Dim f As String = "0"

    Private Sub بياناتسجلالطالبToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form1.Label22.Text = Label14.Text
        Form1.Label23.Text = Label15.Text
        Form1.Label18.Text = Label12.Text
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub السجلالماليToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form3.Label9.Text = Label14.Text
        Form3.Label13.Text = Label15.Text
        Form3.Label12.Text = Label12.Text
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub ادخالنتيجهمقررToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ادخالنتيجهمقررToolStripMenuItem.Click
        set_res.Label16.Text = Label14.Text
        set_res.Label18.Text = Label15.Text
        set_res.Label19.Text = Label12.Text
        set_res.Show()

        Me.Close()
    End Sub

    Private Sub نافذةسدادالرسومToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        add_fees.Label15.Text = Label14.Text
        add_fees.Label16.Text = Label15.Text
        add_fees.Label13.Text = Label12.Text
        add_fees.Show()
        Me.Close()
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

    Private Sub استعلامعنبياناتطالبToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles استعلامعنبياناتطالبToolStripMenuItem.Click
        result.Label16.Text = Label14.Text
        result.Label18.Text = Label15.Text
        result.Label19.Text = Label12.Text
        result.Show()

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
            ComboBox3.Text = dtable(0)(18)
            ComboBox1.Text = dtable(0)(21)

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
            query = " select std_id as'الرقم الجامعى',name_std as'اسم الطالب',lecture as'المقرر',total_degre_exam as'الدرجة',grade as'التقدير' from academy.res_lecture where colage='" & colagebox.Text & "' and dep_name='" & depbox.Text & "' and semester='" & ComboBox4.Text & "' and department='" & ComboBox3.Text & "' and std_id='" & TextBox3.Text & "'"
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
            qu = " select std_id as'الرقم الجامعى',semester as'الفصل الدراسى',res_degre as'الدرجة',grade as'التقدير',res_char as'النتيجة' from academy.result where  std_id='" & TextBox3.Text & "' and semester='" & ComboBox4.Text & "'"
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


    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim no As New note
        no.ShowDialog()
    End Sub

    Private Sub إجلاسالطلابللامتحانToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles إجلاسالطلابللامتحانToolStripMenuItem.Click
        set_std_to_exam.Show()
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
                ComboBox3.Text = dtable(0)(18)
                ComboBox1.Text = dtable(0)(21)

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

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        reji.Label14.Text = Label14.Text
        reji.Label13.Text = Label15.Text
        reji.Label12.Text = Label12.Text
        reji.Show()

        Me.Close()

    End Sub
End Class