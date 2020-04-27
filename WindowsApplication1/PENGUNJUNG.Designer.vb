<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PENGUNJUNG
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
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnCust = New System.Windows.Forms.Button()
        Me.btnMember = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnBack
        '
        Me.btnBack.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.back1
        Me.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBack.Location = New System.Drawing.Point(100, 193)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(127, 52)
        Me.btnBack.TabIndex = 22
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnCust
        '
        Me.btnCust.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.cust
        Me.btnCust.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCust.Location = New System.Drawing.Point(100, 115)
        Me.btnCust.Name = "btnCust"
        Me.btnCust.Size = New System.Drawing.Size(127, 40)
        Me.btnCust.TabIndex = 1
        Me.btnCust.UseVisualStyleBackColor = True
        '
        'btnMember
        '
        Me.btnMember.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.member
        Me.btnMember.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMember.Location = New System.Drawing.Point(100, 57)
        Me.btnMember.Name = "btnMember"
        Me.btnMember.Size = New System.Drawing.Size(127, 40)
        Me.btnMember.TabIndex = 0
        Me.btnMember.UseVisualStyleBackColor = True
        '
        'PENGUNJUNG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(335, 299)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnCust)
        Me.Controls.Add(Me.btnMember)
        Me.Name = "PENGUNJUNG"
        Me.Text = "PENGUNJUNG"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnMember As System.Windows.Forms.Button
    Friend WithEvents btnCust As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
End Class
