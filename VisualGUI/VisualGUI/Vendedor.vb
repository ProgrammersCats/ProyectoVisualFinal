Imports System.Xml

Public Class Vendedor
    Inherits Persona

    Private _contraseña As String
    Public Property Contraseña() As String
        Get
            Return _contraseña
        End Get
        Set(ByVal value As String)
            _contraseña = value
        End Set
    End Property



    Sub New(nombre As String, contraseña As String)
        Me.Nombre = nombre
        Me.Contraseña = contraseña
    End Sub

End Class

