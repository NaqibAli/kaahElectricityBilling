Imports System.Data
Imports System.Data.SqlClient
Public Class Employee
    Inherits System.Web.UI.Page
    Dim str As String = "Data Source=DESKTOP-9CQVGDK\SQLEXPRESS;Initial Catalog=Electricity_billing_system;Integrated Security=True"
    Dim cn As New SqlConnection(str)
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim Totalid As New Dictionary(Of String, Integer)
    Dim names As New Dictionary(Of Integer, String)

    Public Sub display()
        cmd.CommandText = "exec Sp_Employee"
        cmd.Connection = cn
        cn.Open()
        dr = cmd.ExecuteReader()
        GridView1.DataSource = dr
        GridView1.DataBind()
        cn.Close()

    End Sub

    Sub generateID()
        cmd.Connection = cn
        cmd.CommandText = "select case when max(emp_id) is null then 1 else max(emp_id)+1 end from employee"
        cn.Open()

        If cmd.ExecuteScalar Then
            TxtId.Text = cmd.ExecuteScalar
        End If
        cn.Close()
    End Sub

    Sub clear()
        generateID()
        TxtName.Text = ""
        TxtPhone.Text = ""
        TxtAge.Text = ""
        TxtEmail.Text = ""
        TextDate.Text = Format(Now, "yyyy-MM-dd")

        dblname.SelectedIndex = 0

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        display()
        loadnames()

        If Not IsPostBack Then

            generateID()
        End If

        TextDate.Text = Format(Now, "yyyy-MM-dd")

    End Sub


    Protected Sub btn1_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            cmd.Connection = cn
            cmd.CommandText = "insert into  employee values (@emp_id,@emp_name,@empp_phone,@emp_age,@emp_email,@emp_date,@block_id)"

            cmd.Parameters.AddWithValue("@emp_id", TxtId.Text)
        cmd.Parameters.AddWithValue("@emp_name", TxtName.Text)
        cmd.Parameters.AddWithValue("@empp_phone", TxtPhone.Text)
        cmd.Parameters.AddWithValue("@emp_age", TxtAge.Text)
        cmd.Parameters.AddWithValue("@emp_email", TxtEmail.Text)
        cmd.Parameters.AddWithValue("@emp_date", TextDate.Text)
        cmd.Parameters.AddWithValue("@block_id", Totalid.Item(dblname.SelectedValue))

        cn.Open()
        cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        cn.Close()
        display()
        clear()
        Response.Write("<script>alert('Data has inserted')</Script>")

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub TxtName_TextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            cmd.Connection = cn
            cmd.CommandText = "update  employee set emp_name=@emp_name,empp_phone=@empp_phone,emp_age=@emp_age,emp_email=@emp_email,emp_date=@emp_date,block_id=@block_id WHERE emp_id=@emp_id "
            cmd.Parameters.AddWithValue("@emp_id", TxtId.Text)
            cmd.Parameters.AddWithValue("@emp_name", TxtName.Text)
            cmd.Parameters.AddWithValue("@empp_phone", TxtPhone.Text)
            cmd.Parameters.AddWithValue("@emp_age", TxtAge.Text)
            cmd.Parameters.AddWithValue("@emp_email", TxtEmail.Text)
            cmd.Parameters.AddWithValue("@emp_date", TextDate.Text)
            cmd.Parameters.AddWithValue("@block_id", Totalid.Item(dblname.SelectedValue))

            cn.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            Dim name As String = TxtName.Text
            If result > 0 Then
                cmd.Parameters.Clear()
                cn.Close()
                clear()
                display()
                Response.Write("<script>alert('" & name & " has updated')</Script>")
            Else
                cn.Close()
                clear()
                Response.Write("<script>alert('No Employee Updated')</Script>")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged

        Dim row As GridViewRow = GridView1.SelectedRow
        TxtId.Text = row.Cells(1).Text
        TxtName.Text = row.Cells(2).Text
        TxtPhone.Text = row.Cells(3).Text
        TxtAge.Text = row.Cells(4).Text
        TxtEmail.Text = row.Cells(5).Text
        Dim Tdate As Date = row.Cells(6).Text
        TextDate.Text = Format(Tdate, "yyyy-MM-dd")
        dblname.SelectedValue = row.Cells(7).Text

    End Sub

    Protected Sub TextSearch_TextChanged(sender As Object, e As EventArgs) Handles TextSearch.TextChanged
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "exec Sp_searchEmp '" & TextSearch.Text & "%'"
        da.SelectCommand.Connection = cn
        da.Fill(ds, "employee")
        GridView1.DataSource = ds.Tables("employee")
        GridView1.DataBind()

    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        clear()
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
    Protected Sub TxtPhone_TextChanged(sender As Object, e As EventArgs) Handles TxtPhone.TextChanged

    End Sub

    Protected Sub dblname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dblname.SelectedIndexChanged
        Response.Write("done")
    End Sub
End Class