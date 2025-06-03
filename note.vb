Public Class note
    Dim a As Boolean
    Dim m_x As Integer
    Dim m_y As Integer
    Private Sub note_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SendToBack()
        TextBox1.Text = My.Settings.textsave
        Me.BackColor = Color.Red
        Me.TransparencyKey = Me.BackColor
    End Sub

    Private Sub move_m_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles move_m.MouseDown
        a = True
        m_x = Windows.Forms.Cursor.Position.X - Me.Left
        m_y = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub

    Private Sub move_m_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles move_m.MouseMove
        If a Then
            Me.Top = Windows.Forms.Cursor.Position.Y - m_y
            Me.Left = Windows.Forms.Cursor.Position.X - m_x

        End If
    End Sub

    Private Sub move_m_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles move_m.MouseUp
        a = False

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        ColorDialog1.ShowDialog()
        TextBox1.ForeColor = ColorDialog1.Color
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            My.Settings.textsave = TextBox1.Text
        End If
    End Sub

End Class