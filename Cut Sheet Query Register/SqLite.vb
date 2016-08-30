Imports System.Data.SQLite
Module SqLite
    'Create Database
    Public Function CreateDB() As String
        Dim result As String
        Using cn As New SQLiteConnection("Data Source=vault.db;"), cmd As New SQLiteCommand(cn)
            cn.Open()
            cn.Close()
            result = "DB created..."
        End Using
        Return result
    End Function



    'Create table
    Public Function CreateTable() As String
        Dim result As String
        Dim connection As String = "Data Source=vault.db;Version=3"
        Dim SQLConn As New SQLiteConnection
        Dim SQLcmd As New SQLiteCommand
        Dim DT As New DataTable
        Dim oAdapter As New SQLiteDataAdapter(SQLcmd)
        SQLConn.ConnectionString = connection
        Try
            SQLConn.Open() 'Opens SQL Connections
            SQLcmd.Connection = SQLConn
            SQLcmd.CommandText = "SELECT * FROM sqlite_master WHERE name ='MyTable' and type='table'"
            oAdapter.Fill(DT)
            SQLConn.Close()
            If DT.Rows.Count = 0 Then
                SQLConn.Open()
                SQLcmd.CommandText = "CREATE TABLE Register(Name NVARCHAR(50),CsNum NVARCHAR(50),Remarks NVARCHAR(200),SysCreateDate smalldatetime);"
                SQLcmd.ExecuteNonQuery()
                SQLConn.Close()

                'SQLConn.Open()
                'SQLcmd.CommandText = "CREATE TABLE FCR(Component_Code NVARCHAR(50),Component_Description NVARCHAR(200),Rating float,Qty INT, Demand float,SOH float,Commited float,OnOrder float,To_Buy float);"
                'SQLcmd.ExecuteNonQuery()
                'result = "Table created..."
                'SQLConn.Close()
            Else
                ' result = "Table error. Please contact the administrator..."
            End If

            SQLConn.Close()
        Catch ex As Exception
            result = ex.ToString
        End Try

        Return result
    End Function

    'Insert data into table
    Public Sub InsertData()
        Dim connection As String = "Data Source=vault.db;Version=3"
        Dim SQLConn As New SQLiteConnection
        Dim SQLcmd As New SQLiteCommand
        SQLConn.ConnectionString = connection
        Dim cmd As New SQLiteCommand("INSERT INTO Register VALUES (@Name,@CsNum,@Remarks,@SysCreateDate)", SQLConn)

        SQLConn.Open()
        cmd.Parameters.AddWithValue("@Name", "Test")
        cmd.Parameters.AddWithValue("@CsNum", "Test")
        cmd.Parameters.AddWithValue("@SysCreateDate", Date.Now)
        cmd.ExecuteNonQuery()
        SQLConn.Close()
    End Sub

    'Read data from db
    Private Sub ReadTable()
        Dim connection As String = "Data Source=vault.db;Version=3"
        Dim SQLConn As New SQLiteConnection
        Dim SQLcmd As New SQLiteCommand
        Dim DT As New DataTable
        Dim oAdapter As New SQLiteDataAdapter(SQLcmd)
        SQLConn.ConnectionString = connection
        SQLConn.Open()

        SQLcmd.Connection = SQLConn
        SQLcmd.CommandText = "Select * from MyTable"
        oAdapter.Fill(DT)
        '   DataGridView1.DataSource = DT
        SQLConn.Close()
    End Sub

    'Clear table
    Private Sub ClearData()
        Dim connection As String = "Data Source=vault.db;Version=3"
        Dim SQLConn As New SQLiteConnection
        Dim SQLcmd As New SQLiteCommand
        SQLConn.ConnectionString = connection
        SQLConn.Open()
        SQLcmd.Connection = SQLConn
        SQLcmd.CommandText = "Delete from MyTable"
        SQLcmd.ExecuteNonQuery()
        SQLConn.Close()
    End Sub

    'Read DT into db table
    Private Sub CopyDT_SqliteDB(DT As DataTable)
        Dim department, reasoncode As String
        For Each row As DataRow In DT.Rows
            department = row("Department").ToString
            reasoncode = row("ReasonCode").ToString

        Next
        MsgBox("Updated successfully...")
    End Sub

End Module
