<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="DashboardAdmin.aspx.cs" Inherits="recruitment.DashboardAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container">
    
        <br />
      <br />
          <br />
     <div class="row">
         

         <div class="col-12">
    <div class="card text-dark bg-light mb-3" style="max-width: 28rem;">
  <div class="card-header"><asp:Image ID="Image4" src="imgs/book-online.png" witdh="25px" height="45px" runat="server" /> <asp:Label ID="Label1" runat="server" Text="Total Applications Recieved for All Posts" Font-Italic="True" Font-Bold="True"  ForeColor="#339933"></asp:Label></div>
      <div class="card-body">
       <center>   <h6 class="card-title">Total</h6>
        <asp:Label ID="lblCount" runat="server" Text="Nil"></asp:Label></center>
       <%-- <a href="FilterbyPost.aspx" class="btn btn-info">Open</a>--%>
      </div>
    </div>
  </div>
     </div>
         <br />
         <div class="row">
             <div class="col-12">
                 <label><strong>Post Name: </strong></label>
             <asp:DropDownList ID="DropDownList1" runat="server" Height="27px" Width="257px">

                             <asp:ListItem Value="SA-01">Security Assistant (SA-01)</asp:ListItem>
                            
                        </asp:DropDownList>
             <asp:DropDownList ID="SubmitteDrop" runat="server"  Height="27px" Width="57px" Visible="False">

                            <asp:ListItem Value="All">All</asp:ListItem>
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No">No</asp:ListItem>
                        </asp:DropDownList>
             <asp:Button ID="Submitbtn" class="btn-primary" runat="server" Text="Submit" OnClick="Submitbtn_Click" />
         </div>
         </div>
         <br />
        <div class="row">
  
   <div class="col-sm-4">
    
      <div class="card bg-light mb-3" style="max-width: 18rem;">
  <div class="card-header "> <center>  <asp:Image ID="Image3" src="imgs/ticon.png" witdh="25px" height="15px" runat="server" /> <asp:Label ID="Postcodelbl" runat="server" Text="Nil"></asp:Label> </center></div>
          <div class="card-body">
       
         

        <center>     <label>Total:</label>      <asp:Label ID="lblCount1" runat="server" Text="Nil"></asp:Label></center>
</div>
      </div>
    </div>
 
                <div class="col-sm-4">
   <div class="card bg-light mb-3" style="max-width: 18rem;">
  <div class="card-header">  <center> Completed <asp:Image ID="Image1" src="imgs/right.png" witdh="25px" height="25px" runat="server" /></center></div>
      <div class="card-body">
        
          <center>          <label>Total:</label>      <asp:Label ID="lblCount2" runat="server" Text="Nil"></asp:Label> </center>

      </div>
    </div>
  </div>
                <div class="col-sm-4">
    <div class="card bg-light mb-3" style="max-width: 18rem;">
  <div class="card-header"> <center> Not Completed <asp:Image ID="Image2" src="imgs/wrong.png" witdh="25px" height="25px" runat="server" /></center></div>
      <div class="card-body">
        
                   <center>        <label>Total:</label>      <asp:Label ID="lblCount3" runat="server" Text="Nil"></asp:Label></center>

        
      </div>
    </div>
  </div>
</div>
        
    </div>
    
</asp:Content>
