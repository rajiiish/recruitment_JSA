<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="recruitment.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            position: relative;
            width: 100%;
            -ms-flex-preferred-size: 0;
            flex-basis: 0;
            -ms-flex-positive: 1;
            flex-grow: 1;
            max-width: 100%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                 
                  <div class="row">
                     <div class="auto-style5">
                        <center>
                           <h5>Forgot Password</h5>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Email ID</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" placeholder="Email ID"></asp:TextBox>
                        </div>
                      
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Login" runat="server" Text="Send to Mail" OnClick="Login_Click"  />

                         <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                          <asp:Label ID="pwdlbl" runat="server" Text=""></asp:Label>

                        </div>
                                                               
                    
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>
      </div>
   </div>
    </div>
</asp:Content>
