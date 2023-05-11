<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddEducationDetails.aspx.cs" Inherits="recruitment.AddEducationDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <div class="container">
        <center>
        <div class="row">
        <table class="table table-bordered">

         <thead>
    <tr>
      <th scope="col">Qualification</th>
      <th scope="col">Subject/ Specialization</th>
      <th scope="col">College Name</th>
      <th scope="col">Marks in Percentage</th>
         <th scope="col">Month & Year of Passing</th>
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
                 <td><asp:TextBox ID="pmarkstext" runat="server" Height="30 px" Width="80px"></asp:TextBox></td>
                 <td><asp:TextBox ID="pyeartxt" runat="server" Height="30 px" Width="80px"></asp:TextBox></td>

                 <td><asp:DropDownList ID="DropDownList2" runat="server">
                   <asp:ListItem>First Class</asp:ListItem>
                   <asp:ListItem>Second Class</asp:ListItem>
                   <asp:ListItem>Third Class</asp:ListItem>
                   <asp:ListItem>First Class-with Distinction</asp:ListItem>
                   <asp:ListItem>First Class–Exemplary</asp:ListItem>
                   </asp:DropDownList></td>
               
                <td>
                    <asp:Button ID="Addbutton" runat="server" class="btn btn-info" Text="Add" OnClick="Addbutton_Click"  /></td>
            </tr>
        </table>
            </div>
        <div class="row">
            
                <div class="col-12">
            <asp:Label ID="validatelbl" runat="server" ForeColor="#FF3300" ></asp:Label>
                    </div>
                
        </div>
            </center>
    </div>
        <div class="container">
            <center>
        <asp:GridView ID="GridView1" runat="server"  EmptyDataText="No records has been added." BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Height="65px" Width="1000px" OnDataBound="GridView1_DataBound">
            <Columns>
                <asp:BoundField DataField="can_regno" HeaderText="can_regno" SortExpression="can_regno" />
                <asp:BoundField DataField="appregno" HeaderText="appregno" SortExpression="appregno" />
                <asp:TemplateField HeaderText="course" SortExpression="course">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("course") %>'>
                            <asp:ListItem Text ="SSLC" Value="SSLC"></asp:ListItem>
                            <asp:ListItem Text ="HSC" Value="HSC"></asp:ListItem>
                            <asp:ListItem Text ="DIPLOMA" Value="DIPLOMA"></asp:ListItem>
                            <asp:ListItem Text ="UG" Value="UG"></asp:ListItem>
                            <asp:ListItem Text ="PG" Value="PG"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Course Type" ControlToValidate="DropDownList1"
                            Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                         <asp:Label ID="lable1" runat="server" Text='<%# Bind("course") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Subject" SortExpression="Subject">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Subject") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Subject is Required" ControlToValidate="TextBox1"
                            Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Subject") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Institute" SortExpression="Institute">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Institute") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Institute name is Required" ControlToValidate="TextBox2"
                           Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Institute") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Pmarks" SortExpression="Pmarks">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Pmarks") %>'></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Percentage of marks is Required" ControlToValidate="TextBox3"
                           Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Pmarks") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PassYear" SortExpression="PassYear">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("PassYear") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Passed year is Required" ControlToValidate="TextBox4"
                           Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("PassYear") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Class" SortExpression="Class">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Class") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Class is Required" ControlToValidate="TextBox5"
                           Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Class") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" />
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#000066" HorizontalAlign="Left" BackColor="White" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
                
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="red" />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="deleteEducation" 
            SelectMethod="GetAllEducationsData" TypeName="recruitment.EducationDataAccessLayer" UpdateMethod="updateEducation">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="can_regno" Type="String" />
                <asp:Parameter Name="appregno" Type="String" />
                <asp:Parameter Name="course" Type="String" />
                <asp:Parameter Name="Subject" Type="String" />
                <asp:Parameter Name="Institute" Type="String" />
                <asp:Parameter Name="Pmarks" Type="String" />
                <asp:Parameter Name="PassYear" Type="String" />
                <asp:Parameter Name="Class" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </center>
                </div>

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
                     
                <asp:Button ID="SaveEducationbtn" runat="server" class="btn btn-primary" Text="Save and Continue" OnClick="SaveEducationbtn_Click" />
                </center>
                </div>
            <div class="row">
                <div class="col-12 align-items-center">
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
