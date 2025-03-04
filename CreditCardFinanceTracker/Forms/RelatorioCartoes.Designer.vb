<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RelatorioCartoes
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RelatorioCartoes))
        dgvRelatorioCartoes = New DataGridView()
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        CType(dgvRelatorioCartoes, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgvRelatorioCartoes
        ' 
        dgvRelatorioCartoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvRelatorioCartoes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
        dgvRelatorioCartoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvRelatorioCartoes.Location = New Point(57, 103)
        dgvRelatorioCartoes.Name = "dgvRelatorioCartoes"
        dgvRelatorioCartoes.ReadOnly = True
        dgvRelatorioCartoes.Size = New Size(450, 162)
        dgvRelatorioCartoes.TabIndex = 0
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(-1, -16)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(179, 93)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(183, 24)
        Label1.Name = "Label1"
        Label1.Size = New Size(324, 30)
        Label1.TabIndex = 2
        Label1.Text = "Listagem Agrupada por Cartões"
        ' 
        ' RelatorioCartoes
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(545, 297)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Controls.Add(dgvRelatorioCartoes)
        MaximizeBox = False
        Name = "RelatorioCartoes"
        StartPosition = FormStartPosition.CenterParent
        Text = "RelatorioCartoes"
        CType(dgvRelatorioCartoes, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgvRelatorioCartoes As DataGridView
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
End Class
