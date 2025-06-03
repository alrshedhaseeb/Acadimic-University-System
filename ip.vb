Public Class ip
    Private Sub ip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        control.idd.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        control.idd.Text = Me.id.Text
        Me.Hide()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Me.Close()

    End Sub
End Class