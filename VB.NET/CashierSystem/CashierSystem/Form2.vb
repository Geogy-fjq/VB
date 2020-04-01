Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '增添商品
        Dim add(Form1.data.Length / 5, 4) As String
        If TextBox1.Text.Length > 0 And TextBox2.Text.Length > 0 And TextBox3.Text.Length > 0 And TextBox4.Text.Length > 0 Then
            For j = 0 To Form1.data.Length / 5
                If j < Form1.data.Length / 5 Then
                    add(j, 0) = Form1.data(j, 0)
                    add(j, 1) = Form1.data(j, 1)
                    add(j, 2) = Form1.data(j, 2)
                    add(j, 3) = Form1.data(j, 3)
                    add(j, 4) = Form1.data(j, 4)
                Else
                    add(j, 0) = TextBox1.Text
                    add(j, 1) = TextBox2.Text
                    add(j, 2) = TextBox3.Text
                    add(j, 3) = 5
                    add(j, 4) = TextBox4.Text
                End If
            Next
            '修改Form1.data的数据
            ReDim Form1.data(Form1.data.Length / 5, 4)
            Form1.data = add
            '清空输入文本框
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox3.Clear()
            TextBox4.Clear()
            '更新Form1.ComboBox1中的商品数据
            Form1.ComboBox1.Items.Clear()
            For i = 0 To Form1.data.Length / 5 - 1
                If Form1.ComboBox1.Items.Contains(Form1.data(i, 0)) = False Then
                    Form1.ComboBox1.Items.Add(Form1.data(i, 0))
                End If
            Next
            '提示添加成功
            MsgBox("添加成功！")
        Else
            MsgBox("请输入完整的商品信息！")
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '根据商品名称删除商品
        Dim delete(Form1.data.Length / 5 - 2, 4) As String
        If TextBox5.Text.Length > 0 Then
            Dim k As Integer = -1
            '查找需要删除的商品的坐标
            For i = 0 To Form1.data.Length / 5 - 1
                If Form1.data(i, 1) = TextBox5.Text Then
                    k = i
                End If
            Next
            If k = -1 Then '如果需要删除的商品不在商品列表中，则提示不存在
                MsgBox("该商品不存在，请重新输入！")
            Else '将无需删除的商品信息复制到delete中
                For j = 0 To Form1.data.Length / 5 - 2
                    If j < k Then
                        delete(j, 0) = Form1.data(j, 0)
                        delete(j, 1) = Form1.data(j, 1)
                        delete(j, 2) = Form1.data(j, 2)
                        delete(j, 3) = Form1.data(j, 3)
                        delete(j, 4) = Form1.data(j, 4)
                    Else
                        delete(j, 0) = Form1.data(j + 1, 0)
                        delete(j, 1) = Form1.data(j + 1, 1)
                        delete(j, 2) = Form1.data(j + 1, 2)
                        delete(j, 3) = Form1.data(j + 1, 3)
                        delete(j, 4) = Form1.data(j + 1, 4)
                    End If
                Next
                '清空输入文本框
                TextBox5.Clear()
                '修改Form1.data的数据
                ReDim Form1.data(Form1.data.Length / 5 - 2, 4)
                Form1.data = delete
                '更新Form1.ComboBox1中的商品数据
                Form1.ComboBox1.Items.Clear()
                For i = 0 To Form1.data.Length / 5 - 1
                    If Form1.ComboBox1.Items.Contains(Form1.data(i, 0)) = False Then
                        Form1.ComboBox1.Items.Add(Form1.data(i, 0))
                    End If
                Next
                '提示删除成功
                MsgBox("删除成功！")
            End If
        Else
            MsgBox("请输入商品信息名称！")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '根据商品名称修改商品信息
        If TextBox6.Text.Length > 0 And TextBox7.Text.Length > 0 And TextBox8.Text.Length > 0 And TextBox9.Text.Length > 0 And TextBox10.Text.Length > 0 Then
            Dim k As Integer = -1
            For i = 0 To Form1.data.Length / 5 - 1
                If Form1.data(i, 1) = TextBox6.Text Then
                    k = i
                    Form1.data(i, 0) = TextBox7.Text
                    Form1.data(i, 1) = TextBox8.Text
                    Form1.data(i, 2) = TextBox9.Text
                    Form1.data(i, 4) = TextBox10.Text
                    '清空输入文本框
                    TextBox6.Clear()
                    TextBox7.Clear()
                    TextBox8.Clear()
                    TextBox9.Clear()
                    TextBox10.Clear()
                    '更新Form1.ComboBox1中的商品数据
                    Form1.ComboBox1.Items.Clear()
                    For j = 0 To Form1.data.Length / 5 - 1
                        If Form1.ComboBox1.Items.Contains(Form1.data(j, 0)) = False Then
                            Form1.ComboBox1.Items.Add(Form1.data(j, 0))
                        End If
                    Next
                    '提示修改成功
                    MsgBox("修改成功！")
                End If
            Next
            If k = -1 Then '如果需要修改的商品不在商品列表中，则提示错误
                MsgBox("该商品不存在，请重新输入！")
            End If
        Else
            MsgBox("请输入完整的商品信息！")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '根据商品名称查找商品的信息
        If TextBox11.Text.Length > 0 Then
            Dim k As Integer = -1
            For i = 0 To Form1.data.Length / 5 - 1
                If Form1.data(i, 1) = TextBox11.Text Then
                    k = i
                    TextBox12.Text = Form1.data(i, 0)
                    TextBox13.Text = Form1.data(i, 2)
                    TextBox14.Text = CStr(Form1.data(i, 4)) + "%"
                End If
            Next
            If k = -1 Then '如果查找的商品不在商品列表中，则提示不存在
                MsgBox("该商品不存在！")
            End If
        Else
            MsgBox("请输入商品名称！")
        End If
    End Sub
End Class