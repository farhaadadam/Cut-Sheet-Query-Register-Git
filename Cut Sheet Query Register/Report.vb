Public Class Report

    Private Sub BackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackToolStripMenuItem.Click
        Form_QueryReg.Show()
        Me.Close()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub ReceiveCutSheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReceiveCutSheetToolStripMenuItem.Click
        Receive_Cut_Sheet.Show()
        Me.Close()
    End Sub

    Private Sub Button_Search_Click(sender As Object, e As EventArgs) Handles Button_Search.Click


        DataGridView1.DataSource = ReadTable()
        DataGridView1.Columns("Remarks").DefaultCellStyle.WrapMode = DataGridViewTriState.True

    End Sub

    Private Sub Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = ReadTable()
        DataGridView1.Columns("Remarks").DefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub
End Class