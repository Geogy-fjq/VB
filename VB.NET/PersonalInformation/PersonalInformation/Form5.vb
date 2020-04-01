Public Class Form5

    Private ab As AccountManage

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            Return
        End If
        ab.Add(New Account(TextBox1.Text, TextBox2.Text))
        ab.CreateFile("账目.txt")
        Fresh()
    End Sub

    Private Sub Fresh()
        ab.LoadFile("账目.txt")
        ListBox1.Items.Clear()
        Dim t() = ab.GetAllTime
        If t Is Nothing Then
            Return
        End If
        For i = 0 To t.Count - 1
            ListBox1.Items.Add(t(i))
        Next
    End Sub

    Private Sub ListBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedValueChanged
        Dim a = ab.GetAccByTim(ListBox1.Text)
        If a Is Nothing Then
            Return
        End If
        TextBox1.Text = a.note
        TextBox2.Text = a.money
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ab = New AccountManage
        Fresh()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim d = ab.GetAccByTim(ListBox1.Text)
        If d Is Nothing Then
            Return
        End If
        ab.DelByTim(ListBox1.Text)
        ab.CreateFile("账目.txt")
        Fresh()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

End Class