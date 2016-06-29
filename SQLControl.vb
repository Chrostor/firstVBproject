Imports System.Data.Sql
Imports System.Data.SqlClient


Public Class SQLControl
    Public SQLCon As New SqlConnection With {.ConnectionString = "Server=(localdb)\MSSQLLocalDB;Database=EmployeeDatabase;"}
    Public SQLCmd As SqlCommand
    Public SQLDA As SqlDataAdapter
    Public SQLDataset As DataSet

    Public Function HasConnection() As Boolean
        Try
            SQLCon.Open()

            SQLCon.Close()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Sub RunQuery(Query As String)
        Try
            SQLCon.Open()
            SQLCmd = New SqlCommand(Query, SQLCon)

            'LOAD SQL RECORDS FOR DATAGRID
            SQLDA = New SqlDataAdapter(SQLCmd)
            SQLDataset = New DataSet
            SQLDA.Fill(SQLDataset)

            ' READ DIRECTLY FROM THE DATABASE
            'Dim R As SqlDataReader = SQLCmd.ExecuteReader
            'While R.Read
            'MsgBox(R.GetName(0) & ": " & R(0))
            'End While

            SQLCon.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If SQLCon.State = ConnectionState.Open Then SQLCon.Close()
        End Try
    End Sub

End Class
