<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProfessionalAdd.aspx.cs" Inherits="recruitment.ProfessionalAdd" %>
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
       
        .auto-style3 {
            width: 23px;
            height: 21px;
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
       
        .auto-style5 {
            width: 640px;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function(event) { 
            var scrollpos = localStorage.getItem('scrollpos');
            if (scrollpos) window.scrollTo(0, scrollpos);
        });

        window.onbeforeunload = function(e) {
            localStorage.setItem('scrollpos', window.scrollY);
        };
    </script>

       <%-- title start--%>
    <div class="container">
        <div class="bg-light  text-center">
        <p >Note: Don't input any special characters or punctuation marks. Input only alphanumeric characters.<br/>
        Personal Details (fields marked with * are mandatory)</p>
        <p >Candidate Registration Number:
              <asp:Label ID="regidlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="Blue"></asp:Label>
       Application ID: <asp:Label ID="appidnolbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label> 
            Post Applying For: <asp:Label ID="applyhpostlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label>  </p>
      </div>

    </div> 
        <%-- title ends--%>

      <%-- Stepbystep start--%>
        
     <!--   <div class="container ">
            <div class="card bg-light">
               <div class="card-body"> 
            <table class="table titlemenufont">
  
  <tbody>
    <tr>
         <td> <strong><img src="imgs/1.PNG" class="auto-style3" /></strong>PERSONAL DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
         <td> <strong><img src="imgs/2.PNG" class="auto-style3" /></strong>EDUCATION DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
         <td > <strong><img src="imgs/3.PNG" class="auto-style3" /></strong>EXPERIENCE DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
         <td  class="stepfont"> <strong><img src="imgs/ticon.PNG" class="auto-style3" /></strong>PROFESSIONAL INFORMATION<strong><img src="imgs/icons8_forward_48px.PNG" class="auto-style3" /></strong></td> 
         <td > <strong><img src="imgs/4.PNG" class="auto-style3" /></strong>OTHER INFORMATION<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
         <td > <strong><img src="imgs/6.PNG" class="auto-style3" /></strong>FILES UPLOAD<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
               
    </tr>
  </tbody>
</table>
                      </div>
         </div>
            </div>-->
      <%-- Stepbystep ends--%>     
     

     <%-- pulication section starts--%>
   
    <div class="container ">
      <div class="card bg-light">
             <center>    <h6 class="card-header text-white  bg-info ">Research publications (Year-Wise) Details</h6></center>
               <div class="card-body">   
        <div class="row">
            <%-- Two page starts--%>  
   <div class="col-12 ">
       
        <div class="row">

            
     <div class="col-12">
                           <label>* Published any Research Publications?:</label> &nbsp
                <asp:DropDownList ID="ResearchpubDrop"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="ResearchpubDrop_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="Yes">Yes</asp:ListItem>
                         <asp:ListItem Value="No">No</asp:ListItem>
                </asp:DropDownList>
                                                  <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="ResearchpubDrop" InitialValue="0" validationgroup="basicpagegroup" runat="server" ForeColor="Red" />

                       </div>
      

            <asp:Panel ID="ResearchPanel" runat="server">
            <table class="table table-bordered">
  <thead>
    <tr>
      <th scope="col">Year of publication</th>
      <th scope="col">Journal type</th>
      <th scope="col">Number of papers</th>
      <th scope="col">Cumulative Impact Factor (C.I.F)</th>
        <th scope="col"></th>
    </tr>
  </thead>
  <tbody>
   
    <tr>
      
      <td><asp:TextBox ID="publicationYeartxt" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="publicationYeartxt" ErrorMessage="*" ForeColor="Red" validationgroup="JourPubGroup"></asp:RequiredFieldValidator>
          <br />
          <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="publicationYeartxt" ForeColor="Red" ErrorMessage="enter only year." ValidationExpression="^[0-9]+$" ValidationGroup="JourPubGroup"></asp:RegularExpressionValidator>
        </td>
         <td><asp:DropDownList ID="JournalTypetxtdrop" runat="server">
             <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="	SCI_Journal">	SCI Journal</asp:ListItem>
                         <asp:ListItem Value="Non_SCI Journal">Non 	SCI Journal</asp:ListItem>
             </asp:DropDownList> 
             <br />
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="JournalTypetxtdrop" ErrorMessage="Select Journal type" ForeColor="Red" InitialValue="0" validationgroup="JourPubGroup" />
        </td>
         <td><asp:TextBox ID="NoofPaperstxt" runat="server" MaxLength="4"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="NoofPaperstxt" ErrorMessage="*" ForeColor="Red" validationgroup="JourPubGroup"></asp:RequiredFieldValidator>
             <br />
          <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="NoofPaperstxt" ForeColor="Red" ErrorMessage="enter only numbers." ValidationExpression="^[0-9]+$" ValidationGroup="JourPubGroup"></asp:RegularExpressionValidator>
        </td>
         <td><asp:TextBox ID="CIFtxt" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="CIFtxt" ErrorMessage="*" ForeColor="Red" validationgroup="JourPubGroup"></asp:RequiredFieldValidator>
             <br />
             <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="CIFtxt" ErrorMessage="Enter C.I.F" ForeColor="Red" validationgroup="JourPubGroup"></asp:RequiredFieldValidator>
        </td>
      <td><asp:Button ID="AddResearchPub" runat="server" Text="Add" validationgroup="JourPubGroup" OnClick="AddResearchPub_Click" /></td>

        
    </tr>
   
  </tbody>
</table>

            <div class="container">
        <div class="card bg-light">
               <div class="card-body"> 
                       
         <div class="row">
             <div class="col">

        <div class="text-center">
<center>
    <asp:GridView ID="PublishGridView1" runat="server" class="table table-bordered " AutoGenerateColumns="False" DataKeyNames="id"  EmptyDataText="No records has been added." CellPadding="0" ForeColor="#333333" GridLines="None" Height="85px" Width="952px" Font-Size="10pt" >
        <AlternatingRowStyle BackColor="White" />
    <Columns>
        

        <%--<asp:BoundField DataField="can_regno" HeaderText="can_regno" SortExpression="can_regno" />
        
        <asp:BoundField DataField="appregno" HeaderText="appregno" SortExpression="appregno" />--%>
        
        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="false" visible="false" SortExpression="id" />
        <asp:BoundField DataField="can_regno" HeaderText="can_regno" ReadOnly="True" visible="false" SortExpression="can_regno" />
       
        <asp:BoundField DataField="appregno" HeaderText="appregno" visible="false" SortExpression="appregno" />
        <asp:BoundField DataField="Yearofpublish" HeaderText="Year of publication" SortExpression="Yearofpublish" />
           <asp:BoundField DataField="JournalType" HeaderText="Journal type" SortExpression="JournalType" />
        <asp:BoundField DataField="NoPapers" HeaderText="Number of papers" SortExpression="NoPapers" />
        <asp:BoundField DataField="CIF" HeaderText="Cumulative Impact Factor (C.I.F)" SortExpression="CIF" />
          
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID  ="DeletePub_linkbtn" runat="server" OnClick="ResPublicationDeletebtn_Click" >Delete</asp:LinkButton>
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
                </asp:Panel>
             </div>
       
 
       
   </div>

 </div>
                    </div>
           </div>

   
</div>
     <%-- pulication Section ends.--%>  


     <%-- Patents section starts--%>
   
    <div class="container ">
      <div class="card bg-light">
             <center>    <h6 class="card-header text-white  bg-info ">Patents (Year-Wise) Details</h6></center>
               <div class="card-body">   
        <div class="row">
            
            <%-- Two page starts--%>  
             <div class="col-12">
                           <label>* Obtained any Patents?:</label> &nbsp
                <asp:DropDownList ID="PatentDrop"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="PatentDrop_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="Yes">Yes</asp:ListItem>
                         <asp:ListItem Value="No">No</asp:ListItem>
                </asp:DropDownList>
                                                  <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="PatentDrop" InitialValue="0" validationgroup="basicpagegroup" runat="server" ForeColor="Red" />

                       </div>
      <asp:Panel ID="PatentPanel" runat="server">
   <div class="col-12 ">
       
        <div class="row">
            <table class="table table-bordered">
  <thead>
    <tr>
      <th scope="col">Year</th>
      <th scope="col">Number of patents Filed</th>
      <th scope="col">Number of patents Granted</th>
     
        <th scope="col"></th>
    </tr>
  </thead>
  <tbody>
   
    <tr>
      
      <td><asp:TextBox ID="PatentYeartxt" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="PatentYeartxt" ErrorMessage="*" ForeColor="Red" validationgroup="PatentGroup"></asp:RequiredFieldValidator>
          <br />
          <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="PatentYeartxt" ErrorMessage="enter only year." ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="PatentGroup"></asp:RegularExpressionValidator>
          </td>
         <td><asp:TextBox ID="NoPatenttxt" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="NoPatenttxt" ErrorMessage="*" ForeColor="Red" validationgroup="PatentGroup"></asp:RequiredFieldValidator>
             <br />
             <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="NoPatenttxt" ErrorMessage="enter only numbers." ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="PatentGroup"></asp:RegularExpressionValidator>
          </td>
         <td><asp:TextBox ID="NoPatentsGrantedtxt" runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="NoPatentsGrantedtxt" ErrorMessage="*" ForeColor="Red" validationgroup="PatentGroup"></asp:RequiredFieldValidator>
             <br />
             <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="NoPatentsGrantedtxt" ErrorMessage="enter only numbers." ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="PatentGroup"></asp:RegularExpressionValidator>
          </td>
         
      <td><asp:Button ID="AddPatent" runat="server" Text="Add" validationgroup="PatentGroup" OnClick="AddPatent_Click1" /></td>

        
    </tr>
   
  </tbody>
</table>

            <div class="container">
        <div class="card bg-light">
               <div class="card-body"> 
                       
         <div class="row">
             <div class="col">

        <div class="text-center">
<center>
    <asp:GridView ID="PatentGridView1" runat="server" class="table table-bordered " AutoGenerateColumns="False" DataKeyNames="id"  EmptyDataText="No records has been added." CellPadding="0" ForeColor="#333333" GridLines="None" Height="42px" Width="952px" Font-Size="10pt" >
        <AlternatingRowStyle BackColor="White" />
    <Columns>
        

        <%--<asp:BoundField DataField="can_regno" HeaderText="can_regno" SortExpression="can_regno" />
        
        <asp:BoundField DataField="appregno" HeaderText="appregno" SortExpression="appregno" />--%>
        
        <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="false" visible="false" SortExpression="id" />
        <asp:BoundField DataField="can_regno" HeaderText="can_regno" ReadOnly="True" visible="false" SortExpression="can_regno" />
       
        <asp:BoundField DataField="appregno" HeaderText="appregno" visible="false" SortExpression="appregno" />
        <asp:BoundField DataField="PatentYear" HeaderText="PatentYear" SortExpression="PatentYear" />
           <asp:BoundField DataField="NoPatents" HeaderText="NoPatents" SortExpression="NoPatents" />
        <asp:BoundField DataField="NoPatentsGranted" HeaderText="NoPatentsGranted" SortExpression="NoPatentsGranted" />
       
          
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID  ="DeletePatent_linkbtn" runat="server" OnClick="DeletePatentlink_Click" >Delete</asp:LinkButton>
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
             </div>
       
 
       
   </div>
</asp:Panel>
 </div>
                   
                    </div>
           </div>

   
</div>
     <%-- Patents Section ends.--%>  

    <div class="container ">
      <div class="card bg-light">
             <center>    <h6 class="card-header text-white  bg-info ">Awards and Technical Details (Please Leave Blank if you dont have any)</h6></center>
               <div class="card-body">   
        <div class="row">
            <%-- Two page starts--%>  
   <div class="col-12 ">
       <table class="table table-bordered">
 
  <tbody>
       <tr>
       <th class="auto-style5">Number of Technology developed/commercialised:</th>        
       <td><asp:TextBox ID="TechnolgyDevtxt" runat="server"></asp:TextBox></td>        
    </tr>
      <tr>
       <th class="auto-style5">Awards/Honours/Distinctions/Prizes:
           <br />
           (Max 350 Characters)</th>        
       <td><asp:TextBox ID="Awardstxt" runat="server" Height="77px" MaxLength="350" TextMode="MultiLine" Width="340px"></asp:TextBox></td>        
    </tr>
      <tr>
       <th class="auto-style5">Any Additional Qualifications such as membership of Scientific Societies: <br />
           (Max 350 Characters)</th>        
       <td><asp:TextBox ID="membershiptxt" runat="server" Height="69px" MaxLength="350" TextMode="MultiLine" Width="335px"></asp:TextBox></td>        
    </tr>
  </tbody>
</table>
       </div>
            </div>
                   </div>
          </div>
        </div>


    
        <%-- Submit button start.--%>

    <div class="container">
        <div class="row">
            <div class="col-12">
                      <br/>
                </div>
        </div>
    <div class="row">
    <div class="col-12">
                         <asp:Button ID="goBackbtn" CssClass="savebtncolor" runat="server" Text="Go Back to Home" OnClick="goBackbtn_Click"  />

    <center> 

        <asp:Button ID="SaveDetails" CssClass="savebtncolor" runat="server" Text="Save and Continue" causesvalidation="true" validationgroup="basicpagegroup" OnClick="SaveDetails_Click" />
    </center>
    </div>
    </div>
    </div>

    <%-- Submit Section ends.--%>   
    <br/>
</asp:Content>
