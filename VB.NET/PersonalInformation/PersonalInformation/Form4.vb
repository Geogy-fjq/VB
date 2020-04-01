Public Class Form4

    Private db As DiaryManage



    Private Sub Form4_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim d = db.GetAddByTim(ListBox1.Text)
        If d Is Nothing Then
            Return
        End If
        db.DelByTim(ListBox1.Text)
        db.CreateFile("日记.txt")
        Fresh()
        TextBox1.Text = ""
    End Sub

    Private Sub Fresh()
        db.LoadFile("日记.txt")
        ListBox1.Items.Clear()
        Dim t() = db.GetAllTime
        If t Is Nothing Then
            Return
        End If
        For i = 0 To t.Count - 1
            ListBox1.Items.Add(t(i))
        Next
    End Sub

    Private Sub ListBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedValueChanged
        Dim d = db.GetAddByTim(ListBox1.Text)
        If d Is Nothing Then
            Return
        End If
        TextBox1.Text = d.content
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            Return
        End If
        db.Add(New Diary(TextBox1.Text))
        db.CreateFile("日记.txt")
        Fresh()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        db = New DiaryManage
        Fresh()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Form1.Show()
        Me.Close()

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class