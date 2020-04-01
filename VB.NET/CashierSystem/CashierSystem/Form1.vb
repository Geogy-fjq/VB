Public Class Form1
    Public data(,) As String = {{"服装"， "幸福羊毛衫", 400, 5, 30}, {"服装", "幸福男裤", 350, 5, 30}, {"服装", "米奇T恤", 200, 5, 30}, {"服装", "真维斯衬衫", 180, 5, 30}, {"鞋", "红蜻蜓女鞋", 500, 5, 30}, {"鞋", "星期六女鞋", 600, 5, 30}, {"鞋", "苹果男鞋", 550, 5, 30}, {"鞋", "袋鼠男鞋", 400, 5, 30}, {"鞋", "幸福童鞋", 260, 5, 30}, {"箱包", "鳄鱼皮包", 400, 5, 30}, {"箱包", "POLO女包", 500, 5, 30}, {"箱包", "米奇休闲包", 300, 5, 30}, {"化妆品", "小护士大礼包", 100, 5, 30}, {"化妆品", "欧莱雅保湿霜", 300, 5, 30}, {"化妆品", "兰蔻眼霜", 350, 5, 30}, {"床上用品", "睡得香双人被", 400, 5, 30}, {"床上用品", "幸福4件套", 300, 5, 30}, {"床上用品", "舒服服按摩枕", 200, 5, 30}}
    Dim product As String '商品名称
    Dim price As Integer '价格
    Dim num As Integer '用于打折的件数
    Dim discount As Integer '折扣
    Dim sum As Double = 0 '应付款
    Dim pay As Double = 0 '实付款
    Dim names(0) As String
    Dim c As Integer = 1 '用于标记加入names的商品数量

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '初始化ComboBox1
        ListBox1.Items.Clear()
        For i = 0 To data.Length / 5 - 1
            If ComboBox1.Items.Contains(data(i, 0)) = False Then
                ComboBox1.Items.Add(data(i, 0))
            End If
        Next
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        '选择ComboBox1中的文本，在ListBox1中显示对应种类的全部商品名称
        ListBox1.Items.Clear()
        For i = 0 To data.Length / 5 - 1
            If ComboBox1.Text = data(i, 0) Then
                ListBox1.Items.Add(data(i, 1))
            End If
        Next
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        For i = 0 To data.Length / 5 - 1
            If ListBox1.SelectedItem = data(i, 1) Then
                '初始化
                product = data(i, 1)
                price = CInt(data(i, 2))
                num = CInt(data(i, 3))
                discount = CInt(data(i, 4))
                '若已经购买了该商品或者该商品的前5件已经卖出，则按原价出售
                If num <= 0 Or names.Contains(product) Then
                    discount = 100
                End If
                '将该商品的名称、数量、单价、折扣分别显示到对应的文本框中
                TextBox1.Text = product
                TextBox2.Text = 1
                TextBox3.Text = price
                TextBox4.Text = CStr(discount) + "%"
                '使数据能够按列对齐输出到ListBox2
                Dim temps As String
                Dim a As Integer
                Dim str As String
                a = 20
                For j = 1 To product.Length
                    temps = Mid(product, j, 1)
                    If Asc(temps) < 0 Then
                        a = a - 2
                    ElseIf Asc(temps) > 0 Then
                        a = a - 1
                    End If
                Next
                str = (product & Space(a)) + "1"
                a = 16
                str = (str & Space(a - 1)) + CStr(price)
                For j = 1 To data(i, 2).Length
                    temps = Mid(price, j, 1)
                    If Asc(temps) < 0 Then
                        a = a - 2
                    Else
                        a = a - 1
                    End If
                Next
                str = (str & Space(a)) + CStr(discount) + "%"
                '计算并显示商品应付款、实付款和找零
                sum = sum + price * (discount / 100)
                TextBox5.Text = sum
                ListBox2.Items.Add(str)
                ReDim Preserve names(c)
                names(c) = product
                c = c + 1
            End If
        Next
    End Sub
    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text.Length > 0 Then '实付款输入不为空
            If CDbl(TextBox6.Text) >= CDbl(TextBox5.Text) Then '实付款大于应付款
                TextBox7.Text = CSng(CDbl(TextBox6.Text) - CDbl(TextBox5.Text))
            Else
                TextBox7.Clear()
            End If
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox6.Text.Length > 0 Then '实付款输入不为空
            If CDbl(TextBox6.Text) >= CDbl(TextBox5.Text) Then '实付款大于应付款
                names.Distinct
                For i = 0 To names.Length - 1
                    For j = 0 To data.Length / 5 - 1
                        If names.Contains(data(j, 1)) And CInt(data(j, 3)) > 0 Then '若names包含有该种商品，则将该商品可用于打折出售的件数-1
                            data(j, 3) = CSng(CInt(data(j, 3)) - 1)
                        End If
                    Next
                Next
                '在一次付款后清空表，等待下一次结算
                ListBox2.Items.Clear()
                ListBox2.Items.Add("商品名称            数量            单价            折扣            总额")
                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox6.Clear()
                TextBox7.Clear()
                sum = 0 '应付款重新设为0
                ReDim names(0) '清空names
            Else
                MsgBox("实付款金额大于应付款金额！")
            End If
        Else
            MsgBox("请输入实付款金额！")
        End If
    End Sub
    Private Sub 菜单ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 菜单ToolStripMenuItem.Click
        Form2.Show()
    End Sub
End Class
