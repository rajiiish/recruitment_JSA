<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="FilterbyMark.aspx.cs" Inherits="recruitment.FilterbyMark" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
 

  body
    {
        font-family: Arial;
        font-size: 10pt;
    }

 
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        
             <br />
            
        <div class="row">
            <div class="col-12">
                <div class="card border-info">
                    <div class="card-header">
    <ul class="nav nav-tabs card-header-tabs">
      <li class="nav-item">
               <a class="nav-link" href="FilterbyPost.aspx">Filter By Post</a>

      </li>
      <li class="nav-item">
          <a class="nav-link active btn-info" href="FilterbyMark.aspx">Filter By Marks</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="FilterbyCast.aspx">Filter By Cast </a>
      </li>
         <li class="nav-item">
          <a class="nav-link" href="ApplicationManagement.aspx">Application Management</a>
      </li>
    </ul>
  </div>
                    <div class="card-header">
   <center> <h5>Filter By Marks</h5>  </center>
  </div>
                    <div class="card-body">
                  
                        <asp:Label ID="droplblname" runat="server" Text="Select Post Code to View:"></asp:Label>
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="27px" Width="257px">

                            <asp:ListItem Value="TA-CIVIL">Technical Assistant (Civil)</asp:ListItem>
                            <asp:ListItem Value="TA-IT">Technical Assistant (IT)</asp:ListItem>
                            <asp:ListItem Value="JSA">Junior Secretariat Assistant</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;  
                        <asp:Label ID="Label3" runat="server" Text="Submitted:"></asp:Label>
                        <asp:DropDownList ID="SubmitteDrop" runat="server"  Height="27px" Width="57px">

                            
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No">No</asp:ListItem>
                        </asp:DropDownList>
                         &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp;  &nbsp; 
                        <asp:Label ID="Marklbl" runat="server" Text="Filter by Marks:"></asp:Label>
                         &nbsp; 
                                <asp:TextBox ID="markstxt" runat="server" Height="30px" Width="80px"></asp:TextBox>
                         &nbsp;  &nbsp; 
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  validationgroup="filtergrp" ControlToValidate="markstxt" runat="server" Display="Dynamic" ErrorMessage="Only Numbers" ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>


                                 <asp:Label ID="equlabl" runat="server" Text=">=" Font-Bold="False" Font-Size="Larger" ></asp:Label>
                         &nbsp;  &nbsp; 
                        <asp:Label ID="Label1" runat="server" Text="Course:"></asp:Label>
                                 <asp:DropDownList ID="EducatonListDrop" runat="server"  AutoPostBack="True" Height="27px" Width="257px" OnSelectedIndexChanged="EducatonListDrop_SelectedIndexChanged">
              <asp:ListItem Value="0">All</asp:ListItem>
            <asp:ListItem Value="sslc">SSLC</asp:ListItem>
            <asp:ListItem Value="hsc">HSC</asp:ListItem>
            <asp:ListItem Value="iti">ITI</asp:ListItem>
            <asp:ListItem Value="dip">DIPLOMA</asp:ListItem>
            <asp:ListItem Value="ug">UG</asp:ListItem>
            <asp:ListItem Value="pg">PG</asp:ListItem>
          
        </asp:DropDownList>
                 <!-- <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="EducatonListDrop" InitialValue="0" validationgroup="filtergrp" runat="server" ForeColor="Red" />-->
                           &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="Submitbtn" runat="server" validationgroup="filtergrp" Text="Submit" OnClick="Submitbtn_Click" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;   &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="ExportBtn" runat="server" Text="Export to Excel" OnClick="ExportBtn_Click"/>
                           
                    </div>
</div>
                </div>
                </div>
             <br />
             <div class="row">
                 <div class="col-12">
                     <asp:GridView ID="PostWiseGridView1" class="table-sm table-bordered table-hover" runat="server" Font-Size="10pt" AutoGenerateColumns="False" HorizontalAlign="Center" EmptyDataText="Applications Subitted is Nil !! "  BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                       <Columns>
                
                <asp:BoundField DataField="appregno" HeaderText="Application. No." />
                <asp:BoundField DataField="fullname" HeaderText="APPLICANT FULL NAME " />
                <asp:BoundField DataField="fathername" HeaderText="FAHTER / HUSBAND /GURADIAN NAME" />
                <asp:BoundField DataField="dateofbirth" HeaderText="DATE OF BIRTH"  />
                <asp:BoundField DataField="sexuality" HeaderText="GENDER"  />
                <asp:BoundField DataField="cast" HeaderText="CAST"  />               
                <asp:BoundField DataField="religion" HeaderText="RELIGION" />
                <asp:BoundField DataField="csiremp" HeaderText="CSIR EMP?" />
                <asp:BoundField DataField="pwd" HeaderText="PWD?" />
                <asp:BoundField DataField="ExArmy" HeaderText="EX ARMY?"  />
                <asp:BoundField DataField="UnderBond" HeaderText="UNDER BOND?" />
                <asp:BoundField DataField="IsRelativeCSIR" HeaderText="Relative to CSIR?" />
                <asp:BoundField DataField="SSLCPmarks" HeaderText="SSLC MARKS" />
                <asp:BoundField DataField="HSCPmarks" HeaderText="HSC MARKS" />
                <asp:BoundField DataField="ITIPmarks" HeaderText="ITI MARKS"  />
                <asp:BoundField DataField="DIPLOMAPmarks" HeaderText="DIPLOMA MARKS"  />
                <asp:BoundField DataField="UGPmarks" HeaderText="UG MARKS"  />
                 <asp:BoundField DataField="PGPmarks" HeaderText="PG MARKS" />
                <asp:BoundField DataField="IsCompleted"  HeaderText="IsCompleted"  />
                <asp:BoundField DataField="IsShortlisted" HeaderText="Shortlisted"  />
           
               
            </Columns>
                         
                         <FooterStyle BackColor="White" ForeColor="#000066" />
                         <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                         <RowStyle ForeColor="#000066" />
                         <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                         <SortedAscendingCellStyle BackColor="#F1F1F1" />
                         <SortedAscendingHeaderStyle BackColor="#007DBB" />
                         <SortedDescendingCellStyle BackColor="#CAC9C9" />
                         <SortedDescendingHeaderStyle BackColor="#00547E" />
                     </asp:GridView>
                 </div>
             </div>
             
    </div>
</asp:Content>
