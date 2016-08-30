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
                SQLcmd.CommandText = "CREATE TABLE Register(id INTEGER PRIMARY KEY,Name NVARCHAR(50),CsNum NVARCHAR(50),Remarks NVARCHAR(200),Status NVARCHAR(1),SysCreateDate smalldatetime);"
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
    Public Sub InsertData(name As String, CsNum As String, Comments As String)
        Dim connection As String = "Data Source=vault.db;Version=3"
        Dim SQLConn As New SQLiteConnection
        Dim SQLcmd As New SQLiteCommand
        SQLConn.ConnectionString = connection
        Dim cmd As New SQLiteCommand("INSERT INTO Register VALUES (NULL,@Name,@CsNum,@Remarks,@Status,@SysCreateDate)", SQLConn)

        SQLConn.Open()
        'cmd.Parameters.AddWithValue("@id", "NULL")
        cmd.Parameters.AddWithValue("@Name", name)
        cmd.Parameters.AddWithValue("@CsNum", CsNum)
        If Comments = "" Then
            Comments = "No remarks..."
        End If
        cmd.Parameters.AddWithValue("@Remarks", Comments)
        cmd.Parameters.AddWithValue("@Status", "O")
        cmd.Parameters.AddWithValue("@SysCreateDate", Date.Now)
        cmd.ExecuteNonQuery()
        SQLConn.Close()
    End Sub
    'Update Table
    Public Sub UpdateData(id As String)
        Dim connection As String = "Data Source=vault.db;Version=3"
        Dim SQLConn As New SQLiteConnection
        Dim SQLcmd As New SQLiteCommand
        SQLConn.ConnectionString = connection
        SQLConn.Open()
        Dim cmd As New SQLiteCommand("Update Register SET Status = 'C' where CsNum = " & id & "", SQLConn)


        '  cmd.Parameters.AddWithValue("@id", id)
        cmd.ExecuteNonQuery()
        SQLConn.Close()
    End Sub

    'Read data from db
    Public Function ReadTable() As DataTable
        Dim connection As String = "Data Source=vault.db;Version=3"
        Dim SQLConn As New SQLiteConnection
        Dim SQLcmd As New SQLiteCommand
        Dim DT As New DataTable
        Dim oAdapter As New SQLiteDataAdapter(SQLcmd)
        SQLConn.ConnectionString = connection
        SQLConn.Open()

        SQLcmd.Connection = SQLConn
        SQLcmd.CommandText = "Select * from Register where Status = 'O'"
        oAdapter.Fill(DT)
        '   DataGridView1.DataSource = DT
        SQLConn.Close()
        Return DT
    End Function

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
