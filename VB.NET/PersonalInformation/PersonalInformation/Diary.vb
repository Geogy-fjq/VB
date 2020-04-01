Public Class Diary '日记本类
    Public time As String '记日记的时间
    Public content As String '日记内容

    Public Sub New(content As String)
        Me.time = Format(Now, "yy.MM.dd hh:mm:ss")
        Me.content = content
    End Sub

    Public Sub New(time As String, content As String)
        Me.time = time
        Me.content = content
    End Sub

End Class
