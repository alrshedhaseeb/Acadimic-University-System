Imports MySql.Data.MySqlClient

Public Class reji
    Dim conn As MySqlConnection
    Dim com As MySqlCommand
    Dim reader As MySqlDataReader
    Dim table As DataTable
    Dim bsorc As BindingSource
    Dim adapter As MySqlDataAdapter

    Public Sub logout()
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



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form3.Show()
        Me.Hide()
    End Sub












    Private Sub جدولالامتحاناتToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        atendees_exam.Label16.Text = Label14.Text
        atendees_exam.Label18.Text = Label13.Text
        atendees_exam.Label19.Text = Label12.Text

        atendees_exam.Show()
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If TransitionManager1.IsTransition Then
            TransitionManager1.EndTransition()
        Else
            TransitionManager1.StartTransition(ImageSlider1)

            TransitionManager1.StartTransition(Label4)
            Label3.Text = ""
#Disable Warning BC40000 ' Type or member is obsolete
            Label3.Text = "Slide   " & ImageSlider1.GetCurrentImageIndex.ToString
            Label1.Text = "Slide   " & ImageSlider1.GetCurrentImageIndex.ToString
            'Label4.Text = "Slide   " & ImageSlider1.GetCurrentImageIndex.ToString
#Enable Warning BC40000 ' Type or member is obsolete
        End If

        ImageSlider1.AnimationTime = 2500
        Dim max As Byte = ImageSlider1.Images.Count
        Dim courpos As Byte = 0

        If courpos < max Then

            ImageSlider1.SlideNext()
            'Label4.SlideNext()
            courpos = courpos + 1
        Else
            courpos = 0
            Timer1.Stop()

        End If
    End Sub

    Private Sub reji_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

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

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Form1.Label22.Text = Label14.Text
        Form1.Label23.Text = Label13.Text
        Form1.Label18.Text = Label12.Text

        Form1.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)
        Form3.Label9.Text = Label14.Text
        Form3.Label13.Text = Label13.Text
        Form3.Label12.Text = Label12.Text
        Form3.Show()
        Me.Close()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        set_std_to_exam.Label16.Text = Label14.Text
        set_std_to_exam.Label18.Text = Label13.Text
        set_std_to_exam.Label19.Text = Label12.Text

        set_std_to_exam.Show()
        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        mol7.Label14.Text = Label14.Text
        mol7.Label13.Text = Label13.Text
        mol7.Label12.Text = Label12.Text
        mol7.Show()

        Me.Close()


    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        set_res.Label16.Text = Label14.Text
        set_res.Label18.Text = Label13.Text
        set_res.Label19.Text = Label12.Text

        set_res.Show()

        Me.Close()


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        result.Label16.Text = Label14.Text
        result.Label18.Text = Label13.Text
        result.Label19.Text = Label12.Text
        result.Show()

        Me.Close()

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        attendees.Label16.Text = Label14.Text
        attendees.Label18.Text = Label13.Text
        attendees.Label19.Text = Label12.Text

        attendees.Show()
        Me.Close()

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        record_academy.Label14.Text = Label14.Text
        record_academy.Label15.Text = Label13.Text
        record_academy.Label12.Text = Label12.Text
        record_academy.Show()

        Me.Close()

    End Sub
End Class