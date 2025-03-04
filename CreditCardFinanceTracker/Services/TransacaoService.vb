Imports Microsoft.EntityFrameworkCore

Public Class TransacaoService
    Private ReadOnly _context As New FinanceTrackerContext()

    Public Function ListarTransacoes(Optional numeroCartao As String = Nothing, Optional dataInicial As Date? = Nothing, Optional dataFinal As Date? = Nothing) As List(Of Transacao)
        Try
            ' Garante que a conexão com o banco esteja ativa
            _context.Database.CloseConnection()
            _context.Database.OpenConnection()

            Dim query = _context.Transacoes.AsQueryable()

            ' Aplica os filtros apenas se os valores não forem nulos
            If Not String.IsNullOrEmpty(numeroCartao) Then
                query = query.Where(Function(t) t.Numero_Cartao.Contains(numeroCartao))
            End If

            If dataInicial.HasValue Then
                query = query.Where(Function(t) t.Data_Transacao >= dataInicial.Value)
            End If

            If dataFinal.HasValue Then
                query = query.Where(Function(t) t.Data_Transacao <= dataFinal.Value)
            End If

            ' Garante que a consulta não está corrompida
            Dim sqlQuery As String = query.ToQueryString()
            Debug.WriteLine("Query SQL gerada: " & sqlQuery)

            ' Retorna a lista de transações
            Return query.ToList()
        Catch ex As Exception
            MessageBox.Show("Erro ao listar transações: " & ex.Message)
            Return New List(Of Transacao)()
        Finally
            ' Fecha a conexão após a execução
            _context.Database.CloseConnection()
        End Try
    End Function

    Public Sub ExportarParaExcel(dataInicial As Date, dataFinal As Date)
        Try
            ' Obter os dados detalhados sem agrupamento
            Dim service As New TransacaoService()
            Dim listaTransacoes As List(Of Transacao) = service.ListarTransacoes(Nothing, dataInicial, dataFinal)

            ' Criar DataTable para exportação
            Dim dt As New System.Data.DataTable()
            dt.Columns.Add("Numero_Cartao")
            dt.Columns.Add("Valor_Transacao")
            dt.Columns.Add("Data_Transacao")
            dt.Columns.Add("Descricao")
            dt.Columns.Add("Categoria") ' Aqui podemos chamar a função de categorização

            ' Preencher DataTable com os dados da lista de transações
            For Each transacao As Transacao In listaTransacoes
                dt.Rows.Add(transacao.Numero_Cartao,
                        transacao.Valor_Transacao,
                        transacao.Data_Transacao.ToString("dd/MM/yyyy"),
                        transacao.Descricao,
                        CategorizarTransacao(transacao.Valor_Transacao)) ' Chama a função para categorizar
            Next

            ' Verifica se há dados antes de exportar
            If dt.Rows.Count = 0 Then
                MessageBox.Show("Nenhuma transação encontrada para o período selecionado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ' Chama a classe ExportarExcel usando ClosedXML
            ExportarExcel.GerarExcel(dt)

        Catch ex As Exception
            MessageBox.Show("Erro ao exportar para Excel: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function CategorizarTransacao(valor As Decimal) As String
        If valor > 1000 Then
            Return "Alta"
        ElseIf valor >= 500 Then
            Return "Média"
        Else
            Return "Baixa"
        End If
    End Function




    Public Function ObterTotalTransacoesPorPeriodo(dataInicial As Date, dataFinal As Date) As System.Data.DataTable
        Dim dt As New System.Data.DataTable()

        Try
            ' Criar o comando para executar a procedure
            Using connection = _context.Database.GetDbConnection()
                connection.Open() ' Abre a conexão apenas aqui

                Using command As Microsoft.Data.SqlClient.SqlCommand = connection.CreateCommand()
                    command.CommandText = "sp_TotalTransacoesPorPeriodo"
                    command.CommandType = CommandType.StoredProcedure

                    ' Adicionar os parâmetros da procedure
                    command.Parameters.Add(New Microsoft.Data.SqlClient.SqlParameter("@Data_Inicial", dataInicial))
                    command.Parameters.Add(New Microsoft.Data.SqlClient.SqlParameter("@Data_Final", dataFinal))

                    ' Executar a query e carregar os dados no DataTable
                    Using reader As Microsoft.Data.SqlClient.SqlDataReader = command.ExecuteReader()
                        dt.Load(reader)
                    End Using
                End Using
            End Using ' Conexão fechada automaticamente aqui

        Catch ex As Exception
            MessageBox.Show("Erro ao obter total de transações: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dt
    End Function






    Public Sub SalvarTransacao(transacao As Transacao)
        Try

            transacao.Numero_Cartao = transacao.Numero_Cartao.Replace(" ", "")

            _context.Transacoes.Add(transacao) ' Adiciona ao banco
            _context.SaveChanges() ' Tenta salvar no banco

            ' Exibe o ID gerado pelo banco para verificar se foi salvo corretamente
            MessageBox.Show("Transação salva com sucesso! ID gerado: " & transacao.Id_Transacao, "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As DbUpdateException
            ' Erro ao tentar salvar (erro específico do Entity Framework)
            Dim innerMessage As String = If(ex.InnerException IsNot Nothing, ex.InnerException.Message, "Nenhum detalhe interno.")
            MessageBox.Show("Erro ao salvar a transação: " & ex.Message & vbCrLf & "Detalhes internos: " & innerMessage, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            ' Captura qualquer outro erro
            MessageBox.Show("Erro inesperado ao salvar a transação: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Sub AlterarTransacao(id As Integer, numeroCartao As String, valor As Decimal, dataTransacao As DateTime, descricao As String)
        Try
            ' Busca a transação no banco pelo ID
            Dim transacao = _context.Transacoes.FirstOrDefault(Function(t) t.Id_Transacao = id)

            If transacao IsNot Nothing Then
                ' Atualiza os valores da transação
                transacao.Numero_Cartao = numeroCartao.Replace(" ", "") ' Remove espaços
                transacao.Valor_Transacao = valor
                transacao.Data_Transacao = dataTransacao
                transacao.Descricao = descricao

                ' Salva as mudanças no banco
                _context.SaveChanges()

                MessageBox.Show("Transação alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Erro: Transação não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao atualizar transação: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Public Sub ExcluirTransacao(id As Integer)
        Try
            ' Obtém a transação a ser excluída pelo ID
            Dim transacaoId = _context.Transacoes.FirstOrDefault(Function(t) t.Id_Transacao = id)

            ' Se a transação existir, remove do banco
            If transacaoId IsNot Nothing Then
                _context.Transacoes.Remove(transacaoId)
                _context.SaveChanges()
            Else
                MessageBox.Show("Erro: Transação não encontrada no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao excluir transação: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




End Class
