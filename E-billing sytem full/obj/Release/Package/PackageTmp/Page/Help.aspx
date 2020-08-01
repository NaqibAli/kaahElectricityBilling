<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin/Main.Master" CodeBehind="Help.aspx.vb" Inherits="E_billing_sytem_full.Help" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="flex-Home1">


        <div class="card1">

            <%--  <img src="../Image/ARDAYDA-REER-PUNTLAND.jpg" height="260" />--%>
            <div class="container">
                <h4><b>Services</b></h4>
                <p>super market has the Part-time school teaches young children and teaches math, English, Somali and Arabic, and the school has private and offers private day and night classes, school also has adult education</p>
            </div>
        </div>





        <div class="card1">

            <%--  <img src="../Image/b2.jpg" alt="Avatar" width="368" height="260" />--%>
            <div class="container">
                <h4><b>Objectives</b></h4>
                <p>
                    To produce a reliable student of good behavior wherever the student goes so that the student
 who has graduated so long can obtain his or her knowledge of the tests and tests and discipline.
According to the school a student’s password test can be viewed online by student who is unable 
To attend the exam and will be able to observe each student as he or she is at home or in class.

                </p>
            </div>
        </div>


        <div class="card1">


            <%-- <img src="../Image/b4history.jpg" alt="Avatar" width="368" height="260" />--%>
            <div class="container">
                <h4><b>History</b></h4>
                <p>
                    The Super market was founded by abdiwakil aadan nur madaale in 2014 when it was private that provide mathematics, English and Arabic, In 2018 the school has two centers, the umbrella under the school is the save, and graduated with two batches, the curriculum, is located in distract of hodan  
                </p>
            </div>
        </div>



    </div>

    <section id="contact-form" class="py-3">
        <div class="container">
            <h1 class="l-heading"><span class="text-primary">Contact</span> Us</h1>
            <p>Please fill out the form below to contact us</p>
            <div action="process.php">
                <div class="form-group">
                    <label for="name">Name</label>
                    <input type="text" name="name" id="name" />
                </div>
                <div class="form-group">
                    <label for="email">Email</label>
                    
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="message">Message</label>
                    <textarea name="message" id="message"></textarea>
                </div>
                <button type="submit" class="btn">Submit</button>
            </div>
        </div>
    </section>

</asp:Content>
