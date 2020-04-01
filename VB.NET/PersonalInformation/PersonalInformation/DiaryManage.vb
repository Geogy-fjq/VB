Imports System.IO

Public Class DiaryManage

    Private catalog As ArrayList '用动态太数组储存日记内容
    Public Sub New()
        catalog = New ArrayList
    End Sub

    '添加日记：已存在返回1，新建返回2
    Public Sub Add(diary As Diary)
        catalog.Add(diary)
    End Sub
    '删除日记
    Public Sub DelByTim(time As String)
        If (catalog.Count = 0) Then
            Return
        End If
        For i = 0 To catalog.Count - 1
            If (CType(catalog.Item(i), Diary).time = time) Then
                catalog.RemoveAt(i)
                Return
            End If
        Next
    End Sub
    '添加日记
    Public Function GetAddByTim(time As String) As Diary
        If (catalog.Count = 0) Then
            Return Nothing
        End If
        For i = 0 To catalog.Count - 1
            If (CType(catalog.Item(i), Diary).time = time) Then
                Return CType(catalog.Item(i), Diary)
            End If
        Next
        Return Nothing
    End Function
    '获得所有记日记的时间
    Public Function GetAllTime() As String()
        If (catalog.Count = 0) Then
            Return Nothing
        End If
        Dim s As String() = New String(catalog.Count - 1) {}
        For i = 0 To catalog.Count - 1
            s(i) = CType(catalog.Item(i), Diary).time
        Next
        Return s
    End Function
    '加载文件
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
        Dim t, c As String
        br.ReadString()
        catalog.Clear()
        While (True)
            If br.BaseStream.Position = br.BaseStream.Length Then
                Exit While
            End If
            t = br.ReadString
            c = br.ReadString
            Add(New Diary(t, c))
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
            bw.Write(CType(catalog.Item(i), Diary).time)
            bw.Write(CType(catalog.Item(i), Diary).content)
        Next
        bw.Close()
        file.Close()
    End Sub

End Class
