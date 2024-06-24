<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EducationalDetails.aspx.cs" Inherits="recruitment.EducationTechnician" %>
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

        .table-b
        {
    border:1px solid green;
    margin-top:20px;
    width: 100%;

  }

        .table-b > TableHeaderRow >  TableHeaderCell
        {
    border:1px solid green;
}
.table-b >  TableRow > TableCell
{
    width: 100%;
    border:1px solid green;
}

.grid-view-container
 {
  height:auto;
  overflow:scroll;
  max-height:450px;
 }
hr.solid {
  border-top: 3px solid #bbb;
}

            .auto-style5 {
                color: #FF0000;
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
        &nbsp;(fields marked with * are mandatory)</p>
        <p >Candidate Registration Number:
              <asp:Label ID="regidlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="Blue"></asp:Label>
       Application ID: <asp:Label ID="appidnolbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label> 
            Post Applying For: <asp:Label ID="applyhpostlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label>  </p>
      </div>
</div>
  <!--  <div class="container">
    <div class="card bg-light">
               <div class="card-body">   
     </div>
              <table class="table titlemenufont">

  
  <tbody>
   <tr>
         <td > <strong><img src="imgs/1.PNG" class="auto-style3" /></strong>PERSONAL DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
         <td class="stepfont"> <strong><img src="imgs/ticon.PNG" class="auto-style3" /></strong>EDUCATION DETAILS<strong><img src="imgs/icons8_forward_48px.PNG" class="auto-style3" /></strong></td> 

                 <td > <strong><img src="imgs/3.PNG" class="auto-style3" /></strong>EXPERIENCE DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
                       <td > <strong><img src="imgs/4.PNG" class="auto-style3" /></strong>PROFESSIONAL INFORMATION <strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 

                 <td > <strong><img src="imgs/5.PNG" class="auto-style3" /></strong>OTHER INFORMATION<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
                 <td > <strong><img src="imgs/6.PNG" class="auto-style3" /></strong>FILES UPLOAD<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
               
    </tr>
  </tbody>
</table>
        
        </div>
        </div>-->

   <div class="container">
      <div class="card bg-light">
               <div class="card-body align-content-center">   
                   <center>    <h6 id="Addlbl" runat="server" class="card-header text-white  bg-info ">Add Essential Educational Details (Chronological order)</h6></center>
                   <center>    <h6 id="H1" runat="server" class="card-header text-white  bg-danger ">“Irrespective of the essential qualification for the post, all acquired and or acquiring qualifications details should be entered”</h6></center>

        <div class="row">
         <div class="col-12">
            <center> <h5></h5></center>
        <center>
        <div class="row">
           
      
            
            <table class="table table-hover table-bordered">
            <thead>
                <tr>
                    <th scope="col"><asp:Label ID="Qualificationlbl" runat="server" Text="Qualification"></asp:Label></th>
                    <th scope="col"><asp:Label ID="DegreeNamelbl" runat="server" Text="Specialisation/Degree Name"></asp:Label></th>
                    <th scope="col"><asp:Label ID="MainSubjectlbl" runat="server" Text="Main Subject"></asp:Label></th>
                    <th scope="col"><asp:Label ID="Institutelbl" runat="server" Text="Institute/University/College Name"></asp:Label></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><asp:DropDownList ID="coursedropdown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="coursedropdown_SelectedIndexChanged">
    <asp:ListItem Value="0">--Select--</asp:ListItem>
    <asp:ListItem Value="SSC/SSLC/10th">SSC/SSLC/10th</asp:ListItem>
    <asp:ListItem Value="HSC/PUC/12th">HSC/PUC/12th</asp:ListItem>
    <asp:ListItem Value="ITI">ITI</asp:ListItem>
    <asp:ListItem Value="DIPLOMA">DIPLOMA</asp:ListItem>
    <asp:ListItem Value="UG">UG</asp:ListItem>
    <asp:ListItem Value="PG">PG</asp:ListItem>

</asp:DropDownList>
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="Select Qualification" ControlToValidate="coursedropdown" InitialValue="0" validationgroup="regpagegroup" runat="server" ForeColor="Red" Font-Size="Small" ID="RequiredFieldValidator9" /></td>
                    <td><asp:TextBox ID="nameofdegree" runat="server"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="Enter Name of the Degree" ControlToValidate="nameofdegree"  validationgroup="regpagegroup" runat="server" ForeColor="Red" Display="Dynamic" Font-Size="Small" ID="RequiredFieldValidator11" />
                         </td>
                    <td><asp:TextBox ID="subjecttxt" runat="server"></asp:TextBox> 
                        <br />
                         <asp:RequiredFieldValidator ErrorMessage="Enter Main Subject Name" ControlToValidate="subjecttxt"  validationgroup="regpagegroup" runat="server" ForeColor="Red" Display="Dynamic" ID="RequiredFieldValidator7" Font-Size="Small" />
                    </td>
                    <td><asp:TextBox ID="institutetxt" runat="server" Width="285px"></asp:TextBox> 
                        <br />
                         <asp:RequiredFieldValidator ErrorMessage="Enter Main Institute/University/College Name" ControlToValidate="institutetxt"  validationgroup="regpagegroup" runat="server" ForeColor="Red" Display="Dynamic" ID="RequiredFieldValidator8" Font-Size="Small" /> </td>
                </tr>

            </tbody>

            <thead>
                <tr>
                    <th scope="col"><asp:Label ID="Markslbl" runat="server" Text="Marks in Percentage"></asp:Label></th>
                    <th scope="col"><asp:Label ID="PassingYearlbl" runat="server" Text="Year of Passing"></asp:Label></th>
                    <th scope="col"><asp:Label ID="Divisionlbl" runat="server" Text="Division/Grade"></asp:Label></th>
                    <th scope="col">Click to Add Selected Educational Details</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <asp:TextBox ID="pmarkstext" runat="server" Height="30 px" Width="80px"></asp:TextBox> <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="pmarkstext"
                                                                                                                                   CultureInvariantValues="True" ErrorMessage="Enter Percentage" MaximumValue="100.00" MinimumValue="0.00" Type="Double" ValidationGroup="regpagegroup" CssClass="auto-style5"></asp:RangeValidator>
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="Enter Marks" ControlToValidate="pmarkstext"  validationgroup="regpagegroup" runat="server" ForeColor="Red" Display="Dynamic" Font-Size="Small" ID="RequiredFieldValidator12" />
                    </td>
                    <td>
                        <asp:TextBox ID="pyeartxt" runat="server" MaxLength="4" Height="30 px" Width="80px"></asp:TextBox>  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="pyeartxt"
                                                                                                                                                            ValidationExpression="^[0-9]+$" runat="server" ValidationGroup="regpagegroup" ErrorMessage="enter only year."></asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="pyeartxt" ID="RegularExpressionValidator2"
                                                        ValidationExpression="^[\s\S]{4,}$" runat="server" ValidationGroup="regpagegroup" ErrorMessage="Enter Year in Correct Formate."></asp:RegularExpressionValidator>
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="Enter Year" ControlToValidate="pyeartxt"  validationgroup="regpagegroup" runat="server" ForeColor="Red" Display="Dynamic" Font-Size="Small" ID="RequiredFieldValidator13" />
                    </td>
                    <td>
                        <asp:DropDownList ID="Courseclass" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="First Class">First Class</asp:ListItem>
                            <asp:ListItem Value="Second Class"> Second Class</asp:ListItem>
                            <asp:ListItem Value="Third Class">Third Class</asp:ListItem>
                            <asp:ListItem Value="First Class-with Distinction">First Class-with Distinction</asp:ListItem>
                            <asp:ListItem Value="First Class–Exemplary">First Class–Exemplary</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:RequiredFieldValidator ErrorMessage="Select Grade / Division" ControlToValidate="Courseclass" InitialValue="0" validationgroup="regpagegroup" runat="server" ForeColor="Red" Display="Dynamic" Font-Size="Small" ID="RequiredFieldValidator10" />
                    </td>
                    <td align="center"><asp:Button ID="Addbutton" runat="server" class="btn btn-info" Text="Add" OnClick="Addbutton_Click" validationgroup="regpagegroup" />
                        <br />
                        <asp:Label ID="EducationErrorinAddLbl" runat="server" Text="" CssClass="auto-style5"></asp:Label>
                    </td>
                </tr>
               

            </tbody>

        </table>
             
            </div>
        <div class="row">
            
               
             
                
        </div>
            
            </center>
             </div>
    </div>
                   </div>
          </div>
       </div>
   
        <div class="container ">
      <div class="card bg-light shadow-sm p-3 mb-5 bg-white rounded">
               <div class="card-body ">   
        <div class="row">
         <div class="col-12"> 
          <center>      <h6> </h6> </center>
          <center>    <h6 class="card-header text-white  bg-success ">Added Educational Details:</h6></center>  
           
             
            <center>
                <br />
                <asp:Panel ID="SchoolEducationPanel" runat="server">
            <asp:Table ID="Table1"  Height="150px" Width="1020px" BackColor="White" BorderColor="#336666"  BorderStyle="Double" BorderWidth="3px"  Font-Bold="False" Font-Size="10pt" GridLines="Horizontal" runat="server" CssClass="AspCell" >
                                                                    <asp:TableHeaderRow ID="schoolHeadRow" runat="server" class="table table-bordered">
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Qualification</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Group Name</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Main Subject</asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Institute/School Name</asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Marks in Percentage </asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Year of Passing </asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Division/Grade </asp:TableHeaderCell> 
                                                                         <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Delete </asp:TableHeaderCell> 
                                                                    </asp:TableHeaderRow>
                                                                   
                                                                    <asp:TableRow ID="sslcRow" runat="server" class="table table-bordered">
                                                                        <asp:TableCell CssClass="AspCell"> <asp:Label ID="ssl1" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ssl2" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ssl3" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ssl4" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ssl5" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ssl6" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ssl7" runat="server" Text="Label"></asp:Label>  </asp:TableCell>  
                                                                         <asp:TableCell CssClass="AspCell"> <asp:ImageButton ID="sslcDeleteBtn1" OnClick="sscdelete_Click" runat="server" ImageUrl="imgs/deleteicon.png" Width="22" Height="22" />  </asp:TableCell>
                                                                        
                                                                    </asp:TableRow>

                                                                       <asp:TableRow ID="hscRow" runat="server" class="table table-bordered">
                                                                         <asp:TableCell> <asp:Label ID="hsc1" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="hsc2" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="hsc3" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="hsc4" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="hsc5" runat="server" Text="Label"></asp:Label>  </asp:TableCell>  
                                                                         <asp:TableCell> <asp:Label ID="hsc6" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="hsc7" runat="server" Text="Label"></asp:Label>  </asp:TableCell>  
                                                                         <asp:TableCell CssClass="AspCell"> <asp:ImageButton ID="hscdeletebtn"  OnClick="hscdelete_Click"  runat="server" ImageUrl="imgs/deleteicon.png" Width="22" Height="22" />  </asp:TableCell>

                                                                    </asp:TableRow>

                                                                        <asp:TableRow ID="ITIRow" runat="server" class="table table-bordered">
                                                                        <asp:TableCell CssClass="AspCell"> <asp:Label ID="ITI1" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ITI2" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ITI3" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ITI4" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ITI5" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ITI6" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ITI7" runat="server" Text="Label"></asp:Label>  </asp:TableCell>  
                                                                         <asp:TableCell CssClass="AspCell"> <asp:ImageButton ID="ITIDeleteBtn" OnClick="ITIDeleteBtn_Click" runat="server" ImageUrl="imgs/deleteicon.png" Width="22" Height="22" />  </asp:TableCell>
                                                                        
                                                                    </asp:TableRow>
          
                 </asp:Table>
                    <br />
                    </asp:Panel>
                    <asp:Panel ID="CollegeEducationPanel" runat="server">
            <asp:Table ID="Table2"  Height="150px" Width="1012px" BackColor="White" BorderColor="#336666"  BorderStyle="Double" BorderWidth="3px"  Font-Bold="False" Font-Size="10pt" GridLines="Horizontal" runat="server" CssClass="AspCell" >

                                                                      <asp:TableHeaderRow ID="collegHeadRow" runat="server" class="table table-bordered">
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Qualification</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Specialization/Degree Name</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Main Subject</asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" >Institute/University/College Name</asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Marks in Percentage </asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Year of Passing </asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Division/Grade </asp:TableHeaderCell> 
                                                                           <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Delete </asp:TableHeaderCell> 
                                                                    </asp:TableHeaderRow>

                                                                       <asp:TableRow ID="dipRow" runat="server" class="table table-bordered">
                                                                        <asp:TableCell> <asp:Label ID="dip1" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="dip2" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="dip3" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="dip4" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="dip5" runat="server" Text="Label"></asp:Label>  </asp:TableCell> 
                                                                            <asp:TableCell> <asp:Label ID="dip6" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="dip7" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:ImageButton ID="ImageButton2" OnClick="dipdelete_Click" runat="server" ImageUrl="imgs/deleteicon.png" Width="22" Height="22" />  </asp:TableCell>
                                                                    </asp:TableRow>

                                                                       <asp:TableRow ID="ugRow" runat="server" class="table table-bordered">
                                                                        <asp:TableCell > <asp:Label ID="ug1" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ug2" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ug3" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ug4" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ug5" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                           <asp:TableCell> <asp:Label ID="ug6" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ug7" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:ImageButton ID="ImageButton3"  OnClick="ugdelete_Click" runat="server" ImageUrl="imgs/deleteicon.png" Width="22" Height="22" />  </asp:TableCell>
                                                                    </asp:TableRow >
                                                                       <asp:TableRow ID="pgRow" runat="server" class="table table-bordered">
                                                                        <asp:TableCell> <asp:Label ID="pg1" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="pg2" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="pg3" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="pg4" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="pg5" runat="server" Text="Label"></asp:Label>  </asp:TableCell>  
                                                                           <asp:TableCell> <asp:Label ID="pg6" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="pg7" runat="server" Text="Label"></asp:Label>  </asp:TableCell>  
                                                                        <asp:TableCell CssClass="AspCell"> <asp:ImageButton ID="ImageButton4" OnClick="pgdelete_Click" runat="server" ImageUrl="imgs/deleteicon.png" Width="22" Height="22" />  </asp:TableCell>
                                                                        </asp:TableRow>
                
                <asp:TableRow ID="noentryRow" ><asp:TableCell HorizontalAlign="Center">
                  <asp:Label ID="NoEntrylbl" runat="server" Text="" Font-Bold="True" ForeColor="#009933"></asp:Label></asp:TableCell></asp:TableRow>
                                                                  
                                                                </asp:Table>
                    </asp:Panel>

                

    </center> </div>
                </div>
                   <hr class="solid">
                        <!-- Additional Qualifcation start  -->
                       <div class="row">
                       <div class="col-12">                      
                                            <center>    <h6 class="card-header text-white  bg-primary ">Add Extra Qualifaction Details :</h6></center>  
                    
                                <asp:Panel ID="AddQualPanel" runat="server">
                                                               <br />
                                    
                           <table class="table table-hover table-bordered">
                                <thead>
                                    <tr>
                                <th scope="col">Type of Qualification</th>
                                <th scope="col">Name of the Qualification </th>
                                <th scope="col">Institute / Board</th>
                                <th scope="col">Completed Year</th>
                                   </tr>
                                   


                                     </thead>
                               <tr>
                                   <td><asp:TextBox ID="Qualf1" runat="server" Width="218px"></asp:TextBox>  </td>
                                   <td><asp:TextBox ID="Qualf2" runat="server"></asp:TextBox>   </td>
                                   <td><asp:TextBox ID="Qualf3" runat="server" Width="335px"> </asp:TextBox></td>
                                   <td><asp:TextBox ID="Qualf4" runat="server"></asp:TextBox>  </td>
                               </tr>

                               <tr>
                                   <td><asp:TextBox ID="Qualf5" runat="server" Width="218px"></asp:TextBox> </td>
                                   <td><asp:TextBox ID="Qualf6" runat="server"></asp:TextBox>  </td>
                                   <td><asp:TextBox ID="Qualf7" runat="server" Width="335px"></asp:TextBox> </td>
                                   <td><asp:TextBox ID="Qualf8" runat="server"></asp:TextBox>  </td>
                               </tr>
                               <tr>
                                   <td><asp:TextBox ID="Qualf9" runat="server" Width="218px"></asp:TextBox> </td>
                                   <td><asp:TextBox ID="Qualf10" runat="server"></asp:TextBox>  </td>
                                   <td><asp:TextBox ID="Qualf11" runat="server" Width="335px"></asp:TextBox>  </td>
                                   <td><asp:TextBox ID="Qualf12" runat="server"></asp:TextBox>  </td>
                               </tr>
                               <tr>
                                   <td><asp:TextBox ID="Qualf13" runat="server" Width="218px"></asp:TextBox>  </td>
                                   <td><asp:TextBox ID="Qualf14" runat="server"></asp:TextBox>   </td>
                                   <td><asp:TextBox ID="Qualf15" runat="server" Width="335px"></asp:TextBox>  </td>
                                   <td><asp:TextBox ID="Qualf16" runat="server"></asp:TextBox>  </td>
                               </tr>
                                
                               </table>
                                    </asp:Panel>
                                     
                       </div>
                   </div> 

                   <!-- Additional Qualifcation end  -->

                    <!-- Phd Panel  start 
                   <br />
               <hr class="solid"> -->
                    <div class="row">
                       <div class="col-12">                      
                      <asp:Label ID="PhdLable" runat="server" Text="*Phd Details:"> </asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="phddrop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="phddrop_SelectedIndexChanged" >
                                <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="Yes">Yes</asp:ListItem>
                         <asp:ListItem Value="No">No</asp:ListItem>
                                                                               </asp:DropDownList>
                                                    
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="phddrop" ErrorMessage="*" ForeColor="Red" InitialValue="0" validationgroup="educationigroup" />
                           
                                <asp:Panel ID="PhdPanel" runat="server">
                                                               <br />
                                    
                           <table class="table table-hover table-bordered">
                                <thead>
                                    <tr>
                                <th scope="col">Ph.D Thesis Title</th>
                                <th scope="col">Month & Year of PhD awarding</th>
                                <th scope="col">Name and address of the University from where  the Ph.D is completed</th>
                                <th scope="col">Breif the Title</th>
                                   </tr>
                                     </thead>
                               <tr>
                                   <td><asp:TextBox ID="phdtxt1" runat="server" Width="218px"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator4" validationgroup="educationigroup" runat="server" ErrorMessage="*"  ControlToValidate="phdtxt1" ForeColor="Red" ></asp:RequiredFieldValidator> </td>
                                   <td><asp:TextBox ID="phdtxt2" runat="server"></asp:TextBox>  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" validationgroup="educationigroup" runat="server" ErrorMessage="*"  ControlToValidate="phdtxt2" ForeColor="Red" ></asp:RequiredFieldValidator> </td>
                                   <td><asp:TextBox ID="phdtxt3" runat="server" Width="335px"></asp:TextBox>  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" validationgroup="educationigroup" runat="server" ErrorMessage="*"  ControlToValidate="phdtxt3" ForeColor="Red" ></asp:RequiredFieldValidator></td>
                                   <td><asp:TextBox ID="phdtxt4" runat="server"></asp:TextBox>  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" validationgroup="educationigroup" runat="server" ErrorMessage="*"  ControlToValidate="phdtxt4" ForeColor="Red" ></asp:RequiredFieldValidator></td>
                               </tr>
                                
                               </table>
                                    </asp:Panel>
                                     
                       </div>
                   </div> 

                    <!-- Additional Qualifcation end  -->
                   <br />
                      <!-- Additional Qualifcation start 
                  <hr class="solid"> -->
                     <div class="row">
                       <div class="col-12">                      
                          
                           <asp:Label ID="GateLbl" runat="server" Text="*GATE Qualified :"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="GateQualDrop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="GateQualDrop_SelectedIndexChanged" >
                                <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="Yes">Yes</asp:ListItem>
                         <asp:ListItem Value="No">No</asp:ListItem>
                                                                               </asp:DropDownList>
                                                    
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="GateQualDrop" ErrorMessage="*" ForeColor="Red" InitialValue="0" validationgroup="educationigroup" />
                           
                                <asp:Panel ID="GateQualPanel" runat="server">
                                                               <br />
                           <table class="table table-hover table-bordered">
                                <thead>
                                    <tr>
                                <th scope="col">Gate Marks in Percentage</th>
                                <th scope="col">Month & Year</th>
                                <th scope="col">Branch</th>
                                
                                   </tr>
                                     </thead>
                               <tr>
                                   <td><asp:TextBox ID="GateMarkstxt" runat="server"></asp:TextBox>  <asp:RequiredFieldValidator ID="RequiredFieldValidator14" validationgroup="educationigroup" runat="server" ErrorMessage="*"  ControlToValidate="GateMarkstxt" ForeColor="Red" ></asp:RequiredFieldValidator> 
                                       <br />
                                       <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="GateMarkstxt" CultureInvariantValues="True" ErrorMessage="Enter Percentage" ForeColor="Red" MaximumValue="100.00" MinimumValue="0.00" Type="Double" ValidationGroup="educationigroup"></asp:RangeValidator>
                                   </td>
                                   <td><asp:TextBox ID="Gatepassyeartxt" runat="server"></asp:TextBox>  <asp:RequiredFieldValidator ID="RequiredFieldValidator15" validationgroup="educationigroup" runat="server" ErrorMessage="*"  ControlToValidate="Gatepassyeartxt" ForeColor="Red" ></asp:RequiredFieldValidator> </td>
                                   <td><asp:DropDownList ID="GatebranchDrop" runat="server" AutoPostBack="True" >
                                <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="AE">Aerospace Engineering</asp:ListItem>
                         <asp:ListItem Value="AG">Agricultural Engineering</asp:ListItem>
                                       <asp:ListItem Value="AR">Architecture and Planning (New Pattern)</asp:ListItem>
                                       <asp:ListItem Value="BM">Biomedical Engineering</asp:ListItem>
                                       <asp:ListItem Value="BT">Biotechnology</asp:ListItem>
                                       <asp:ListItem Value="CE">Civil Engineering</asp:ListItem>
                                       <asp:ListItem Value="CH">Chemical Engineering</asp:ListItem>
                                       <asp:ListItem Value="CS">Computer Science & Information Technology</asp:ListItem>
                                       <asp:ListItem Value="CY">Chemistry</asp:ListItem>
                                       <asp:ListItem Value="EC">Electronics and Communication Engineering</asp:ListItem>

                                       <asp:ListItem Value="EE">Electrical Engineering</asp:ListItem>
                                       <asp:ListItem Value="ES">Environmental Science & Engineering</asp:ListItem>
                                        <asp:ListItem Value="EY">Ecology and Evolution</asp:ListItem>
                                        <asp:ListItem Value="GE">Geomatics Engineering</asp:ListItem>
                                        <asp:ListItem Value="GG">Geology and Geophysics</asp:ListItem>
                                        <asp:ListItem Value="IN">Instrumentation Engineering</asp:ListItem>
                                        <asp:ListItem Value="MA">Mathematics</asp:ListItem>
                                        <asp:ListItem Value="ME">Mechanical Engineering</asp:ListItem>
                                       <asp:ListItem Value="MN">Mining Engineering</asp:ListItem>
                                       <asp:ListItem Value="MT">Metallurgical Engineering</asp:ListItem>
                                       <asp:ListItem Value="NM">Naval Architecture and Marine Engineering</asp:ListItem>
                                       <asp:ListItem Value="PE">Petroleum Engineering</asp:ListItem>
                                       <asp:ListItem Value="PH">Physics</asp:ListItem>
                                       <asp:ListItem Value="PI">Production and Industrial Engineering</asp:ListItem>
                                       <asp:ListItem Value="ST">Statistics</asp:ListItem>
                                       <asp:ListItem Value="TF">Textile Engineering and Fibre Science</asp:ListItem>
                                       <asp:ListItem Value="XE">Engineering Sciences</asp:ListItem>
                                       <asp:ListItem Value="XH">Humanities & Social Science</asp:ListItem>
                                       <asp:ListItem Value="XL">Life Science</asp:ListItem>



                                                                               </asp:DropDownList>
                                       <br />
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="GatebranchDrop" Display="Dynamic" ErrorMessage="Confirm/Select Branch" Font-Size="Small" ForeColor="Red" InitialValue="0" validationgroup="educationigroup" />
                                   </td>
                                  
                               </tr>
                                
                               </table>
                                    </asp:Panel>
                                     
                       </div>
                   </div> 
                     <!-- Additional Qualifcation end  -->


              </div>
        </div>
        </div>
                      
                    <!-- Phd Panel  end  -->
                   

    <div class="container">
        <center>
              <asp:Label ID="countlbl" runat="server" Text=""></asp:Label>
              <asp:Label ID="errorlbl" runat="server" Text=""></asp:Label>
            </center>
    </div>

    <div class="container">
        <div class="row">
            <div class="col-12 align-items-center">
                                 <asp:Button ID="goBackbtn" CssClass="savebtncolor" runat="server" Text="Go Back to Home" OnClick="goBackbtn_Click"  />

                 <center>                     
                <asp:Button ID="SaveEducationbtn" runat="server" CssClass="savebtncolor"  validationgroup="educationigroup" Text="Save and Continue" OnClick="SaveEducationbtn_Click" />                    
                </center>
                 <br />
                </div>
           
        </div>
    </div>
               
</asp:Content>
