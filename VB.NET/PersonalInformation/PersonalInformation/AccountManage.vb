Imports System.IO

Public Class AccountManage

    Private catalog As ArrayList '使用动态数组来储存账簿信息

    Public Sub New()
        catalog = New ArrayList
    End Sub

    Public Sub Add(account As Account)
        catalog.Add(account)
    End Sub
    '通过记账时间来删除账簿信息
    Public Sub DelByTim(time As String)
        If (catalog.Count = 0) Then
            Return
        End If
        For i = 0 To catalog.Count - 1
            If (CType(catalog.Item(i), Account).time = time) Then
                catalog.RemoveAt(i)
                Return
            End If
        Next
    End Sub
    '通过记账时间来获得账簿信息
    Public Function GetAccByTim(time As String) As Account
        If (catalog.Count = 0) Then
            Return Nothing
        End If
        For i = 0 To catalog.Count - 1
            If (CType(catalog.Item(i), Account).time = time) Then
                Return CType(catalog.Item(i), Account)
            End If
        Next
        Return Nothing
    End Function
    '获得所有的记账时间
    Public Function GetAllTime() As String()
        If (catalog.Count = 0) Then
            Return Nothing
        End If
        Dim s As String() = New String(catalog.Count - 1) {}
        For i = 0 To catalog.Count - 1
            s(i) = CType(catalog.Item(i), Account).time
        Next
        Return s
    End Function
    '文件加载
    Public Sub LoadFile(filename As String)
        If Not Dir(filename) <> "" Then
            Dim fs As New FileStream(filename, FileMode.Create)
            Dim bw As New BinaryWriter(fs)
            bw.Write("")
            bw.Close()
            fs.Close()
        End If
        Dim file As New FileStream(filename, FileMode.Open)
        Dim br As New BinaryReader(file)
        Dim t, n As String
        Dim m As Double
        br.ReadString()
        catalog.Clear()
        While (True)
            If br.BaseStream.Position = br.BaseStream.Length Then
                Exit While
            End If
            t = br.ReadString
            n = br.ReadString
            m = br.ReadDouble
            Add(New Account(t, n, m))
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
            bw.Write(CType(catalog.Item(i), Account).time)
            bw.Write(CType(catalog.Item(i), Account).note)
            bw.Write(CType(catalog.Item(i), Account).money)
        Next
        bw.Close()
        file.Close()
    End Sub
End Class
