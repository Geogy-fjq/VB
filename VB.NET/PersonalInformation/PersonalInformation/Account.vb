Public Class Account '账簿类
    Public time As String '记账时间
    Public note As String '账目名称
    Public money As Double '账目金额

    Public Sub New(time As String, note As String, money As Double)
        Me.time = time
        Me.note = note
        Me.money = money
    End Sub

    Public Sub New(note As String, money As Double)
        time = Format(Now, "yy.MM.dd hh:mm:ss")
        Me.note = note
        Me.money = money
    End Sub

End Class
