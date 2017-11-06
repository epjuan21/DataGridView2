Imports System.Data.SqlClient
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Creacion de la Cadena de Conexion
        Dim builder As New SqlConnectionStringBuilder
        builder("Data Source") = "SERVIDOR01\SQLEXPRESS"
        builder("Integrated Security") = True
        builder("Initial Catalog") = "AdventureWorks2012"

        Using connection As New SqlConnection(builder.ConnectionString)

            'Dim adapter As SqlDataAdapter = New SqlDataAdapter("Select BusinessEntityID, NationalIDNumber, LoginID,OrganizationLevel From HumanResources.Employee", connection)
            ' adapter.SelectCommand.CommandType = CommandType.Text


            ' Otra Alternativa Seria Crear Un SQl Command
            Dim cmd As SqlCommand = New SqlCommand("Select BusinessEntityID, NationalIDNumber, LoginID,OrganizationLevel From HumanResources.Employee", connection)
            cmd.CommandType = CommandType.Text
            'Luego SQL Data Adapter Con Otra Sobrecarga
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)

            ' Esta tabla se almacena en la Memoria Cache
            Dim tabla As DataTable = New DataTable

            ' El DataAdapter al Momento de Hace e Fill abre la conexion y la cierra
            adapter.Fill(tabla)

            DataGridView1.DataSource = tabla

        End Using



    End Sub
End Class
