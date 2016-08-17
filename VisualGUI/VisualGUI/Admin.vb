Imports System.Xml

Public Class Admin
    Inherits Persona
    Private _usuario As String
    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property
    'Private _tipoPagos As TipoPagos
    'Public Property TipoPagos() As TipoPagos
    '    Get
    '        Return _tipoPagos
    '    End Get
    '    Set(ByVal value As TipoPagos)
    '        _tipoPagos = value
    '    End Set
    'End Property
    Private _contraseña As String
    Public Property Contraseña() As String
        Get
            Return _contraseña
        End Get
        Set(ByVal value As String)
            _contraseña = value
        End Set
    End Property
    Public Sub New(usuario As String, contraseña As String)
        Me.Usuario = usuario
        Me.Contraseña = contraseña
    End Sub
    Public Sub New(nombre As String, apellido As String, telefono As String, direccion As String)
        MyBase.New(nombre, apellido, telefono, direccion)
    End Sub
    'Private _repositorio As RepositorioProductos
    'Public Property RepositorioProductos() As RepositorioProductos
    '    Get
    '        Return _repositorio
    '    End Get
    '    Set(ByVal value As RepositorioProductos)
    '        _repositorio = value
    '    End Set
    'End Property
    'Private _repositorioProvincias As RepositorioProvincias
    'Public Property RepositorioProvincias() As RepositorioProvincias
    '    Get
    '        Return _repositorioProvincias
    '    End Get
    '    Set(ByVal value As RepositorioProvincias)
    '        _repositorioProvincias = value
    '    End Set
    'End Property

    ''Public Sub AsignarRepositorios(repositorioProd As RepositorioProductos, repositorioProv As RepositorioProvincias, tipoP As TipoPagos)
    'Me.RepositorioProductos = repositorioProd
    '    Me.RepositorioProvincias = repositorioProv
    '    Me.TipoPagos = tipoP
    'End Sub
    'Public Sub ModificarPagos()
    '    Dim opcion As String
    '    Console.WriteLine("Escoja la opción (1-3): ")
    '    opcion = Console.ReadLine()
    '    Me.TipoPagos.ModificarPagos(opcion)
    'End Sub

    Public Overrides Function ValidarDatos()
        Dim path As String = "..\..\admin.xml"
        Dim XmlDom As New XmlDocument()
        XmlDom.Load(path)
        Dim raiz As XmlNodeList = XmlDom.GetElementsByTagName("collection")
        Dim cont As Short = 0
        For Each nodo As XmlNode In raiz
            For Each admin As XmlNode In nodo.ChildNodes
                If (admin.Name.Contains("Admin")) Then
                    For Each datos As XmlNode In admin.ChildNodes
                        Select Case datos.Name
                            Case "usuario"
                                If (Me.Usuario.Contains(datos.InnerText)) Then
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

    'Public Sub ModificarIva()

    '    While (True)
    '        Console.WriteLine("Elija una opción (1-24): ")
    '        Console.WriteLine("- Si desea cancelar y salir digite 0 -")
    '        Dim op3 As Short
    '        op3 = CShort(Console.ReadLine)
    '        If op3 = "0" Then
    '            Console.WriteLine("- No se modificó el IVA de la provincia -")
    '            Exit Sub
    '        End If
    '        If op3 > 0 And op3 < 25 Then
    '            Console.WriteLine("Usted eligió: " + Me.RepositorioProvincias.ArrayProvincias.Item(op3 - 1).NombreProvincia + " con IVA: " & Me.RepositorioProvincias.ArrayProvincias.Item(op3 - 1).Iva & "%")
    '            Console.WriteLine("Ingrese el nuevo valor del IVA: ")
    '            Me.RepositorioProvincias.ArrayProvincias.Item(op3 - 1).Iva = Console.ReadLine
    '            Console.WriteLine("El IVA fue modificado a: " & Me.RepositorioProvincias.ArrayProvincias.Item(op3 - 1).Iva & "%")
    '            Me.RepositorioProvincias.ActualizarXml()
    '            Console.WriteLine("****************** IVA MODIFICADO ******************")
    '            Exit While
    '        Else
    '            Console.WriteLine(" OPCIÓN INCORRECTA !!")
    '        End If
    '    End While

    'End Sub

    'Public Sub EliminarProducto()
    '    Dim cod As Short = 0
    '    Console.WriteLine("- Si desea cancelar y salir digite 0 -")
    '    Console.WriteLine("Ingrese el código del producto a eliminar: ")
    '    cod = Console.ReadLine()
    '    If (cod = "0") Then
    '        Console.WriteLine("- No se eliminó ningun producto -")
    '        Exit Sub
    '    End If
    '    RepositorioProductos.EliminarProductoPorCodigo(cod)
    '    Me.RepositorioProductos.ActualizarXml()
    '    Console.WriteLine("********** PRODUCTO ELIMINADO **********")
    'End Sub

    'Public Sub AgregarProducto()
    '    Dim codigo, descripcion, costo, precio As String

    '    Console.WriteLine(" /////////// AGREGAR PRODUCTO \\\\\\\\\\\")
    '    Console.WriteLine("- Si desea cancelar y salir digite 0 -")
    '    Console.Write("Código: ")
    '    codigo = Console.ReadLine()
    '    If (codigo = "0") Then
    '        Exit Sub
    '    End If
    '    Console.Write("Descripción: ")
    '    descripcion = Console.ReadLine()
    '    If (descripcion = "0") Then
    '        Exit Sub
    '    End If
    '    Console.Write("Costo: ")
    '    costo = Console.ReadLine()
    '    If (costo = "0") Then
    '        Exit Sub
    '    End If
    '    Console.Write("Precio: ")
    '    precio = Console.ReadLine()
    '    If (precio = "0") Then
    '        Exit Sub
    '    End If
    '    Dim newProd As New Producto(codigo, descripcion, CDbl(precio), CDbl(costo))
    '    Me.RepositorioProductos.AgregarProducto(newProd)
    '    Me.RepositorioProductos.ActualizarXml()
    '    Console.WriteLine("****************** PRODUCTO GUARDADO ******************")
    'End Sub


End Class
