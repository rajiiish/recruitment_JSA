<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="education.aspx.cs" Inherits="recruitment.education" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
         .stepfont
        {
            color: green;
     text-shadow: 2px 2px 5px green;
        font-size: 100%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
    <div class="container">
        <div class="bg-light  text-center">
        <p >eNote: Don't input any special characters or punctuation marks. Input only alphanumeric characters.</br>
        Personal Details (fields marked with * are mandatory)</p>
        <p >Candidate Registration Number:
              <asp:Label ID="regidlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="Blue"></asp:Label>
       Application ID: <asp:Label ID="appidnolbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label> 
            Post Applying For: <asp:Label ID="applyhpostlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label>  </p>
           Today's Date: <asp:Label ID="datetimelbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label>
      </div>

    </div>
        </section>

     <%-- title ends--%>

    <div class="container">
        <table class="table ">
  
  <tbody>
    <tr>
         <td>1.PERSONAL DETAILS<strong>--></strong></td> 
         <td class="stepfont">2.EDUCATION DETAILS <strong>--></strong> </td>  
         <td >3.EXPERIENCE DETAILS <strong>--></strong></td>  
         <td>4.OTHER INFORMATION <strong>--></strong></td>  
         <td ><font> 5.FILES UPLOAD </font><strong>--></strong></td>  
        
    </tr>
  </tbody>
</table>
    </div>
    </br>
    <div class="container">
        <div class="text-center">
    
<table class="table table-bordered">

         <thead>
    <tr>
      <th scope="col">Course</th>
      <th scope="col">Subject</th>
      <th scope="col">Name of the Board/Institute</th>
      <th scope="col">Percentage of Marks/</th>
         <th scope="col">Passed Year</th>
         <th scope="col">Class</th>
    </tr>
  </thead>
            <tr>               
               <td><asp:DropDownList ID="coursedropdown" runat="server">
                   <asp:ListItem>SSLC</asp:ListItem>
                   <asp:ListItem>HSC</asp:ListItem>
                   <asp:ListItem>DIPLOMA</asp:ListItem>
                   <asp:ListItem>UG</asp:ListItem>
                   <asp:ListItem>PG</asp:ListItem>
                   </asp:DropDownList></td>
                 <td><asp:TextBox ID="subjecttxt" runat="server"></asp:TextBox></td>
                 <td><asp:TextBox ID="institutetxt" runat="server"></asp:TextBox></td>
                 <td><asp:TextBox ID="pmarkstext" runat="server" Height="30 px" Width="100px"></asp:TextBox></td>
                 <td><asp:TextBox ID="pyeartxt" runat="server" Height="30 px" Width="100px"></asp:TextBox></td>
                <td><asp:TextBox ID="clastxt" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Button ID="Addbutton" runat="server" Text="Add" OnClick="Addbutton_Click"  /></td>
            </tr>
        </table>
    
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"   EmptyDataText="No records has been added." CellPadding="4" ForeColor="#333333" GridLines="None" Height="178px" Width="1108px" OnRowDeleting="GridView1_RowDeleting" >
        <AlternatingRowStyle BackColor="White" />
    <Columns>
        

        <%--<asp:BoundField DataField="can_regno" HeaderText="can_regno" SortExpression="can_regno" />
        
        <asp:BoundField DataField="appregno" HeaderText="appregno" SortExpression="appregno" />--%>
        
        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="id" />
        <asp:BoundField DataField="course" HeaderText="Course" ReadOnly="True" SortExpression="course" />
        <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
        <asp:BoundField DataField="Institute" HeaderText="Name of the Board/Institute" SortExpression="Institute" />
        <asp:BoundField DataField="Pmarks" HeaderText="Passed Year" SortExpression="Pmarks" />
           <asp:BoundField DataField="PassYear" HeaderText="Passed Year" SortExpression="PassYear" />
        <asp:BoundField DataField="Class" HeaderText="Class" SortExpression="Class" />
        <asp:BoundField DataField="can_regno" HeaderText="can_regno" SortExpression="can_regno" />
          
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
 
       
            <br />
 
       
    <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineapplicationConnectionString1 %>" SelectCommand="SELECT * FROM [educational]"></asp:SqlDataSource>--%>
            
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        &nbsp;<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        </div>
        </div>
    <div class="container">
        <div class="row">
          <center>  <asp:Button ID="continue" runat="server" Text="Continue and Save" /></center>
        </div>
    </div>
</asp:Content>
