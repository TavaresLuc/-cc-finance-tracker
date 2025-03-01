Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Clientes")>
Public Class Cliente
    <Key>
    Public Property Id_Cliente As Integer

    Public Property Nome_Cliente As String

    Public Property Numero_Cartao As String
End Class
