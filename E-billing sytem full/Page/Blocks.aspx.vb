Imports System.Data
Imports System.Data.SqlClient
Public Class Blocks
    Inherits System.Web.UI.Page
    Dim str As String = "Data Source=DESKTOP-9CQVGDK\SQLEXPRESS;Initial Catalog=Electricity_billing_system;Integrated Security=True"
    Dim cn As New SqlConnection(str)
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet

    Sub generateID()
        cmd.Connection = cn
        cmd.CommandText = "select case when max(block_id) is null then 1 else max(block_id)+1 end from blocks"
        cn.Open()
        If cmd.ExecuteScalar Then
            TxtBlockID.Text = cmd.ExecuteScalar
        End If
        cn.Close()
    End Sub

    Public Sub display()
        cmd.CommandText = "select block_id as 'Block Id', block_name as 'Block Name', block_date as 'Register Date' from blocks"
        cmd.Connection = cn
        cn.Open()
        dr = cmd.ExecuteReader()
        GridView1.DataSource = dr
        GridView1.DataBind()
        cn.Close()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        display()
        TxtDate.Text = Format(Now, "yyyy-MM-dd")

        If Not IsPostBack Then
            generateID()
        End If
    End Sub


    Protected Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Try
            cmd.Connection = cn
            cmd.CommandText = "insert into  blocks values (@block_id,@block_name,@block_phone)"
            cmd.Parameters.AddWithValue("@block_id", TxtBlockID.Text)
            cmd.Parameters.AddWithValue("@block_name", TextBlockName.Text)
            cmd.Parameters.AddWithValue("@block_phone", TxtDate.Text)

            cn.Open()
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            cn.Close()
            display()
            Response.Write("<script>alert('" & TextBlockName.Text & " has inserted')</Script>")
            clear()
        Catch ex As Exception

        End Try
        


    End Sub

    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        Dim row As GridViewRow = GridView1.SelectedRow
        TxtBlockID.Text = row.Cells(1).Text
        TextBlockName.Text = row.Cells(2).Text
        Dim Tdate As Date = row.Cells(3).Text
        TxtDate.Text = Format(Tdate, "yyyy-MM-dd")



    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            cmd.Connection = cn
            cmd.CommandText = "update  blocks set block_name=@block_name,block_date=@block_date WHERE block_id=@block_id "
            cmd.Parameters.AddWithValue("@block_id", TxtBlockID.Text)
            cmd.Parameters.AddWithValue("@block_name", TextBlockName.Text)
            cmd.Parameters.AddWithValue("@block_date", TxtDate.Text)

            cn.Open()
            Dim result As Integer = cmd.ExecuteNonQuery()
            Dim name As String = TextBlockName.Text
            If result > 0 Then
                cmd.Parameters.Clear()
                cn.Close()
                clear()
                display()
                Response.Write("<script>alert('" & name & " has updated')</Script>")
            Else
                cn.Close()
                clear()
                Response.Write("<script>alert('No Block Updated')</Script>")

            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub TextSearch_TextChanged(sender As Object, e As EventArgs) Handles TextSearch.TextChanged
        da.SelectCommand = New SqlCommand
        da.SelectCommand.Connection = cn
        da.SelectCommand.CommandText = "select *from blocks where block_name like '" & TextSearch.Text & "%'"
        da.SelectCommand.Connection = cn
        da.Fill(ds, "blocks")
        GridView1.DataSource = ds.Tables("blocks")
        GridView1.DataBind()
    End Sub

   
    Protected Sub TxtDate_TextChanged(sender As Object, e As EventArgs) Handles TxtDate.TextChanged

    End Sub

    Sub clear()
        generateID()
        TextBlockName.Text = ""
        TxtDate.Text = Format(Now, "yyyy-MM-dd")
    End Sub
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class