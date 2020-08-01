<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Main.Master" CodeBehind="Blocks.aspx.vb" Inherits="E_billing_sytem_full.Blocks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container ">
        <div class="card mt-5">
            <div class="card-header bg-success text-light">
              
                <h4>&nbsp; Registration Blocks </h4>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-6">
                            Block ID
                                <asp:TextBox ID="TxtBlockID" runat="server" ReadOnly="true" placeholder="Block ID" CssClass="form-control form-control-sm" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtBlockID" ErrorMessage="Please Enter Id" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            Block Name
                             
                             <asp:TextBox ID="TextBlockName" runat="server" placeholder="Block Name" CssClass="form-control form-control-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBlockName" ErrorMessage="Please Enter Name" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-md-6">
                            Date
                               <asp:TextBox ID="TxtDate" runat="server" placeholder="E-mail" CssClass="form-control form-control-sm" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtDate" ErrorMessage="Please Enter Date" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                    </div>
                    <div class="row ml-auto w-75">
                        <div class="col-md-2 mt-4">
                            <asp:Button ID="btn1" runat="server" CssClass="w-100 btn btn-success form-control" Text="Save"></asp:Button>
                        </div>
                        <div class="col-md-2 mt-4">
                            <asp:Button ID="Button1" runat="server" CssClass="btn btn-info form-control" Text="Update"></asp:Button>
                        </div>
                        <div class="col-md-2 mt-4">
                            <asp:Button ID="Button2" runat="server" CssClass="btn btn-danger form-control" Text="Clear"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container ">
        <div class="card">
            <div class="card-header bg-dark text-light">
                <div class="row w-100">
                    <div class="col-8">
                        <h4>Block </h4>
                    </div>
                    <div class="col-4 ">
                        <div class="input-group">
                            <asp:TextBox ID="textsearch" runat="server" placeholder="Search" CssClass="form-control form-control-sm"></asp:TextBox>
                            <span class="input-group-append">
                                <button class="btn btn-warning"><i class="ik ik-search"></i></button>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card-body">

                <asp:GridView ID="GridView1" CssClass="table table-hover table-bordered" runat="server">
                    <Columns>
                        <asp:CommandField HeaderText="Actions" SelectText="&lt;i class=&quot;ik ik-edit&quot;&gt;&lt;/i&gt; Edit" ShowHeader="True" ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="thead-light" />
                </asp:GridView>
            </div>


        </div>
    </div>
</asp:Content>
