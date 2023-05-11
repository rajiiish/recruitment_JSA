<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PDFUpload.aspx.cs" Inherits="recruitment.PDFUpload" %>
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
    <center>
   <div class="container">regidlbl
       
    <div class="row">
    <div class="col-12">
        <div class="row bg-info">
        <table>  
           
            <tr>  
                <td> Select File&nbsp;&nbsp; </td>  
                <td>  
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="10th">SSLC</asp:ListItem>
                        <asp:ListItem Value="12TH">HSC</asp:ListItem>
                        <asp:ListItem>UG</asp:ListItem>
                        <asp:ListItem>PG</asp:ListItem>
                        <asp:ListItem>COMMUNITY</asp:ListItem>
                    </asp:DropDownList>
                    <asp:FileUpload ID="FileUpload1" runat="server" ToolTip="Select Only PDF File" /> </td>  
                <td>  
                    <asp:Button ID="Button1" runat="server" Text="Upload" onclick="Button1_Click" /> </td>  
                <td>  
                    <asp:Button ID="Button2" runat="server" Text="View Files" onclick="Button2_Click" /> </td>  
            </tr>  
           
        </table>  
             </div>
        <table>  
            <tr>  
                <td>  
                    <p>  
                        <asp:Label ID="Label2" runat="server" Text="label"></asp:Label>  
                    </p>  
                </td>  
            </tr>  
        </table>  
        <asp:GridView ID="GridView1" runat="server" Caption="pdf Files " CaptionAlign="Top" HorizontalAlign="Justify" DataKeyNames="can_regno" onselectedindexchanged="GridView1_SelectedIndexChanged" ToolTip="pdf FIle DownLoad Tool" CellPadding="4" ForeColor="#333333" GridLines="None">  
            <RowStyle BackColor="#E3EAEB" />  
            <Columns>  
                <asp:CommandField ShowSelectButton="True" SelectText="View Uploaded Document" ControlStyle-ForeColor="Blue" /> </Columns>  
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />  
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />  
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />  
            <HeaderStyle BackColor="Gray" Font-Bold="True" ForeColor="White" />  
            <EditRowStyle BackColor="#7C6F57" />  
            <AlternatingRowStyle BackColor="White" /> </asp:GridView>  
    </div>  
    </div>
        </div>  
        </center>
        
</asp:Content>
