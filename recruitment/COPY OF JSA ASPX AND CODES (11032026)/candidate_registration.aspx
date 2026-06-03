<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="candidate_registration.aspx.cs" Inherits="recruitment.candidate_registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function(event) { 
            var scrollpos = localStorage.getItem('scrollpos');
            if (scrollpos) window.scrollTo(0, scrollpos);
        });

        window.onbeforeunload = function(e) {
            localStorage.setItem('scrollpos', window.scrollY);
        };
     </script><div class="container">
      <div class="row">
         <div class="col-md-12 mx-auto">
            <div class="card">
                <div class="card-header">
                <center><h5>Applicants Registration </h5></center>

                </div>
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <asp:Label ID="regnolbl1" runat="server" Text=""></asp:Label>
                         </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                          
                        </center>
                     </div>
                  </div>
                 
                  <div class="row">

                     <div class="col-md-6">
                         <label>
                <label for="fullname">Full Name </label>
                  

                  &nbsp;</label><asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" validationgroup="regpagegroup" runat="server" ErrorMessage="Full Name Required"  ControlToValidate="TextBox1" ForeColor="Red" ></asp:RequiredFieldValidator>
                                                  
                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name"></asp:TextBox>
                      <center>   <span class="text-success">As per SSC/Matric/X Certificate.</span></center>
                         </div>
                         <div class="col-md-6">
                         <label>Mobile </label>
                         <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label> <asp:RequiredFieldValidator ID="rfvMobNo" runat="server" validationgroup="regpagegroup" ErrorMessage="Mobile Number Required"
                      ForeColor="Red" ControlToValidate="TextBox6"></asp:RequiredFieldValidator>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="10 Digit Mobile Number"></asp:TextBox>
                           
                    <asp:RegularExpressionValidator ID="revMobNo" runat="server" ErrorMessage="Invalid Mobile Number."
                     ValidationExpression="^([0-9]{10})$" ControlToValidate="TextBox6" ValidationGroup="regpagegroup"
                     ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                         </div>
                     
                      </div>

                  <div class="row">
                        <div class="col-md-6">
                        <label>Email ID (Valid and Active)</label>
                         <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" validationgroup="regpagegroup" ErrorMessage="Email ID is Required"
                      ForeColor="Red" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Email ID"></asp:TextBox>
                          
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3" validationgroup="regpagegroup"
                         ForeColor="Red" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" Display = "Dynamic" ErrorMessage = "Invalid email address"/>
                      
                        </div>
                            </div>
                        <div class="col-md-6">
                         <label>Confirm Email ID</label>
                         <asp:Label ID="Label8" runat="server" Text="*" ForeColor="Red"></asp:Label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" validationgroup="regpagegroup" ErrorMessage="Confirm Email is Required"
                      ForeColor="Red" ControlToValidate="TextBox7"></asp:RequiredFieldValidator>
                                               <div class="form-group">
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Email ID"></asp:TextBox> <asp:CompareValidator ID="CompareValidator2" runat="server" 
            ControlToCompare="TextBox3" ControlToValidate="TextBox7" validationgroup="regpagegroup" ErrorMessage ="Email does not match." ForeColor="Red"></asp:CompareValidator>
                        </div>
                           </div>

                        </div>
                        </div>


                  <div class="row">
                        <div class="col-md-6">
                         <label>Password</label>
                         <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" validationgroup="regpagegroup" ErrorMessage="Password is Required"
                      ForeColor="Red" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
                                               <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                                        
                           
                        </div>
                            </div>
                            
                        <div class="col-md-6">
                        <label>Re-Enter Password</label>
                         <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" validationgroup="regpagegroup" ErrorMessage="Confirm Password is Required"
                      ForeColor="Red" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Re-Enter Password" TextMode="Password"></asp:TextBox>

                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
            ControlToCompare="TextBox4" ControlToValidate="TextBox5" 
            ErrorMessage="Password does not match." ForeColor="#CC3300"></asp:CompareValidator>
                             <br />
                             
                        </div>
                            </div>
                            </div>

                  <div class="row">
                             <div class="col-md-6">
                         <label>Verification Code:</label>
                        <div class="form-group">
                            <asp:Image ID="Image2" runat="server" Height="55px" ImageUrl="~/Captcha.aspx" Width="186px" />  <asp:TextBox runat="server" ID="txtVerificationCode" Height="32px" Width="185px"></asp:TextBox> 
                <br />  
                <asp:Label runat="server" ID="lblCaptchaMessage"></asp:Label>
                        </div>
                                 </div>

                      <div class="col-md-6">
                          <asp:RegularExpressionValidator ID="Regex4" runat="server" ControlToValidate="TextBox4" validationgroup="regpagegroup" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,}"
                            ErrorMessage="Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet, 1 Number and 1 Special Character" ForeColor="Red" Font-Size="9pt" />
                          </div>

                       </div>
            <div class="row">
                             <div class="col-md-12">
                        <div class="form-group">
                        <center>    <asp:Button class="btn btn-success btn-block btn-md" ID="regisration_btn" runat="server" Text="Register" causesvalidation="true" validationgroup="regpagegroup" OnClick="regisration_btn_Click1" /></center>
                            <asp:Label ID="Label7" runat="server" Text="*Please ensure that Applicant's Name and email-id are entered correctly as it would not be possible to change them later " ForeColor="Green"></asp:Label>
                            <label></label>

                           </div>
                                 </div>
                        </div>
                     
                  
               
                  
            </div>
                

          </div>
            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>

          
      </div>
         
         <br />

           <br />

           <br />
           <br />

         <br />

           <br />

           <br />
           <br />


         
</asp:Content>
