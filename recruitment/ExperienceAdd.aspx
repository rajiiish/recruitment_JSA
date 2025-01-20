<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ExperienceAdd.aspx.cs" Inherits="recruitment.ExperienceAdd" %>
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

  }

        .table-b > thead > tr > th{

    border:2px solid green;
}
.table-b > tbody > tr > td{

    border:1px solid green;
}
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>

    <script type="text/javascript">
        $(function () {
            $('#fromtxt').datepicker({
                format: "dd/mm/yyyy"
            });
        });
    
         document.addEventListener("DOMContentLoaded", function (event) {
             var scrollpos = localStorage.getItem('scrollpos');
             if (scrollpos) window.scrollTo(0, scrollpos);
         });

         window.onbeforeunload = function (e) {
             localStorage.setItem('scrollpos', window.scrollY);
         };
     </script>


    
    <div class="container">
        <div class="bg-light  text-center">
        <p >Note: Don't input any special characters or punctuation marks. Input only alphanumeric characters.<br/>
            (fields marked with * are mandatory)</p>
        <p >Candidate Registration Number:
              <asp:Label ID="regidlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="Blue"></asp:Label>
       Application ID: <asp:Label ID="appidnolbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label> 
            Post Applying For: <asp:Label ID="applyhpostlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label>  </p>
      </div>

    </div>

  <!--  <div class="container ">
            <div class="card bg-light">
               <div class="card-body"> 
            <table class="table titlemenufont">
  
  <tbody>
      <tr>
         <td > <strong><img src="imgs/1.PNG" class="auto-style3" /></strong>PERSONAL DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
         <td> <strong><img src="imgs/2.PNG" class="auto-style3" /></strong>EDUCATION DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 

                 <td  class="stepfont"> <strong><img src="imgs/ticon.PNG" class="auto-style3" /></strong>EXPERIENCE DETAILS<strong><img src="imgs/icons8_forward_48px.PNG" class="auto-style3" /></strong></td> 
                          <td > <strong><img src="imgs/4.PNG" class="auto-style3" /></strong>PROFESSIONAL INFORMATION <strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 

                 <td > <strong><img src="imgs/5.PNG" class="auto-style3" /></strong>OTHER INFORMATION<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
                 <td > <strong><img src="imgs/6.PNG" class="auto-style3" /></strong>FILES UPLOAD<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
               
    </tr>
  </tbody>
</table>
                      </div>
         </div>
            </div>-->

    
    <div class="container">
         <div class="card bg-light">
               <div class="card-body"> 
                   <div class="row">
                       <div class="col-12">
                           <center>    <h6 class="card-header text-white  bg-info ">Add Experience Details (All Experience Details Including Service Details)</h6></center>
                 <center> <h5></h5></center> 
                 </div><br />
            <div class="col-12">
                <br />
                <label>*Are You Experienced? If Yes, Give Details of the Experience:</label> &nbsp
                <asp:DropDownList ID="expdetailsdrop"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="expdetailsdrop_SelectedIndexChanged" >
                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="Yes">Yes</asp:ListItem>
                         <asp:ListItem Value="No">No</asp:ListItem>
                </asp:DropDownList>
            </div>
            </div>
                   <asp:Panel ID="exppanel" runat="server">
                    
         <div class="row">
             
             <div class="col-12">
        <div class="text-center">
    
<table class="table table-hover table-bordered">

        
            <tr align="center">               
                                
                 <td><label>Name of the Employer:</label> <asp:TextBox ID="employertxt" runat="server"  Height="30 px" Width="350px"></asp:TextBox></td>
                 <td><label>Designation or Position or Grade:</label><asp:TextBox ID="designationtxt" runat="server" Height="30 px" Width="350px"></asp:TextBox></td>
                 <td><label>Employment Type:</label>
                     
                     <asp:DropDownList ID="emptypetxt" runat="server">
                         <asp:ListItem>--Select--</asp:ListItem>
                   <asp:ListItem>Government/PSU </asp:ListItem>
                   <asp:ListItem>Acadamic</asp:ListItem>
                   <asp:ListItem>Research</asp:ListItem>
                   <asp:ListItem>Industry</asp:ListItem>
                   <asp:ListItem>Other Sectors</asp:ListItem>
                   
                   </asp:DropDownList>
                 </td>
                
            </tr>


    
    <tr align="center">
         <td >    <lable>Date of Joining:</lable> <asp:TextBox ID="fromtxt" runat="server" Height="30 px" Width="250px" Format="dd/MM/yyyy" class="form-control" AutoPostBack="true" TextMode="Date" placeholder="" value=""  OnTextChanged="fromtxt_TextChanged"></asp:TextBox> </td>
        
                <td> <lable>Date of Leaving: (Enter Current Date in case of working presently)</lable><br />
                                    
                        <asp:TextBox ID="totxt" runat="server" AutoPostBack="true" class="form-control" Format="dd/MM/yyyy" Height="30 px" OnTextChanged="totxt_TextChanged" placeholder="" TextMode="Date" value="" Width="250px"></asp:TextBox>
                   
                    </td>
                <td><lable >Total Exp:</lable><br /><asp:Label ID="totalexptxt" runat="server" Text="0" Font-Bold="True" ForeColor="#006600"></asp:Label></td>
                
    </tr>
  <tr align="center">
        <td colspan="2"><lable> Details and Nature of Work: (350 characters only allowed) (Optional)</lable><br /><asp:TextBox ID="expbrieftxt" runat="server"  Height="100px" Width="695px" TextMode="MultiLine" MaxLength="350"></asp:TextBox>
            
            <br />
            
        </td>

       <td><br /><asp:Button ID="Addbutton" runat="server" class="btn btn-info" Text="Add" OnClick="Addbutton_Click"  /></td>

    </tr>
        </table>
    </div>
                 </div>
             </div>
                       </asp:Panel>
        </div>
</div>  
         </div>
       
      
             
    <div class="container">
        <div class="card bg-light">
               <div class="card-body"> 
                       
         <div class="row">
             <div class="col">
 <center>    <h6 class="card-header text-white  bg-primary ">Added Experience Details</h6></center>
        <div class="text-center">
<center>
    <asp:GridView ID="GridView1" runat="server" class="table table-bordered " AutoGenerateColumns="False" DataKeyNames="id"  EmptyDataText="No records has been added." CellPadding="0" ForeColor="#333333" GridLines="None" Height="85px" Width="1068px" OnRowDeleting="GridView1_RowDeleting" Font-Size="10pt" OnRowDataBound="GridView1_RowDataBound" >
        <AlternatingRowStyle BackColor="White" />
    <Columns>
        

        <%--<asp:BoundField DataField="can_regno" HeaderText="can_regno" SortExpression="can_regno" />
        
        <asp:BoundField DataField="appregno" HeaderText="appregno" SortExpression="appregno" />--%>
        
        <asp:BoundField DataField="id" HeaderText="Job ID" ReadOnly="false" visible="false" SortExpression="id" />
        <asp:BoundField DataField="employer" HeaderText="Name of the employer" ReadOnly="True" SortExpression="employer" />
       
        <asp:BoundField DataField="designation" HeaderText="Designation / Post Held" SortExpression="designation" />
        <asp:BoundField DataField="emptype" HeaderText="Employment Type" SortExpression="emptype" />
           <asp:BoundField DataField="joindate" HeaderText="Joining Date" SortExpression="joindate" />
        <asp:BoundField DataField="leavedate" HeaderText="Releaving Date" SortExpression="leavedate" />
        <asp:BoundField DataField="totalexp" HeaderText="Total Exp" SortExpression="leavedate" />
          
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
 
   </center>         


    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineapplicationConnectionString1 %>" SelectCommand="SELECT * FROM [educational]"></asp:SqlDataSource>--%>
      
       </div>
                 </div>
             </div>
</div>                   </div>
        
</div>
    <br/>
    
   
        <div class="container">
        <div class="row">
            <div class="col-12 align-items-center">
                                 <asp:Button ID="goBackbtn" CssClass="savebtncolor" runat="server" Text="Go Back to Home" OnClick="goBackbtn_Click"   />

                 <center>
                <asp:Button ID="SaveEducationbtn" runat="server" CssClass="savebtncolor" Text="Save and Continue" OnClick="SaveEducationbtn_Click" />
                </center>
                </div>
            <div class="row">
                <div class="col-12 align-items-center">
                    </div>
            </div>
            <br />
            <br />
        </div>
    </div>
         
</asp:Content>
