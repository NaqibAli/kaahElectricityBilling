<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Main.Master" CodeBehind="Payment.aspx.vb" Inherits="E_billing_sytem_full.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container ">
        <div class="card mt-5">
            <div class="card-header bg-info text-light">
                
                   <h4>&nbsp;Payments </h4>
               
            </div>
            <div class="card-body">
                <div class="form-group">
                    <div class="row">


                        <div class="col-md-6">
                            Customer name
                               <asp:DropDownList ID="dblname" runat="server" CssClass="form-control form-control-sm" EnableViewState="true" AutoPostBack="True" ></asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dblname" ErrorMessage="Please Enter Before balance" ForeColor="Red"></asp:RequiredFieldValidator>

                        </div>
<div class="col-md-6">
                            Sign Date
                           
                              <asp:TextBox ID="TxtSignDate" runat="server"  placeholder=" Sign Date" CssClass="form-control form-control-sm" TextMode="Date"></asp:TextBox>


                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtSignDate" ErrorMessage="please Enter Date" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="row col-12">
                         <div class="col-md-4">
                            Balance
                                <asp:TextBox ID="TxtIBeforeBalance" runat="server" placeholder=" Before Balance" CssClass="form-control form-control-sm pbalance" TextMode="Number" Enabled="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtIBeforeBalance" ErrorMessage="Please Enter Before balance" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-md-4">
                            Payments
                                <asp:TextBox ID="TxtPayments" runat="server" TextMode="Number" placeholder=" Payments" CssClass="form-control form-control-sm ppayment"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtPayments" ErrorMessage="please Enter Payments" ForeColor="Red"></asp:RequiredFieldValidator>
                            &nbsp;

                        </div>
                        <div class="col-md-4">
                            Rest 
                                <asp:TextBox ID="TxtRemain" runat="server" TextMode="Number"  placeholder="Remain" CssClass="form-control form-control-sm premain"  ClientIDMode="Static"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtRemain" ErrorMessage="Please Enter Remaining" ForeColor="Red"></asp:RequiredFieldValidator>
                            &nbsp;
                        </div>
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
                            <asp:Button ID="Button2" runat="server" CssClass="btn btn-danger form-control clear" Text="Clear" CausesValidation="False"></asp:Button>
                        </div>
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
                        <h4>Payment </h4>
                    </div>
                    <div class="col-4 ">
                        <div class="input-group">
                            <asp:TextBox ID="TextBox1" runat="server" placeholder="Search" CssClass="form-control form-control-sm"></asp:TextBox>
                            <span class="input-group-append">
                                <button class="btn btn-warning"><i class="ik ik-search"></i> </button>
                            </span>
                        </div>
                    </div>
                </div>
                </div>
            <div class="card-body">
                <asp:GridView ID="GridView1" CssClass="table table-hover table-bordered" runat="server" AutoGenerateSelectButton="True">
                    <HeaderStyle CssClass="thead-dark" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="footer" ContentPlaceHolderID="footer" runat="server">
    <script defer>
        const pbalance = document.querySelector(".pbalance");
        const ppayment = document.querySelector(".ppayment");
        const Premain = document.querySelector(".premain");
        const clear = document.querySelector(".clear");

        ppayment.addEventListener("blur", () => {
            if (ppayment.value < 1) {
                ppayment.classList.add("is-invalid");
            }
            else {
                ppayment.classList.remove("is-invalid");
                Premain.value = pbalance.value - ppayment.value

            }

        })
        clear.addEventListener("click", () => {
            pbalance.value = ""
            ppayment.value = ""
            Premain.value = ""
           

        })
    </script>

</asp:Content>
