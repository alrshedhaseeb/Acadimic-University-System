Imports MySql.Data.MySqlClient
Imports MaterialSkin
Public Class tagmeed
    Dim p_t As String = ""
    Dim flag = 3
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim dtable As DataTable

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub
        Else

            Me.Close()
            Form2.Show()
            Form2.textbox2.Clear()
            Form2.PictureBox2.Visible = True
            Form2.PictureBox3.Visible = False
        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        mosgel.Label14.Text = Label14.Text
        mosgel.Label13.Text = Label13.Text
        mosgel.Label12.Text = Label12.Text
        reji.Show()

        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim Ans As MsgBoxResult
        Ans = MsgBox("؟..   " & textbox1.Text & "   هل تــريد تجــميـد الســنـة الدراســـية للــطالــب", vbYesNo + vbExclamation, "هل انت متأكد ")
        If Ans = vbNo Then

            Exit Sub
            'Continue For
        Else
            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"

            Try
                conn.Open()
                Dim fk As String = "عــذرآ لم يتم تجــميـد بيـــانــات هــذا الطـالـب   :"
                Dim tg As String = "تــم تــجـمـيـد الــسـنـة الدراســيـة للطـــالــب  : "

                Dim qq As String
                qq = " update academy.std_info set active='" & 1 & "' where id_std='" & textbox1.Text & "' "

                com = New MySqlCommand(qq, conn)

                If com.ExecuteNonQuery > 0 Then
                    Label6.Text = tg
                    Panel6.Visible = False
                    Panel8.Visible = False
                    Panel7.Visible = True

                    Label7.Text = textbox1.Text
                Else
                    Label8.Text = fk
                    Panel7.Visible = False
                    Panel6.Visible = False
                    Panel8.Visible = True
                    Label15.Text = textbox1.Text
                End If



            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()
            End Try

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        flag = 0
        Dim Ans As MsgBoxResult
        Ans = MsgBox("؟..   " & textbox1.Text & "   هل تــريد فــك  تجــميـد الســنـة الدراســـية للــطالــب", vbYesNo + vbExclamation, "هل انت متأكد ")
        If Ans = vbNo Then

            Exit Sub
            'Continue For
        Else
            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"

            Try
                conn.Open()

                Dim fk As String = "عــذرآ لم يتم فــك تجــميـد بيـــانــات هــذا الطـالـب   :"
                Dim tg As String = "تــم فــك تــجـمـيـد الــسـنـة الدراســيـة للطـــالــب  : "
                Dim qq As String
                qq = " update academy.std_info set active='" & 0 & "' where id_std='" & textbox1.Text & "' "

                com = New MySqlCommand(qq, conn)

                If com.ExecuteNonQuery > 0 Then
                    Label6.Text = tg
                    Panel6.Visible = False
                    Panel8.Visible = False
                    Panel7.Visible = True

                    Label7.Text = textbox1.Text
                Else
                    Label8.Text = fk
                    Panel7.Visible = False
                    Panel6.Visible = False
                    Panel8.Visible = True
                    Label15.Text = textbox1.Text
                End If



            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()
            End Try

        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try


            conn.Open()


            Dim q As String
            q = " select name_std as'اسم الموظف',name_mother as'اسم الوالدة',nationa_id as'الهوية القومية' from academy.std_info where  id_std='" & textbox1.Text & "' or name_std='" & textbox1.Text & "' "
            Dim co = New MySqlCommand(q, conn)
            Dim ad As New MySqlDataAdapter(co)
            dtable = New DataTable()


            ad.Fill(dtable)
            If dtable.Rows.Count > 0 Then
                process_load.TextBox1.Text = "t1"
                process_load.Show()
                'Timer1.Enabled = True
            Else
                '        Panel6.Visible = True
                process_load.TextBox1.Text = "t2"
                process_load.Show()
                '    Timer2.Enabled = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        PictureBox5.Visible = False
        textbox1.Enabled = False
        Timer1.Enabled = False
        DataGridView1.Columns.Clear()
        DataGridView1.DataSource = dtable
        Button1.Enabled = True
        Button2.Enabled = True

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Panel6.Visible = False
        Timer2.Enabled = False
        DataGridView1.Columns.Clear()
        textbox1.Clear()
    End Sub

    Private Sub tagmeed_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Timer1.Enabled = False
        Timer2.Enabled = False

        Dim skinmanager As MaterialSkin.MaterialSkinManager = MaterialSkin.MaterialSkinManager.Instance


        skinmanager.Theme = MaterialSkinManager.Themes.LIGHT

        skinmanager.ColorScheme = New ColorScheme(Primary.Indigo900, Primary.Indigo300, Primary.Pink100, Accent.Cyan700, TextShade.WHITE)



        textbox1.Enabled = True
        textbox1.Visible = True



        Me.textbox1.ForeColor = System.Drawing.Color.BurlyWood
        Me.textbox1.Font = New Font("Arabic Typesetting", 18)


    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Timer1.Enabled = False
        Timer2.Enabled = False
        PictureBox5.Visible = False
        Panel6.Visible = False
        Panel7.Visible = False
        Panel8.Visible = False
        textbox1.Clear()
        textbox1.Enabled = True
        process_load.TextBox1.Clear()

        DataGridView1.Columns.Clear()
        Button1.Enabled = False
        Button2.Enabled = False
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Panel6.Visible = False
    End Sub

    Private Sub textbox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textbox1.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then

            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try


                conn.Open()


                Dim q As String
                q = " select name_std as'اسم الموظف',name_mother as'اسم الوالدة',nationa_id as'الهوية القومية' from academy.std_info where  id_std='" & textbox1.Text & "' or name_std='" & textbox1.Text & "' "
                Dim co = New MySqlCommand(q, conn)
                Dim ad As New MySqlDataAdapter(co)
                dtable = New DataTable()


                ad.Fill(dtable)
                If dtable.Rows.Count > 0 Then
                    process_load.TextBox1.Text = "t1"
                    process_load.Show()
                    'Timer1.Enabled = True
                Else
                    '        Panel6.Visible = True
                    process_load.TextBox1.Text = "t2"
                    process_load.Show()
                    '    Timer2.Enabled = True
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()
            End Try

        End If
    End Sub

    Private Sub السجلالماليToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles السجلالماليToolStripMenuItem.Click
        Form3.Label9.Text = Label14.Text
        Form3.Label13.Text = Label13.Text
        Form3.Label12.Text = Label12.Text
        Form3.Show()
        Me.Close()
    End Sub

    Private Sub قـــبولطــالبمنالتعليمالعالىToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles قـــبولطــالبمنالتعليمالعالىToolStripMenuItem.Click
        Form1.Label22.Text = Label14.Text
        Form1.Label23.Text = Label13.Text
        Form1.Label18.Text = Label12.Text
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub خروجToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles خروجToolStripMenuItem.Click
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