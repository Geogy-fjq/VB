Imports System.IO

Public Class CommunicationManage

    Private catalog As ArrayList

    Public Sub New()
        catalog = New ArrayList
    End Sub

    '添加联系人：已存在则返回1，新建则返回2
    Public Function Add(address As communication) As Integer
        For i = 0 To catalog.Count - 1
            If (CType(catalog.Item(i), communication).name = address.name) Then
                CType(catalog.Item(i), communication).tel = address.tel
                Return 1
            End If
        Next
        catalog.Add(address)
        Return 2
    End Function
    '删除联系人
    Public Sub DelByNam(name As String)
        If (catalog.Count = 0) Then
            Return
        End If
        For i = 0 To catalog.Count - 1
            If (CType(catalog.Item(i), communication).name = name) Then
                catalog.RemoveAt(i)
                Return
            End If
        Next
    End Sub
    '添加联系人
    Public Function GetAddByNam(name As String) As communication
        If (catalog.Count = 0) Then
            Return Nothing
        End If
        For i = 0 To catalog.Count - 1
            If (CType(catalog.Item(i), communication).name = name) Then
                Return CType(catalog.Item(i), communication)
            End If
        Next
        Return Nothing
    End Function
    '获得所有的联系人姓名
    Public Function GetAllName() As String()
        If (catalog.Count = 0) Then
            Return Nothing
        End If
        Dim s As String() = New String(catalog.Count - 1) {}
        For i = 0 To catalog.Count - 1
            s(i) = CType(catalog.Item(i), communication).name
        Next
        Return s
    End Function
    '加载文件
    Public Sub LoadFile(filename As String)
        If Not Dir(filename) <> "" Then
            Dim fs As New FileStream(filename, FileMode.OpenOrCreate)
            Dim bw As New BinaryWriter(fs)
            bw.Write("")
            bw.Close()
            fs.Close()
        End If
        Dim file As New FileStream(filename, FileMode.Open)
        Dim br As New BinaryReader(file)
        Dim n, t As String
        br.ReadString()
        While (True)
            If br.BaseStream.Position = br.BaseStream.Length Then
                Exit While
            End If
            n = br.ReadString
            t = br.ReadString
            Add(New communication(n, t))
        End While
        br.Close()
        file.Close()
    End Sub
    '更新文件
    Public Sub CreateFile(filename As String)
        Dim file As New FileStream(filename, FileMode.Create)
        Dim bw As New BinaryWriter(file)
        bw.Write("")
        For i = 0 To catalog.Count - 1
            bw.Write(CType(catalog.Item(i), communication).name)
            bw.Write(CType(catalog.Item(i), communication).tel)
        Next
            bw.Close()
            file.Close()
        End Sub


    End Class
