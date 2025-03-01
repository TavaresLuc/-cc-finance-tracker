Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Define o formato para exibir apenas a data
        dtpDataInicial.Format = DateTimePickerFormat.Custom
        dtpDataInicial.CustomFormat = "dd/MM/yyyy"

        dtpDataFinal.Format = DateTimePickerFormat.Custom
        dtpDataFinal.CustomFormat = "dd/MM/yyyy"

    End Sub

    Private Sub BotaoNovo_Click() Handles BotaoNovo.Click
        NovoCadastro()
    End Sub

    Private Sub FiltrarTransacoes2() Handles BtnFiltrarTransacoes.Click
        Dim service As New TransacaoService()
        Dim numeroCartao = txtNumeroCartao.Text
        Dim dataInicial As Date? = If(dtpDataInicial.Value <> Nothing, dtpDataInicial.Value, Nothing)
        Dim dataFinal As Date? = If(dtpDataFinal.Value <> Nothing, dtpDataFinal.Value, Nothing)

        Dim lista = service.ListarTransacoes(numeroCartao, dataInicial, dataFinal)
        dgvTransacoes.DataSource = lista

    End Sub
End Class