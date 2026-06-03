<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="basicinformation.aspx.cs" Inherits="recruitment.basicinformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
      <div class="bg-secondary  text-white py-5 text-center">
        <h2>CSIR ONLINE APPLICATION </h2>
        <p class="lead">Note: Don't input any special characters or punctuation marks. Input only alphanumeric characters.</p>
<p class="lead">Personal Details (fields marked with * are mandatory)</p>
          <p class="lead">Candidate Registration Number:
              <asp:Label ID="regidlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="Blue"></asp:Label>
          &nbsp; Application ID:
              <asp:Label ID="appidnolbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label>
          </p>
      </div>

      <div class="row">
        <div class="bg-dark text-white col-md-12 order-md-1"> 
          <h4 class= "bg-primary mb-3 text-center">Basic Details</h4>
          <form class="needs-validation" novalidate>
            <div class="row">
              <div class="col-md-4 mb-3">
                <label for="firstName">First name</label>
                  

                  <asp:TextBox ID="firstname" runat="server" class="form-control" placeholder="" value="" required></asp:TextBox>

                <div class="invalid-feedback">
                  Valid first name is required.
                </div>
              </div>
              <div class="col-md-4 mb-3">
                <label for="lastname">Last name</label>
                  <asp:TextBox ID="lastname" runat="server" class="form-control" placeholder="" value="" required></asp:TextBox>
              

                <div class="invalid-feedback">
                  Valid last name is required.
                </div>
              </div>
                <div class="col-md-4 mb-3">
                <label for="dob">DOB</label>

                    <asp:TextBox ID="dateofbirth" Cssclass="form-control"  runat="server" placeholder="" TextMode="Date" ></asp:TextBox>
                
                    
                <div class="invalid-feedback">
                  Valid last name is required.
                </div>
              </div>
            </div>



              


        <div class="row">
            <div class="col-md-4 mb-3">
                
             
                <label for="fatherName">Father Name / Husband Name</label>

                <asp:TextBox ID="fatherName" runat="server" class="form-control" placeholder="" value="" required></asp:TextBox>
               
                <div class="invalid-feedback">
                  Valid last name is required.
                </div>
              </div>

            <div class="col-md-4 mb-3">
                <label for="email">Selected Post <span class="text-muted">(Optional)</span></label>
                    <asp:TextBox ID="postDetailsdrop" runat="server" class="form-control" placeholder="" value="" required></asp:TextBox>

               
                <div class="invalid-feedback" style="width: 100%;">
                  Your username is required.
                </div>
              
            </div>

                 <div class="col-md-4 mb-3">

              <label for="email">Email <span class="text-muted">(Optional)</span></label>
                      <asp:TextBox ID="email" runat="server" class="form-control" placeholder="" value="" required></asp:TextBox>
            
              <div class="invalid-feedback">
                Please enter a valid email address for  updates.
              </div>
            </div>


            </div>
         
              <div class="row">
            <div class="col-md-6 mb-3">
                
             
                <label for="lastName">Present Address</label>

                 <asp:TextBox ID="presentAddress" runat="server" class="form-control" placeholder="" value="" required></asp:TextBox>
              
                <div class="invalid-feedback">
                  address is required.
                </div>
              </div>

            <div class="col-md-6 mb-3">
                <label for="lastName">Permentant  Address</label>
              
                 <asp:TextBox ID="permenAddress" runat="server" class="form-control" placeholder="" value="" required></asp:TextBox>
                <div class="invalid-feedback"> address is required.</div>
              
            </div>

                
            </div>

            <div class ="row">
                <div class="col-md-4 mb-3">

                        

              <label for="mobile">Mobile No <span class="text-muted">(For Communicatoin)</span></label>
                      <asp:TextBox ID="mobiletextbox" runat="server" class="form-control" placeholder="" value="" required></asp:TextBox>
            
              <div class="invalid-feedback">
                Please enter a valid mobile no address for  updates.
              </div>
            </div>


                    <div class="col-md-4 mb-3">

                        

              <label for="mobile">Mobile No <span class="text-muted">(For Communicatoin)</span></label>
                      <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="" value="" required></asp:TextBox>
            
              <div class="invalid-feedback">
                Please enter a valid mobile no address for  updates.
              </div>
            </div>
                    <div class="col-md-4 mb-3">

                        

              <label for="mobile">Mobile No <span class="text-muted">(For Communicatoin)</span></label>
                      <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="" value="" required></asp:TextBox>
            
              <div class="invalid-feedback">
                Please enter a valid mobile no address for  updates.
              </div>
            </div>
            </div>
        
              
              <div class="row">
                     <div class="col-md-12 mb-3">
                        <center>
                           
                            <asp:Button ID="continue" class="btn btn-primary btn-lg" runat="server" Text="Save and Continue" OnClick="continue_Click"></asp:Button>
                          
                            <br />
                            <asp:Label ID="submitlable" runat="server" Text="Label"></asp:Label>
                          
                           <h4>Clicking Next will save the information to database, please check all information are entered correctly</h4>
                        </center>
                     </div>
                  </div>
              
            
           
          </form>
        </div>
      </div>

      <footer class="my-5 pt-5 text-muted text-center text-small">
        <p class="mb-1">&copy; 2017-2018 Company Name</p>
        <ul class="list-inline">
          <li class="list-inline-item"><a href="#">Privacy</a></li>
          <li class="list-inline-item"><a href="#">Terms</a></li>
          <li class="list-inline-item"><a href="#">Support</a></li>
        </ul>
      </footer>
    </div>
</asp:Content>
