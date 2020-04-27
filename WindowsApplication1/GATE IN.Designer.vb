<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GATEIN
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.btnOut = New System.Windows.Forms.Button()
        Me.btnIn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 42)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "QR_CODE"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Adobe Gothic Std B", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.Location = New System.Drawing.Point(236, 48)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(203, 39)
        Me.RichTextBox1.TabIndex = 1
        Me.RichTextBox1.Text = ""
        '
        'btnOut
        '
        Me.btnOut.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.out
        Me.btnOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOut.Location = New System.Drawing.Point(287, 124)
        Me.btnOut.Name = "btnOut"
        Me.btnOut.Size = New System.Drawing.Size(91, 47)
        Me.btnOut.TabIndex = 29
        Me.btnOut.UseVisualStyleBackColor = True
        '
        'btnIn
        '
        Me.btnIn.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources._in
        Me.btnIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnIn.Location = New System.Drawing.Point(81, 124)
        Me.btnIn.Name = "btnIn"
        Me.btnIn.Size = New System.Drawing.Size(95, 47)
        Me.btnIn.TabIndex = 28
        Me.btnIn.UseVisualStyleBackColor = True
        '
        'GATEIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(460, 203)
        Me.Controls.Add(Me.btnOut)
        Me.Controls.Add(Me.btnIn)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "GATEIN"
        Me.Text = "GATE IN"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents btnOut As System.Windows.Forms.Button
    Friend WithEvents btnIn As System.Windows.Forms.Button
End Class
