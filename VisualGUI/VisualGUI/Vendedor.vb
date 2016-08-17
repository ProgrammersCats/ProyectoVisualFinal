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

    Public Overrides Function ValidarDatos()
        Dim path As String = "..\..\admin.xml"
        Dim XmlDom As New XmlDocument()
        XmlDom.Load(path)
        Dim raiz As XmlNodeList = XmlDom.GetElementsByTagName("collection")
        Dim cont As Short = 0
        For Each nodo As XmlNode In raiz
            For Each admin As XmlNode In nodo.ChildNodes
                If (admin.Name.Contains("Vendedor")) Then
                    For Each datos As XmlNode In admin.ChildNodes
                        Select Case datos.Name
                            Case "usuario"
                                If (Me.Nombre.Contains(datos.InnerText)) Then
                                    cont = cont + 1
                                End If
                            Case "contraseña"
                                If (Me.Contraseña.Contains(datos.InnerText)) Then
                                    cont = cont + 1
                                End If
                            Case "nombre"
                                Me.Nombre = datos.InnerText
                            Case "apellido"
                                Me.Apellido = datos.InnerText
                            Case "telefono"
                                Me.Telefono = datos.InnerText
                            Case "direccion"
                                Me.Direccion = datos.InnerText
                        End Select
                    Next
                End If
            Next


        Next
        If (cont = 2) Then
            Return True
        End If
        Return False
    End Function

    Sub New(nombre As String, contraseña As String)
        Me.Nombre = nombre
        Me.Contraseña = contraseña
    End Sub

    Public Function GenerarXml(xmlDom As XmlDocument) As XmlNode
        Dim item As XmlElement = xmlDom.CreateElement("Vendedor")
        Dim nombre As XmlElement = xmlDom.CreateElement("nombre")
        Dim apellido As XmlElement = xmlDom.CreateElement("apellido")
        Dim telefono As XmlElement = xmlDom.CreateElement("telefono")
        Dim direccion As XmlElement = xmlDom.CreateElement("direccion")

        nombre.InnerText = Me.Nombre
        apellido.InnerText = Me.Apellido
        telefono.InnerText = Me.Telefono
        direccion.InnerText = Me.Direccion

        item.AppendChild(nombre)
        item.AppendChild(apellido)
        item.AppendChild(telefono)
        item.AppendChild(direccion)
        Return item
    End Function
End Class

