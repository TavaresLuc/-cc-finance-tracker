Public Class TransacaoService
    Private ReadOnly _context As New FinanceTrackerContext()

    Public Function ListarTransacoes(numeroCartao As String, dataInicial As Date?, dataFinal As Date?) As List(Of Transacao)
        Dim query = _context.Transacoes.AsQueryable()

        query = query.Where(Function(t) _
                            (String.IsNullOrEmpty(numeroCartao) OrElse t.Numero_Cartao.Contains(numeroCartao)) AndAlso
                            (Not dataInicial.HasValue OrElse t.Data_Transacao >= dataInicial.Value) AndAlso
                            (Not dataFinal.HasValue OrElse t.Data_Transacao <= dataFinal.Value))

        Return query.ToList()
    End Function

End Class
