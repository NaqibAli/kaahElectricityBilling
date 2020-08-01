<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Main.Master" CodeBehind="Employees.aspx.vb" Inherits="E_billing_sytem_full.Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container ">
        <div class="card">
            <div class="card-header bg-success text-light">
                <h4>&nbsp; Registration Employees </h4>
            </div>
            <div class="card-body">
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-6">
                            Employee ID
                                <asp:TextBox ID="TxtId" runat="server" placeholder="Employee ID" CssClass="form-control form-control-sm" ReadOnly="true" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtId" ErrorMessage="please Enter Id" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            Employee Name
                                <asp:TextBox ID="TxtName" type="text" runat="server" placeholder="Employee Name" CssClass="form-control form-control-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtName" ErrorMessage="Please Enter  Employee Name" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            Phone
                                <asp:TextBox ID="TxtPhone" runat="server" placeholder=" Phone" CssClass="form-control form-control-sm" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtPhone" ErrorMessage="Please Enter Phone" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            Age
                                <asp:TextBox ID="TxtAge" runat="server" placeholder="Age" CssClass="form-control form-control-sm" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtAge" ErrorMessage="Please Enter Age" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            E-mail
                                <asp:TextBox ID="TxtEmail" runat="server" placeholder="E-mail" type="email" CssClass="form-control form-control-sm" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Please Enter E-mail" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        
                        <div class="col-md-6">
                            Block Name
                                <asp:DropDownList  ID="dblname" runat="server" placeholder="-- Select Block Name --" CssClass="form-control form-control-sm">
                                   </asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                            Date
                               <asp:TextBox ID="TextDate" runat="server" placeholder="E-mail" CssClass="form-control form-control-sm" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row ml-auto w-75">
                        <div class="col-md-2 mt-4">
                            <asp:Button ID="btnSave" runat="server" CssClass="w-100 btn btn-success form-control" Text="Save"></asp:Button>
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

    <%--.......data gride view......--%>

    <div class="container ">
        <div class="card"> 
            <div class="card-header bg-dark  text-light">
                    <div class="row w-100">
                    <div class="col-8">
                        <h4>Employee </h4>
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
                 <asp:GridView ID="GridView1" CssClass="table table-hover table-bordered" runat="server" GridLines="None">
                     <Columns>
                         <asp:CommandField HeaderText="Actions" SelectText="&lt;i class=&quot;ik ik-edit&quot;&gt;&lt;/i&gt; Edit" ShowSelectButton="True" />
                     </Columns>
                    <HeaderStyle CssClass="thead-light" />
                </asp:GridView>
            </div>
        </div>
    </div>
    <%--<script src="../src/js/vendor/modernizr-2.8.3.min.js"></script>--%>
</asp:Content>
