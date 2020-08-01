
Imports System.Data
Imports System.Data.SqlClient
Public Class Create_Accoun
    Inherits System.Web.UI.Page
    Dim str As String = "Data Source=DESKTOP-9CQVGDK\SQLEXPRESS;Initial Catalog=Electricity_biiling_system;Integrated Security=True"
    Dim cn As New SqlConnection(str)
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            cmd.Connection = cn
            cmd.CommandText = "insert into  login values(@UserName,@pasword,@Status,@type)"
            cmd.Parameters.AddWithValue("@UserName", TxtUserName.Text)
            cmd.Parameters.AddWithValue("@pasword", Textpass.Text)
            cmd.Parameters.AddWithValue("@Status", TextStatus.Text)
            cmd.Parameters.AddWithValue("@type", Txttype.Text)
            cn.Open()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            cn.Close()
            Response.Write("<script>alert('Data has inserted')</Script>")
        Catch ex As Exception

        End Try
    End Sub
End Class