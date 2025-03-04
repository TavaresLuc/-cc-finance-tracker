<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlterarTransacao
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        PictureBox1 = New PictureBox()
        dataTransacaotxt = New DateTimePicker()
        descricaotxt = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        btnSalvar = New Button()
        btnCancelar = New Button()
        numeroCartaotxt = New MaskedTextBox()
        valorTransacaotxt = New MaskedTextBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.newLogo
        PictureBox1.Location = New Point(-3, -21)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(179, 93)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' dataTransacaotxt
        ' 
        dataTransacaotxt.Location = New Point(215, 151)
        dataTransacaotxt.Name = "dataTransacaotxt"
        dataTransacaotxt.Size = New Size(214, 23)
        dataTransacaotxt.TabIndex = 3
        ' 
        ' descricaotxt
        ' 
        descricaotxt.Location = New Point(215, 183)
        descricaotxt.Multiline = True
        descricaotxt.Name = "descricaotxt"
        descricaotxt.Size = New Size(214, 78)
        descricaotxt.TabIndex = 4
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(100, 87)
        Label1.Name = "Label1"
        Label1.Size = New Size(92, 15)
        Label1.TabIndex = 5
        Label1.Text = "Numero Cartão:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(100, 120)
        Label2.Name = "Label2"
        Label2.Size = New Size(36, 15)
        Label2.TabIndex = 6
        Label2.Text = "Valor:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(100, 151)
        Label3.Name = "Label3"
        Label3.Size = New Size(34, 15)
        Label3.TabIndex = 7
        Label3.Text = "Data:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(100, 183)
        Label4.Name = "Label4"
        Label4.Size = New Size(61, 15)
        Label4.TabIndex = 8
        Label4.Text = "Descrição:"
        ' 
        ' btnSalvar
        ' 
        btnSalvar.Location = New Point(321, 278)
        btnSalvar.Name = "btnSalvar"
        btnSalvar.Size = New Size(127, 49)
        btnSalvar.TabIndex = 9
        btnSalvar.Text = "Salvar"
        btnSalvar.UseVisualStyleBackColor = True
        ' 
        ' btnCancelar
        ' 
        btnCancelar.Location = New Point(137, 278)
        btnCancelar.Name = "btnCancelar"
        btnCancelar.Size = New Size(127, 49)
        btnCancelar.TabIndex = 10
        btnCancelar.Text = "Cancelar"
        btnCancelar.UseVisualStyleBackColor = True
        ' 
        ' numeroCartaotxt
        ' 
        numeroCartaotxt.Location = New Point(215, 84)
        numeroCartaotxt.Mask = "0000 0000 0000 0000"
        numeroCartaotxt.Name = "numeroCartaotxt"
        numeroCartaotxt.Size = New Size(214, 23)
        numeroCartaotxt.TabIndex = 1
        ' 
        ' valorTransacaotxt
        ' 
        valorTransacaotxt.Location = New Point(215, 117)
        valorTransacaotxt.Name = "valorTransacaotxt"
        valorTransacaotxt.Size = New Size(214, 23)
        valorTransacaotxt.TabIndex = 2
        valorTransacaotxt.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
        ' 
        ' AlterarTransacao
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(567, 339)
        ControlBox = False
        Controls.Add(valorTransacaotxt)
        Controls.Add(numeroCartaotxt)
        Controls.Add(btnCancelar)
        Controls.Add(btnSalvar)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(descricaotxt)
        Controls.Add(dataTransacaotxt)
        Controls.Add(PictureBox1)
        MaximizeBox = False
        MdiChildrenMinimizedAnchorBottom = False
        MinimizeBox = False
        Name = "AlterarTransacao"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "NovaTransacao"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents dataTransacaotxt As DateTimePicker
    Friend WithEvents descricaotxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnSalvar As Button
    Friend WithEvents btnCancelar As Button
    Friend WithEvents numeroCartaotxt As MaskedTextBox
    Friend WithEvents valorTransacaotxt As MaskedTextBox
End Class
