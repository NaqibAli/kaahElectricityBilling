<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Main.Master" CodeBehind="Sign Customers.aspx.vb" Inherits="E_billing_sytem_full.Sign_Customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container ">
        <div class="card mt-5">
            <div class="card-header bg-info text-light">

                <h4>Sign Customer </h4>



            </div>
            <div class="card-body">
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-6">
                            Customer Name
                               <asp:DropDownList ID="dblname" runat="server" DataTextField="Select Customer" CssClass="form-control form-control-sm" EnableViewState="true" AutoPostBack="True"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dblname" ErrorMessage="Please Enter Customer Name" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-6">
                            Date
                                <asp:TextBox ID="TxtDate" runat="server" CssClass="form-control form-control-sm txtdate" Text="now" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtDate" ErrorMessage="Please Enter Date finance" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-12 row">
                            <div class="col-md-3">
                                Killo watt
                                <asp:TextBox ID="TxtKillowat" runat="server" placeholder=" Killo wat" CssClass="form-control form-control-sm nwatt"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TxtKillowat" ErrorMessage="Please Enter Killo wat" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3">
                                Previous watt
                                <asp:TextBox ID="TxtBeforeWatt" runat="server" placeholder="Previous watt" ReadOnly="true" CssClass="form-control form-control-sm bwatt"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtBeforeWatt" ErrorMessage="Please Enter Killo wat" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3">
                                Previous Balance
                                <asp:TextBox ID="TxtBeforeBalance" runat="server" placeholder="Previous Balance" CssClass="form-control form-control-sm bbalance" ReadOnly="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtBeforeBalance" ErrorMessage="Please Enter Before Balance" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3">
                                Total
                                <asp:TextBox ID="TxtNewBalance" runat="server" placeholder="Total" type="New Balance" CssClass="form-control form-control-sm total"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtNewBalance" ErrorMessage="Please Enter New Balance" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>



                    </div>
                    <div class="row ml-auto w-75">
                        <div class="col-md-2 mt-4">
                            <asp:Button ID="btnSave" runat="server" CssClass="w-100 btn btn-success form-control" Text="Save"></asp:Button>
                        </div>
                        <div class="col-md-2 mt-4">
                            <asp:Button ID="BtnUpdate" runat="server" CssClass="btn btn-info form-control" Text="Update"></asp:Button>
                        </div>
                        <div class="col-md-2 mt-4">
                            <button class="btn btn-danger form-control cleartxt" type="button">Clear</button>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    <div class="container ">
        <div class="card">
            <div class="card-header bg-info text-light">

                <div class="row w-100">
                    <div class="col-8">
                        <h4>&nbsp;Customer Sign Information </h4>
                    </div>
                    <div class="col-4 ">
                        <div class="input-group">
                            <asp:TextBox ID="TextSearch" runat="server" placeholder="Search" CssClass="form-control form-control-sm"></asp:TextBox>
                            <span class="input-group-append">
                                <button class="btn btn-warning"><i class="ik ik-search"></i> </button>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card-body">

                <asp:GridView ID="GridView1" CssClass="table table-hover table-bordered" runat="server">
                    <Columns>
                        <asp:CommandField HeaderText="Actions" SelectText="&lt;i class=&quot;ik ik-edit&quot;&gt;&lt;/i&gt; Edit" ShowSelectButton="True" />
                    </Columns>
                    <HeaderStyle CssClass="thead-dark text-uppercase" />
                </asp:GridView>
            </div>
        </div>
    </div>



    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body notify">
                </div>
                <div class="modal-footer">
                    <div class="row">
                        <div class="col-6 offset-6">
                            <button type="button" class="btn btn-secondary form-control" data-dismiss="modal">Ok</button>
                        </div>

                    </div>


                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script defer>
        const bwat = document.querySelector(".bwatt");
        const nwat = document.querySelector(".nwatt");
        const bbalance = document.querySelector(".bbalance");
        const total = document.querySelector(".total");
        const clear = document.querySelector(".cleartxt");


        nwat.addEventListener("blur", calculate);

        clear.addEventListener("click", () => {
            bwat.value = ""
            nwat.value = ""
            bbalance.value = ""
            total.value = ""

        })

        function calculate() {

            var totalBalance;
            if (nwat.value < bwat.value) {
                nwat.classList.add("is-invalid");
            }
            else {
                nwat.classList.remove("is-invalid");
                totalBalance = (nwat.value - bwat.value) * 0.5 + +bbalance.value;
                total.value = totalBalance;
            }
        }

    </script>
</asp:Content>
