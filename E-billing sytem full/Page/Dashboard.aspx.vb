Imports System.Data.SqlClient

Public Class Dashboard
    Inherits System.Web.UI.Page
    Dim str As String = "Data Source=DESKTOP-9CQVGDK\SQLEXPRESS;Initial Catalog=Electricity_billing_system;Integrated Security=True"
    Dim cn As New SqlConnection(str)
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        summery("id", "customer", TotalCustomer)
        summery("emp_id", "employee", TtotalEmployee)
        summery("block_id", "blocks", totalblocks)
        monthly()

    End Sub

    Sub summery(cname As String, tname As String, ctrol As Label)
        Dim cmd As New SqlCommand()
        cmd.Connection = cn
        cmd.CommandText = "select count(" & cname & ") from " & tname & ""
        cn.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        If dr.Read Then
            ctrol.Text = dr(0)
        End If
        cn.Close()
    End Sub
    Sub monthly()
        Dim cmd As New SqlCommand()
        cmd.Connection = cn
        cmd.CommandText = "select sum(Payments) from finance where Date between @date AND GETDATE()"
        cmd.Parameters.AddWithValue("@date", (Now.Month & "/1/" & Now.Year))
        cn.Open()
        Dim dr As SqlDataReader = cmd.ExecuteReader
        If dr.Read Then
            MonthlyIncome.Text = dr(0).ToString
        End If
        cn.Close()
    End Sub




End Class