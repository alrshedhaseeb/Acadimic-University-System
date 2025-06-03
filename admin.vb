
Imports MySql.Data.MySqlClient

Public Class admin
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim table As DataTable

    Dim adabter = New MySqlDataAdapter
    Dim bsourc = New BindingSource
    Dim dtable = New DataTable


    Dim Ans As MsgBoxResult
    Public Sub out()
        DateTimePicker1.Value = Date.Now
        Dim qu As String
        qu = " update academy.login set time_out='" & DateTimePicker1.Value & "' where username='" & Label14.Text & "'"

        Dim comm = New MySqlCommand(qu, conn)
        If comm.ExecuteNonQuery > 0 Then
            reader = comm.ExecuteReader
            MsgBox(DateTimePicker1.Value & "   ..زمن الخروج")

        Else
            MsgBox("عذرآ تاكد من اعدادات الوقت")
        End If

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        

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

   
    Private Sub admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            'DataGridView1.Columns.Clear()
            ComboBox1.Text = Nothing
            ComboBox1.Items.Clear()
            conn.Open()
            Dim query As String
            query = " select* from academy.colage"
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)

            While reader.Read
                Dim sname = reader.GetString("colage_name")
                ComboBox5.Items.Add(sname)
                ComboBox1.Items.Add(sname)
                ComboBox8.Items.Add(sname)

            End While




        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

      
    End Sub

    Private Sub السجلالماليToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles السجلالماليToolStripMenuItem.Click
        Form5.Label14.Text = Label14.Text
        Form5.Label12.Text = Label12.Text
        Form5.Label15.Text = Label13.Text
        Form5.Show()
        Me.Close()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        If TextBox9.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox9, "ادخل اسم الكلية")
            Return

        Else
            ErrorProvider1.Clear()

            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"

            Try
                conn.Open()
                Dim query As String
                query = " Insert Into academy.colage(colage_name) values('" & TextBox9.Text & "')"
                com = New MySqlCommand(query, conn)
                reader = com.ExecuteReader

                MsgBox("لقد تم اضافة كلية جدبده")
                '''''''''''''''''''''''''''''''''''''''''''''''

                Dim qq1 As String = ""
                Dim de As String = "'" + TextBox9.Text + "'"
                Dim mass As String = de & "لقد تم اضافة كلية جدبده"
                qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label13.Text & "','" & Label14.Text & "' )"

                com = New MySqlCommand(qq1, conn)

                TextBox9.Clear()

                Try

                    reader.Close()

                    ComboBox1.Text = Nothing
                    ComboBox1.Items.Clear()
                    ComboBox5.Items.Clear()
                    ComboBox8.Items.Clear()


                    Dim query1 As String
                    query1 = " select* from academy.colage"
                    com = New MySqlCommand(query1, conn)
                    reader = com.ExecuteReader
                    adabter.Update(dtable)

                    While reader.Read
                        Dim sname = reader.GetString("colage_name")
                        ComboBox5.Items.Add(sname)
                        ComboBox1.Items.Add(sname)
                        ComboBox8.Items.Add(sname)

                    End While




                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()

                End Try

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click



        If TextBox6.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox6, "ادخل اسم القسم")
            Return

        ElseIf ComboBox6.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox6, "ادخل اسم الدرجة العلمية")
            Return
        ElseIf ComboBox5.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox5, "ادخل اسم اكلية")
            Return


        Else
            ErrorProvider1.Clear()
            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try
                conn.Open()

                Dim query As String
                query = " Insert Into academy.depart_colage(dep_name,colage,department) values('" & TextBox6.Text & "','" & ComboBox5.Text & "','" & ComboBox6.Text & "')"

                com = New MySqlCommand(query, conn)
                reader = com.ExecuteReader
                Dim qq1 As String = ""
                Dim de As String = "'" + ComboBox6.Text + "/" + TextBox6.Text + "/" + ComboBox5.Text + "'"
                Dim mass As String = de & "لقد تم اضافة قسم جدبد"
                qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label13.Text & "','" & Label14.Text & "' )"

                com = New MySqlCommand(qq1, conn)

                MsgBox("لقد تم اضافة قسم جديد")

                reader.Close()

                ComboBox5.Text = Nothing
                ComboBox6.Text = Nothing
                TextBox6.Clear()

                Try
                    'DataGridView1.Columns.Clear()
                    ComboBox1.Text = Nothing
                    ComboBox1.Items.Clear()
                    ComboBox5.Items.Clear()
                    ComboBox8.Items.Clear()


                    Dim query01 As String
                    query01 = " select* from academy.colage"
                    com = New MySqlCommand(query01, conn)
                    reader = com.ExecuteReader
                    adabter.Update(dtable)

                    While reader.Read
                        Dim sname = reader.GetString("colage_name")
                        ComboBox5.Items.Add(sname)
                        ComboBox1.Items.Add(sname)
                        ComboBox8.Items.Add(sname)

                    End While




                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()

                End Try


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim adabter = New MySqlDataAdapter
        Dim bsourc = New BindingSource
        Dim dtable = New DataTable
        Dim table = New DataTable


        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try

            conn.Open()
            Dim query As String
            query = " select* from academy.depart_colage where colage='" & ComboBox1.Text & "' and dep_name='" & ComboBox2.Text & "'"
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)

            While reader.Read
                Dim sname = reader.GetString("dep_name")
                TextBox7.Text = sname
           
                'TextBox7.Text = dtable(0)(1)
                'TextBox7.Text = dtable(0)(2)
                'TextBox9.Text = dtable(0)(29)

                com.Parameters.Clear()
                ' Dim sname As String

                If ComboBox2.Text = sname And ComboBox3.Text = "بكالاريوس" Then
                    ComboBox4.Items.Clear()
                    ComboBox4.Items.Add("الفصل الاول")
                    ComboBox4.Items.Add("الفصل الثانى")
                    ComboBox4.Items.Add("الفصل الثالث")
                    ComboBox4.Items.Add("الفصل الرابع")
                    ComboBox4.Items.Add("الفصل الخامس")
                    ComboBox4.Items.Add("الفصل السادس")
                    ComboBox4.Items.Add("الفصل السابع")
                    ComboBox4.Items.Add("الفصل الثامن")
                ElseIf ComboBox2.Text = sname And ComboBox3.Text = "دبلوم" Then
                    ComboBox4.Items.Clear()
                    ComboBox4.Items.Add("الفصل الاول")
                    ComboBox4.Items.Add("الفصل الثانى")
                    ComboBox4.Items.Add("الفصل الثالث")
                    ComboBox4.Items.Add("الفصل الرابع")
                    ComboBox4.Items.Add("الفصل الخامس")
                    ComboBox4.Items.Add("الفصل السادس")

                ElseIf ComboBox2.Text = "it" And ComboBox3.Text = "ماجستير" Or ComboBox2.Text = "it2" And ComboBox3.Text = "ماجستير" Or ComboBox2.Text = "it3" And ComboBox3.Text = "ماجستير" Then
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        If ComboBox2.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox2, "ادخل اسم القسم")
            Return

        ElseIf ComboBox3.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox3, "ادخل اسم الدرجة العلمية")
            Return
        ElseIf ComboBox1.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox1, "ادخل اسم اكلية")
            Return
        ElseIf ComboBox4.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox4, "ادخل اسم الفصل الدراسى")
            Return
        ElseIf TextBox1.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox1, "ادخل اسم المقرر")
            Return

        Else
            ErrorProvider1.Clear()

            conn = New MySqlConnection
            Dim con = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try


                conn.Open()

                Dim query003 As String
                query003 = " select* from academy.record_academy where colage='" & ComboBox1.Text & "' AND depart_name='" & ComboBox2.Text & "' AND depart_certificate='" & ComboBox3.Text & "' AND semester='" & ComboBox4.Text & "' "

                com = New MySqlCommand(query003, conn)

                Dim adapter As New MySqlDataAdapter
                adapter.SelectCommand = com

                Dim tb As New DataTable

                adapter.Fill(tb)

                If tb.Rows.Count > 0 Then

                    Dim Ans As MsgBoxResult
                    Ans = MsgBox(" لقد تمت إضافه هذا المقرر مسبقآ" & "   هل تريد التعديل   " & "  ؟..", vbYesNo + vbExclamation, "تعديل ")

                    If Ans = vbNo Then

                        Exit Sub

                    Else

                        Dim qq0 As String
                        qq0 = " update academy.record_academy set time_lecture=' " & TextBox4.Text & " ',degre_pass=' " & TextBox2.Text & " ',semester=' " & ComboBox4.Text & " ',lecture=' " & TextBox1.Text & " ',colage=' " & ComboBox1.Text & " ',teatcher_name=' " & TextBox3.Text & " ',depart_name=' " & ComboBox2.Text & " ',depart_certificate=' " & ComboBox3.Text & " '"

                        com = New MySqlCommand(qq0, conn)

                        If com.ExecuteNonQuery > 0 Then

                            reader = com.ExecuteReader

                            Dim qq1 As String = ""
                            Dim de As String = "'" + TextBox1.Text + "/" + ComboBox4.Text + "/" + ComboBox3.Text + "/" + ComboBox2.Text + "/" + ComboBox1.Text + "'"
                            Dim mass As String = de & "لقد تم تعديل مقرر"
                            qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label13.Text & "','" & Label14.Text & "' )"

                            com = New MySqlCommand(qq1, conn)

                            MsgBox("   تم التعديل")


                            ComboBox1.Text = Nothing
                            ComboBox2.Text = Nothing
                            ComboBox3.Text = Nothing
                            ComboBox4.Text = Nothing
                            TextBox1.Clear()
                            TextBox2.Clear()
                            TextBox3.Clear()
                            TextBox4.Clear()

                            Try
                                reader.Close()

                                ComboBox1.Text = Nothing
                                ComboBox1.Items.Clear()
                                ComboBox5.Items.Clear()
                                ComboBox8.Items.Clear()


                                Dim query01 As String
                                query01 = " select* from academy.colage"

                                com = New MySqlCommand(query01, conn)

                                reader = com.ExecuteReader
                                adabter.Update(dtable)

                                While reader.Read

                                    Dim sname = reader.GetString("colage_name")
                                    ComboBox5.Items.Add(sname)
                                    ComboBox1.Items.Add(sname)
                                    ComboBox8.Items.Add(sname)

                                End While




                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                conn.Dispose()

                            End Try

                        Else
                            MsgBox("لم بتم التعديل")

                        End If

                    End If
                Else


                    Dim query02 As String
                    query02 = " Insert Into academy.record_academy(time_lecture,degre_pass,semester,lecture,colage,teatcher_name,depart_name,depart_certificate) values('" & TextBox4.Text & "','" & TextBox2.Text & "','" & ComboBox4.Text & "','" & TextBox1.Text & "','" & ComboBox1.Text & "','" & TextBox3.Text & "','" & ComboBox2.Text & "','" & ComboBox3.Text & "')"

                    com = New MySqlCommand(query02, conn)

                    reader = com.ExecuteReader

                    com.Parameters.Clear()
                    reader.Close()
                    Dim qq1 As String = ""
                    Dim de As String = "'" + TextBox1.Text + "/" + ComboBox4.Text + "/" + ComboBox3.Text + "/" + ComboBox2.Text + "/" + ComboBox1.Text + "'"
                    Dim mass As String = de & "لقد تم ادخال مقرر"
                    qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label13.Text & "','" & Label14.Text & "' )"

                    com = New MySqlCommand(qq1, conn)

                    MsgBox("لقد قمت بادخال مقرر جديد")


                    ComboBox1.Text = Nothing
                    ComboBox2.Text = Nothing
                    ComboBox3.Text = Nothing
                    ComboBox4.Text = Nothing
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox3.Clear()
                    TextBox4.Clear()

                    Try
                        'DataGridView1.Columns.Clear()
                        ComboBox1.Text = Nothing
                        ComboBox1.Items.Clear()
                        ComboBox5.Items.Clear()
                        ComboBox8.Items.Clear()


                        Dim query01 As String
                        query01 = " select* from academy.colage"
                        com = New MySqlCommand(query01, conn)
                        reader = com.ExecuteReader
                        adabter.Update(dtable)

                        While reader.Read
                            Dim sname = reader.GetString("colage_name")
                            ComboBox5.Items.Add(sname)
                            ComboBox1.Items.Add(sname)
                            ComboBox8.Items.Add(sname)

                        End While




                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conn.Dispose()

                    End Try

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim adabter = New MySqlDataAdapter
        Dim bsourc = New BindingSource
        Dim dtable = New DataTable



        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            'DataGridView1.Columns.Clear()

            conn.Open()
            Dim query As String
            query = " select* from academy.depart_colage where colage='" & ComboBox1.Text & "' AND dep_name='" & ComboBox2.Text & "' "
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)

            While reader.Read
                ComboBox3.Items.Clear()

                Dim sname = reader.GetString("department")
                If sname = "بكالاريوس+دبلوم" Then
                    ComboBox3.Items.Add("بكالاريوس")
                    ComboBox3.Items.Add("دبلوم")
                Else
                    ComboBox3.Items.Add(sname)
                End If
                
            End While




        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
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
                'Dim Degre_COL = reader.GetString("department")
                ComboBox2.Items.Add(sname)
                'ComboBox6.Items.Add(Degre_COL)

            End While




        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub School_degreTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim no As New note
        no.ShowDialog()
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim adabter = New MySqlDataAdapter
        Dim bsourc = New BindingSource
        Dim dtable = New DataTable



        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            'DataGridView1.Columns.Clear()

            conn.Open()
            Dim query As String
            query = " select* from academy.depart_colage where colage='" & ComboBox1.Text & "' AND dep_name='" & ComboBox2.Text & "' "
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)

            While reader.Read
                ComboBox3.Items.Clear()

                Dim sname = reader.GetString("department")
                If sname = "بكالاريوس+دبلوم" Then
                    ComboBox3.Items.Add("بكالاريوس")
                    ComboBox3.Items.Add("دبلوم")
                Else
                    ComboBox3.Items.Add(sname)
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



        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            ComboBox9.Items.Clear()

            'DataGridView1.Columns.Clear()
            conn.Open()
            Dim query As String
            query = " select* from academy.depart_colage where colage='" & ComboBox8.Text & "'"
            com = New MySqlCommand(query, conn)
            reader = com.ExecuteReader
            adabter.Update(dtable)

            While reader.Read
                Dim sname = reader.GetString("dep_name")
                'Dim Degre_COL = reader.GetString("department")
                ComboBox9.Items.Add(sname)
                'ComboBox6.Items.Add(Degre_COL)

            End While




        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox9.SelectedIndexChanged
        Dim adabter = New MySqlDataAdapter
        Dim bsourc = New BindingSource
        Dim dtable = New DataTable



        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            'DataGridView1.Columns.Clear()

            conn.Open()
            Dim query As String
            query = " select* from academy.depart_colage where colage='" & ComboBox8.Text & "' AND dep_name='" & ComboBox9.Text & "' "
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy"

        If ComboBox9.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox9, "ادخل اسم القسم")
            Return

        ElseIf ComboBox7.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox7, "ادخل اسم الدرجة العلمية")
            Return
        ElseIf ComboBox8.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox8, "ادخل اسم اكلية")
            Return

        Else
            ErrorProvider1.Clear()
            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try
                conn.Open()

                Dim query005 As String
                query005 = " select* from academy.dep_fees where colage='" & ComboBox8.Text & "' AND dep_name='" & ComboBox9.Text & "' AND department='" & ComboBox7.Text & "' "

                com = New MySqlCommand(query005, conn)

                Dim adapter As New MySqlDataAdapter
                adapter.SelectCommand = com

                Dim tb As New DataTable

                adapter.Fill(tb)

                If tb.Rows.Count > 0 Then

                    Dim Ans As MsgBoxResult
                    Ans = MsgBox(" لقد تمت إضافه رسوم هذا القسم مسبقآ" & "   هل تريد التعديل   " & "  ؟..", vbYesNo + vbExclamation, "تعديل ")

                    If Ans = vbNo Then

                        Exit Sub

                    Else

                        Dim qq010 As String
                        qq010 = " update academy.dep_fees set fees='" & TextBox5.Text & "' where colage='" & ComboBox8.Text & "' AND dep_name='" & ComboBox9.Text & "' AND department='" & ComboBox7.Text & "'"

                        com = New MySqlCommand(qq010, conn)

                        If com.ExecuteNonQuery > 0 Then

                            reader = com.ExecuteReader
                            Dim qq1 As String = ""
                            Dim de As String = "'" + TextBox5.Text + "/" + ComboBox7.Text + "/" + ComboBox9.Text + "/" + ComboBox8.Text + "'"
                            Dim mass As String = de & "لقد تم تعديل رسوم القسم"
                            qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label13.Text & "','" & Label14.Text & "' )"

                            com = New MySqlCommand(qq1, conn)

                            MsgBox("   تم التعديل")

                            ComboBox7.Text = Nothing
                            ComboBox8.Text = Nothing
                            ComboBox9.Text = Nothing
                            TextBox5.Clear()

                            Try
                                conn.Open()

                                reader.Close()

                                ComboBox1.Text = Nothing
                                ComboBox1.Items.Clear()
                                ComboBox5.Items.Clear()
                                ComboBox8.Items.Clear()


                                Dim query0100 As String
                                query0100 = " select* from academy.colage"

                                com = New MySqlCommand(query0100, conn)

                                reader = com.ExecuteReader
                                adabter.Update(dtable)

                                While reader.Read

                                    Dim sname = reader.GetString("colage_name")
                                    ComboBox5.Items.Add(sname)
                                    ComboBox1.Items.Add(sname)
                                    ComboBox8.Items.Add(sname)

                                End While




                            Catch ex As Exception
                                MsgBox(ex.Message)
                            Finally
                                conn.Dispose()

                            End Try

                        Else
                            MsgBox("لم بتم التعديل")

                        End If

                    End If
                Else

                    Dim query1 As String
                    query1 = " Insert Into academy.dep_fees(dep_name,colage,department,fees,dep_patch) values('" & ComboBox9.Text & "','" & ComboBox8.Text & "','" & ComboBox7.Text & "','" & TextBox5.Text & "','" & DateTimePicker1.Value & "')"

                    com = New MySqlCommand(query1, conn)
                    reader = com.ExecuteReader
                    Dim qq1 As String = ""
                    Dim de As String = "'" + TextBox5.Text + "/" + ComboBox7.Text + "/" + ComboBox9.Text + "/" + ComboBox8.Text + "'"
                    Dim mass As String = de & "لقد تم اضافة رسوم   "
                    qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label13.Text & "','" & Label14.Text & "' )"

                    com = New MySqlCommand(qq1, conn)

                    MsgBox("لقد تم اضافة رسوم القسم ")

                    ComboBox7.Text = Nothing
                    ComboBox8.Text = Nothing
                    ComboBox9.Text = Nothing
                    TextBox5.Clear()

                    Try
                        conn.Open()

                        reader.Close()

                        ComboBox1.Text = Nothing
                        ComboBox1.Items.Clear()
                        ComboBox5.Items.Clear()
                        ComboBox8.Items.Clear()


                        Dim query031 As String
                        query031 = " select* from academy.colage"

                        com = New MySqlCommand(query031, conn)

                        reader = com.ExecuteReader
                        adabter.Update(dtable)

                        While reader.Read

                            Dim sname = reader.GetString("colage_name")
                            ComboBox5.Items.Add(sname)
                            ComboBox1.Items.Add(sname)
                            ComboBox8.Items.Add(sname)

                        End While




                    Catch ex As Exception
                        MsgBox(ex.Message)
                    Finally
                        conn.Dispose()

                    End Try

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()

            End Try

        End If
    End Sub

    Private Sub TextBox5_KeyPress_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ComboBox5.Text = Nothing
        ComboBox6.Text = Nothing
        TextBox6.Clear()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ComboBox7.Text = Nothing
        ComboBox8.Text = Nothing
        ComboBox9.Text = Nothing
        TextBox5.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ComboBox1.Text = Nothing
        ComboBox2.Text = Nothing
        ComboBox3.Text = Nothing
        ComboBox4.Text = Nothing
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox9.Clear()

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        If TextBox9.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox9, "ادخل اسم الكلية")
            Return

        Else

            ErrorProvider1.Clear()
            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try

                conn.Open()



                Dim Ans As MsgBoxResult
                Ans = MsgBox(" هل تريد حذف كلية..؟", vbYesNo + MessageBoxIcon.Warning, "حذف ")

                If Ans = vbNo Then

                    Exit Sub

                Else

                    Dim qq010 As String
                    qq010 = " delete from academy.colage where colage_name='" & TextBox9.Text & "' "

                    com = New MySqlCommand(qq010, conn)

                    If com.ExecuteNonQuery > 0 Then

                        reader = com.ExecuteReader
                        Dim qq1 As String = ""
                        Dim de As String = "'" + TextBox9.Text + "'"
                        Dim mass As String = de & "لقد تم حذف كلية"
                        qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label13.Text & "','" & Label14.Text & "' )"

                        com = New MySqlCommand(qq1, conn)

                        MsgBox("   تم حذف كلية")

                        TextBox9.Clear()


                        Try
                            conn.Open()

                            reader.Close()

                            ComboBox1.Text = Nothing
                            ComboBox1.Items.Clear()
                            ComboBox5.Items.Clear()
                            ComboBox8.Items.Clear()


                            Dim query1 As String
                            query1 = " select* from academy.colage"
                            com = New MySqlCommand(query1, conn)
                            reader = com.ExecuteReader
                            adabter.Update(dtable)

                            While reader.Read
                                Dim sname = reader.GetString("colage_name")
                                ComboBox5.Items.Add(sname)
                                ComboBox1.Items.Add(sname)
                                ComboBox8.Items.Add(sname)

                            End While




                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            conn.Dispose()

                        End Try


                    Else
                        MsgBox("   لم يتم الحذف")
                    End If

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()
            End Try

        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click


        If TextBox6.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox6, "ادخل اسم القسم")
            Return

        ElseIf ComboBox6.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox6, "ادخل اسم الدرجة العلمية")
            Return
        ElseIf ComboBox5.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox5, "ادخل اسم اكلية")
            Return

        Else

            ErrorProvider1.Clear()
            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try

                conn.Open()



                Dim Ans As MsgBoxResult
                Ans = MsgBox(" هل تريد حذف قسم..؟", vbYesNo + MessageBoxIcon.Warning, "حذف ")

                If Ans = vbNo Then

                    Exit Sub

                Else

                    Dim qq010 As String
                    qq010 = " delete from academy.depart_colage where dep_name='" & TextBox6.Text & "' and colage='" & ComboBox5.Text & "' and department='" & ComboBox6.Text & "' "

                    com = New MySqlCommand(qq010, conn)

                    If com.ExecuteNonQuery > 0 Then

                        reader = com.ExecuteReader
                        Dim qq1 As String = ""
                        Dim de As String = "'" + ComboBox6.Text + "/" + TextBox6.Text + "/" + ComboBox5.Text + "'"
                        Dim mass As String = de & "لقد تم حذف قسم "
                        qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label13.Text & "','" & Label14.Text & "' )"

                        com = New MySqlCommand(qq1, conn)

                        MsgBox("   تم حذف قسم")

                        ComboBox5.Text = Nothing
                        ComboBox6.Text = Nothing
                        TextBox6.Clear()

                        Try
                            conn.Open()

                            reader.Close()

                            ComboBox1.Text = Nothing
                            ComboBox1.Items.Clear()
                            ComboBox5.Items.Clear()
                            ComboBox8.Items.Clear()


                            Dim query1 As String
                            query1 = " select* from academy.colage"
                            com = New MySqlCommand(query1, conn)
                            reader = com.ExecuteReader
                            adabter.Update(dtable)

                            While reader.Read
                                Dim sname = reader.GetString("colage_name")
                                ComboBox5.Items.Add(sname)
                                ComboBox1.Items.Add(sname)
                                ComboBox8.Items.Add(sname)

                            End While




                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            conn.Dispose()

                        End Try


                    Else
                        MsgBox("   لم يتم الحذف")
                    End If

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()
            End Try

        End If

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click


        If ComboBox9.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox9, "ادخل اسم القسم")
            Return

        ElseIf ComboBox7.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox7, "ادخل اسم الدرجة العلمية")
            Return
        ElseIf ComboBox8.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox8, "ادخل اسم اكلية")
            Return

        Else

            ErrorProvider1.Clear()
            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try

                conn.Open()



                Dim Ans As MsgBoxResult
                Ans = MsgBox(" هل تريد حذف رسوم هذه الكلية..؟", vbYesNo + MessageBoxIcon.Warning, "حذف ")

                If Ans = vbNo Then

                    Exit Sub

                Else

                    Dim qq010 As String
                    qq010 = " delete from academy.dep_fees where dep_name='" & ComboBox9.Text & "' and colage='" & ComboBox8.Text & "' and department='" & ComboBox7.Text & "' "

                    com = New MySqlCommand(qq010, conn)

                    If com.ExecuteNonQuery > 0 Then

                        reader = com.ExecuteReader
                        Dim qq1 As String = ""
                        Dim de As String = "'" + TextBox5.Text + "/" + ComboBox7.Text + "/" + ComboBox9.Text + "/" + ComboBox8.Text + "'"
                        Dim mass As String = de & "لقد تم حذف رسوم كلية"
                        qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label13.Text & "','" & Label14.Text & "' )"

                        com = New MySqlCommand(qq1, conn)

                        MsgBox("   تم حذف  رسوم الكلية")

                        ComboBox7.Text = Nothing
                        ComboBox8.Text = Nothing
                        ComboBox9.Text = Nothing
                        TextBox5.Clear()

                        Try

                            conn.Open()

                            reader.Close()

                            ComboBox1.Text = Nothing
                            ComboBox1.Items.Clear()
                            ComboBox5.Items.Clear()
                            ComboBox8.Items.Clear()


                            Dim query1 As String
                            query1 = " select* from academy.colage"
                            com = New MySqlCommand(query1, conn)
                            reader = com.ExecuteReader
                            adabter.Update(dtable)

                            While reader.Read
                                Dim sname = reader.GetString("colage_name")
                                ComboBox5.Items.Add(sname)
                                ComboBox1.Items.Add(sname)
                                ComboBox8.Items.Add(sname)

                            End While




                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            conn.Dispose()

                        End Try


                    Else
                        MsgBox("   لم يتم الحذف")
                    End If

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Dispose()
            End Try

        End If

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click


        If ComboBox2.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox2, "ادخل اسم القسم")
            Return

        ElseIf ComboBox3.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox3, "ادخل اسم الدرجة العلمية")
            Return
        ElseIf ComboBox1.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox1, "ادخل اسم اكلية")
            Return
        ElseIf ComboBox4.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.ComboBox4, "ادخل اسم الفصل الدراسى")
            Return
        ElseIf TextBox1.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox1, "ادخل اسم المقرر")
            Return

        Else

            ErrorProvider1.Clear()
            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try

                conn.Open()



                Dim Ans As MsgBoxResult
                Ans = MsgBox(" هل تريد حذف هذه المقرر..؟", vbYesNo + MessageBoxIcon.Warning, "حذف ")

                If Ans = vbNo Then

                    Exit Sub

                Else

                    Dim qq010 As String
                    qq010 = " delete from academy.dep_fees where depart_name='" & ComboBox2.Text & "' and colage='" & ComboBox1.Text & "' and depart_certificate='" & ComboBox3.Text & "' and semester='" & ComboBox4.Text & "' and lecture='" & TextBox1.Text & "' "

                    com = New MySqlCommand(qq010, conn)

                    If com.ExecuteNonQuery > 0 Then

                        reader = com.ExecuteReader
                        Dim qq1 As String = ""
                        Dim de As String = "'" + TextBox1.Text + "/" + ComboBox4.Text + "/" + ComboBox3.Text + "/" + ComboBox2.Text + "/" + ComboBox1.Text + "'"
                        Dim mass As String = de & "لقد تم حذف مقرر"
                        qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label13.Text & "','" & Label14.Text & "' )"

                        com = New MySqlCommand(qq1, conn)

                        MsgBox("   تم حذف المقرر")

                        TextBox1.Clear()
                        ComboBox1.Text = Nothing
                        ComboBox2.Text = Nothing
                        ComboBox3.Text = Nothing
                        ComboBox4.Text = Nothing

                        Try
                            conn.Open()


                            reader.Close()

                            ComboBox1.Text = Nothing
                            ComboBox1.Items.Clear()
                            ComboBox5.Items.Clear()
                            ComboBox8.Items.Clear()


                            Dim query1 As String
                            query1 = " select* from academy.colage"
                            com = New MySqlCommand(query1, conn)
                            reader = com.ExecuteReader
                            adabter.Update(dtable)

                            While reader.Read
                                Dim sname = reader.GetString("colage_name")
                                ComboBox5.Items.Add(sname)
                                ComboBox1.Items.Add(sname)
                                ComboBox8.Items.Add(sname)

                            End While




                        Catch ex As Exception
                            MsgBox(ex.Message)
                        Finally
                            conn.Dispose()

                        End Try


                    Else
                        MsgBox("   لم يتم الحذف")
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
