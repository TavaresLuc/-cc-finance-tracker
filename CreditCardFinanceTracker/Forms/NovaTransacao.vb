Public Class NovaTransacao


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dataTransacaotxt.Format = DateTimePickerFormat.Custom
        dataTransacaotxt.CustomFormat = "dd/MM/yyyy"

    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            ' Verifica se os controles estão corretamente inicializados
            If numeroCartaotxt Is Nothing OrElse valorTransacaotxt Is Nothing OrElse
           dataTransacaotxt Is Nothing OrElse descricaotxt Is Nothing Then
                MessageBox.Show("Erro: Um ou mais controles não foram inicializados corretamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Validação antes de salvar
            If numeroCartaotxt.Text.Replace(" ", "").Length <> 16 Then
                MessageBox.Show("Número do cartão inválido! Digite um número completo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Validação do valor da transação (Convertendo corretamente)
            Dim valorFormatado As Decimal
            If Not Decimal.TryParse(valorTransacaotxt.Text.Replace(" ", "").Replace(",", "."), Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, valorFormatado) Then
                MessageBox.Show("Digite um valor válido!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Criar a nova transação
            Dim novaTransacao As New Transacao() With {
            .Numero_Cartao = numeroCartaotxt.Text,
            .Valor_Transacao = valorFormatado,
            .Data_Transacao = dataTransacaotxt.Value,
            .Descricao = descricaotxt.Text
        }



            ' Salvar no banco
            Dim service As New TransacaoService()
            service.SalvarTransacao(novaTransacao)

            MessageBox.Show("Transação salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Erro ao salvar transação: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub valorTransacaotxt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles valorTransacaotxt.KeyPress
        ' Permitir apenas números, vírgula, ponto e teclas de controle (Backspace, Delete)
        If Not Char.IsDigit(e.KeyChar) AndAlso Not e.KeyChar = "."c AndAlso Not e.KeyChar = ","c AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True ' Bloqueia caracteres inválidos
        End If
    End Sub

End Class