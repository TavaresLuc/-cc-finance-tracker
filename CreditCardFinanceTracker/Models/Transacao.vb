Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Transacoes")>
Public Class Transacao
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property Id_Transacao As Integer

    Public Property Numero_Cartao As String

    Public Property Valor_Transacao As Decimal

    Public Property Data_Transacao As DateTime

    Public Property Descricao As String

    ' Public Overridable Property Cliente As Cliente

End Class
