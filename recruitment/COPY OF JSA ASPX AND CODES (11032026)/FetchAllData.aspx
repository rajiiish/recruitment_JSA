<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="FetchAllData.aspx.cs" Inherits="recruitment.FetchAllData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
     <div class="card-body">
                        
                        <asp:Label ID="droplblname" runat="server" Text="Select Post Code to View:"></asp:Label>
         <asp:TextBox ID="TextBox1" runat="server" ViewStateMode="Enabled"></asp:TextBox> 
         <asp:Label ID="resultlbl" runat="server" Text="Label"></asp:Label>
                        &nbsp;  
                      
                        
                           &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="Submitbtn" runat="server" Text="Submit" OnClick="Submitbtn_Click" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;   &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="ExportBtn" runat="server" Text="Export to Excel" />
                           
                    </div>

    </div>
</asp:Content>
