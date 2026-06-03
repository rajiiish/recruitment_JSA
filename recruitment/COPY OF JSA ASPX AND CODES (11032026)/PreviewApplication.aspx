d<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PreviewApplication.aspx.cs" Inherits="recruitment.PreviewApplication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

                                                                                                  
   <style>
    
      .divtext {
       
        font-family: Arial;
        font-size: 14px;
      }
    </style>

       </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <section>
    <div class="container">
        <div class="bg-light  text-center">
        <p >Note: Don't input any special characters or punctuation marks. Input only alphanumeric characters.</br>
        Personal Details (fields marked with * are mandatory)</p>
        <p >Candidate Registration Number:
              <asp:Label ID="regidlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="Blue"></asp:Label>
       Application ID: <asp:Label ID="appidnolbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label> 
            Post Applying For: <asp:Label ID="applyhpostlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label>  </p>
      </div>

    </div>
        </section>
    <div class="container">
        <div class="divtext">
		 <div class="container">

        <div class="row">
            <%-- Two page starts--%>  
   <div class="col-8 border">
         <section >
        
        <div class="row">
              <div class="col-md-4 mb-3">
                <label for="firstName">First name</label> <br/>
                  

                  <asp:Label ID="fname" runat="server" Text="Label"></asp:Label>
              </div>
              <div class="col-md-4 mb-3">
                <label for="lastname">Last name</label><br/>
                  <asp:Label ID="lname" runat="server" Text="Label"></asp:Label>
              </div>
                <div class="col-md-4 mb-3">
                <label for="fathername">Father Name</label><br/>

                    <asp:Label ID="fathername" runat="server" Text="Label"></asp:Label>
              </div>
            </div>
              <%-- ROW 1 starts--%>
        <div class="row">
              <div class="col-md-4 mb-3">
                <label for="dob">DOB</label><br/>
                  
                  <asp:Label ID="dob" runat="server" Text="Label"></asp:Label>
              </div>
              <div class="col-md-4 mb-3">
                <label for="gender">GENDER</label><br/>
                  <asp:Label ID="gender" runat="server" Text="Label"></asp:Label>
              </div>
                <div class="col-md-4 mb-3">
                <label for="cast">CATEGORY</label><br/>

                    <asp:Label ID="caste" runat="server" Text="Label"></asp:Label>
              </div>
            </div>
              <%-- ROW 2 starts--%>
        <div class="row">
              <div class="col-md-4 mb-3">
                <label for="marital">Marital Status</label><br/>
                  

                  <asp:Label ID="martial" runat="server" Text="Label"></asp:Label>
              </div>
              <div class="col-md-4 mb-3">
                <label for="religion">Religion</label><br/>
                  <asp:Label ID="religion" runat="server" Text="Label"></asp:Label>
              </div>
                <div class="col-md-4 mb-3">
                <label for="csiremp">Are you a CSIR Employee</label><br/>

                    <asp:Label ID="csiremp" runat="server" Text="Label"></asp:Label>
              </div>
            </div>
             <%-- ROW3 starts--%>
        <div class="row">
              <div class="col-md-4 mb-3">
                <label for="pwd">PWD Catagory</label><br />
                  

                 <asp:Label ID="pwd" runat="server" Text="Label"></asp:Label>
              </div>
              <div class="col-md-4 mb-3">
                <label for="aadhaar">Aadhaar Number</label><br />
                  <asp:Label ID="aadhaar" runat="server" Text="Label"></asp:Label>
              </div>
                <div class="col-md-4 mb-3">
                <label for="citizen">Are you a Indian Citizen</label><br />

                   <asp:Label ID="citizen" runat="server" Text="Label"></asp:Label>
              </div>

           


            </div>

<div class="row">
              <div class="col-md-4 mb-3">
                <label for="bank1">Bank Reference Number</label><br />
                  
                 <asp:Label ID="bandrefno" runat="server" Text="Label"></asp:Label>
                  
                  
              </div>
              <div class="col-md-4 mb-3">
                <label for="bank2">Payment Date</label><br />
                 
              
                  <asp:Label ID="paydate" runat="server" Text="Label"></asp:Label>
               
              </div>
                <div class="col-md-4 mb-3">
                <label for="bank3">Mode of Payment</label> <br />

                   <asp:Label ID="paymode" runat="server" Text="Label"></asp:Label>
              
                    
               
              </div>

           


            </div>

        </section>
   </div>
          <%-- Payment Section starts--%>  
       
        <div class="col-4 border border-warning"">
            
         <center>Photograph Details </center>

            <div class="row-6">

                <div class="col-12">
                    <asp:Image ID="Image1" runat="server" />
                 </div>
                <div class="col-12">
                   <asp:Image ID="Image2" runat="server" />
                 </div>
               

            </div>
            
             </div>
          <%-- Payment Section Ends--%>   
               <%-- Two page ends--%>  
            

     </div>
        
        
        </div>
    <%-- Main Section ends.--%>  
     <%-- Address Section start.--%>  
    <div class="container border">
        <div class="row">
        <div class="col-6">
               <label for="email">E-Mail Address</label>
            <br />

                   <asp:Label ID="email" runat="server" Text="Label"></asp:Label>
                  
                 
                  
        </div>

        <div class="col-4">

            <label for="mobile">Mobile Number</label>
                  
                 <br />

                   <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>
                  
          </div>
    </div>
    <div class="row">
        
        <div class="col-6">
            <div class="row">
                <div class="col-12">
               <label for="address1">Present Address / Communication Address</label>
                  
                  <br />

                   <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>
                    </div>

                <div class="col-4">
               <label for="address1">City</label><br />
                  
                   <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
                    </div>

                <div class="col-4">
               <label for="address1">state</label><br />
                  
                  <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>
                    </div>

                <div class="col-4">
               <label for="address1">Pincode</label> <br />
                  
                  <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>
                    </div>
          </div>        
        </div>
        
        <div class="col-6">

            <label for="address1"> Permenant Address </label>
                  <br />
             <asp:Label ID="Label22" runat="server" Text="Label" TextMode="MultiLine"></asp:Label>
                 
          </div>
            
    </div>
        </div>
        </div>

        <div class="container">
            =--------------

        </div>
		</div>
</asp:Content>
