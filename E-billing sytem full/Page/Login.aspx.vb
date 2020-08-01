Imports System.Data
Imports System.Data.SqlClient
Public Class Login
    Inherits System.Web.UI.Page

    Dim str As String = "Data Source=DESKTOP-9CQVGDK\SQLEXPRESS;Initial Catalog=Electricity_billing_system;Integrated Security=True"
    Dim cn As New SqlConnection(str)

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        cn.Open()
        Dim cmd As New SqlCommand()
        cmd.CommandText = "select * from login where pasword=@pass and username=@user"
        cmd.Connection = cn
        cmd.Parameters.AddWithValue("@pass", txtPassword.Text)
        cmd.Parameters.AddWithValue("@user", txtUerName.Text)

        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader

        If dr.Read Then
            Response.Redirect("Dashboard.aspx")
        Else
            lblmessage.Text = "incorrect Credentials"
        End If

        cn.Close()
    End Sub
End Class