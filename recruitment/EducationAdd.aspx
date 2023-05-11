<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EducationAdd.aspx.cs" Inherits="recruitment.EducationAdd" %>
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
      <div class="card bg-light">
               <div class="card-body">   
                   <center>    <h6 class="card-header text-white  bg-info ">Add Essential Educational Details (Chronological order)</h6></center>
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
               <td><asp:DropDownList ID="coursedropdown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="coursedropdown_SelectedIndexChanged">
                   <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                   <asp:ListItem Value="SSC/SSLC/10th">SSC/SSLC/10th</asp:ListItem>
                   <asp:ListItem Value="HSC/PUC/12th">HSC/PUC/12th</asp:ListItem>
                   <asp:ListItem Value="DIPLOMA">DIPLOMA</asp:ListItem>
                   <asp:ListItem Value="UG">UG</asp:ListItem>
                   <asp:ListItem Value="PG">PG</asp:ListItem>

                   </asp:DropDownList></td>
                <td><asp:TextBox ID="nameofdegree" runat="server"></asp:TextBox></td>
                 <td><asp:TextBox ID="subjecttxt" runat="server"></asp:TextBox></td>
                 <td><asp:TextBox ID="institutetxt" runat="server"></asp:TextBox></td>
                </tr>
                         <tr>
      <th scope="col">Marks in Percentage</th>
         <th scope="col">Year of Passing</th>
         <th scope="col">Division/Grade</th>
    </tr>
            <tr>
                 <td><asp:TextBox ID="pmarkstext" runat="server" Height="30 px" Width="80px"></asp:TextBox> <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="pmarkstext"
            CultureInvariantValues="True" ErrorMessage="Enter Percentage" MaximumValue="100.00"  MinimumValue="0.00" Type="Double" ValidationGroup="regpagegroup"></asp:RangeValidator></td>
                 <td><asp:TextBox ID="pyeartxt" runat="server" MaxLength="4" Height="30 px" Width="80px"></asp:TextBox>  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="pyeartxt" 
                     ValidationExpression="^[0-9]+$" runat="server"  ValidationGroup="regpagegroup" ErrorMessage="enter only year."></asp:RegularExpressionValidator>
                     <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "pyeartxt" ID="RegularExpressionValidator2" 
                         ValidationExpression = "^[\s\S]{4,}$" runat="server" ValidationGroup="regpagegroup" ErrorMessage="Enter Year in Correct Formate."></asp:RegularExpressionValidator>
                 </td>

                 <td><asp:DropDownList ID="Courseclass" runat="server" AutoPostBack="True">
                     <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                   <asp:ListItem  Value= "First Class">First Class</asp:ListItem>
                   <asp:ListItem  Value= "Second Class"> Second Class</asp:ListItem>
                   <asp:ListItem  Value="Third Class">Third Class</asp:ListItem>
                   <asp:ListItem  Value="First Class-with Distinction">First Class-with Distinction</asp:ListItem>
                   <asp:ListItem  Value="First Class–Exemplary">First Class–Exemplary</asp:ListItem>
                   </asp:DropDownList></td>
               
                <td>
                    <asp:Button ID="Addbutton" runat="server" class="btn btn-info" Text="Add" OnClick="Addbutton_Click" validationgroup="regpagegroup" /></td>
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
                   </div>
          </div>
       </div>
    <br />
    <br />
        <div class="container ">
      <div class="card bg-light">
               <div class="card-body">   
        <div class="row">
         <div class="col-12"> 
          <center>      <h6> </h6> </center>
          <center>    <h6 class="card-header text-white  bg-primary ">Added Educational Details:</h6></center>  
            
            <center>
                <asp:GridView ID="GridView1"  runat="server"  class="table table-bordered  " AutoGenerateColumns="False" DataKeyNames="id"  EmptyDataText="No records for Educational Qualification has been added."  CellPadding="0" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound" Font-Bold="False" Font-Size="10pt">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
        

        <%--<asp:BoundField DataField="can_regno" HeaderText="can_regno" SortExpression="can_regno" />
        
        <asp:BoundField DataField="appregno" HeaderText="appregno" SortExpression="appregno" />--%>
        
        <asp:BoundField DataField="id" HeaderText="Education ID" ReadOnly="false" visible="false" SortExpression="id" />

       

    <%--    <asp:BoundField DataField="can_regno" HeaderText="can_regno" ReadOnly="True" SortExpression="can_regno" />--%>
       
        <asp:BoundField DataField="appregno" HeaderText="App. No." SortExpression="appregno" />

        <asp:BoundField DataField="course" HeaderText="Degree/Qualification" SortExpression="course" />

         <asp:BoundField DataField="coursename" HeaderText="Specialization/Degree Name" SortExpression="coursename" />

           <asp:BoundField DataField="Subject" HeaderText="Main Subject" SortExpression="Subject" />

        <asp:BoundField DataField="Institute" HeaderText="Institute Name" SortExpression="Institute" />

        <asp:BoundField DataField="Pmarks" HeaderText="% Marks/Grade" SortExpression="Pmarks" />

         

        <asp:BoundField DataField="PassYear" HeaderText="Year Passed" SortExpression="PassYear" />
          
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID  ="LinkButton1" runat="server" OnClick="LinkButton1_Click">Delete</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        
    </Columns>

                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />

                </asp:GridView>

                

    </center> </div>
                </div>

                    <!-- Phd Panel  start  -->
                   <br />
                   <div class="row">
                       <div class="col-12">                      
                           <lable><strong>*Phd Details: </strong></lable>&nbsp;<asp:DropDownList ID="phddrop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="phddrop_SelectedIndexChanged1">
                                <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="Yes">Yes</asp:ListItem>
                         <asp:ListItem Value="No">No</asp:ListItem>
                                                                               </asp:DropDownList>
                                                    
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="phddrop" ErrorMessage="*" ForeColor="Red" InitialValue="0" validationgroup="educationigroup" />
                           
                                <asp:Panel ID="PhdPanel" runat="server">
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
                                   <td><asp:TextBox ID="phdtxt1" runat="server"></asp:TextBox> <asp:RequiredFieldValidator ID="RequiredFieldValidator4" validationgroup="educationigroup" runat="server" ErrorMessage="*"  ControlToValidate="phdtxt1" ForeColor="Red" ></asp:RequiredFieldValidator> </td>
                                   <td><asp:TextBox ID="phdtxt2" runat="server"></asp:TextBox>  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" validationgroup="educationigroup" runat="server" ErrorMessage="*"  ControlToValidate="phdtxt2" ForeColor="Red" ></asp:RequiredFieldValidator> </td>
                                   <td><asp:TextBox ID="phdtxt3" runat="server"></asp:TextBox>  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" validationgroup="educationigroup" runat="server" ErrorMessage="*"  ControlToValidate="phdtxt3" ForeColor="Red" ></asp:RequiredFieldValidator></td>
                                   <td><asp:TextBox ID="phdtxt4" runat="server"></asp:TextBox>  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" validationgroup="educationigroup" runat="server" ErrorMessage="*"  ControlToValidate="phdtxt4" ForeColor="Red" ></asp:RequiredFieldValidator></td>
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
