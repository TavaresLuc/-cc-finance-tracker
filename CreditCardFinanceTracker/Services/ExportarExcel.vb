Imports System.Data
Imports System.IO
Imports ClosedXML.Excel

Public Class ExportarExcel
    ' Método para gerar um arquivo Excel sem precisar do Microsoft Excel instalado
    Public Shared Sub GerarExcel(dt As DataTable)
        Try
            ' Criar caixa de diálogo para salvar o arquivo
            Dim saveFileDialog As New SaveFileDialog()
            saveFileDialog.Filter = "Arquivos Excel (*.xlsx)|*.xlsx"
            saveFileDialog.Title = "Salvar Relatório de Transações"
            saveFileDialog.FileName = "Relatorio_Transacoes.xlsx"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                ' Criar um novo arquivo Excel
                Using workbook As New XLWorkbook()
                    Dim worksheet = workbook.Worksheets.Add("Relatório")

                    ' Adiciona os cabeçalhos das colunas
                    For i As Integer = 0 To dt.Columns.Count - 1
                        worksheet.Cell(1, i + 1).Value = dt.Columns(i).ColumnName
                    Next

                    ' Preencher as linhas com os dados
                    For row As Integer = 0 To dt.Rows.Count - 1
                        For col As Integer = 0 To dt.Columns.Count - 1
                            worksheet.Cell(row + 2, col + 1).Value = dt.Rows(row)(col).ToString()
                        Next
                    Next

                    ' Ajustar o tamanho das colunas
                    worksheet.Columns().AdjustToContents()

                    ' Salvar o arquivo no caminho escolhido pelo usuário
                    workbook.SaveAs(saveFileDialog.FileName)
                End Using

                MessageBox.Show("Relatório exportado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Erro ao exportar para Excel: " & ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
