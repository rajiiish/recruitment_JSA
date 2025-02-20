<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="position_details.aspx.cs" Inherits="recruitment.position_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-left: 0px;
        }
        .auto-style3 {
            margin-left: 0px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
          <div class="row">
       <div class="col-12">
    <div class="card bg-light">
               <div class="card-body"> 
    <div class="container  my-2  text-dark border">

        <div class="row">
           <div class="col-sm-12">
            <center>   <strong>Welcome :</strong>   <asp:Label ID="regidlbl" runat="server" Text="Registration ID" Font-Bold="True" ForeColor="Blue"></asp:Label></center>
               </div>
           </div>
    </div>
  

   <div class="container  my-5">
       
  <div class="row">
      <div col="col-4">
    <div class="md-col-2">
 <div class="card background-color:white text-Green" style="width: 25rem; height: 15rem;">
     <div class="card-header text-blue"><strong> <asp:Label ID="Label1" runat="server" Text="Current Openings" ForeColor="Maroon"></asp:Label></strong></div>
  <div class="card-body shadow-sm bg-white rounded">
    <h5 class="card-title">Select Post you are applying for:</h5>
    <p class="card-text">
        <asp:DropDownList ID="PostDropDownList" class="form-control" runat="server" OnSelectedIndexChanged="PostDropDownList_SelectedIndexChanged" AutoPostBack="True" Height="36px" Width="313px">
   <asp:ListItem Value="Select">-Select-</asp:ListItem>
               

        <asp:ListItem Value="JSA-GEN">Junior Secretariat Assistant(JSA-GEN)</asp:ListItem>
        <asp:ListItem Value="JSA-FA">Junior Secretariat Assistant(JSA-F&A)</asp:ListItem>
        <asp:ListItem Value="JSA-SP">Junior Secretariat Assistant(JSA-S&P)</asp:ListItem>
        <asp:ListItem Value="STENO-01">Junior Stenographer(Steno)</asp:ListItem>

        </asp:DropDownList>
        &nbsp;<asp:Label ID="appidnolbl" runat="server" Text=""></asp:Label>
        &nbsp;<br /> </p>
      
       
   
      <asp:Button ID="applybtn" class="btn btn-primary" runat="server" Text="Apply" OnClick="applybtn_Click" />
</div>
  </div>
</div>
          </div>
       <div col="col-2">
           <div>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
           </div>
       <div col="col-6">
      <div class="md-col-6">
          <div class="card margin-bottom: 10px" ">
  
</div>
          </div>
       </div>
      <div class="md-col-6">
 <div class="card background-color:white text-Green" style="width: 30rem; height: 15rem;">
     <div class="card-header text-blue"><strong><asp:Label ID="Label2" runat="server" Text="Mandatory Qualification" ForeColor="Maroon"></asp:Label> </strong></div>
  &nbsp;<div class="card-body shadow-sm bg-white rounded">
    <h5 class="card-title">Post Qualification Required to Apply</h5>
    <p class="card-text">
        <asp:Label ID="qualificationlable" runat="server" Text="qualification"></asp:Label>

  </div>
</div>
    </div>
 
  
       
     </div></div>
    
   
    <div class="container">

         <div class="row">
       <div class="col-6">
        <asp:GridView ID="GridView1" runat="server" class="table table-bordered" Font-Size="11pt" AutoGenerateColumns="False" EmptyDataText="Applications Subitted is Nil !! " DataSourceID="SqlDataSource1" Width="1026px" CellPadding="3" OnRowDataBound="GridView1_RowDataBound" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CssClass="auto-style3">
            
            <Columns>
                <asp:BoundField DataField="can_regno" HeaderText="Registration Number" SortExpression="can_regno" />
                <asp:BoundField DataField="postcode" HeaderText="Postcode" SortExpression="postcode" />
                <asp:BoundField DataField="postdetails" HeaderText="Post Applied For" SortExpression="postdetails" />
                <asp:BoundField DataField="appregno" HeaderText="Application Number" SortExpression="appregno" />
                <asp:BoundField DataField="IsCompleted" HeaderText="Application Submitted" SortExpression="IsCompleted" />

                 <asp:TemplateField>
            <ItemTemplate>
              <asp:LinkButton ID  ="ContinueApplication" class="btn btn-sm btn-success"  runat="server" OnClick="ContinueApplication_Click">Continue Application</asp:LinkButton>
             
            </ItemTemplate>


        </asp:TemplateField>
                <asp:TemplateField>
            <ItemTemplate>
             <asp:LinkButton ID  ="PrintApplication" class="btn btn-sm btn-warning" runat="server"  OnClick="PrintApplication_Click" >Print Application</asp:LinkButton>
             
            </ItemTemplate>


        </asp:TemplateField>
                
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

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineapplicationConnectionString1 %>" SelectCommand="SELECT DISTINCT [can_regno], [postcode], [postdetails], [appregno],[IsCompleted] FROM [basicdetailsNew] WHERE ([can_regno] = @can_regno)">
            <SelectParameters>
                <asp:ControlParameter ControlID="regidlbl" Name="can_regno" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
           
           
            
        </div>

        <div class="col-12">
            <br />
            <h5 class="text-primary"> *Please fill all the required details for the post, incomplete applications are not valid for selection.</h5>
        </div>

    </div>
     
        </div>


    </div>
    </div>
    </div>  
              </div>
         </div>
    
</asp:Content>
