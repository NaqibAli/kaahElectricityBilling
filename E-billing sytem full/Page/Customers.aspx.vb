Imports System.Data
Imports System.Data.SqlClient
Public Class Customers
    Inherits System.Web.UI.Page
    Dim str As String = "Data Source=DESKTOP-9CQVGDK\SQLEXPRESS;Initial Catalog=Electricity_billing_system;Integrated Security=True"
    Dim cn As New SqlConnection(str)
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim totalid As New Dictionary(Of String, Integer)
    Dim names As New Dictionary(Of Integer, String)

    Public Sub display()
        cmd.CommandText = "SELECT ID as 'Customer ID',name as 'Customer Name',Phone,block_name as 'Block Name',customer.Date,Email FROM customer INNER JOIN blocks ON blocks.block_id= customer.Block_Id"
        cmd.Connection = cn
        cn.Open()
        dr = cmd.ExecuteReader()
        customerTbl.DataSource = dr
        customerTbl.DataBind()
        cn.Close()
    End Sub

    Sub loadnames()
        If Not IsPostBack Then
            dblname.Items.Clear()
        End If

        cmd.CommandText = "select block_name,block_id from blocks"
        cmd.Connection = cn
        cn.Open()
        dr = cmd.ExecuteReader()
        While dr.Read
            If Not IsPostBack Then
                dblname.Items.Add(dr(0))
            End If
            Totalid.Add(dr(0), dr(1))
            names.Add(dr(1), dr(0))
        End While
        cn.Close()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        display()
        loadnames()
        If Not IsPostBack Then
            generateID()
        End If
        TxtDate.Text = Format(Now, "yyyy-MM-dd")
    End Sub


    Protected Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Try
            cmd.Connection = cn
            cmd.CommandText = "insert into customer values (@cus_id,@cus_BlockName,@cus_CustomerName,@cus_Date,@cus_email,@cus_phone)"
            cmd.Parameters.AddWithValue("@cus_id", TxtCustomerId.Text)
            cmd.Parameters.AddWithValue("@cus_BlockName", totalid.Item(dblname.SelectedValue))
            cmd.Parameters.AddWithValue("@cus_CustomerName", TxtCustomerName.Text)
            cmd.Parameters.AddWithValue("@cus_Date", TxtDate.Text)
            cmd.Parameters.AddWithValue("@cus_email", TxtEmail.Text)
            cmd.Parameters.AddWithValue("@cus_phone", txtphone.Text)
            cn.Open()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            cn.Close()
            display()
            Response.Write("<script>alert('" & TxtCustomerName.Text & " has inserted')</Script>")
            clear()
        Catch ex As Exception

        End Try

    End Sub


    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            cmd.Connection = cn
            cmd.CommandText = "update  customer set block_id=@cus_BlockName,Name=@cus_CustomerName,Date=@cus_Date,Email=@cus_email,phone=@cus_phone WHERE id=@cus_id "
            cmd.Parameters.AddWithValue("@cus_id", TxtCustomerId.Text)
            cmd.Parameters.AddWithValue("@cus_BlockName", totalid.Item(dblname.SelectedValue))
            cmd.Parameters.AddWithValue("@cus_CustomerName", TxtCustomerName.Text)
            cmd.Parameters.AddWithValue("@cus_Date", TxtDate.Text)
            cmd.Parameters.AddWithValue("@cus_email", TxtEmail.Text)
            cmd.Parameters.AddWithValue("@cus_phone", txtphone.Text)
            cn.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            Dim name As String = TxtCustomerName.Text
            If result > 0 Then
                cmd.Parameters.Clear()
                cn.Close()
                clear()
                display()
                Response.Write("<script>alert('" & name & " has updated')</Script>")
            Else
                cn.Close()
                clear()
                Response.Write("<script>alert('No customer Updated')</Script>")

            End If


        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles customerTbl.SelectedIndexChanged


        Dim row As GridViewRow = customerTbl.SelectedRow
        TxtCustomerId.Text = Val(row.Cells(1).Text)
        dblname.SelectedValue = row.Cells(4).Text
        txtphone.Text = row.Cells(3).Text
        TxtCustomerName.Text = row.Cells(2).Text
        Dim sdate As Date = row.Cells(5).Text
        TxtDate.Text = Format(sdate, "yyyy-MM-dd")
        TxtEmail.Text = row.Cells(6).Text


    End Sub


    Protected Sub TextSearch_TextChanged(sender As Object, e As EventArgs) Handles TextSearch.TextChanged

        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "select * from customer where name like '" & TextSearch.Text & "%'"
        da.SelectCommand.Connection = cn

        da.Fill(ds, "customer")
        customerTbl.DataSource = ds.Tables("customer")
        customerTbl.DataBind()

    End Sub



    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clear()
    End Sub
    Sub clear()
        generateID()
        dblname.SelectedIndex = 0
        TxtCustomerName.Text = ""
        TxtDate.Text = Format(Now, "yyyy-MM-dd")
        TxtEmail.Text = ""
        txtphone.Text = ""
    End Sub
    Sub generateID()
        cmd.Connection = cn
        cmd.CommandText = "select case when max(id) is null then 1 else max(id)+1 end from customer"
        cn.Open()

        If cmd.ExecuteScalar Then
            TxtCustomerId.Text = cmd.ExecuteScalar
        End If
        cn.Close()
    End Sub

    Protected Sub DropDownListBlockName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dblname.SelectedIndexChanged

    End Sub
End Class