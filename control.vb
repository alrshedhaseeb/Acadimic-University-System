Imports MaterialSkin
Imports MySql.Data.MySqlClient

Public Class control
    Dim flag = 0
    Dim id As String = ""

    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim adabter As MySqlDataAdapter
    Dim dtable As DataTable

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

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
    Private Sub control_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conn = New MySqlConnection
        conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
        Try
            conn.Open()
            Dim add = New MySqlDataAdapter
            Dim tablee03 = New DataTable
            Dim q001 As String
            q001 = " SELECT * FROM academy.vision ORDER BY time DESC"

            Dim co012 = New MySqlCommand(q001, conn)
            add.SelectCommand = co012
            add.Fill(tablee03)


            If tablee03.Rows.Count > 0 Then
                DataGridView1.Columns.Clear()
                DataGridView1.DataSource = tablee03
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        flag = 0

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GroupBox1.Visible = True
        Button5.Visible = True
        RemoteDesktop1.Visible = True
        DataGridView1.Visible = False
        Label1.Visible = True
        TextBox1.Visible = True
        Label3.Visible = False
        Label4.Visible = False
        ComboBox1.Visible = False
        ComboBox2.Visible = False
        ComboBox3.Visible = False
        TextBox2.Visible = False
        flag = 1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GroupBox1.Visible = True
        Button5.Visible = True
        RemoteDesktop1.Visible = False
        DataGridView1.Visible = True
        Label1.Visible = False
        TextBox1.Visible = False
        Label3.Visible = True
        Label4.Visible = True
        ComboBox1.Visible = True
        ComboBox2.Visible = True
        ComboBox3.Visible = True
        TextBox2.Visible = True

        flag = 2

    End Sub

    Private Sub idd_TextChanged(sender As Object, e As EventArgs) Handles idd.TextChanged
        If idd.Text = "" Then
            RemoteDesktop1.Visible = False
            RemoteDesktop1.Disconnect()

        Else
            RemoteDesktop1.Visible = True
            RemoteDesktop1.Connect(idd.Text)

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If flag = 1 Then
            Try
                Me.RemoteDesktop1.Connect(TextBox1.Text)

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Me.RemoteDesktop1.Disconnect()
            End Try

        ElseIf flag = 2 Then
            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try
                conn.Open()

                Dim add = New MySqlDataAdapter
                Dim tablee03 = New DataTable
                Dim q001 As String
                q001 = " SELECT * FROM academy.vision where user='" & TextBox1.Text & "' or department='" & TextBox2.Text & "' ORDER BY time DESC"

                Dim co012 = New MySqlCommand(q001, conn)
                add.SelectCommand = co012
                add.Fill(tablee03)


                If tablee03.Rows.Count > 0 Then
                    DataGridView1.Columns.Clear()
                    DataGridView1.DataSource = tablee03
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Erorr Entry")

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = Nothing Then
            Button5.Enabled = False
        Else
            Button5.Enabled = True

        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = Nothing Then
            Button5.Enabled = False
        Else
            Button5.Enabled = True
            conn = New MySqlConnection
            conn.ConnectionString = "server =127.0.0.1;userid=root;password=root;database=academy;port=3307;persistsecurityinfo=True;SslMode=none"
            Try
                conn.Open()
                Dim add = New MySqlDataAdapter
                Dim tablee03 = New DataTable
                Dim q001 As String
                q001 = " SELECT * FROM academy.vision where user='" & TextBox1.Text & "' or department='" & TextBox2.Text & "' ORDER BY time DESC"

                Dim co012 = New MySqlCommand(q001, conn)
                add.SelectCommand = co012
                add.Fill(tablee03)


                If tablee03.Rows.Count > 0 Then
                    DataGridView1.Visible = True
                    DataGridView1.Columns.Clear()
                    DataGridView1.DataSource = tablee03
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class