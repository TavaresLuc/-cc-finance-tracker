Imports Microsoft.EntityFrameworkCore

Public Class FinanceTrackerContext
    Inherits DbContext

    Public Property Transacoes As DbSet(Of Transacao)
    Public Property Clientes As DbSet(Of Cliente)

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        optionsBuilder.UseSqlServer("Server=localhost\SQLEXPRESS;Database=GestaoFinanceiro;User Id=sa;Password=qaz@123;TrustServerCertificate=True")
    End Sub
End Class