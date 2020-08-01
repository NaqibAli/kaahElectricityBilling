Imports System.Data
Imports System.Data.SqlClient
Public Class Payment
    Inherits System.Web.UI.Page
    Dim str As String = "Data Source=DESKTOP-9CQVGDK\SQLEXPRESS;Initial Catalog=Electricity_billing_system;Integrated Security=True"
    Dim cn As New SqlConnection(str)
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim ids As New Dictionary(Of String, Integer)
    Dim names As New Dictionary(Of Integer, String)

    Public Sub display()
        cmd.CommandText = "select * from finance"
        cmd.Connection = cn
        cn.Open()
        dr = cmd.ExecuteReader()
        GridView1.DataSource = dr
        GridView1.DataBind()
        cn.Close()

    End Sub
    Sub loadnames()
        If Not IsPostBack Then
            dblname.Items.Clear()
            dblname.Items.Add(" ")
        End If
        cmd.CommandText = "select DISTINCT sign_table.id,name from sign_table inner join customer on customer.ID=sign_table.id where balance > 0"
        cmd.Connection = cn
        cn.Open()
        dr = cmd.ExecuteReader()

        While dr.Read
            If Not IsPostBack Then
                dblname.Items.Add(dr(1))
            End If
            ids.Add(dr(1), dr(0))
            names.Add(dr(0), dr(1))
        End While
        cn.Close()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TxtSignDate.Text = Format(Now, "yyyy-MM-dd")

        End If
        TxtSignDate.Attributes("min") = Format(Now, "yyyy-MM-dd")
        loadnames()
        display()

    End Sub

    Protected Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click

        Try
            cmd.Connection = cn
            cmd.CommandText = "insert into  finance values(@sign_CustomerID,@sign_Balance,@sign_Payments,@sign_Remain,@sign_SignDate); update sign_table set balance=@sign_Remain where id=@sign_CustomerID and date=@date"
            cmd.Parameters.AddWithValue("@sign_CustomerID", ids.Item(dblname.Text))
            cmd.Parameters.AddWithValue("@sign_Balance", TxtIBeforeBalance.Text)
            cmd.Parameters.AddWithValue("@sign_Payments", TxtPayments.Text)
            cmd.Parameters.AddWithValue("@sign_Remain", Val(TxtRemain.Text))
            cmd.Parameters.AddWithValue("@sign_SignDate", TxtSignDate.Text)
            cmd.Parameters.AddWithValue("@date", CDate(Session("lsdate")))

            cn.Open()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            cn.Close()
            display()
            Response.Write("<script>alert('Data has inserted')</Script>")

        Catch ex As Exception
            Response.Write("<script>alert(ex.message)</Script>")
        End Try

    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            cmd.Connection = cn
            cmd.CommandText = "update  finance set Total=@total, Payments=@Payments, Remain=@Remain, Date=@Date WHERE ID=@ID"
            cmd.Parameters.AddWithValue("@ID", ids.Item(dblname.Text))
            cmd.Parameters.AddWithValue("@total", TxtIBeforeBalance.Text)
            cmd.Parameters.AddWithValue("@Payments", TxtPayments.Text)
            cmd.Parameters.AddWithValue("@Remain", TxtRemain.Text)
            cmd.Parameters.AddWithValue("@Date", TxtSignDate.Text)
            cn.Open()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            cn.Close()
            Response.Write("<script>alert('Data has updated')</Script>")
            display()
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow
        dblname.SelectedValue = names.Item(row.Cells(1).Text)
        TxtIBeforeBalance.Text = row.Cells(2).Text
        TxtPayments.Text = row.Cells(3).Text
        TxtRemain.Text = row.Cells(4).Text
        Dim sdate As Date = row.Cells(5).Text
        TxtSignDate.Text = Format(sdate, "yyyy-MM-dd")
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TxtIBeforeBalance.Text = ""
        dblname.SelectedIndex = 0
        TxtPayments.Text = ""
        TxtRemain.Text = ""
        TxtSignDate.Text = ""
    End Sub

    Dim dd As Date
    Protected Sub dblname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dblname.SelectedIndexChanged
        cmd.CommandText = "select balance,date from sign_table where id=@id order by date desc"
        cmd.Parameters.AddWithValue("@id", ids.Item(dblname.SelectedValue))
        cmd.Connection = cn
        cn.Open()
        dr = cmd.ExecuteReader()
        If dr.Read Then
            TxtIBeforeBalance.Text = dr(0)
            dd = dr(1)
            Session("lsdate") = dd
            TxtSignDate.Attributes("min") = Format(dd, "yyyy-MM-dd")
        Else
            TxtIBeforeBalance.Text = 0
        End If

        cn.Close()
    End Sub

End Class