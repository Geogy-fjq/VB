
Imports System.IO

Public Class Form2

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        File.Delete("个人信息.txt")
        Dim sw As StreamWriter = New StreamWriter("个人信息.txt", True)
        sw.WriteLine(TextBox1.Text)
        sw.WriteLine(TextBox2.Text)
        sw.WriteLine(TextBox3.Text)
        sw.WriteLine(TextBox7.Text)
        sw.WriteLine(TextBox4.Text)
        sw.WriteLine(TextBox5.Text)
        sw.WriteLine(TextBox6.Text)
        sw.Close()
        If (Len(TextBox1.Text) = 0 Or Len(TextBox2.Text) = 0 Or Len(TextBox3.Text) = 0 Or Len(TextBox4.Text) = 0 Or Len(TextBox5.Text) = 0 Or Len(TextBox6.Text) = 0 Or Len(TextBox7.Text) = 0) Then
            MessageBox.Show("输入错误，请重新输入！")
        Else
            MessageBox.Show("修改成功！")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim sr As StreamReader = New StreamReader("个人信息.txt", True)
        TextBox1.Text = sr.ReadLine
        TextBox2.Text = sr.ReadLine
        TextBox3.Text = sr.ReadLine
        TextBox7.Text = sr.ReadLine
        TextBox4.Text = sr.ReadLine
        TextBox5.Text = sr.ReadLine
        TextBox6.Text = sr.ReadLine
        sr.Close()

    End Sub
End Class