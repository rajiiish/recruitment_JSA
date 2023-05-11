<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="FilterbyPost.aspx.cs" Inherits="recruitment.FilterbyPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style>
        .dropbtn {
            background-color: #4CAF50;
            color: white;
            padding: 16px;
            font-size: 16px;
            border: none;
        }

        .dropdown {
            ;
            display: inline-block;
        }

        .dropdown-content {
            display: none;
            ;
            background-color: #f1f1f1;
            min-width: 160px;
            box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
            z-index: 1;
        }

            .dropdown-content a {
                color: black;
                padding: 12px 16px;
                text-decoration: none;
                display: block;
            }

                .dropdown-content a:hover {
                    background-color: #ddd;
                }

        .dropdown:hover .dropdown-content {
            display: block;
        }

        .dropdown:hover .dropbtn {
            background-color: #3e8e41;
        }
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
                    <center>
                    <div class="card-header">
    <ul class="nav nav-tabs card-header-tabs">
      <li class="nav-item">
        <a class="nav-link btn-info active" href="FilterbyPost.aspx">Filter By Post</a>

      </li>
      <li class="nav-item">
                  <a class="nav-link " href="FilterbyMark.aspx">Filter By Marks</a>

      </li>
      <li class="nav-item">
        <a class="nav-link" href="FilterbyCast.aspx">Filter By Cast </a>
      </li>
         <li class="nav-item">
           <a class="nav-link" href="ApplicationManagement.aspx">Application Management</a>
      </li>
<%--         <li class="nav-item">
                  <div class="dropdown">
            <button class="dropbtn">Dropdown</button>
            <div class="dropdown-content">
                <a href="#">username</a>
                <a href="#">Login Out</a>
            </div>
        </div>
      </li>--%>
    </ul>
             
  </div>
                        </center>
                    <div class="card-header">
   <center> <h5>Filter By Post</h5>  </center>
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

                            <asp:ListItem Value="All">All</asp:ListItem>
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No">No</asp:ListItem>
                        </asp:DropDownList>
                           &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="Submitbtn" runat="server" Text="Submit" OnClick="Submitbtn_Click" />
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
