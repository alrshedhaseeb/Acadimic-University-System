Public Class mosgel
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Label22.Text = Label14.Text
        Form1.Label23.Text = Label13.Text
        Form1.Label18.Text = Label12.Text

        Form1.Show()
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form3.Label9.Text = Label14.Text
        Form3.Label13.Text = Label13.Text
        Form3.Label12.Text = Label12.Text
        Form3.Show()
        Me.Close()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tagmeed.Label14.Text = Label14.Text
        tagmeed.Label13.Text = Label13.Text
        tagmeed.Label12.Text = Label12.Text
        tagmeed.Show()
        Me.Close()

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

    Private Sub mosgel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class