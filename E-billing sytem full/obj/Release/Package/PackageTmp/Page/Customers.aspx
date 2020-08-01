<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Main.Master" CodeBehind="Customers.aspx.vb" Inherits="E_billing_sytem_full.Customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container ">
        <div class="card mt-5 shadow">
            <div class="card-header bg-dark text-light">

                <h4>&nbsp; Registration Customers  </h4>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-6">
                            Customer ID
                                <asp:TextBox ID="TxtCustomerId" ReadOnly="true" runat="server" placeholder="Customer ID" CssClass="form-control form-control-sm" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtCustomerId" ErrorMessage="Please Customer ID" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            Block Name
                                <asp:DropDownList ID="dblname" runat="server" CssClass="form-control form-control-sm">
                                    <asp:ListItem Value="1">Hodan</asp:ListItem>
                                </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dblname" ErrorMessage="Please Enter Block Name" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            Customer Name
                                <asp:TextBox ID="TxtCustomerName" runat="server" placeholder=" Customer Name" CssClass="form-control form-control-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtCustomerName" ErrorMessage="Please Enter Customer Name" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            Date
                               <asp:TextBox ID="TxtDate" runat="server" placeholder="E-mail" CssClass="form-control form-control-sm" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtDate" ErrorMessage="Please Enter  Date" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            Phone
                                <asp:TextBox ID="txtphone" runat="server" placeholder="Phone" type="text" CssClass="form-control form-control-sm" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtphone" ErrorMessage="Please Enter Phone Number" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            E-mail
                                <asp:TextBox ID="TxtEmail" runat="server" placeholder="E-mail" type="email" CssClass="form-control form-control-sm" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Please Enter E-mail" ForeColor="Red"></asp:RequiredFieldValidator>
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
                        <h4>Customer </h4>
                    </div>
                    <div class="col-4 ">
                        <div class="input-group">
                            <asp:TextBox ID="TextSearch" runat="server" placeholder="Search" CssClass="form-control form-control-sm"></asp:TextBox>
                            <span class="input-group-append">
                                <button class="btn btn-warning"><i class="ik ik-search"></i></button>
                            </span>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card-body">

                <asp:GridView ID="customerTbl" CssClass="table table-hover table-bordered table-responsive-sm" runat="server" AutoGenerateSelectButton="True">
                    <HeaderStyle CssClass="thead-light" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
