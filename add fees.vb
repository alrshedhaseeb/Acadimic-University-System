Imports MySql.Data.MySqlClient
Public Class add_fees
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource
    Dim dtable As DataTable
    Dim totall As Double
    Dim total As Double = 0
    Dim patc As String = ""
    Dim tot As Double = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        adabter = New MySqlDataAdapter
        bsourc = New BindingSource
        dtable = New DataTable
        Dim table = New DataTable


        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try

            conn.Open()

            Dim query As String
            query = " SELECT * FROM academy.std_info where id_std='" & TextBox3.Text & "' and active='0'"

            com = New MySqlCommand(query, conn)

            adabter.SelectCommand = com
            adabter.Fill(dtable)

            If dtable.Rows.Count > 0 Then

                TextBox4.Text = dtable(0)(1)
                TextBox5.Text = dtable(0)(3)
                TextBox6.Text = dtable(0)(4)
                TextBox8.Text = dtable(0)(7)
                TextBox10.Text = dtable(0)(18)
                TextBox9.Text = dtable(0)(20)

                patc = dtable(0)(21)

                com.Parameters.Clear()
                Try


                    Dim q As String

                    q = " SELECT * FROM academy.payment where std_id='" & TextBox3.Text & "' and semester='" & TextBox9.Text & "' and patch='" & patc & "' and active='0'"

                    Dim comm = New MySqlCommand(q, conn)

                    adabter.SelectCommand = comm
                    adabter.Fill(table)

                    DateTimePicker1.Value = Date.Now


                    If table.Rows.Count > 0 Then

                        If IsDBNull(table(0)(2)) Then
                        End If
                        TextBox1.Enabled = True

                            MsgBox(table(0)(3))


                            Me.TextBox7.Text = table(0)(3)
                            Me.TextBox11.Text = table(0)(4)
                            Me.TextBox2.Text = table(0)(6)
                            Me.TextBox12.Text = table(0)(2)
                            Me.TextBox13.Text = table(0)(1)
                            Me.TextBox14.Text = table(0)(7)

                            Label12.Text = Me.TextBox13.Text

                        Else

                            MsgBox("مراجعة حسابات هذا الطالب")

                        com.Parameters.Clear()

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()
                End Try

            Else

                MsgBox("تاكد من هوية الطالب")

                com.Parameters.Clear()

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try

    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub TextBox7_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub add_fees_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Now

    End Sub
    Public Sub out()
        DateTimePicker2.Value = Date.Now
        Dim qu As String
        qu = " update academy.login set time_out='" & DateTimePicker2.Value & "' where username='" & Label15.Text & "'"

        Dim comm = New MySqlCommand(qu, conn)
        If comm.ExecuteNonQuery > 0 Then
            reader = comm.ExecuteReader
            MsgBox(DateTimePicker1.Value & "   ..زمن الخروج")

        Else
            MsgBox("عذرآ تاكد من اعدادات الوقت")
        End If

    End Sub


    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If TextBox3.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox3, "ادخل هوية الطالب")
            Return
        ElseIf TextBox4.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox4, "ادخل اسم الطالب")
            Return
        ElseIf TextBox8.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox8, "ادخل اسم الوالدة")
            Return
        ElseIf TextBox10.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox10, "ادخل الدرجة العلمية")
        ElseIf TextBox5.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox5, "ادخل الكلية")
        ElseIf TextBox6.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox6, "ادخل القسم")
        ElseIf TextBox9.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox9, "ادخل الفصل الدراسى")
        ElseIf TextBox1.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox1, "ادخل المبلغ المراد دفعه")
        ElseIf TextBox11.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox11, "plemase")
        ElseIf TextBox2.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox2, "plemase")
        ElseIf TextBox7.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox7, "plemase")
        ElseIf Label12.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.Label12, "plemase")
        ElseIf TextBox12.Text = Nothing Then
            Me.ErrorProvider1.Clear()
            Me.ErrorProvider1.SetError(Me.TextBox12, "plemase")

        Else
            ErrorProvider1.Clear()


            Dim conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"

            If Me.TextBox1.Text = Nothing Then

                MsgBox("الرجاء ادخال المبلغ المراد دفعه")

            ElseIf Me.TextBox1.Text = 0 Then

                MsgBox("الرجاء ادخال المبلغ المراد دفعه")

            ElseIf Me.TextBox11.Text = Me.TextBox7.Text Then

                MsgBox("عذرا لقد تم دفع كل الرسوم مسبقآ")

            Else

                Try

                    conn.Open()

                    Dim query As String

                    If Me.TextBox11.Text = Nothing Then

                        tot = Val(Me.TextBox1.Text)

                    Else

                        tot = (Val(Me.TextBox1.Text) + (Me.TextBox11.Text))

                    End If

                    query = " update academy.payment set total_pay='" & Label12.Text & "', price_rejisteration='" & TextBox12.Text & "', pay_now='" & tot & "',time_pay='" & DateTimePicker1.Value & "',l_pay='" & TextBox1.Text & "',l_pay_befor='" & TextBox14.Text & "',l_p_t_b='" & TextBox2.Text & "',l_paytime='" & TextBox2.Text & "' where std_id='" & TextBox3.Text & "' and semester='" & TextBox9.Text & "' and patch='" & patc & "'"
                    com = New MySqlCommand(query, conn)

                    If com.ExecuteNonQuery > 0 Then

                        reader = com.ExecuteReader
                        com.Parameters.Clear()
                        reader.Close()
                        '''''''''''''''''''''''''''''''''''''''''''''''

                        Dim qq1 As String = ""
                        Dim de As String = "'" + TextBox1.Text + "/" + TextBox4.Text + "'"
                        Dim mass As String = de & "تم تدفيع الطالب   "
                        qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label16.Text & "','" & Label15.Text & "' )"

                        com = New MySqlCommand(qq1, conn)

                        MsgBox("تم سداد المبلغ المحدد")

                        '''''''''''''''''''''''''''''''''''print ''''''''''''''
                        PrintDocument1.PrinterSettings.Copies = 2
                        PrintDocument1.Print()

                        '''''''''''''''''''''''''''''''''''''''''''''

                        TextBox1.Clear()

                        ' Label12.Text = 0


                        Dim ttref = New DataTable
                        Dim ref As String = ""
                        ref = " SELECT * FROM academy.payment where std_id='" & TextBox3.Text & "' and semester='" & TextBox9.Text & "' and patch='" & patc & "' "

                        Dim comm = New MySqlCommand(ref, conn)

                        adabter.SelectCommand = comm
                        adabter.Fill(ttref)

                        If ttref.Rows.Count > 0 Then

                            TextBox1.Clear()

                            Label12.Text = TextBox13.Text
                            Me.TextBox7.Text = ttref(0)(3)
                            Me.TextBox11.Text = ttref(0)(4)
                            Me.TextBox2.Text = ttref(0)(6)
                            Me.TextBox12.Text = ttref(0)(2)
                            Me.TextBox13.Text = ttref(0)(1)
                            Me.TextBox14.Text = ttref(0)(7)


                        End If
                        '  Label21.Text = 0
                    Else

                        MsgBox("لم يتم الدفع")

                    End If



                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    conn.Dispose()

                End Try

            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        Try
            If Me.TextBox11.Text = 0 Then

                total = Val(Me.TextBox7.Text) - Val(Me.TextBox1.Text)
                Label12.Text = total

                ''''''''''''''''''''''''''''''''''''''''''''''''
                If Val(Me.TextBox1.Text) <= Val(Me.TextBox7.Text) Then

                Else

                    MsgBox("عذرا هذا المبلغ الذى ادخلته اكثر من المبلغ المفروض علي الطالب")

                    TextBox1.Clear()

                    Label12.Text = Val(TextBox13.Text)

                End If
                '''''''''''''''''''''''''''''''''


            ElseIf Me.TextBox11.Text > 0 Then

                total = Val(Me.TextBox13.Text)
                Label12.Text = total

                total = Val(Label12.Text) - Val(Me.TextBox1.Text)
                Label12.Text = total

                If Val(Me.TextBox13.Text) >= Val(Me.TextBox1.Text) Then

                Else

                    MsgBox("عذرا هذا المبلغ الذى ادخلته اكثر من المبلغ المفروض علي الطالب")

                    TextBox1.Clear()

                    Label12.Text = Val(TextBox13.Text)

                End If

            Else

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub خروجToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub

        End If
        Me.Close()
        Form2.Show()
        Form2.TextBox2.Clear()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox8.Clear()
        TextBox10.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox9.Clear()
        TextBox11.Text = 0
        TextBox2.Text = "0 / 0 / 0"
        TextBox7.Clear()
        Label12.Text = 0
        'Label21.Text = 0
        TextBox1.Enabled = False

    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form1.Label22.Text = Label15.Text
        Form1.Label23.Text = Label16.Text
        Form1.Label18.Text = Label13.Text

        Form1.Show()
        Me.Close()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form3.Label9.Text = Label15.Text
        Form3.Label13.Text = Label16.Text
        Form3.Label12.Text = Label13.Text
        Form3.Show()
        Me.Close()

    End Sub

    
    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        record_academy.Label14.Text = Label15.Text
        record_academy.Label15.Text = Label16.Text
        record_academy.Label12.Text = Label13.Text
        record_academy.Show()

        Me.Close()

    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        set_res.Label16.Text = Label15.Text
        set_res.Label18.Text = Label16.Text
        set_res.Label19.Text = Label13.Text

        set_res.Show()

        Me.Close()

    End Sub

    Private Sub النتيجةالنهائيهToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'result.Label16.Text = Label15.Text
        'result.Label18.Text = Label16.Text
        'result.Label19.Text = Label17.Text

        'result.Show()

        Me.Close()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub

        End If
        Me.Close()
        Form2.Show()
        Form2.TextBox2.Clear()

    End Sub

    Private Sub TextBox11_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox11.TextChanged
        Label12.Text = totall

    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged
        Label12.Text = Me.TextBox13.Text
    End Sub


    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage



        Dim x As String = " بسم الله الرحمن الرحيم"
        Dim repuplic As String = " جمهورية السودان"
        Dim repuplic1 As String = " Republic of Sudan"
        Dim unv As String = " جامعة الصفا"
        Dim unv1 As String = " University of Alsafa Aviation college"

        Dim std_no As String = "Student No ................................................................. "
        Dim id As String = Me.TextBox3.Text
        Dim a As String = "ايصال مالى"

        Dim name_std As String = " ................................................................................................................................ اسم الطالب"
        Dim name As String = Me.TextBox4.Text

        Dim fees_char As String = " ......................................................................................................................... المبلغ المدفوع كتابه"
        Dim fees_ch As String = ""

        Dim fees_nu As String = "..............................................  المبلغ المدفوع ارقام"
        Dim fees_n As String = tot

        Dim motbgee As String = " .......................................... المبلغ المتبقى من الرسوم"
        Dim fees_M As String = Me.Label12.Text

        Dim fees As String = "............................................... الرسوم الدراسية"
        Dim fess As String = Me.TextBox7.Text

        Dim signe As String = ".................................................  التوقيــع"



        e.Graphics.DrawString(x, New Font("Arabic Typesetting", 12, FontStyle.Regular), New SolidBrush(Color.Black), New Point(405, 10))
        e.Graphics.DrawString(repuplic, New Font("Arabic Typesetting", 16, FontStyle.Bold), New SolidBrush(Color.Black), New Point(400, 35))

        e.Graphics.DrawString(repuplic1, New Font("Arabic Typesetting", 16, FontStyle.Bold), New SolidBrush(Color.Black), New Point(385, 60))
        e.Graphics.DrawString(unv, New Font("Arabic Typesetting", 20, FontStyle.Bold), New SolidBrush(Color.Black), New Point(400, 80))

        e.Graphics.DrawString(unv1, New Font("Arabic Typesetting", 20, FontStyle.Bold), New SolidBrush(Color.Black), New Point(300, 110))

        e.Graphics.DrawString(std_no, New Font("Arabic Typesetting", 14, FontStyle.Italic), New SolidBrush(Color.Black), New Point(100, 140))
        e.Graphics.DrawString(id, New Font("Arabic Typesetting", 14, FontStyle.Regular), New SolidBrush(Color.Black), New Point(180, 137))

        e.Graphics.DrawString(a, New Font("Arabic Typesetting", 20, FontStyle.Italic), New SolidBrush(Color.Black), New Point(400, 170))

        e.Graphics.DrawString(name_std, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 200))
        e.Graphics.DrawString(name, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 196))

        e.Graphics.DrawString(fees_char, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 250))
        e.Graphics.DrawString(fees_ch, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 246))

        e.Graphics.DrawString(fees_nu, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 280))
        e.Graphics.DrawString(fees_n, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 280))

        e.Graphics.DrawString(motbgee, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(450, 280))
        e.Graphics.DrawString(fees_M, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(450, 280))

        e.Graphics.DrawString(fees, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 310))
        e.Graphics.DrawString(fess, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(100, 310))

        e.Graphics.DrawString(signe, New Font("Arabic Typesetting", 20, FontStyle.Regular), New SolidBrush(Color.Black), New Point(500, 310))



    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim Ans As MsgBoxResult
        Ans = MsgBox("هل تريد الخروج..؟", vbYesNo + vbExclamation, "Exite")
        If Ans = vbNo Then

            Exit Sub

        End If
        Me.Close()
        Form2.Show()
        Form2.TextBox2.Clear()

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Dim a As New note
        a.ShowDialog()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

        PrintDocument1.Print()

    End Sub
End Class