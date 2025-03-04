Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Office.Interop.Excel


Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtpDataInicial.Format = DateTimePickerFormat.Custom
        dtpDataInicial.CustomFormat = "dd/MM/yyyy"

        dtpDataFinal.Format = DateTimePickerFormat.Custom
        dtpDataFinal.CustomFormat = "dd/MM/yyyy"

    End Sub

    Private Sub BotaoNovo_Click() Handles BotaoNovo.Click
        Dim novaTransacaoForm As New NovaTransacao()
        novaTransacaoForm.ShowDialog()
    End Sub

    Private Sub FiltrarTransacoes2() Handles BtnFiltrarTransacoes.Click
        Dim service As New TransacaoService()
        Dim numeroCartao = txtNumeroCartao.Text

        ' Converter para DateTime e formatar para o padrão SQL (YYYY-MM-DD)
        Dim dataInicial As Date? = If(dtpDataInicial.Checked, dtpDataInicial.Value.Date, Nothing)
        Dim dataFinal As Date? = If(dtpDataFinal.Checked, dtpDataFinal.Value.Date, Nothing)

        If dataFinal.HasValue Then
            dataFinal = dataFinal.Value.AddDays(1).AddSeconds(-1) ' Ajusta para o final do dia 23:59:59
        End If

        ' Chamar a função de filtragem
        Dim lista = service.ListarTransacoes(numeroCartao, dataInicial, dataFinal)

        ' Exibir no DataGridView
        dgvTransacoes.DataSource = lista
        AdicionarBotoesAoDataGridView()
    End Sub


    ' Função para adicionar os botões dinamicamente APÓS os dados serem carregados
    Private Sub AdicionarBotoesAoDataGridView()
        ' Remove colunas antigas se já existirem
        If dgvTransacoes.Columns.Contains("btnAlterar") Then dgvTransacoes.Columns.Remove("btnAlterar")
        If dgvTransacoes.Columns.Contains("btnExcluir") Then dgvTransacoes.Columns.Remove("btnExcluir")

        ' Se o DataGridView não tiver linhas, não adiciona os botões
        If dgvTransacoes.Rows.Count = 0 Then Exit Sub

        ' Criar botão "Alterar"
        Dim btnAlterar As New DataGridViewImageColumn()
        btnAlterar.Name = "btnAlterar"
        btnAlterar.HeaderText = "Alterar"
        btnAlterar.Image = My.Resources.editIcon ' Substitua pelo nome correto no Resources
        btnAlterar.ImageLayout = DataGridViewImageCellLayout.Zoom
        btnAlterar.Width = 1
        dgvTransacoes.Columns.Add(btnAlterar)

        ' Criar botão "Excluir"
        Dim btnExcluir As New DataGridViewImageColumn()
        btnExcluir.Name = "btnExcluir"
        btnExcluir.HeaderText = "Excluir"
        btnExcluir.Image = My.Resources.deleteIcon ' Substitua pelo nome correto no Resources
        btnExcluir.ImageLayout = DataGridViewImageCellLayout.Zoom
        btnExcluir.Width = 1
        dgvTransacoes.Columns.Add(btnExcluir)
    End Sub

    Private Sub dgvTransacoes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTransacoes.CellClick
        If e.RowIndex < 0 Then Exit Sub ' Evita erro ao clicar no cabeçalho

        ' Obtém o ID da transação corretamente (substitua pelo nome real da coluna de ID)
        Dim idTransacao As Integer = Convert.ToInt32(dgvTransacoes.Rows(e.RowIndex).Cells("Id_Transacao").Value)

        ' Verifica se clicou no botão "Alterar"
        If dgvTransacoes.Columns(e.ColumnIndex).Name = "btnAlterar" Then
            ' Obtém os dados da linha selecionada
            Dim numeroCartao As String = dgvTransacoes.Rows(e.RowIndex).Cells("Numero_Cartao").Value.ToString()
            Dim valor As Decimal = Convert.ToDecimal(dgvTransacoes.Rows(e.RowIndex).Cells("Valor_Transacao").Value)
            Dim dataTransacao As DateTime = Convert.ToDateTime(dgvTransacoes.Rows(e.RowIndex).Cells("Data_Transacao").Value)
            Dim descricao As String = dgvTransacoes.Rows(e.RowIndex).Cells("Descricao").Value.ToString()

            ' Abre o formulário de alteração com os dados carregados
            Dim frmAlterar As New AlterarTransacao(idTransacao, numeroCartao, valor, dataTransacao, descricao)
            frmAlterar.ShowDialog()

            ' Atualiza a listagem após fechar a tela de alteração
            FiltrarTransacoes2()

            ' Verifica se clicou no botão "Excluir"
        ElseIf dgvTransacoes.Columns(e.ColumnIndex).Name = "btnExcluir" Then
            Dim confirm As DialogResult = MessageBox.Show("Tem certeza que deseja excluir esta transação?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If confirm = DialogResult.Yes Then
                ' Chama o serviço para excluir a transação
                Dim service As New TransacaoService()
                service.ExcluirTransacao(idTransacao)

                ' Atualiza a lista no DataGridView após excluir
                FiltrarTransacoes2()

                MessageBox.Show("Transação excluída com sucesso!")
            End If
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles VerificarRelatorio.LinkClicked
        ' Pega as datas do DateTimePicker
        Dim dataInicial = dtpDataInicial.Value
        Dim dataFinal = dtpDataFinal.Value

        ' Abre o relatório passando as datas como parâmetro
        Dim relatorioForm As New RelatorioCartoes(dataInicial, dataFinal)
        relatorioForm.ShowDialog()
    End Sub

    Private Sub ExportarExcel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles ExportarExcel.LinkClicked
        Try
            ' Captura as datas dos DateTimePickers
            Dim dataInicial As Date = dtpDataInicial.Value
            Dim dataFinal As Date = dtpDataFinal.Value

            ' Chama a função do serviço para exportar os dados para Excel
            Dim service As New TransacaoService()
            service.ExportarParaExcel(dataInicial, dataFinal)

        Catch ex As Exception
            MessageBox.Show("Erro ao exportar para Excel: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class