Imports System.Data
Imports Microsoft.EntityFrameworkCore

Public Class RelatorioCartoes
    Private _dataInicial As Date
    Private _dataFinal As Date

    ' Construtor para receber as datas do Form1
    Public Sub New(dataInicial As Date, dataFinal As Date)
        InitializeComponent() ' Inicializa o formulário
        _dataInicial = dataInicial
        _dataFinal = dataFinal
    End Sub

    ' Evento de Load do Form
    Private Sub RelatorioCartoes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CarregarRelatorio()
    End Sub

    ' Método para buscar os dados no banco e exibir no DataGridView
    Private Sub CarregarRelatorio()
        Try
            Dim service As New TransacaoService()
            Dim dt As DataTable = service.ObterTotalTransacoesPorPeriodo(_dataInicial, _dataFinal)

            ' Verifica se há dados antes de exibir
            If dt.Rows.Count > 0 Then
                dgvRelatorioCartoes.DataSource = dt
            Else
                MessageBox.Show("Nenhuma transação encontrada para o período selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Erro ao carregar relatório: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
