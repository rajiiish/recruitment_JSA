<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AcadmicQualificationsAdd.aspx.cs" Inherits="recruitment.AcacadmicQualificationsAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
         .stepfont
        {
            color: green;
     text-shadow: 2px 2px 5px green;
        font-size: 100%;
        }
         .auto-style3 {
            width: 23px;
            height: 21px;
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

        .table-b
        {
    border:1px solid green;
    margin-top:20px;

  }

        .table-b > thead > tr > th{
    border:1px solid green;
}
.table-b > tbody > tr > td{
    border:1px solid green;
}

.grid-view-container
 {
  height:auto;
  overflow:scroll;
  max-height:450px;
 }
        
.auto-style5 {
            height: 27px;
        }
        .auto-style6 {
            position: relative;
            width: 100%;
            -ms-flex: 0 0 100%;
            flex: 0 0 100%;
            max-width: 100%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style7 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function(event) { 
            var scrollpos = localStorage.getItem('scrollpos');
            if (scrollpos) window.scrollTo(0, scrollpos);
        });

        window.onbeforeunload = function(e) {
            localStorage.setItem('scrollpos', window.scrollY);
        };
     </script>
     <div class="container">
        <div class="bg-light  text-center">
        <p >Note: Don't input any special characters or punctuation marks. Input only alphanumeric characters.<br />
        Personal Details (fields marked with * are mandatory)</p>
        <p >Candidate Registration Number:
              <asp:Label ID="regidlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="Blue"></asp:Label>
       Application ID: <asp:Label ID="appidnolbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label> 
            Post Applying For: <asp:Label ID="applyhpostlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label>  </p>
      </div>
</div>
    <div class="container">
    <div class="card bg-light">
               <div class="card-body">   
     </div>
              <table class="table">
  
  <tbody>
    <tr>
         <td > <strong><img src="imgs/icons8_back_32px.PNG" class="auto-style3" /></strong>PERSONAL DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
         <td class="stepfont"> <strong><img src="imgs/icons8_back_48px.PNG" class="auto-style3" /></strong>EDUCATION DETAILS<strong><img src="imgs/icons8_forward_48px.PNG" class="auto-style3" /></strong></td> 

                 <td > <strong><img src="imgs/icons8_back_32px.PNG" class="auto-style3" /></strong>EXPERIENCE DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 

                 <td > <strong><img src="imgs/icons8_back_32px.PNG" class="auto-style3" /></strong>OTHER INFORMATION<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
                 <td > <strong><img src="imgs/icons8_back_32px.PNG" class="auto-style3" /></strong>FILES UPLOAD<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 


         
        
    </tr>
  </tbody>
</table>
        </div>
        </div>

   <div class="container ">

        <!-- SSLC Panel  start  -->
      <div class="card bg-light">
               <div class="card-body">   
                   <asp:Panel ID="SSCLAddpanel" runat="server">
                   <center>    <h6 class="card-header text-white  bg-info ">Add SSLC/SSC/10th Details</h6></center>
                   
        <div class="row">
         <div class="col-12">
            <center> <h5></h5></center>
        <center>
        <div class="row">
        <table class="table table-b">

         <thead>
    <tr>
      <th scope="col">Qualification</th>
     
      <th scope="col">Institute/School Name</th>

        <th scope="col" class="auto-style5">Marks in Percentage</th>
        </tr>

  </thead>
            <tr>               
               <td>

                   <asp:Label ID="SSLClbl" runat="server" Text="SSLC/SSC/10th"></asp:Label>

               </td>

                 <td><asp:TextBox ID="SSLCinstitutetxt" runat="server" MaxLength="150"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" validationgroup="SSLCgroup" runat="server" ErrorMessage="*"  ControlToValidate="SSLCinstitutetxt" ForeColor="Red" ></asp:RequiredFieldValidator></td>
                <td><asp:TextBox ID="SSLCpmarkstext" runat="server" Height="30 px" Width="80px"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator21" validationgroup="SSLCgroup" runat="server" ErrorMessage="*"  ControlToValidate="SSLCpmarkstext" ForeColor="Red" ></asp:RequiredFieldValidator> <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="SSLCpmarkstext"
            CultureInvariantValues="True" ErrorMessage="Enter Percentage" MaximumValue="100.00"  MinimumValue="0.00" Type="Double" ValidationGroup="SSLCgroup"></asp:RangeValidator></td>
                </tr>
                         <tr>
      
         <th scope="col" class="auto-style5">Year of Passing</th>
         <th scope="col" class="auto-style5">Division/Grade</th>
    </tr>
            <tr>
                 
                 <td><asp:TextBox ID="SSLCpyeartxt" runat="server" MaxLength="4" Height="30 px" Width="80px"></asp:TextBox>  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" validationgroup="SSLCgroup" runat="server" ErrorMessage="*"  ControlToValidate="SSLCpyeartxt" ForeColor="Red" ></asp:RequiredFieldValidator>  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="SSLCpyeartxt" 
                     ValidationExpression="^[0-9]+$" runat="server"  ValidationGroup="SSLCgroup" ErrorMessage="enter only year."></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "SSLCpyeartxt" ID="RegularExpressionValidator2" 
                         ValidationExpression = "^[\s\S]{4,}$" runat="server" ValidationGroup="SSLCgroup" ErrorMessage="Enter Year in Correct Formate."></asp:RegularExpressionValidator>
                 </td>

                 <td><asp:DropDownList ID="SSLCCourseclass" runat="server" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                   <asp:ListItem  Value= "First Class">First Class</asp:ListItem>
                   <asp:ListItem  Value= "Second Class"> Second Class</asp:ListItem>
                   <asp:ListItem  Value="Third Class">Third Class</asp:ListItem>
                   <asp:ListItem  Value="First Class-with Distinction">First Class-with Distinction</asp:ListItem>
                   <asp:ListItem  Value="First Class–Exemplary">First Class–Exemplary</asp:ListItem>
                   </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display = "Dynamic" ControlToValidate="SSLCCourseclass" ErrorMessage="*" ForeColor="Red" InitialValue="0" validationgroup="SSLCgroup" />

                 </td>
               
                <td>
                    <asp:Button ID="AddSSLCbutton" runat="server" class="btn btn-info" Text="Add" validationgroup="SSLCgroup" OnClick="AddSSLCbutton_Click" /></td>
            </tr>
        </table>
            </div>
        <div class="row">
            
                <div class="col-12">
            <asp:Label ID="validatelbl" runat="server" ForeColor="#FF3300" ></asp:Label>
                                <asp:Label ID="Label1" runat="server" ForeColor="#FF3300" ></asp:Label>

                    </div>
                
        </div>
            
            </center>
             </div>
    </div>
                       </asp:Panel>

                   <asp:Panel ID="SSLCGridPanel" runat="server">
                   <div class="row">
         <div class="col-12"> 
          <center>      <h6> </h6> </center>
          <center>    <h6 class=" text-white bg-secondary"> SSLC/SSC/10th Details:</h6></center>  
            
             <table class="table table-b table-sm">

                               <thead>
                                  
                                   <tr>
                                       <th>Qualification</th>
                                       <th>Institute/School Name</th>
                                       <th>Marks in Percentage</th>
                                       <th>Year of Passing/</th>
                                       <th>Division/Grade</th>
                                   </tr>
                               </thead>
                               <tr>
                                  
                                    <td class="auto-style5"><asp:Label ID="SSLC1" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="SSLC2" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="SSLC3" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="SSLC4" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="SSLC5" runat="server" Text="Label"></asp:Label></td>
                                 
                               </tr>
                              <tr>
                                   <td colspan="5" class="auto-style7">
                                     <center>  <asp:Button ID="SSLCDeletebtn" class="btn btn-primary" runat="server" Text="Delete SSLC" OnClick="SSLCDeletebtn_Click" /></td> </center>
                              </tr>
                              
                              
                           </table>


         </div>
                </div>
                       </asp:Panel>

                   </div>
          </div>
        <!-- SSLC Panel  start  -->
       <br />
        <!-- HSC Panel  start  -->
       <div class="card bg-light">
               <div class="card-body">   
                   <asp:Panel ID="HSCAddpanel" runat="server">
                   <center>    <h6 class="card-header text-white  bg-info ">Add HSC/12th Details</h6></center>
                   
        <div class="row">
         <div class="col-12">
            <center> <h5></h5></center>
        <center>
        <div class="row">
        <table class="table table-b">

         <thead>
    <tr>
      <th scope="col">Qualification</th>
      <th scope="col">Group Name</th>
         <th scope="col">Main Subject</th>
      <th scope="col">Institute/School Name</th>
        </tr>

  </thead>
            <tr>               
               <td>

                   <asp:Label ID="HSClable" runat="server" Text="HSC/12th"></asp:Label>

               </td>

                <td><asp:TextBox ID="HSCsplstxt" runat="server" ></asp:TextBox></td>
                 <td><asp:TextBox ID="HSCsub" runat="server" ></asp:TextBox></td>
                 <td><asp:TextBox ID="HSCinstitutetxt" runat="server"></asp:TextBox></td>
                </tr>
                         <tr>
      <th scope="col" class="auto-style5">Marks in Percentage</th>
         <th scope="col" class="auto-style5">Year of Passing</th>
         <th scope="col" class="auto-style5">Division/Grade</th>
    </tr>
            <tr>
                 <td><asp:TextBox ID="HSCpmarkstext" runat="server" Height="30 px" Width="80px"></asp:TextBox> <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="HSCpmarkstext"
            CultureInvariantValues="True" ErrorMessage="Enter Percentage" MaximumValue="100.00"  MinimumValue="0.00" Type="Double" ValidationGroup="hscregpagegroup"></asp:RangeValidator></td>
                 <td><asp:TextBox ID="HSCpyeartxt" runat="server" MaxLength="4" Height="30 px" Width="80px"></asp:TextBox>  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="HSCpyeartxt" 
                     ValidationExpression="^[0-9]+$" runat="server"  ValidationGroup="hscregpagegroup" ErrorMessage="enter only year."></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "SSLCpyeartxt" ID="RegularExpressionValidator4" 
                         ValidationExpression = "^[\s\S]{4,}$" runat="server" ValidationGroup="hscregpagegroup" ErrorMessage="Enter Year in Correct Formate."></asp:RegularExpressionValidator>
                 </td>

                 <td><asp:DropDownList ID="HSCCourseclass" runat="server" AutoPostBack="True">
                     <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                   <asp:ListItem  Value= "First Class">First Class</asp:ListItem>
                   <asp:ListItem  Value= "Second Class"> Second Class</asp:ListItem>
                   <asp:ListItem  Value="Third Class">Third Class</asp:ListItem>
                   <asp:ListItem  Value="First Class-with Distinction">First Class-with Distinction</asp:ListItem>
                   <asp:ListItem  Value="First Class–Exemplary">First Class–Exemplary</asp:ListItem>
                   </asp:DropDownList></td>
               
                <td>
                    <asp:Button ID="AddHSCbutton" runat="server" class="btn btn-info" Text="Add" validationgroup="hscregpagegroup" OnClick="AddHSCbutton_Click1"  /></td>
            </tr>
        </table>
            </div>
        <div class="row">
            
                <div class="col-12">
            <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" ></asp:Label>
                                <asp:Label ID="Label4" runat="server" ForeColor="#FF3300" ></asp:Label>

                    </div>
                
        </div>
            
            </center>
             </div>
    </div>
                       </asp:Panel>

                   <asp:Panel ID="HSCGridPanel" runat="server">
                   <div class="row">
         <div class="col-12"> 
          <center>      <h6> </h6> </center>
          <center>   <h6 class=" text-white bg-secondary">HSC/12th Details:</h6></center>  
            
             <table class="table table-b table-sm">

                               <thead>
                                  
                                   <tr>
                                       <th>Qualification</th>
                                       <th>Degree</th>
                                        <th>Subject</th>
                                       <th>Institute/School Name</th>
                                       <th>Marks in Percentage</th>
                                       <th>Year of Passing/</th>
                                       <th>Division/Grade</th>
                                   </tr>
                               </thead>
                               <tr>
                                  
                                    <td class="auto-style5"><asp:Label ID="HSC1" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="HSC2" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="HSC3" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="HSC4" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="HSC5" runat="server" Text="Label"></asp:Label></td>
                                   <td class="auto-style5"><asp:Label ID="HSC6" runat="server" Text="Label"></asp:Label></td>
                                   <td class="auto-style5"><asp:Label ID="HSC7" runat="server" Text="Label"></asp:Label></td>
                                 
                               </tr>
                              <tr>
                                   <td colspan="7" class="auto-style7">
                                     <center>  <asp:Button ID="hscDeletebtn" class="btn btn-primary" runat="server" Text="Delete HSC" OnClick="hscDeletebtn_Click"  /></td> </center>
                              </tr>
                              
                              
                           </table>


         </div>
                </div>
                       </asp:Panel>

                   </div>
          </div>
        <!-- HSC Panel  start  -->
       <br />

        <!-- DIPLOMA Panel  start  -->
       <div class="card bg-light">
               <div class="card-body">   
                   <asp:Panel ID="DIPLOMAAddpanel" runat="server">
                   <center>    <h6 class="card-header text-white  bg-info ">Add DIPLOMA Details (3 Years or equivalent)</h6></center>
                   
        <div class="row">
         <div class="auto-style6">
            <center> <h5></h5></center>
        <center>
        <div class="row">
        <table class="table table-b">

         <thead>
    <tr>
      <th scope="col">Qualification</th>
      <th scope="col">Specialization/Course Name</th>
         <th scope="col">Department</th>
      <th scope="col">Institute/University/College Name</th>
        </tr>

  </thead>
            <tr>               
               <td class="auto-style7">

                   <asp:Label ID="DIPLOMAlable" runat="server" Text="DIPLOMA"></asp:Label>

               </td>

                <td class="auto-style7"><asp:TextBox ID="DIPLOMAsplstxt" runat="server" ></asp:TextBox></td>
                 <td class="auto-style7"><asp:TextBox ID="DIPLOMAsubTXT" runat="server" ></asp:TextBox></td>
                 <td class="auto-style7"><asp:TextBox ID="DIPLOMAinstitutetxt" runat="server"></asp:TextBox></td>
                </tr>
                         <tr>
      <th scope="col" class="auto-style5">Marks in Percentage</th>
         <th scope="col" class="auto-style5">Month & Year of Passing</th>
         <th scope="col" class="auto-style5">Division/Grade</th>
    </tr>
            <tr>
                 <td><asp:TextBox ID="DIPLOMApmarkstext" runat="server" Height="30 px" Width="80px"></asp:TextBox> <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="DIPLOMApmarkstext"
            CultureInvariantValues="True" ErrorMessage="Enter Percentage" MaximumValue="100.00"  MinimumValue="0.00" Type="Double" ValidationGroup="dipregpagegroup"></asp:RangeValidator></td>
                 <td><asp:TextBox ID="DIPLOMApyeartxt" runat="server" MaxLength="4" Height="30 px" Width="80px"></asp:TextBox>  <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="DIPLOMApyeartxt" 
                     ValidationExpression="^[0-9]+$" runat="server"  ValidationGroup="dipregpagegroup" ErrorMessage="enter only year."></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "SSLCpyeartxt" ID="RegularExpressionValidator10" 
                         ValidationExpression = "^[\s\S]{4,}$" runat="server" ValidationGroup="dipregpagegroup" ErrorMessage="Enter Year in Correct Formate."></asp:RegularExpressionValidator>
                 </td>

                 <td><asp:DropDownList ID="DIPLOMACourseclass" runat="server" AutoPostBack="True">
                     <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                   <asp:ListItem  Value= "First Class">First Class</asp:ListItem>
                   <asp:ListItem  Value= "Second Class"> Second Class</asp:ListItem>
                   <asp:ListItem  Value="Third Class">Third Class</asp:ListItem>
                   <asp:ListItem  Value="First Class-with Distinction">First Class-with Distinction</asp:ListItem>
                   <asp:ListItem  Value="First Class–Exemplary">First Class–Exemplary</asp:ListItem>
                   </asp:DropDownList></td>
               
                <td>
                    <asp:Button ID="AddDIPLOMAbutton" runat="server" class="btn btn-info" Text="Add" validationgroup="dipregpagegroup" OnClick="AddDIPLOMAbutton_Click"   /></td>
            </tr>
        </table>
            </div>
        <div class="row">
            
                <div class="col-12">
            <asp:Label ID="Label8" runat="server" ForeColor="#FF3300" ></asp:Label>
                                <asp:Label ID="Label9" runat="server" ForeColor="#FF3300" ></asp:Label>

                    </div>
                
        </div>
            
            </center>
             </div>
    </div>
                       </asp:Panel>

                   <asp:Panel ID="DIPLOMAGridPanel" runat="server">
                   <div class="row">
         <div class="col-12"> 
          <center>      <h6> </h6> </center>
          <center>   <h6 class=" text-white bg-secondary">DIPLOMA Details:</h6></center>  
            
             <table class="table table-b table-sm">

                               <thead>
                                  
                                   <tr>
                                       <th>Qualification</th>
                                       <th>Degree</th>
                                        <th>Subject</th>
                                       <th>Institute/School Name</th>
                                       <th>Marks in Percentage</th>
                                       <th>Year of Passing/</th>
                                       <th>Division/Grade</th>
                                   </tr>
                               </thead>
                               <tr>
                                  
                                    <td class="auto-style5"><asp:Label ID="DIP1" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="DIP2" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="DIP3" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="DIP4" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="DIP5" runat="server" Text="Label"></asp:Label></td>
                                   <td class="auto-style5"><asp:Label ID="DIP6" runat="server" Text="Label"></asp:Label></td>
                                   <td class="auto-style5"><asp:Label ID="DIP7" runat="server" Text="Label"></asp:Label></td>
                                 
                               </tr>
                              <tr>
                                   <td colspan="7" class="auto-style7">
                                     <center>  <asp:Button ID="DIPLOMADeletebtn" class="btn btn-primary" runat="server" Text="Delete DIPLOMA" OnClick="DIPLOMADeletebtn_Click"   /></td> </center>
                              </tr>
                              
                              
                           </table>


         </div>
                </div>
                       </asp:Panel>

                   </div>
          </div>
        <!-- DIPLOMA Panel  start  -->
       <br />
        <!-- UG Panel  start  -->
       <div class="card bg-light">
               <div class="card-body">   
                   <asp:Panel ID="UGAddpanel" runat="server">
                   <center>    <h6 class="card-header text-white  bg-info ">Add UG Details</h6></center>
                   
        <div class="row">
         <div class="col-12">
            <center> <h5></h5></center>
        <center>
        <div class="row">
        <table class="table table-b">

         <thead>
    <tr>
      <th scope="col">Qualification</th>
      <th scope="col">Specialization/Degree Name</th>
         <th scope="col">Main Subject</th>
      <th scope="col">Institute/University/College Name</th>
        </tr>

  </thead>
            <tr>               
               <td>

                   <asp:Label ID="UGlable" runat="server" Text="UG"></asp:Label>

               </td>

                <td><asp:TextBox ID="UGsplstxt" runat="server" ></asp:TextBox></td>
                 <td><asp:TextBox ID="UGsubTXT" runat="server" ></asp:TextBox></td>
                 <td><asp:TextBox ID="UGinstitutetxt" runat="server"></asp:TextBox></td>
                </tr>
                         <tr>
      <th scope="col" class="auto-style5">Marks in Percentage</th>
         <th scope="col" class="auto-style5">Month & Year of Passing</th>
         <th scope="col" class="auto-style5">Division/Grade</th>
    </tr>
            <tr>
                 <td><asp:TextBox ID="UGpmarkstext" runat="server" Height="30 px" Width="80px"></asp:TextBox> <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="UGpmarkstext"
            CultureInvariantValues="True" ErrorMessage="Enter Percentage" MaximumValue="100.00"  MinimumValue="0.00" Type="Double" ValidationGroup="ugregpagegroup"></asp:RangeValidator></td>
                 <td><asp:TextBox ID="UGpyeartxt" runat="server" MaxLength="4" Height="30 px" Width="80px"></asp:TextBox>  <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="UGpyeartxt" 
                     ValidationExpression="^[0-9]+$" runat="server"  ValidationGroup="ugregpagegroup" ErrorMessage="enter only year."></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "SSLCpyeartxt" ID="RegularExpressionValidator6" 
                         ValidationExpression = "^[\s\S]{4,}$" runat="server" ValidationGroup="ugregpagegroup" ErrorMessage="Enter Year in Correct Formate."></asp:RegularExpressionValidator>
                 </td>

                 <td><asp:DropDownList ID="UGCourseclass" runat="server" AutoPostBack="True">
                     <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                   <asp:ListItem  Value= "First Class">First Class</asp:ListItem>
                   <asp:ListItem  Value= "Second Class"> Second Class</asp:ListItem>
                   <asp:ListItem  Value="Third Class">Third Class</asp:ListItem>
                   <asp:ListItem  Value="First Class-with Distinction">First Class-with Distinction</asp:ListItem>
                   <asp:ListItem  Value="First Class–Exemplary">First Class–Exemplary</asp:ListItem>
                   </asp:DropDownList></td>
               
                <td>
                    <asp:Button ID="AddUGbutton" runat="server" class="btn btn-info" Text="Add" validationgroup="ugregpagegroup" OnClick="AddUGbutton_Click"  /></td>
            </tr>
        </table>
            </div>
        <div class="row">
            
                <div class="col-12">
            <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" ></asp:Label>
                                <asp:Label ID="Label5" runat="server" ForeColor="#FF3300" ></asp:Label>

                    </div>
                
        </div>
            
            </center>
             </div>
    </div>
                       </asp:Panel>

                   <asp:Panel ID="UGGridPanel" runat="server">
                   <div class="row">
         <div class="col-12"> 
          <center>      <h6> </h6> </center>
          <center>    <h6 class=" text-white bg-secondary">UG Details:</h6></center>  
            
             <table class="table table-b table-sm">

                               <thead>
                                  
                                   <tr>
                                       <th>Qualification</th>
                                       <th>Degree</th>
                                        <th>Subject</th>
                                       <th>Institute/School Name</th>
                                       <th>Marks in Percentage</th>
                                       <th>Year of Passing/</th>
                                       <th>Division/Grade</th>
                                   </tr>
                               </thead>
                               <tr>
                                  
                                    <td class="auto-style5"><asp:Label ID="UG1" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="UG2" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="UG3" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="UG4" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="UG5" runat="server" Text="Label"></asp:Label></td>
                                   <td class="auto-style5"><asp:Label ID="UG6" runat="server" Text="Label"></asp:Label></td>
                                   <td class="auto-style5"><asp:Label ID="UG7" runat="server" Text="Label"></asp:Label></td>
                                 
                               </tr>
                              <tr>
                                   <td colspan="7" class="auto-style7">
                                     <center>  <asp:Button ID="UGDeletebtn" class="btn btn-primary" runat="server" Text="Delete UG" OnClick="UGDeletebtn_Click1"  /></td> </center>
                              </tr>
                              
                              
                           </table>


         </div>
                </div>
                       </asp:Panel>

                   </div>
          </div>
        <!-- UG Panel  start  -->
       <br />
        <!-- PG Panel  start  -->
       <div class="card bg-light">
               <div class="card-body">   
                   <asp:Panel ID="PGAddpanel" runat="server">
                   <center>    <h6 class="card-header text-white  bg-info ">Add PG Details</h6></center>
                   
        <div class="row">
         <div class="col-12">
            <center> <h5></h5></center>
        <center>
        <div class="row">
        <table class="table table-b">

         <thead>
    <tr>
      <th scope="col">Qualification</th>
      <th scope="col">Specialization/Degree Name</th>
         <th scope="col">Main Subject</th>
      <th scope="col">Institute/University/College Name</th>
        </tr>

  </thead>
            <tr>               
               <td>

                   <asp:Label ID="PGlable" runat="server" Text="PG"></asp:Label>

               </td>

                <td><asp:TextBox ID="PGsplstxt" runat="server" ></asp:TextBox></td>
                 <td><asp:TextBox ID="PGsubTXT" runat="server" ></asp:TextBox></td>
                 <td><asp:TextBox ID="PGinstitutetxt" runat="server"></asp:TextBox></td>
                </tr>
                         <tr>
      <th scope="col" class="auto-style5">Marks in Percentage</th>
         <th scope="col" class="auto-style5">Month & Year of Passing</th>
         <th scope="col" class="auto-style5">Division/Grade</th>
    </tr>
            <tr>
                 <td><asp:TextBox ID="PGpmarkstext" runat="server" Height="30 px" Width="80px"></asp:TextBox> <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="PGpmarkstext"
            CultureInvariantValues="True" ErrorMessage="Enter Percentage" MaximumValue="100.00"  MinimumValue="0.00" Type="Double" ValidationGroup="regpagegroup"></asp:RangeValidator></td>
                 <td><asp:TextBox ID="PGpyeartxt" runat="server" MaxLength="4" Height="30 px" Width="80px"></asp:TextBox>  <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="PGpyeartxt" 
                     ValidationExpression="^[0-9]+$" runat="server"  ValidationGroup="regpagegroup" ErrorMessage="enter only year."></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "SSLCpyeartxt" ID="RegularExpressionValidator8" 
                         ValidationExpression = "^[\s\S]{4,}$" runat="server" ValidationGroup="regpagegroup" ErrorMessage="Enter Year in Correct Formate."></asp:RegularExpressionValidator>
                 </td>

                 <td><asp:DropDownList ID="PGCourseclass" runat="server" AutoPostBack="True">
                     <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                   <asp:ListItem  Value= "First Class">First Class</asp:ListItem>
                   <asp:ListItem  Value= "Second Class"> Second Class</asp:ListItem>
                   <asp:ListItem  Value="Third Class">Third Class</asp:ListItem>
                   <asp:ListItem  Value="First Class-with Distinction">First Class-with Distinction</asp:ListItem>
                   <asp:ListItem  Value="First Class–Exemplary">First Class–Exemplary</asp:ListItem>
                   </asp:DropDownList></td>
               
                <td>
                    <asp:Button ID="AddPGbutton" runat="server" class="btn btn-info" Text="Add" validationgroup="regpagegroup" OnClick="AddPGbutton_Click1"   /></td>
            </tr>
        </table>
            </div>
        <div class="row">
            
                <div class="col-12">
            <asp:Label ID="Label6" runat="server" ForeColor="#FF3300" ></asp:Label>
                                <asp:Label ID="Label7" runat="server" ForeColor="#FF3300" ></asp:Label>

                    </div>
                
        </div>
            
            </center>
             </div>
    </div>
                       </asp:Panel>

                   <asp:Panel ID="PGGridPanel" runat="server">
                   <div class="row">
         <div class="col-12"> 
          <center>      <h6> </h6> </center>
          <center>   <h6 class=" text-white bg-secondary">PG Details:</h6></center>  
            
             <table class="table table-b table-sm">

                               <thead>
                                  
                                   <tr>
                                       <th>Qualification</th>
                                       <th>Degree</th>
                                        <th>Subject</th>
                                       <th>Institute/School Name</th>
                                       <th>Marks in Percentage</th>
                                       <th>Year of Passing/</th>
                                       <th>Division/Grade</th>
                                   </tr>
                               </thead>
                               <tr>
                                  
                                    <td class="auto-style5"><asp:Label ID="PG1" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="PG2" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="PG3" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="PG4" runat="server" Text="Label"></asp:Label></td>
                                    <td class="auto-style5"><asp:Label ID="PG5" runat="server" Text="Label"></asp:Label></td>
                                   <td class="auto-style5"><asp:Label ID="PG6" runat="server" Text="Label"></asp:Label></td>
                                   <td class="auto-style5"><asp:Label ID="PG7" runat="server" Text="Label"></asp:Label></td>
                                 
                               </tr>
                              <tr>
                                   <td colspan="7" class="auto-style7">
                                     <center>  <asp:Button ID="PGDeletebtn" class="btn btn-primary" runat="server" Text="Delete PG" OnClick="PGDeletebtn_Click1"   /></td> </center>
                              </tr>
                              
                              
                           </table>


         </div>
                </div>
                       </asp:Panel>

                   </div>
          </div>
       </div>
     <!-- PG Panel  start  -->
    <br />

    
    <br />
    <br />
        <div class="container ">
      <div class="card bg-light">
               <div class="card-body">   
        
                    <!-- Phd Panel  start  -->
                   <br />
                   <div class="row">
                       <div class="col-12">                      
                          
                                <asp:Panel ID="PhdPanel" runat="server">
                                    <center>    <h6 class="card-header text-white  bg-info ">Add PHD Details</h6></center>
                                  
                           <table class="table table-b">
                                <thead>
                                    <tr>
                                <th scope="col">Phd Title</th>
                                <th scope="col">Month & Year of Completion</th>
                                <th scope="col">Area of Study</th>
                                <th scope="col">Breif the Title</th>
                                   </tr>
                                     </thead>
                               <tr>
                                   <td><asp:TextBox ID="phdtxt1" runat="server" MaxLength="50"></asp:TextBox> </td>
                                   <td><asp:TextBox ID="phdtxt2" runat="server" MaxLength="50"></asp:TextBox> </td>
                                   <td><asp:TextBox ID="phdtxt3" runat="server" MaxLength="350"></asp:TextBox> </td>
                                   <td><asp:TextBox ID="phdtxt4" runat="server" MaxLength="600" Height="71px" TextMode="MultiLine" Width="237px"></asp:TextBox> </td>
                               </tr>
                               <tr>
                               <center>  <td colspan="4" class="text-center"> <asp:Button ID="addPhdbtn" class="btn btn-info" runat="server" Text="Add" OnClick="addPhdbtn_Click" /></td> </center>
                               </tr>
                               </table>

                                 </asp:Panel>
                             <asp:Panel ID="phdGridPanel" runat="server">
                                   <center>   <h6 class=" text-white bg-secondary">PHD Details:</h6></center> 
                            <table class="table table-b">
                                <thead>
                                    <tr>
                                <th scope="col">Phd Title</th>
                                <th scope="col">Month & Year of Completion</th>
                                <th scope="col">Area of Study</th>
                                <th scope="col">Breif the Title</th>
                                   </tr>
                                     </thead>
                               <tr>
                                 <td>  <asp:Label ID="PHD1" runat="server" Text="Label"></asp:Label>  </td>
                                   <td>  <asp:Label ID="PHD2" runat="server" Text="Label"></asp:Label>  </td>
                                   <td>  <asp:Label ID="PHD3" runat="server" Text="Label"></asp:Label>  </td>
                                   <td>  <asp:Label ID="PHD4" runat="server" Text="Label"></asp:Label>  </td>
                               </tr>
                                <tr>
                                   <td colspan="5" class="auto-style7">
                                     <center>  <asp:Button ID="deletePHdbtn" class="btn btn-primary" runat="server" Text="Delete Phd" OnClick="deletePHdbtn_Click"    /></td> </center>
                              </tr>

                               </table>
                        </asp:Panel>
                       </div>
                   </div>
              </div>
        </div>
        </div>
                      
                    <!-- Phd Panel  end  -->
                   <br /><br />
                   
                

    <div class="container">
        <center>
              <asp:Label ID="countlbl" runat="server" Text="*Add Minimum Two Qualificatioins"></asp:Label>
              <asp:Label ID="errorlbl" runat="server" Text="*Add Minimum Two Qualificatioins"></asp:Label>
            </center>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-12 align-items-center">
                 <center>
                     
                <asp:Button ID="SaveEducationbtn" runat="server" CssClass="savebtncolor"  validationgroup="educationigroup" Text="Save and Continue" OnClick="SaveEducationbtn_Click" />
                </center>
                </div>
           
        </div>
    </div>
               
</asp:Content>
