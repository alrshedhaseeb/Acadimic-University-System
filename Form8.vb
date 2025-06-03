Imports MySql.Data.MySqlClient
Public Class Form8
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim a As Boolean
    Dim m_x As Integer
    Dim m_y As Integer

    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x = 0
        x = Date.Now.ToString("MM")
        Dim y = x + 1
        Dim minNum As Integer = x
        Dim maxNum As Integer = y
        Me.ComboBox1.Items.AddRange(Enumerable.Range(minNum, maxNum - minNum + 1).Select(Function(s) s.ToString()).ToArray())
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.MinDate = Date.Now.ToString("yyy-MM")
        DateTimePicker1.CustomFormat = "yyy-MM"

    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        Me.Close()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Me.Label2.Text = DateTimePicker1.Value.ToString("MM")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try

            conn.Open()

            Dim ad = New MySqlDataAdapter
            Dim tablee05 = New DataTable

            Dim yar = DateTimePicker1.Value.ToString("yyy")
            Dim d_choice = yar + "-" + Me.Label2.Text
            MsgBox(d_choice)

            Dim q As String = ""
            q = " SELECT * FROM academy.staff_acount "
            Dim co05 = New MySqlCommand(q, conn)
            ad.SelectCommand = co05
            ad.Fill(tablee05)
            reader = co05.ExecuteReader

            If tablee05.Rows.Count > 0 Then
                ListBox1.Items.Clear()
                While reader.Read()
                    Dim id As String = reader.GetString("staff_id")
                    ListBox1.Items.Add(reader.GetString("staff_id"))
                End While

                For Each id In ListBox1.Items
                    Dim qy As String = ""
                    qy = " update academy.staff_acount set catch_date='" & d_choice & "',flag='" & 0 & "' where staff_id='" & id & "' "

                    Dim commm = New MySqlCommand(qy, conn)
                    reader.Close()
                    If commm.ExecuteNonQuery > 0 Then
                        Dim qq1 As String = ""
                        Dim de As String = "'" + Label2.Text + "'"
                        Dim mass As String = de & "لقد تم السماح بصرف مرتبابات الموظفين لشهر "

                        qq1 = " Insert Into ac ademy.vision (time,massage,department,user)values('" & Date.Now & "','" & mass & "','" & Label4.Text & "','" & Label15.Text & "' )"

                        com = New MySqlCommand(qq1, conn)
                        MsgBox("تم تعدبل مرتبات الموظفين")
                    Else
                        MsgBox("لم يتم ")
                    End If
                Next
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.Dispose()

        End Try
        End Sub


    Private Sub Panel1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If a Then
            Me.Top = Windows.Forms.Cursor.Position.Y - m_y
            Me.Left = Windows.Forms.Cursor.Position.X - m_x

        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        a = False

    End Sub

    Private Sub Panel1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        a = True
        m_x = Windows.Forms.Cursor.Position.X - Me.Left
        m_y = Windows.Forms.Cursor.Position.Y - Me.Top

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = 1 Or ComboBox1.Text = 2 Or ComboBox1.Text = 3 Or ComboBox1.Text = 4 Or ComboBox1.Text = 5 Or ComboBox1.Text = 6 Or ComboBox1.Text = 7 Or ComboBox1.Text = 8 Or ComboBox1.Text = 9 Then

            Me.Label2.Text = "0" + ComboBox1.Text
        Else
            Me.Label2.Text = ComboBox1.Text
        End If
    End Sub
End Class