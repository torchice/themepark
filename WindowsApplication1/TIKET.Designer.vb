<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TIKET
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
        Me.lbCust = New System.Windows.Forms.Label()
        Me.tbIdCust = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbJenisTiket = New System.Windows.Forms.ComboBox()
        Me.btnBayar = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.spJumTiket = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbHarga = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbNmrNota = New System.Windows.Forms.Label()
        Me.lbIdPeg = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnBeli = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spJumTiket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbCust
        '
        Me.lbCust.AutoSize = True
        Me.lbCust.Location = New System.Drawing.Point(23, 59)
        Me.lbCust.Name = "lbCust"
        Me.lbCust.Size = New System.Drawing.Size(122, 13)
        Me.lbCust.TabIndex = 0
        Me.lbCust.Text = "NAMA PENGUNJUNG :"
        '
        'tbIdCust
        '
        Me.tbIdCust.Location = New System.Drawing.Point(161, 56)
        Me.tbIdCust.Name = "tbIdCust"
        Me.tbIdCust.Size = New System.Drawing.Size(164, 20)
        Me.tbIdCust.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(68, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "JENIS TIKET :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(55, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "JUMLAH TIKET :"
        '
        'cbJenisTiket
        '
        Me.cbJenisTiket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbJenisTiket.FormattingEnabled = True
        Me.cbJenisTiket.Items.AddRange(New Object() {"ANAK-ANAK", "DEWASA", "ANAK-ANAK (WEEKEND)", "DEWASA (WEEKEND)"})
        Me.cbJenisTiket.Location = New System.Drawing.Point(161, 86)
        Me.cbJenisTiket.Name = "cbJenisTiket"
        Me.cbJenisTiket.Size = New System.Drawing.Size(121, 21)
        Me.cbJenisTiket.TabIndex = 8
        '
        'btnBayar
        '
        Me.btnBayar.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.pay
        Me.btnBayar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBayar.Location = New System.Drawing.Point(566, 191)
        Me.btnBayar.Name = "btnBayar"
        Me.btnBayar.Size = New System.Drawing.Size(87, 48)
        Me.btnBayar.TabIndex = 11
        Me.btnBayar.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(9, 245)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(644, 150)
        Me.DataGridView1.TabIndex = 13
        '
        'spJumTiket
        '
        Me.spJumTiket.Location = New System.Drawing.Point(161, 117)
        Me.spJumTiket.Name = "spJumTiket"
        Me.spJumTiket.Size = New System.Drawing.Size(64, 20)
        Me.spJumTiket.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(385, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(197, 55)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "TOTAL "
        '
        'lbHarga
        '
        Me.lbHarga.AutoSize = True
        Me.lbHarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbHarga.Location = New System.Drawing.Point(457, 111)
        Me.lbHarga.Name = "lbHarga"
        Me.lbHarga.Size = New System.Drawing.Size(37, 39)
        Me.lbHarga.TabIndex = 17
        Me.lbHarga.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(388, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 39)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Rp."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "NOMOR NOTA : "
        '
        'lbNmrNota
        '
        Me.lbNmrNota.AutoSize = True
        Me.lbNmrNota.Location = New System.Drawing.Point(161, 22)
        Me.lbNmrNota.Name = "lbNmrNota"
        Me.lbNmrNota.Size = New System.Drawing.Size(49, 13)
        Me.lbNmrNota.TabIndex = 20
        Me.lbNmrNota.Text = "XXXXXX"
        '
        'lbIdPeg
        '
        Me.lbIdPeg.AutoSize = True
        Me.lbIdPeg.Location = New System.Drawing.Point(478, 22)
        Me.lbIdPeg.Name = "lbIdPeg"
        Me.lbIdPeg.Size = New System.Drawing.Size(49, 13)
        Me.lbIdPeg.TabIndex = 23
        Me.lbIdPeg.Text = "XXXXXX"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(392, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "ID PEGAWAI : "
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.cancel1
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.Location = New System.Drawing.Point(562, 405)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 47)
        Me.btnCancel.TabIndex = 26
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.back1
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Location = New System.Drawing.Point(465, 405)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(91, 47)
        Me.Button2.TabIndex = 27
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnBeli
        '
        Me.btnBeli.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.buy
        Me.btnBeli.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBeli.Location = New System.Drawing.Point(348, 188)
        Me.btnBeli.Name = "btnBeli"
        Me.btnBeli.Size = New System.Drawing.Size(91, 47)
        Me.btnBeli.TabIndex = 25
        Me.btnBeli.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.parkir
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(452, 188)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 49)
        Me.Button1.TabIndex = 24
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TIKET
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 462)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnBeli)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbIdPeg)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lbNmrNota)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lbHarga)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.spJumTiket)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnBayar)
        Me.Controls.Add(Me.cbJenisTiket)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.tbIdCust)
        Me.Controls.Add(Me.lbCust)
        Me.Name = "TIKET"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TIKET"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spJumTiket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbCust As System.Windows.Forms.Label
    Friend WithEvents tbIdCust As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cbJenisTiket As System.Windows.Forms.ComboBox
    Friend WithEvents btnBayar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents spJumTiket As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbHarga As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbNmrNota As System.Windows.Forms.Label
    Friend WithEvents lbIdPeg As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnBeli As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
