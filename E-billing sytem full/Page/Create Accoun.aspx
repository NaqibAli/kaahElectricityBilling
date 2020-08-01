<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Main.Master" CodeBehind="Create Accoun.aspx.vb" Inherits="E_billing_sytem_full.Create_Accoun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../fonts/material-icon/css/material-design-iconic-font.min.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="main">
        <!-- Sign up form -->
        <section class="signup">
            <div class="container">
                <div class="signup-content">
                    <div class="signup-form">
                        <h2 class="form-title">Create users</h2>
                       
                        <form method="POST" class="register-form" id="Form1">

                            <div class="form-group">
                                <label for="name"><i class="zmdi zmdi-account material-icons-name"></i></label>
                                <asp:TextBox ID="TxtUserName" runat="server" type="text" name="name" placeholder="Your Name"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtUserName" ErrorMessage="Please Enter Name" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="email"><i class="zmdi zmdi-lock"></i></label>
                                <asp:TextBox ID="Textpass" runat="server"  textmode="Password" placeholder="Your Password"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Textpass" ErrorMessage="Please Enter password" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="pass"><i class="zmdi zmdi-check"></i></label>
                                <asp:TextBox ID="TextStatus" runat="server"  placeholder="Enter Status"></asp:TextBox>
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextStatus" ErrorMessage="Please Enter Status" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label for="re-pass"><i class="zmdi zmdi-pocket"></i></label>
                                <asp:TextBox ID="Txttype" runat="server"  placeholder="Enter Type"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Txttype" ErrorMessage="Please Enter type" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>

                            <div class="form-group form-button">
                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-info form-control" class="form-submit" value="Register" Text="Create" />

                            </div>
                           
                        </form>
                    </div>
                    <div class="signup-image">
                        <figure>
                            <img src="../images/signup-image.jpg" alt="sing up image" />
                        </figure>
                        <a href="#" class="signup-image-link">I am already member</a>
                    </div>
                </div>
            </div>
        </section>

        <!-- Sing in  Form -->


    </div>
    <!-- JS -->
    <%--<script src="vendor/jquery/jquery.min.js"></script>--%>
    <script src="../vendor/jquery.min.js"></script>
    <script src="../js/main.js"></script>
</asp:Content>
