Public Class Form1
    Dim SQL As New SQLControl

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If SQL.HasConnection = True Then
            ' MsgBox("Sucessfully Connected")
            ' SQL.RunQuery("select first from employees")
        End If
    End Sub

    Private Sub cmdQuery_Click(sender As Object, e As EventArgs) Handles cmdQuery.Click
        If txtQuery.Text <> "" Then


            If SQL.HasConnection = True Then
                SQL.RunQuery(txtQuery.Text)

                If SQL.SQLDataset.Tables.Count > 0 Then
                    DGVData.DataSource = SQL.SQLDataset.Tables(0)
                End If
            End If
        End If
    End Sub
End Class
