<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.خروجToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.اعداداتموToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.متابعةحضورالموظفينمتابعةحضورالموظفينToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.التحكمفىصرفياتالموظفينToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.إدارةصلاحيهموظفToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.flag = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.textbox1 = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.textbox2 = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.textbox3 = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.textbox4 = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.CheckBox1 = New MaterialSkin.Controls.MaterialCheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arabic Typesetting", 36.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(616, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(271, 55)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "واجهة تسجيل مستخدم"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(228, 414)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(287, 283)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label12.Font = New System.Drawing.Font("Arabic Typesetting", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Cyan
        Me.Label12.Location = New System.Drawing.Point(224, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(17, 27)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "-"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label11.Font = New System.Drawing.Font("Arabic Typesetting", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(508, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 27)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "زمن الدخول"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Arabic Typesetting", 20.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Cyan
        Me.GroupBox1.Location = New System.Drawing.Point(64, 166)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(1260, 76)
        Me.GroupBox1.TabIndex = 77
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "المستخدم"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label14.Font = New System.Drawing.Font("Arabic Typesetting", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Cyan
        Me.Label14.Location = New System.Drawing.Point(948, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(17, 27)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "-"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label13.Font = New System.Drawing.Font("Arabic Typesetting", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Cyan
        Me.Label13.Location = New System.Drawing.Point(618, 33)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(17, 27)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "-"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label10.Font = New System.Drawing.Font("Arabic Typesetting", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(815, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 27)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "الصلاحيه "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label9.Font = New System.Drawing.Font("Arabic Typesetting", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(1158, 33)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 27)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "اسم المستخدم"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(215, 726)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 20)
        Me.DateTimePicker1.TabIndex = 78
        Me.DateTimePicker1.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        Me.ErrorProvider1.RightToLeft = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(1346, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(29, 32)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 90
        Me.PictureBox2.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.White
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.خروجToolStripMenuItem, Me.HelpToolStripMenuItem, Me.اعداداتموToolStripMenuItem, Me.متابعةحضورالموظفينمتابعةحضورالموظفينToolStripMenuItem, Me.التحكمفىصرفياتالموظفينToolStripMenuItem, Me.إدارةصلاحيهموظفToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1383, 39)
        Me.MenuStrip1.TabIndex = 91
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'خروجToolStripMenuItem
        '
        Me.خروجToolStripMenuItem.Font = New System.Drawing.Font("Arabic Typesetting", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.خروجToolStripMenuItem.ForeColor = System.Drawing.Color.Red
        Me.خروجToolStripMenuItem.Image = CType(resources.GetObject("خروجToolStripMenuItem.Image"), System.Drawing.Image)
        Me.خروجToolStripMenuItem.Name = "خروجToolStripMenuItem"
        Me.خروجToolStripMenuItem.Size = New System.Drawing.Size(77, 35)
        Me.خروجToolStripMenuItem.Text = "خروج"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutUsToolStripMenuItem})
        Me.HelpToolStripMenuItem.Font = New System.Drawing.Font("Arabic Typesetting", 20.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.HelpToolStripMenuItem.Image = CType(resources.GetObject("HelpToolStripMenuItem.Image"), System.Drawing.Image)
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(86, 35)
        Me.HelpToolStripMenuItem.Text = "مساعدة"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.BackColor = System.Drawing.Color.DimGray
        Me.AboutUsToolStripMenuItem.Font = New System.Drawing.Font("Arabic Typesetting", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboutUsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(139, 28)
        Me.AboutUsToolStripMenuItem.Text = "   من نحن"
        '
        'اعداداتموToolStripMenuItem
        '
        Me.اعداداتموToolStripMenuItem.Font = New System.Drawing.Font("Arabic Typesetting", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.اعداداتموToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.اعداداتموToolStripMenuItem.Name = "اعداداتموToolStripMenuItem"
        Me.اعداداتموToolStripMenuItem.Size = New System.Drawing.Size(86, 35)
        Me.اعداداتموToolStripMenuItem.Text = "اضافه موظف"
        '
        'متابعةحضورالموظفينمتابعةحضورالموظفينToolStripMenuItem
        '
        Me.متابعةحضورالموظفينمتابعةحضورالموظفينToolStripMenuItem.Font = New System.Drawing.Font("Arabic Typesetting", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.متابعةحضورالموظفينمتابعةحضورالموظفينToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.متابعةحضورالموظفينمتابعةحضورالموظفينToolStripMenuItem.Name = "متابعةحضورالموظفينمتابعةحضورالموظفينToolStripMenuItem"
        Me.متابعةحضورالموظفينمتابعةحضورالموظفينToolStripMenuItem.Size = New System.Drawing.Size(121, 35)
        Me.متابعةحضورالموظفينمتابعةحضورالموظفينToolStripMenuItem.Text = "متابعة حضور الموظفين"
        '
        'التحكمفىصرفياتالموظفينToolStripMenuItem
        '
        Me.التحكمفىصرفياتالموظفينToolStripMenuItem.Font = New System.Drawing.Font("Arabic Typesetting", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.التحكمفىصرفياتالموظفينToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.التحكمفىصرفياتالموظفينToolStripMenuItem.Name = "التحكمفىصرفياتالموظفينToolStripMenuItem"
        Me.التحكمفىصرفياتالموظفينToolStripMenuItem.Size = New System.Drawing.Size(144, 35)
        Me.التحكمفىصرفياتالموظفينToolStripMenuItem.Text = "التحكم فى صرفيات الموظفين"
        '
        'إدارةصلاحيهموظفToolStripMenuItem
        '
        Me.إدارةصلاحيهموظفToolStripMenuItem.Font = New System.Drawing.Font("Arabic Typesetting", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.إدارةصلاحيهموظفToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.إدارةصلاحيهموظفToolStripMenuItem.Name = "إدارةصلاحيهموظفToolStripMenuItem"
        Me.إدارةصلاحيهموظفToolStripMenuItem.Size = New System.Drawing.Size(97, 35)
        Me.إدارةصلاحيهموظفToolStripMenuItem.Text = "إعدادت الموظف"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arabic Typesetting", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(754, 810)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 43)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "الغاء"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arabic Typesetting", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1088, 425)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(83, 27)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "اسم المستخدم"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arabic Typesetting", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(1103, 483)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(68, 27)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "كلمه المرور"
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arabic Typesetting", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.DarkCyan
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(910, 800)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(128, 60)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "انشاء "
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arabic Typesetting", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(1110, 680)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(61, 27)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "الصلاحيه"
        '
        'flag
        '
        Me.flag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.flag.Enabled = False
        Me.flag.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.flag.Font = New System.Drawing.Font("Arabic Typesetting", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.flag.ForeColor = System.Drawing.Color.Blue
        Me.flag.FormattingEnabled = True
        Me.flag.Items.AddRange(New Object() {"as admin", "as admiston", "as HR", "as Maktba", "as HR_Fees", "as STD_Fees", "as control", "as clinc", "as IdCard", "as mosgel"})
        Me.flag.Location = New System.Drawing.Point(573, 674)
        Me.flag.Name = "flag"
        Me.flag.Size = New System.Drawing.Size(460, 35)
        Me.flag.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arabic Typesetting", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(1099, 598)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(72, 27)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "الرقم الوطنى"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arabic Typesetting", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(1076, 539)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(95, 27)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "تاكيد كلمه المرور"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.Panel1.Location = New System.Drawing.Point(350, 373)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(819, 3)
        Me.Panel1.TabIndex = 92
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Unicode MS", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(670, 280)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label7.Size = New System.Drawing.Size(202, 21)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "إنشــــــاء صلاحـــيه لمــســتخدم"
        '
        'textbox1
        '
        Me.textbox1.Depth = 0
        Me.textbox1.Enabled = False
        Me.textbox1.Hint = "اسم الــــمستخــدم"
        Me.textbox1.Location = New System.Drawing.Point(569, 427)
        Me.textbox1.MaxLength = 32767
        Me.textbox1.MouseState = MaterialSkin.MouseState.HOVER
        Me.textbox1.Name = "textbox1"
        Me.textbox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.textbox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.textbox1.SelectedText = ""
        Me.textbox1.SelectionLength = 0
        Me.textbox1.SelectionStart = 0
        Me.textbox1.Size = New System.Drawing.Size(463, 23)
        Me.textbox1.TabIndex = 94
        Me.textbox1.TabStop = False
        Me.textbox1.UseSystemPasswordChar = False
        '
        'textbox2
        '
        Me.textbox2.Depth = 0
        Me.textbox2.Enabled = False
        Me.textbox2.Hint = "كــلمـــة الــــــمـرور"
        Me.textbox2.Location = New System.Drawing.Point(569, 483)
        Me.textbox2.MaxLength = 32767
        Me.textbox2.MouseState = MaterialSkin.MouseState.HOVER
        Me.textbox2.Name = "textbox2"
        Me.textbox2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.textbox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.textbox2.SelectedText = ""
        Me.textbox2.SelectionLength = 0
        Me.textbox2.SelectionStart = 0
        Me.textbox2.Size = New System.Drawing.Size(463, 23)
        Me.textbox2.TabIndex = 95
        Me.textbox2.TabStop = False
        Me.textbox2.UseSystemPasswordChar = True
        '
        'textbox3
        '
        Me.textbox3.Depth = 0
        Me.textbox3.Enabled = False
        Me.textbox3.Hint = "تطابق كــلمـــة الــــــمـرو1"
        Me.textbox3.Location = New System.Drawing.Point(569, 539)
        Me.textbox3.MaxLength = 32767
        Me.textbox3.MouseState = MaterialSkin.MouseState.HOVER
        Me.textbox3.Name = "textbox3"
        Me.textbox3.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.textbox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.textbox3.SelectedText = ""
        Me.textbox3.SelectionLength = 0
        Me.textbox3.SelectionStart = 0
        Me.textbox3.Size = New System.Drawing.Size(463, 23)
        Me.textbox3.TabIndex = 96
        Me.textbox3.TabStop = False
        Me.textbox3.UseSystemPasswordChar = True
        '
        'textbox4
        '
        Me.textbox4.Depth = 0
        Me.textbox4.Enabled = False
        Me.textbox4.Hint = "ألـهــوية القــــومــــية"
        Me.textbox4.Location = New System.Drawing.Point(569, 598)
        Me.textbox4.MaxLength = 32767
        Me.textbox4.MouseState = MaterialSkin.MouseState.HOVER
        Me.textbox4.Name = "textbox4"
        Me.textbox4.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.textbox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.textbox4.SelectedText = ""
        Me.textbox4.SelectionLength = 0
        Me.textbox4.SelectionStart = 0
        Me.textbox4.Size = New System.Drawing.Size(463, 23)
        Me.textbox4.TabIndex = 97
        Me.textbox4.TabStop = False
        Me.textbox4.UseSystemPasswordChar = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Depth = 0
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox1.Font = New System.Drawing.Font("Roboto", 10.0!)
        Me.CheckBox1.Location = New System.Drawing.Point(940, 739)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.CheckBox1.MouseLocation = New System.Drawing.Point(-1, -1)
        Me.CheckBox1.MouseState = MaterialSkin.MouseState.HOVER
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Ripple = True
        Me.CheckBox1.Size = New System.Drawing.Size(140, 30)
        Me.CheckBox1.TabIndex = 98
        Me.CheckBox1.Text = "إظهــار كلمة ألـــمــرور"
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arabic Typesetting", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.LightCoral
        Me.Label8.Location = New System.Drawing.Point(1087, 327)
        Me.Label8.Name = "Label8"
        Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label8.Size = New System.Drawing.Size(84, 27)
        Me.Label8.TabIndex = 99
        Me.Label8.Text = " الموظف المراد"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel2.Location = New System.Drawing.Point(647, 308)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(242, 3)
        Me.Panel2.TabIndex = 101
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.BackColor = System.Drawing.Color.White
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox1.Font = New System.Drawing.Font("Arabic Typesetting", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(707, 322)
        Me.ComboBox1.MaxDropDownItems = 15
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox1.Size = New System.Drawing.Size(317, 32)
        Me.ComboBox1.Sorted = True
        Me.ComboBox1.TabIndex = 102
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1383, 920)
        Me.ControlBox = False
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.textbox4)
        Me.Controls.Add(Me.textbox3)
        Me.Controls.Add(Me.textbox2)
        Me.Controls.Add(Me.textbox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.flag)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form4"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Public WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents خروجToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents اعداداتموToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents متابعةحضورالموظفينمتابعةحضورالموظفينToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents التحكمفىصرفياتالموظفينToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents إدارةصلاحيهموظفToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents textbox4 As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents textbox3 As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents textbox2 As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents textbox1 As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents flag As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBox1 As MaterialSkin.Controls.MaterialCheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents ComboBox1 As ComboBox
End Class
