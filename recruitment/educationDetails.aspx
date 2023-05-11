<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="educationDetails.aspx.cs" Inherits="recruitment.educationDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">


    <div class="row">
        <div class="col-12">
            <asp:Label ID="regidlbl" runat="server" Text="Label"></asp:Label>
        </div>

    </div>
    <div class="row">

        <div class="col-md-4">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="firstName" runat="server" Width="300px"></asp:TextBox>

        </div>

        <div class="col-md-4">
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="lastName" runat="server" Width="300px"></asp:TextBox>

        </div>

        <div class="col-md-4">
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <asp:TextBox ID="email" runat="server" Width="300px"></asp:TextBox>

        </div>

    </div>

</div>

</asp:Content>
