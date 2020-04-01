Imports System.IO

Public Class Form3
    Private ad As CommunicationManage

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim address = ad.GetAddByNam(ListBox1.Text)
        If address Is Nothing Then
            MessageBox.Show("不存在")
            Return
        End If
        TextBox1.Text = address.name
        TextBox2.Text = address.tel
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("请重新输入！")
            Return
        End If
        ad.Add(New communication(TextBox1.Text, TextBox2.Text))
        MessageBox.Show("修改成功！")
        ad.CreateFile("通讯录.txt")
        Fresh()

    End Sub

    Private Sub Fresh()
        ad.LoadFile("通讯录.txt")
        Dim s() = ad.GetAllName
        If (s Is Nothing) Then
            Return
        End If
        ListBox1.Items.Clear()
        For i = 0 To s.Count - 1
            ListBox1.Items.Add(s(i))
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ad.Add(New communication(TextBox1.Text, TextBox2.Text))
        MessageBox.Show("添加成功！")
        ad.CreateFile("通讯录.txt")
        Fresh()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ad = New CommunicationManage
        Fresh()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim d = ad.GetAddByNam(ListBox1.Text)
        If d Is Nothing Then
            Return
        End If
        ad.DelByNam(ListBox1.Text)
        ad.CreateFile("通讯录.txt")
        Fresh()
        TextBox1.Text = ""
        TextBox2.Text = ""
        MessageBox.Show("删除成功！")
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class