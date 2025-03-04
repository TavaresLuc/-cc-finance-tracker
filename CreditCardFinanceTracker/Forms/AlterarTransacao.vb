Imports Microsoft.EntityFrameworkCore

Public Class AlterarTransacao
    Private _idTransacao As Integer

    ' Construtor que recebe os dados da transação
    Public Sub New(idTransacao As Integer, numeroCartao As String, valor As Decimal, dataTransacao As DateTime, descricao As String)
        ' Chama o método de inicialização do formulário
        InitializeComponent()

        ' Armazena o ID da transação para posterior atualização
        _idTransacao = idTransacao

        ' Preenche os campos do formulário com os dados recebidos
        numeroCartaotxt.Text = numeroCartao
        valorTransacaotxt.Text = valor.ToString("0.00")
        dataTransacaotxt.Value = dataTransacao
        descricaotxt.Text = descricao
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            ' Criar uma instância do serviço
            Dim service As New TransacaoService()

            ' Obter os novos valores digitados pelo usuário
            Dim novoNumeroCartao As String = numeroCartaotxt.Text.Replace(" ", "") ' Remove espaços
            Dim novoValor As Decimal = Convert.ToDecimal(valorTransacaotxt.Text.Replace(",", "."))
            Dim novaData As DateTime = dataTransacaotxt.Value
            Dim novaDescricao As String = descricaotxt.Text

            ' Chamar o serviço para alterar a transação no banco
            service.AlterarTransacao(_idTransacao, novoNumeroCartao, novoValor, novaData, novaDescricao)

            ' Fechar o formulário após a atualização bem-sucedida
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Erro ao salvar alterações: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class
