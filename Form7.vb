Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Public Class Form7
    ' Dim ports As String() = SerialPort.GetPortNames
    Dim port As Array

    Private Sub Form7_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            port = System.IO.Ports.SerialPort.GetPortNames

            ComboBox1.Items.AddRange(port)

            ' ComboBox1.SelectedIndex = 0
          
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If SerialPort1.IsOpen Then
                With SerialPort1
                    .Write("AT" & vbCrLf)
                    .Write("AT+CMGF-1" & vbCrLf)
                    .Write("AT+CMGF-1" & Chr(34) & TextBox1.Text & Chr(34) & vbCrLf)
                    .Write(RichTextBox1.Text & Chr(26))
                    MsgBox("hi")
                End With
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        With SerialPort1
            .PortName = ComboBox1.Text
            .BaudRate = 115200
            .Parity = Parity.None
            .StopBits = StopBits.One
            .DataBits = 8
            .Handshake = Handshake.RequestToSend
            .DtrEnable = True
            .RtsEnable = True
            .NewLine = vbCrLf
            .Open()



        End With
    End Sub
End Class