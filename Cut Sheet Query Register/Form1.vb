Imports System.Data.SQLite
Public Class Form_QueryReg

    Private Sub Form_QueryReg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateTable()
    End Sub

    Private Sub Button_Add_Click(sender As Object, e As EventArgs) Handles Button_Add.Click
        InsertData()
    End Sub
End Class
