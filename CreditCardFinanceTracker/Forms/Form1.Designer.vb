<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        PictureBox1 = New PictureBox()
        BotaoNovo = New PictureBox()
        BtnFiltrarTransacoes = New PictureBox()
        txtNumeroCartao = New TextBox()
        dtpDataInicial = New DateTimePicker()
        dtpDataFinal = New DateTimePicker()
        dgvTransacoes = New DataGridView()
        VerificarRelatorio = New LinkLabel()
        ExportarExcel = New LinkLabel()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(BotaoNovo, ComponentModel.ISupportInitialize).BeginInit()
        CType(BtnFiltrarTransacoes, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvTransacoes, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.newLogo
        PictureBox1.Location = New Point(363, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(289, 82)
        PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' BotaoNovo
        ' 
        BotaoNovo.BackgroundImageLayout = ImageLayout.None
        BotaoNovo.Cursor = Cursors.Hand
        BotaoNovo.Image = CType(resources.GetObject("BotaoNovo.Image"), Image)
        BotaoNovo.Location = New Point(762, 129)
        BotaoNovo.Name = "BotaoNovo"
        BotaoNovo.Size = New Size(212, 59)
        BotaoNovo.SizeMode = PictureBoxSizeMode.StretchImage
        BotaoNovo.TabIndex = 1
        BotaoNovo.TabStop = False
        ' 
        ' BtnFiltrarTransacoes
        ' 
        BtnFiltrarTransacoes.Cursor = Cursors.Hand
        BtnFiltrarTransacoes.Image = CType(resources.GetObject("BtnFiltrarTransacoes.Image"), Image)
        BtnFiltrarTransacoes.Location = New Point(628, 129)
        BtnFiltrarTransacoes.Name = "BtnFiltrarTransacoes"
        BtnFiltrarTransacoes.Size = New Size(128, 59)
        BtnFiltrarTransacoes.SizeMode = PictureBoxSizeMode.CenterImage
        BtnFiltrarTransacoes.TabIndex = 2
        BtnFiltrarTransacoes.TabStop = False
        ' 
        ' txtNumeroCartao
        ' 
        txtNumeroCartao.AllowDrop = True
        txtNumeroCartao.Font = New Font("Segoe UI", 20.0F)
        txtNumeroCartao.Location = New Point(330, 134)
        txtNumeroCartao.Multiline = True
        txtNumeroCartao.Name = "txtNumeroCartao"
        txtNumeroCartao.PlaceholderText = "Número do Cartão"
        txtNumeroCartao.Size = New Size(294, 51)
        txtNumeroCartao.TabIndex = 3
        ' 
        ' dtpDataInicial
        ' 
        dtpDataInicial.Location = New Point(69, 145)
        dtpDataInicial.Name = "dtpDataInicial"
        dtpDataInicial.Size = New Size(104, 23)
        dtpDataInicial.TabIndex = 1
        ' 
        ' dtpDataFinal
        ' 
        dtpDataFinal.CustomFormat = "dd/MM/yyyy"
        dtpDataFinal.Location = New Point(194, 145)
        dtpDataFinal.Name = "dtpDataFinal"
        dtpDataFinal.Size = New Size(104, 23)
        dtpDataFinal.TabIndex = 2
        ' 
        ' dgvTransacoes
        ' 
        dgvTransacoes.AllowUserToOrderColumns = True
        dgvTransacoes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTransacoes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTransacoes.Location = New Point(69, 194)
        dgvTransacoes.Name = "dgvTransacoes"
        dgvTransacoes.Size = New Size(905, 200)
        dgvTransacoes.TabIndex = 6
        ' 
        ' VerificarRelatorio
        ' 
        VerificarRelatorio.AutoSize = True
        VerificarRelatorio.Location = New Point(778, 406)
        VerificarRelatorio.Name = "VerificarRelatorio"
        VerificarRelatorio.Size = New Size(196, 15)
        VerificarRelatorio.TabIndex = 7
        VerificarRelatorio.TabStop = True
        VerificarRelatorio.Text = "Verificar Total agrupado por Cartões"
        ' 
        ' ExportarExcel
        ' 
        ExportarExcel.AutoSize = True
        ExportarExcel.Location = New Point(69, 406)
        ExportarExcel.Name = "ExportarExcel"
        ExportarExcel.Size = New Size(140, 15)
        ExportarExcel.TabIndex = 8
        ExportarExcel.TabStop = True
        ExportarExcel.Text = "Exportar dados para Excel"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1017, 450)
        Controls.Add(ExportarExcel)
        Controls.Add(VerificarRelatorio)
        Controls.Add(dgvTransacoes)
        Controls.Add(dtpDataFinal)
        Controls.Add(dtpDataInicial)
        Controls.Add(txtNumeroCartao)
        Controls.Add(BtnFiltrarTransacoes)
        Controls.Add(BotaoNovo)
        Controls.Add(PictureBox1)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(BotaoNovo, ComponentModel.ISupportInitialize).EndInit()
        CType(BtnFiltrarTransacoes, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvTransacoes, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BotaoNovo As PictureBox
    Friend WithEvents BtnFiltrarTransacoes As PictureBox
    Friend WithEvents txtNumeroCartao As TextBox
    Friend WithEvents dtpDataInicial As DateTimePicker
    Friend WithEvents dtpDataFinal As DateTimePicker
    Friend WithEvents dgvTransacoes As DataGridView
    Friend WithEvents VerificarRelatorio As LinkLabel
    Friend WithEvents ExportarExcel As LinkLabel
End Class
