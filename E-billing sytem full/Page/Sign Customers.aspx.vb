Imports System.Data
Imports System.Data.SqlClient
Public Class Sign_Customers
    Inherits System.Web.UI.Page
    Dim str As String = "Data Source=DESKTOP-9CQVGDK\SQLEXPRESS;Initial Catalog=Electricity_billing_system;Integrated Security=True"
    Dim cn As New SqlConnection(str)
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim sdate As Date

    Public Sub display()
        cmd.CommandText = "select * from sign_table"
        cmd.Connection = cn
        cn.Open()
        dr = cmd.ExecuteReader()
        GridView1.DataSource = dr
        GridView1.DataBind()
        cn.Close()

    End Sub

    Sub loadnames()
        dblname.Items.Clear()
        cmd.CommandText = "select name from customer"
        cmd.Connection = cn
        cn.Open()
        dr = cmd.ExecuteReader()
        dblname.Items.Add(" ")
        While dr.Read
            dblname.Items.Add(dr(0))
        End While
        cn.Close()

    End Sub

    Function getId(par As String, type As String)
        Dim a As Integer
        Dim name As String
        Dim cond As String
        If type = "id" Then
            cond = "name"
        Else
            cond = "id"
        End If
        cmd.CommandText = "select " & type & " from customer where " & cond & " = @name"
        cmd.Parameters.AddWithValue("@name", par)
        cmd.Connection = cn
        cn.Open()
        dr = cmd.ExecuteReader()
        If dr.Read Then
            If type = "id" Then
                a = dr(0)
            Else
                name = dr(0)
            End If
        End If
        cn.Close()
        If type = "name" Then
            Return name
        Else
            Return a
        End If
    End Function



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadnames()
            TxtDate.Text = Format(Now, "yyyy-MM-dd")
        Else
            sdate = TxtDate.Text
        End If
        display()
        TxtDate.Attributes("min") = Format(Now, "yyyy-MM-dd")
        'yyyy-MM-dd
    End Sub


    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim a As Integer = getId(dblname.SelectedValue, "id")
            Dim lastmonth As Date = Session("month")
            cmd.Connection = cn

            cmd.CommandText = "insert into  sign_table values (@sign_id,@sign_Date,@sign_BeforeWatt,@sign_Killowat,@sign_BeforeBalancet,@sign_Balance,@total)"
            cmd.Parameters.AddWithValue("@sign_id", a)
            cmd.Parameters.AddWithValue("@sign_Date", TxtDate.Text)
            cmd.Parameters.AddWithValue("@sign_BeforeWatt", TxtBeforeWatt.Text)
            cmd.Parameters.AddWithValue("@sign_Killowat", TxtKillowat.Text)
            cmd.Parameters.AddWithValue("@sign_BeforeBalancet", TxtBeforeBalance.Text)
            cmd.Parameters.AddWithValue("@sign_Balance", Val(TxtNewBalance.Text))
            cmd.Parameters.AddWithValue("@total", Val(TxtNewBalance.Text))
            cn.Open()
            Dim thismonth As Date = TxtDate.Text
            If lastmonth.Month = thismonth.Month Then
                Response.Write("<script>alert('The customer is already signed for this month')</script>")
            Else
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
                cn.Close()
                display()
                dblname.SelectedIndex = 0
                Response.Write("<script>alert('Data successfully saved')</script>")
            End If
            cn.Close()

            Response.Write("<script>$('.modal - title').text('Save Customer Electricity Bill'); $('.notify').html('<h5>Data Has been Inserted</h5>'); $('#exampleModal').modal('show')</script>")



        Catch ex As Exception

        End Try


    End Sub

    Protected Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Dim a As Integer = getId(dblname.SelectedValue, "id")
        cmd.Connection = cn
        cmd.CommandText = "update sign_table set date=@sign_Date,kilo_wat=@sign_Killowat,total=@total,balance=@total WHERE id=@sign_id and date=@Sdate"
        cmd.Parameters.AddWithValue("@sign_id", a)
        cmd.Parameters.AddWithValue("@sign_Date", TxtDate.Text)
        cmd.Parameters.AddWithValue("@sign_Killowat", TxtKillowat.Text)
        cmd.Parameters.AddWithValue("@total", TxtNewBalance.Text)
        cmd.Parameters.AddWithValue("@Sdate", sdate)
        cn.Open()
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        cn.Close()
        display()
        Response.Write("<script>alert('Data has updated')</Script>")
        display()
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow
        dblname.SelectedValue = getId((row.Cells(1).Text), "name")
        sdate = row.Cells(2).Text
        TxtDate.Text = Format(sdate, "yyyy-MM-dd")
        TxtBeforeWatt.Text = row.Cells(3).Text
        TxtKillowat.Text = row.Cells(4).Text
        TxtBeforeBalance.Text = row.Cells(5).Text
        TxtNewBalance.Text = row.Cells(6).Text


    End Sub


    Sub getPrevbalance(id As Integer)
        cmd.Connection = cn
        cmd.CommandText = "select sum(balance) from sign_table where id=@cid"
        cmd.Parameters.AddWithValue("@cid", id)
        cn.Open()
        dr = cmd.ExecuteReader()
        If dr.Read Then
            TxtBeforeBalance.Text = dr(0)
        Else
            TxtBeforeBalance.Text = 0
        End If

        cn.Close()
    End Sub

    Dim Month As Date

    Protected Sub dblname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dblname.SelectedIndexChanged

        Dim a As Integer
        cmd = New SqlCommand
        a = getId(dblname.SelectedItem.Text, "id")

        cmd.CommandText = "select * from sign_table where id=@id order by Date desc"
        cmd.Parameters.AddWithValue("@id", a)
        cmd.Connection = cn
        cn.Open()
        dr = cmd.ExecuteReader()
        Dim Pkw As Integer = 0
        Dim Bbalance As Integer = 0

        If dr.Read Then
            Pkw = dr(3)
            Session("month") = dr(1)
        End If

        TxtBeforeWatt.Text = Pkw
        cn.Close()
        getPrevbalance(a)
    End Sub


End Class