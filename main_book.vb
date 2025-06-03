Imports MySql.Data.MySqlClient
Public Class main_book
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader

    Dim adabter As MySqlDataAdapter
    Dim bsourc As BindingSource

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

    Private Sub اعداداتموToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles اعداداتموToolStripMenuItem.Click
        I_Book.Label16.Text = Label16.Text
        I_Book.Label18.Text = Label18.Text
        I_Book.Label19.Text = Label19.Text

        I_Book.Show()
        Me.Close()
    End Sub

    Private Sub main_book_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Dim adapter = New MySqlDataAdapter
        Dim bsorc = New BindingSource
        Dim table = New DataTable

        Dim conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try

            conn.Open()
            Dim query As String
            query = " select n_book from academy.o_book where status='" & 1 & "'"
            com = New MySqlCommand(query, conn)
            adapter.SelectCommand = com
            adapter.Fill(table)

        
          
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.DataSource = table
            Dim exam As New DataGridViewTextBoxColumn() With {.HeaderText = "status", .Name = "exam", .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells}
            DataGridView1.Columns.Insert(1, exam)
            Try
                com.Parameters.Clear()

                Dim t As New DataTable
                Dim row As Integer = DataGridView1.Rows.Count
                For i = 0 To row - 1
                    Dim query1 As String
                    query1 = " select * from academy.o_book where status='" & 1 & "'"
                    com = New MySqlCommand(query1, conn)
                    adapter.SelectCommand = com
                    adapter.Fill(t)
                    reader = com.ExecuteReader
                    Dim re As String = ""
                    Dim a As String = t(0)(3)
                    If a = 1 Then
                        re = "محجوز"
                        DataGridView1.Rows(i).Cells(1).Value = re
                    Else
                        re = "متاح"

                        DataGridView1.Rows(i).Cells(1).Value = re
                    End If
                    ListBox1.Items.Clear()
                    While reader.Read
                        ListBox1.Items.Add(reader.GetString("id_user"))
                    End While
                    reader.Close()
                Next i

            Catch ex As Exception
                MsgBox (ex.Message )
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            conn.dispose()
        End Try

    End Sub

    Private Sub كتابجديدToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles كتابجديدToolStripMenuItem.Click
        o_Book.Label16.Text = Label16.Text
        o_Book.Label18.Text = Label18.Text
        o_Book.Label19.Text = Label19.Text

        o_Book.Show()
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim index As Integer = 0
        index = e.RowIndex
        Dim selecterow As DataGridViewRow
        selecterow = DataGridView1.Rows(index)
        TextBox1.Text = selecterow.Cells(0).Value.ToString
        ListBox1.SelectedIndex = index

        Dim adapter = New MySqlDataAdapter
        Dim bsorc = New BindingSource
        Dim table = New DataTable

        Dim conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try

            conn.Open()

            DataGridView2.Columns.Clear()

           
            adapter = New MySqlDataAdapter
            Dim ttt As New DataTable
            Dim query101 As String
            query101 = " select n_book,status,time from academy.o_book where status='" & 1 & "' and id_user='" & ListBox1.SelectedItem.ToString & "' and n_book='" & TextBox1.Text & "'"
            com = New MySqlCommand(query101, conn)
            adapter.SelectCommand = com

            adapter.Fill(ttt)

            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

             DataGridView2.DataSource = ttt
            '  Dim id As String = ttt(0)(1)
            Dim stat As String = ttt(0)(1)

            If stat = 1 Then
                DataGridView2.Rows(0).Cells(1).Value = "محجوز"
            Else
                DataGridView2.Rows(0).Cells(1).Value = "متاح"
            End If

            Try
                DataGridView3.Columns.Clear()


                adapter = New MySqlDataAdapter
                Dim tt As New DataTable
                Dim query10 As String

                query10 = " select id_user,n_user,address,email,phone from academy.useres where id_user='" & ListBox1.SelectedItem.ToString & "'"
                com = New MySqlCommand(query10, conn)
                adapter.SelectCommand = com

                adapter.Fill(tt)

                DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
              
                DataGridView3.DataSource = tt
              



            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Try
                adapter = New MySqlDataAdapter
                Dim tt0 As New DataTable
                Dim query100 As String

                query100 = " select * from academy.useres where id_user='" & ListBox1.SelectedItem.ToString & "'"
                com = New MySqlCommand(query100, conn)
                adapter.SelectCommand = com

                adapter.Fill(tt0)

                DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                Dim img() As Byte
                img = tt0.Rows(0)(7)
                Dim ms As New System.IO.MemoryStream(img)
                PictureBox1.Image = Image.FromStream(ms)

            Catch ex As Exception

            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub

    Private Sub المكتبةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles المكتبةToolStripMenuItem.Click
        process_Book.Label1.Text = Label16.Text
        process_Book.Label2.Text = Label18.Text
        process_Book.Label23.Text = Label19.Text

        process_Book.Show()
        Me.Close()

    End Sub

End Class