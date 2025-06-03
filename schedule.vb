Imports System.IO
Public Class schedule
    Public Function color(ByVal clr As Color) As UInt32
        Dim t As Int32
        Dim a() As Byte
        t = ColorTranslator.ToOle(clr)
        a = BitConverter.GetBytes(t)
        Return BitConverter.ToInt32(a, 0)

    End Function

    Private Sub schedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TextBox1.Text = CStr(Me.AxCalendar1.Year)
        Me.TextBox2.Text = CStr(Me.AxCalendar1.Month)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ColorDialog1.ShowDialog()
        'Me.AxCalendar1.setHiglightday(CShort(TextBox1.Text), CShort(TextBox2.Text), color(ColorDialog1.Color))
    End Sub
End Class