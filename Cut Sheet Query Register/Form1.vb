Imports System.Data.SQLite
Public Class Form_QueryReg

    Private Sub Form_QueryReg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateTable()
    End Sub

    Private Sub Button_Add_Click(sender As Object, e As EventArgs) Handles Button_Add.Click
        If TextBox_Name.Text = "" Or TextBox_CsNum.Text = "" Then
            MsgBox("Please complete required info....")
        Else
            InsertData(TextBox_Name.Text, TextBox_CsNum.Text, TextBox_Comments.Text)
            TextBox_Name.Text = Nothing
            TextBox_CsNum.Text = Nothing
            TextBox_Comments.Text = Nothing
        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox_Name.TextChanged

    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchToolStripMenuItem.Click
        Report.Show()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub ReceiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceiveToolStripMenuItem.Click
        Receive_Cut_Sheet.Show()
        Me.Close()
    End Sub
End Class
