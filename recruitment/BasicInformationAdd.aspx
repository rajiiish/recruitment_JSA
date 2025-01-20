<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BasicInformationAdd.aspx.cs" Inherits="recruitment.BasicInformationAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
         .titlemenufont
    {
        font-family: Arial;
        font-size: 10pt;
    }
         .stepfont
        {
            color: green;
     text-shadow: 2px 2px 5px green;
        font-size: 100%;
        }
       
        .savebtncolor 
{
   background-color: dodgerblue; 
   padding: 4px 10px;
   font: 16px sans-serif;
   text-decoration: none;
   border: 2px solid #000;
   border-color: #aaa #444 #444 #aaa;
   color: white;
}
       
        .auto-style5 {
            left: 0px;
            top: 0px;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    m<script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function(event) { 
            var scrollpos = localStorage.getItem('scrollpos');
            if (scrollpos) window.scrollTo(0, scrollpos);
        });

        window.onbeforeunload = function(e) {
            localStorage.setItem('scrollpos', window.scrollY);
        };
    </script><%-- title start--%><div class="container">
        <div class="bg-light  text-center">
        <p >Note: Don't input any special characters or punctuation marks. Input only alphanumeric characters.<br/>
        &nbsp;(fields marked with * are mandatory) PLEASE BE VERY CAREFUL WHILE FILLING THE APPLICATION FORM </p>
        <p >Candidate Registration Number:
              <asp:Label ID="regidlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="Blue"></asp:Label>
       Application ID: <asp:Label ID="appidnolbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label> 
            Post Applying For: <asp:Label ID="applyhpostlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label>  </p>
      </div>

    </div> 
        <%-- title ends--%>
               

      <%-- Stepbystep start --%>
        
    <!--    <div class="container ">
            <div class="card bg-light">
               <div class="card-body"> 
            <table class="table titlemenufont">
  
  <tbody>
    <tr>
         <td class="stepfont"> <strong><img src="imgs/ticon.PNG" class="auto-style3" /></strong>PERSONAL DETAILS<strong><img src="imgs/icons8_forward_48px.PNG" class="auto-style3" /></strong></td> 
         <td> <strong><img src="imgs/2.PNG" class="auto-style3" /></strong>EDUCATION DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 

                 <td > <strong><img src="imgs/3.PNG" class="auto-style3" /></strong>EXPERIENCE DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 

                <td > <strong><img src="imgs/4.PNG" class="auto-style3" /></strong>PROFESSIONAL INFORMATION<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
                         <td > <strong><img src="imgs/5.PNG" class="auto-style3" /></strong>OTHER INFORMATION<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 

                 <td > <strong><img src="imgs/6.PNG" class="auto-style3" /></strong>FILES UPLOAD<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
               
    </tr>
  </tbody> --%> 
</table>
                      </div>
         </div>
            </div>-->
      <%-- Stepbystep ends--%>             
      

     <br />
   
 
       <%-- Main section starts--%>
   
    <div class="container ">
      <div class="card bg-light">
             <center>    <h6 class="card-header text-white  bg-info ">Personal Details</h6></center>
               <div class="card-body">   
        <div class="row">
            <%-- Two page starts--%>  
   <div class="col-12 ">
         <section >
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <div class="row">
              <div class="col-md-4 mb-3">
                <label for="fullname">Full Name</label>
                  

                  <asp:TextBox ID="fullnametxt" runat="server" class="form-control" placeholder="" value=""  ReadOnly="True"></asp:TextBox>

               
              </div>
              
                <div class="col-md-4 mb-3">
                <label for="fathername">Father&nbsp;Name </label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" validationgroup="basicpagegroup" runat="server" ErrorMessage="*Required"  ControlToValidate="fathernameText" ForeColor="Red" ></asp:RequiredFieldValidator>

                    <asp:TextBox ID="fathernameText" runat="server" class="form-control"  placeholder="" value="" ></asp:TextBox>
                
                    
              
              </div>
             <div class="col-md-4 mb-3">
                <label for="mothername">Mother Name</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" validationgroup="basicpagegroup" runat="server" ErrorMessage="*Required"  ControlToValidate="mothernameText" ForeColor="Red" ></asp:RequiredFieldValidator>

                  <asp:TextBox ID="mothernameText" runat="server" class="form-control" placeholder="" value=""></asp:TextBox>
              

                <div class="invalid-feedback">
                  Valid last name is required.
                </div>
              </div>
            </div>
              <%-- ROW 1 starts--%>
        <div class="row">
             <div class="col-md-4 mb-3">
                <label for="dob">Date of Birth</label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidatorDob" runat="server" ForeColor="Red" ErrorMessage="*Required" ControlToValidate="dobText" validationgroup="basicpagegroup"></asp:RequiredFieldValidator>
                 
                <%--    <asp:TextBox ID="dobText1" runat="server"  Format="dd-MM-yyyy" class="form-control" TextMode="Date" placeholder="dd-MM-yyyy" value="" required></asp:TextBox>--%>
                  <asp:TextBox ID="dobText" class="form-control" Format="dd-MM-yyyy" placeholder="dd-MM-yyyy" runat="server" MaxLength="10" ></asp:TextBox> 
                  <asp:RegularExpressionValidator ID="RegularExpressionValidatorDob" runat="server" ErrorMessage="Invalid Date Format" ControlToValidate="dobText" validationgroup="basicpagegroup"
                    ForeColor="Red" ValidationExpression="(^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))-(((0[1-9])|(1[0-2]))|([1-9]))-(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$)"></asp:RegularExpressionValidator>
                 
                     
                  <ajaxToolkit:CalendarExtender ID="CalendarExtender1" PopupButtonID="dobText" TargetControlID="dobText" runat="server" Format="dd-MM-yyyy"/>
               
              </div>

              <div class="col-md-4 mb-3">
                <label for="gender">Gender</label> <asp:Label ID="genvallbl" runat="server" Text="" ForeColor="Red"></asp:Label>
                  <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="genderDrop" InitialValue="0" validationgroup="basicpagegroup" runat="server" ForeColor="Red" />
                  <asp:DropDownList ID="genderDrop" runat="server" class="form-control" placeholder="" value="" OnSelectedIndexChanged="genderDrop_SelectedIndexChanged" AutoPostBack="True" >

                    <asp:ListItem Selected="True"  Value="0">--Select--</asp:ListItem>
                   <asp:ListItem Value="Male">Male</asp:ListItem>
                   <asp:ListItem Value="Female" >Female</asp:ListItem>
                      <asp:ListItem Value="Thired Gender">Third Gender</asp:ListItem>
                  

                  
                </asp:DropDownList>

                
              </div>
                <div class="col-md-4 mb-3">
                <label for="cast">Caste Category</label>
                  <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="castDrop" InitialValue="0" validationgroup="basicpagegroup" runat="server" ForeColor="Red" />

                     <asp:DropDownList ID="castDrop" runat="server" class="form-control" placeholder="" value="" AutoPostBack="True" OnSelectedIndexChanged="castDrop_SelectedIndexChanged" >
                          <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                          <asp:ListItem Value="SC">SC</asp:ListItem>
                          <asp:ListItem Value="ST">ST</asp:ListItem>
                          <asp:ListItem Value="OBC">OBC</asp:ListItem>
                          <asp:ListItem Value="GENERAL">GENERAL</asp:ListItem>
                          <asp:ListItem Value="EWS" >EWS</asp:ListItem>
                     </asp:DropDownList>
                
                    
               
              </div>
            </div>
              <%-- ROW 2 starts--%>
        <div class="row">
              <div class="col-md-4 mb-3">
                <label for="marital">Marital Status</label>
                  <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="maritalDrop" InitialValue="0" validationgroup="basicpagegroup" runat="server" ForeColor="Red" />
                  

                  <asp:DropDownList ID="maritalDrop" runat="server" class="form-control" placeholder="" value="" >
                       <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                      <asp:ListItem Value="Married">Married</asp:ListItem>
                      <asp:ListItem Value="Not Married">Not Married</asp:ListItem>
                        <asp:ListItem Value="Widow">Widow</asp:ListItem>
                      <asp:ListItem Value="Divorcee">Divorcee</asp:ListItem>
                       <asp:ListItem Value="Judically Seperated">Judically Seperated</asp:ListItem>
                   
                  </asp:DropDownList>
                                  
              </div>
              <div class="col-md-4 mb-3">
                <label for="religion">Religion</label>
                  <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="religionText"  validationgroup="basicpagegroup" runat="server" ForeColor="Red" />

                  <asp:TextBox ID="religionText" runat="server" class="form-control" placeholder="" value="" ></asp:TextBox>
                             
              </div>
                <div class="col-md-4 mb-3">
                <label for="csiremp">Are you a CSIR Employee</label>
                  <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="csirDrop" InitialValue="0" validationgroup="basicpagegroup" runat="server" ForeColor="Red" />

                    <asp:DropDownList ID="csirDrop" runat="server" class="form-control" placeholder="" value="" AutoPostBack="True" OnSelectedIndexChanged="csirDrop_SelectedIndexChanged" >
                         <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="Yes">Yes</asp:ListItem>
                         <asp:ListItem Value="No">No</asp:ListItem>

                    </asp:DropDownList>

                
              </div>
            </div>
             <%-- ROW3 starts--%>
        <div class="row">
            
            <div class="col-md-4 mb-3">
                <label for="placeofbirth">Place of Birth</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" validationgroup="basicpagegroup" runat="server" ErrorMessage="*Required"  ControlToValidate="placeofbirthtxt" ForeColor="Red" ></asp:RequiredFieldValidator>

                  <asp:TextBox ID="placeofbirthtxt" runat="server" class="form-control" placeholder="" value="" ></asp:TextBox>
                            
              </div>
              


              <div class="col-md-4 mb-3">
                <label for="aadhaar">Aadhaar Number</label>
                 

                  <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="aadhaarText"  validationgroup="basicpagegroup" runat="server" ForeColor="Red" />

                  <asp:TextBox ID="aadhaarText" runat="server" class="form-control" maxlength="12" placeholder="" value="" ></asp:TextBox>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  validationgroup="basicpagegroup" ControlToValidate="aadhaarText" runat="server" Display="Dynamic" ErrorMessage="Only Numbers" ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>
                                 
              </div>
                <div class="col-md-4 mb-3">
                <label for="citizen">Are you a Citizen of India by Birth</label>
                  <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="citizenDrop" InitialValue="0" validationgroup="basicpagegroup" runat="server" ForeColor="Red" />

                    <asp:DropDownList ID="citizenDrop" runat="server" class="form-control" placeholder="" value="" >
                        <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem  Value="Yes, Indian">Yes, Indian Citizen</asp:ListItem>
                         <asp:ListItem  Value="No, Forigner">No, Other Country</asp:ListItem>
                    </asp:DropDownList>
                                                  
               
              </div>
            </div>


             <div class="row">
                 <div class="col-md-4 mb-3">
              <div class="auto-style5">
                <label for="pwd">Essential Quaification:</label>
                  <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="ArmyDrop" InitialValue="0" validationgroup="basicpagegroup" runat="server" ForeColor="Red" />
                  
                  <asp:DropDownList ID="ArmyDrop" runat="server" class="form-control" placeholder="" value="" AutoPostBack="True" OnSelectedIndexChanged="ArmyDrop_SelectedIndexChanged"  >
                       <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                       <asp:ListItem Value="ExArmy">Ex-Servicemen</asp:ListItem>
                      <asp:ListItem Value="JCO">JCO</asp:ListItem>
                      <asp:ListItem Value="Para-Military">Para-Military Forces</asp:ListItem>                      
                      <asp:ListItem Value="Others">Others</asp:ListItem>

                  </asp:DropDownList>

                
              </div>
                     </div>
                    <div class="col-md-4 mb-3">
                <label for="pwd">Name of Essential Quaification:</label>
                         <asp:TextBox ID="EssnQualficationTxt" runat="server" class="form-control" placeholder="" value="" ></asp:TextBox>
<asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="pwdDrop" InitialValue="0" validationgroup="basicpagegroup" runat="server" ForeColor="Red" />               
                  
 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" validationgroup="basicpagegroup" runat="server" ErrorMessage="*Required"  ControlToValidate="EssnQualficationTxt" ForeColor="Red" ></asp:RequiredFieldValidator>

                 
                
              </div>

                 

                  <div class="col-md-4 mb-3">
             <asp:Label ID="servicelbl" runat="server" Text="Period of Service (in Years)"> </asp:Label>
                  <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="ArmyService" InitialValue="" validationgroup="basicpagegroup" runat="server" ForeColor="Red" /> 
                  <asp:TextBox ID="ArmyService" runat="server" class="form-control" maxlength="2" placeholder="" value="" ></asp:TextBox>
                      <br />
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="ArmyService" ValidationExpression="^[0-9]+$" runat="server" validationgroup="basicpagegroup" ForeColor="Red" ErrorMessage="enter numbers."></asp:RegularExpressionValidator>

                
              </div>
                              
              
                
            </div>

             <div class="row">
                    <div class="col-md-4 mb-3">
                                     <asp:Label ID="pwd" runat="server" Text="Whether Person with Disability(PWD):"> </asp:Label>

                
<asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="pwdDrop" InitialValue="0" validationgroup="basicpagegroup" runat="server" ForeColor="Red" />                  
                  <asp:DropDownList ID="pwdDrop" runat="server" class="form-control" placeholder="" value="" AutoPostBack="True" OnSelectedIndexChanged="pwdDrop_SelectedIndexChanged" >
                       <asp:ListItem Value="0">--Select--</asp:ListItem>
                       <asp:ListItem Value="Yes">Yes</asp:ListItem>
                      <asp:ListItem Selected="True" Value="No">No</asp:ListItem>
                  </asp:DropDownList>
                
              </div>              
                                               
              
                
            </div>


        </section>
   </div>

 </div>
                    </div>
           </div>

   
</div>
    


     <%-- Address Section start.--%>  

    <div class="container">
        <div class="card bg-light">
             <center>    <h6 class="card-header text-white  bg-info ">Communication Details</h6></center>
               <div class="card-body">   
        <div class="row">
        <div class="col-6">
               <label for="email">E-Mail Address</label>
                  
                  <asp:TextBox ID="emailText" runat="server" class="form-control"  placeholder="" value=""  ReadOnly="True"></asp:TextBox>
                  
        </div>

        <div class="col-4">

            <label for="mobile">Mobile Number</label>
                  
                  <asp:TextBox ID="mobileText" runat="server" class="form-control"  placeholder="" value=""  ReadOnly="True"></asp:TextBox>
                  
          </div>
    </div>
    <div class="row">
        
        <div class="col-6">
            <div class="row">
                <div class="col-12">
                      <br />
               <label for="address1">Present Address / Communication Address</label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="*Required" ControlToValidate="preaddressText" validationgroup="basicpagegroup"></asp:RequiredFieldValidator>
                  
                  <asp:TextBox ID="preaddressText" runat="server" class="form-control"  placeholder="" value="" ></asp:TextBox>
                    </div>

                <div class="col-4">
               <label for="address1">City</label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" ErrorMessage="*Required" ControlToValidate="precityText" validationgroup="basicpagegroup"></asp:RequiredFieldValidator>
                  
                  <asp:TextBox ID="precityText" runat="server" class="form-control"  placeholder="" value="" ></asp:TextBox>
                    </div>

                <div class="col-4">
               <label for="address1">state</label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" ErrorMessage="*Required" ControlToValidate="prestateText" validationgroup="basicpagegroup"></asp:RequiredFieldValidator>
                  
                  <asp:TextBox ID="prestateText" runat="server" class="form-control"  placeholder="" value="" ></asp:TextBox>
                    </div>

                <div class="col-4">
               <label for="address1">Pincode</label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" ErrorMessage="*Required" ControlToValidate="pincodeText" validationgroup="basicpagegroup"></asp:RequiredFieldValidator>
                  
                  <asp:TextBox ID="pincodeText" runat="server" class="form-control"  placeholder="" value="" ></asp:TextBox>
                    </div>
          </div>        
        </div>
        
        <div class="col-6">
              <br />
            <label for="address1"> Permenant Address </label>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" ErrorMessage="*Required" ControlToValidate="permaddressText" validationgroup="basicpagegroup"></asp:RequiredFieldValidator>
                  
                 <br /> <asp:CheckBox ID="AddresSamecheck" runat="server"  AutoPostBack="True" OnCheckedChanged="AddresSamecheck_CheckedChanged" />
            <asp:Label ID="Label1" runat="server" Text="Is your permanent address same as present address?" ForeColor="#3333FF"></asp:Label>
&nbsp;<asp:TextBox ID="permaddressText" runat="server" height="100px"  class="form-control"  ToolTip="Enter Date of Birth" placeholder="" value=""  TextMode="MultiLine"></asp:TextBox>
                  
          </div>
            
    </div>
        <div class="row">
            <div class="col-12">
                      <br/>
                </div>
        </div>
                   </div>
            </div>
        </div>
  
     <%-- Address Section start.--%> 
     
     
    

    <%-- Submit button start.--%>

    <div class="container">
        <div class="row">
            <div class="col-12">
                      <br/>
                </div>
        </div>
    <div class="row">
    <div class="col-12">
                         <asp:Button ID="goBackbtn" CssClass="savebtncolor" validationgroup="NONE" runat="server" Text="Go Back to Home"  OnClick="goBackbtn_Click"  />

    <center> 

        <asp:Button ID="SaveDetails" CssClass="savebtncolor" runat="server" Text="Save and Continue" causesvalidation="true" validationgroup="basicpagegroup" OnClick="SaveDetails_Click" />
    </center>
    </div>
    </div>
    </div>

    <%-- Submit Section ends.--%>   
    <br/>
</asp:Content>
