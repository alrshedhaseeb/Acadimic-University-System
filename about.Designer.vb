<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class about
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MapControl1 = New DevExpress.XtraMap.MapControl()
        Me.ShapefileDataAdapter1 = New DevExpress.XtraMap.ShapefileDataAdapter()
        Me.VectorItemsLayer1 = New DevExpress.XtraMap.VectorItemsLayer()
        CType(Me.MapControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MapControl1
        '
        Me.MapControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MapControl1.Layers.Add(Me.VectorItemsLayer1)
        Me.MapControl1.Location = New System.Drawing.Point(0, 0)
        Me.MapControl1.Name = "MapControl1"
        Me.MapControl1.Size = New System.Drawing.Size(800, 450)
        Me.MapControl1.TabIndex = 0
        Me.ShapefileDataAdapter1.FileUri = New System.Uri("C:\Users\roaosh\Downloads\SDN_adm3.shp", System.UriKind.Absolute)
        Me.VectorItemsLayer1.Data = Me.ShapefileDataAdapter1
        '
        'about
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MapControl1)
        Me.Name = "about"
        Me.Text = "about"
        CType(Me.MapControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MapControl1 As DevExpress.XtraMap.MapControl
    Friend WithEvents VectorItemsLayer1 As DevExpress.XtraMap.VectorItemsLayer
    Friend WithEvents ShapefileDataAdapter1 As DevExpress.XtraMap.ShapefileDataAdapter
End Class
