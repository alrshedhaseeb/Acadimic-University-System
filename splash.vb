Public Class splash

    Private Sub splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        If ProgressBar1.Value < 1 Then
            Label1.Text = ""
        End If
        Label2.Text = "" & ProgressBar1.Value & "%"
        ProgressBar1.Increment(1)

        If ProgressBar1.Value = 1 Then
            Label1.Text = "Wellcome"

        End If
        If ProgressBar1.Value = 25 Then
            Label2.Text = "" & ProgressBar1.Value & "%"
            Label1.Text = "please waite "

        End If
        If ProgressBar1.Value = 50 Then
            Label2.Text = "" & ProgressBar1.Value & "%"
            Label1.Text = "Enjoy"
        End If

        If ProgressBar1.Value = 75 Then
            Label2.Text = "" & ProgressBar1.Value & "%"
            Label1.Text = "vision"
        End If

        If ProgressBar1.Value = ProgressBar1.Maximum Then



            Label2.Text = " " & ProgressBar1.Value & "%"
            Label1.Text = "execution"

            Timer1.Enabled = False
            Me.Hide()

            Form2.Show()


        End If
    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click

        Timer1.Start()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class