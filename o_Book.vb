Imports MySql.Data.MySqlClient

Public Class o_Book
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim dtable As DataTable
    Dim flag = 0
    Dim search As String = ""
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        If TextBox1.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox1, "اسم الكتاب")
            Return
        ElseIf TextBox2.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox2, "نبذة عن الكتاب")
            Return
        ElseIf ComboBox1.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox1, "plemase")
            Return
        ElseIf ComboBox2.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox2, "plemase")
            Return

        ElseIf TextBox5.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox5, "plemase")
            Return
        ElseIf TextBox6.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox6, "اسم الكاتب")
            Return

        Else
            Me.ErrorProvider1.Clear()

            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"

            Try
                conn.Open()


                If flag = 1 Then


                    Dim query As String
                    query = " Insert Into academy.book(n_book,department,about,dep,flag,date,writer) values('" & TextBox1.Text & "','" & ComboBox1.Text & "','" & TextBox2.Text & "','" & ComboBox2.Text & "','" & TextBox5.Text & "','" & Date.Now & "','" & TextBox6.Text & "')"

                    com = New MySqlCommand(query, conn)

                    ' com.Parameters.AddWithValue("@image", bytImage)
                    If com.ExecuteNonQuery > 0 Then

                        MsgBox("لقد قمت باضافه كتاب جديد")
                        TextBox1.Clear()
                        TextBox2.Clear()
                        TextBox5.Clear()
                        TextBox6.Clear()
                    Else
                        MsgBox("لم يتم التعديل")
                    End If
              
                    ElseIf flag = 2 Then

                    Dim qy As String
                    qy = " update academy.book set  n_book='" & TextBox1.Text & "',department='" & TextBox3.Text & "',about='" & TextBox2.Text & "',writer='" & TextBox6.Text & "',dep='" & TextBox4.Text & "',flag='" & TextBox5.Text & "',date='" & Date.Now & "' where n_book='" & search & "'"

                    com = New MySqlCommand(qy, conn)
                    If com.ExecuteNonQuery > 0 Then

                        reader = com.ExecuteReader
                        com.Parameters.Clear()
                        reader.Close()
                        MsgBox("تم التعديل")

                        TextBox1.Clear()
                        TextBox2.Clear()
                        TextBox5.Clear()
                        TextBox6.Clear()
                    Else
                        MsgBox("لم يتم التعديل")
                    End If

                End If
            Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        End If



    End Sub


    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If flag = 1 Then
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()

            TextBox5.Clear()
            TextBox6.Clear()
        ElseIf flag = 2 Then
            TextBox2.Clear()
            TextBox5.Clear()
            TextBox3.Clear()
            TextBox4.Clear()

            TextBox6.Clear()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"


        If flag = 2 Then
            Try

                conn.Open()

                Dim ad = New MySqlDataAdapter
                Dim tablee = New DataTable

                Dim q As String
                q = " SELECT * FROM academy.book where n_book='" & TextBox1.Text & "'"

                Dim co = New MySqlCommand(q, conn)
                ad.SelectCommand = co
                ad.Fill(tablee)


                If tablee.Rows.Count > 0 Then
                    search = tablee(0)(1)
                    MsgBox(search)
                    '            Dim img() As Byte
                    '           img = tablee.Rows(0)(13)
                    '          Dim ms As New System.IO.MemoryStream(img)
                    '         PictureBox1.Image = Image.FromStream(ms)

                    TextBox2.Text = tablee(0)(2)

                    TextBox3.Text = tablee(0)(3)
                    TextBox4.Text = tablee(0)(4)
                    TextBox5.Text = tablee(0)(5)
                    TextBox6.Text = tablee(0)(7)
                    co.Parameters.Clear()

                    '''''''''''''''''''''''''''''''''
                    TextBox3.Enabled = True
                    TextBox4.Enabled = True
                    TextBox2.Enabled = True
                    TextBox3.Enabled = True
                    TextBox4.Enabled = True
                    TextBox5.Enabled = True
                    TextBox6.Enabled = True
                    ''''''''''''''''''''''''
                Else

                    MsgBox("عذرآ هذا الكتاب غبر موجود او الاسم غير صحيح")
                    TextBox2.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try
        End If

    End Sub

    Private Sub o_Book_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        adabter = New MySqlDataAdapter
        Dim bsourc = New BindingSource
        dtable = New DataTable



        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            'DataGridView1.Columns.Clear()
            'ComboBox1.Text = Nothing
            ComboBox1.Items.Clear()
            conn.Open()
            Dim query As String
            query = " select* from academy.colage "
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)
            While reader.Read
                Dim sname = reader.GetString("colage_name")
                ComboBox1.Items.Add(sname)

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

            Me.Close()
            Form2.Show()
            Form2.TextBox2.Clear()
        End If
    End Sub

    Private Sub الرئيسيةToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles الرئيسيةToolStripMenuItem.Click
        main_book.Label16.Text = Label16.Text
        main_book.Label18.Text = Label18.Text
        main_book.Label19.Text = Label19.Text
        main_book.Show()
        Me.Close()

    End Sub

    Private Sub المكتبةToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles المكتبةToolStripMenuItem.Click
        process_Book.Label1.Text = Label16.Text
        process_Book.Label2.Text = Label18.Text
        process_Book.Label23.Text = Label19.Text

        process_Book.Show()
        Me.Close()
    End Sub

    Private Sub اعداداتموToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles اعداداتموToolStripMenuItem.Click
        I_Book.Label16.Text = Label16.Text
        I_Book.Label18.Text = Label18.Text
        I_Book.Label19.Text = Label19.Text

        I_Book.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        flag = 1
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox3.Visible = False
        TextBox4.Visible = False
        ComboBox1.Visible = True
        ComboBox2.Visible = True

        TextBox1.Enabled = True
        TextBox2.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        TextBox5.Enabled = True
        TextBox6.Enabled = True
        Button5.Visible = False
        GroupBox4.Enabled = True

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        flag = 2
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox3.Visible = True
        TextBox4.Visible = True
        ComboBox1.Visible = False
        ComboBox2.Visible = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False

        GroupBox4.Enabled = True
        Button5.Visible = True
        TextBox2.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim adabter = New MySqlDataAdapter
        Dim bsourc = New BindingSource
        Dim dtable = New DataTable



        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            ComboBox2.Items.Clear()

            'DataGridView1.Columns.Clear()
            conn.Open()
            Dim query As String
            query = " select* from academy.depart_colage where colage='" & ComboBox1.Text & "'"
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)

            While reader.Read
                Dim sname = reader.GetString("dep_name")
                ComboBox2.Items.Add(sname)

            End While




        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then

            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"


            If flag = 2 Then
                Try

                    conn.Open()

                    Dim ad = New MySqlDataAdapter
                    Dim tablee = New DataTable

                    Dim q As String
                    q = " SELECT * FROM academy.book where n_book='" & TextBox1.Text & "'"

                    Dim co = New MySqlCommand(q, conn)
                    ad.SelectCommand = co
                    ad.Fill(tablee)


                    If tablee.Rows.Count > 0 Then
                        search = tablee(0)(1)
                        MsgBox(search)
                        '            Dim img() As Byte
                        '           img = tablee.Rows(0)(13)
                        '          Dim ms As New System.IO.MemoryStream(img)
                        '         PictureBox1.Image = Image.FromStream(ms)

                        TextBox2.Text = tablee(0)(2)

                        TextBox3.Text = tablee(0)(3)
                        TextBox4.Text = tablee(0)(4)
                        TextBox5.Text = tablee(0)(5)
                        TextBox6.Text = tablee(0)(7)
                        co.Parameters.Clear()

                        '''''''''''''''''''''''''''''''''
                        TextBox3.Enabled = True
                        TextBox4.Enabled = True
                        TextBox2.Enabled = True
                        TextBox3.Enabled = True
                        TextBox4.Enabled = True
                        TextBox5.Enabled = True
                        TextBox6.Enabled = True
                        ''''''''''''''''''''''''
                    Else

                        MsgBox("عذرآ هذا الكتاب غبر موجود او الاسم غير صحيح")
                        TextBox2.Clear()
                        TextBox5.Clear()
                        TextBox6.Clear()
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()

                End Try
            End If

        End If
    End Sub
End Class