<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="reg_redirect.aspx.cs" Inherits="recruitment.reg_redirect" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                            &nbsp;</center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                            <div class="alert alert-success" role="alert">
  <h4 class="alert-heading">Candidate Successfully Registerd. </h4> <h4> Please Login to Continue.</h4>
 
</div>
                           
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     
                      
                           <asp:Button class="btn btn-success btn-block btn-lg" ID="Login" runat="server" Text="Login" OnClick="Button1_Click" />
                        </div>
                        
                        <div class="form-group">
                           &nbsp;</div>
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>
      
   </asp:Content>
