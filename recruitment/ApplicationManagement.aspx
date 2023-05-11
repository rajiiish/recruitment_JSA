<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="ApplicationManagement.aspx.cs" Inherits="recruitment.ApplicationManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
  .successMerit {
    background-color: #1fa756;
    border: medium none;
    color: White;
  }
    .defaultColor
    {
        background-color: white;
        color: black;
    }
  .dangerFailed {
    background-color: #f2283a;
    color: White;
  }

  body
    {
        font-family: Arial;
        font-size: 10pt;
    }
    .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=40);
        opacity: 0.7;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        width: 300px;
        border: 3px solid #0DA9D0;
    }

    .modalPopup1
    {
        background-color: #FFFFFF;
        width: 90%;
         height: 85%;

        border: 5px solid #0DA9D0;
    }
    .modalPopup2
    {
        background-color: #FFFFFF;
        width: 90%;
         height: 85%;

        border: 5px solid #0DA9D0;
    }
    .modalPopup .header
    {
        background-color: #2FBDF1;
        height: 30px;
        color: White;
        line-height: 30px;
        text-align: center;
        font-weight: bold;
    }
    .modalPopup .body
    {
        min-height: 50px;
        line-height: 30px;
        text-align: center;
        padding:5px
    }

      .modalPopup .bodynew
    {
        max-height:90%;
        max-width:1502px;
        line-height: 20px;
        text-align: left;
        padding:1px
    }
    .modalPopup .footer
    {
        padding: 3px;   
    }
    .modalPopup .button
    {
        height: 23px;
        color: White;
        line-height: 23px;
        text-align: center;
        font-weight: bold;
        cursor: pointer;
        background-color: #9F9F9F;
        border: 1px solid #5C5C5C;
    }
    .modalPopup td
    {
        text-align:left;
    }
    .hideGridColumn
    {
        display:none;
    }
    tr {
  border-bottom: 1px solid #ddd;
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
        <a class="nav-link " href="FilterbyPost.aspx">Filter By Post</a>
      </li>
      <li class="nav-item">
                  <a class="nav-link " href="FilterbyMark.aspx">Filter By Marks</a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="FilterbyCast.aspx">Filter By Cast</a>
      </li>

        <li class="nav-item">
        <a class="nav-link btn-info active" href="#">Application Management</a>
      </li>
    
    </ul>
             
  </div>
                        </center>

                    <table class ="table">
                        <tr>
                            <td colspan="2">
                            <center> <h5 class="text-success">Application Management</h5>  </center>
                                </td>
                        </tr>
                        <tr>
                        <td>
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

                             <asp:Label ID="Label9" runat="server" Text="Shortlisted:"></asp:Label>
                        <asp:DropDownList ID="ShortlistDrop" runat="server"  Height="27px" Width="57px">

                          
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                            <asp:ListItem Value="No">No</asp:ListItem>
                        </asp:DropDownList>
                           &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="Submitbtn" runat="server" Text="Submit" CssClass="btn-primary" OnClick="Submitbtn_Click" />
                &nbsp; &nbsp; &nbsp; 
                            </td>
                            <td>
                                                  <asp:Label ID="Label8" runat="server" Text="Search by Name or Application Number:"></asp:Label>
  <asp:TextBox ID="SearchLiketxt" runat="server"></asp:TextBox>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<asp:Button ID="SearchBtn" runat="server" Text="Search"  CssClass="btn-primary" OnClick="SearchBtn_Click" />
                &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;   &nbsp; &nbsp; &nbsp; &nbsp; <asp:Button ID="ExportBtn" CssClass="alert-info" runat="server" Text="Export to Excel" OnClick="ExportBtn_Click"/>
                           
                        </td>
                            </tr>
                        
                        </table>
                    

                    
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
                <asp:BoundField DataField="can_regno" HeaderText="can_regno" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
           
                           <asp:TemplateField>
                 <ItemTemplate>
                 <asp:LinkButton ID  ="ShortlistLbtn1" class="btn btn-sm btn-success" runat="server" OnClick="ShortlistLbtn_Click">Shortlist</asp:LinkButton>
                     
                   <%--  <asp:ImageButton ID="rigthimgbtn" src="imgs/right.png" width="25" height="25" runat="server" />--%>
                 </ItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField>
                 <ItemTemplate>
                 <asp:LinkButton ID  ="NotEligibleBtn" class="btn btn-sm btn-warning"   runat="server" OnClick="RejecLinkClick_Click" >Reject</asp:LinkButton>
              <%--       <asp:ImageButton ID="wrnimgbtn" src="imgs/wrong.png" width="25" height="25" runat="server" />--%>
                 </ItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField>
                 <ItemTemplate>
                 <asp:LinkButton ID  ="PreviewBtn" class="btn btn-sm btn-info"   runat="server" OnClick="PreviewClicklinbtn_Click">Preview</asp:LinkButton>
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
                 </div>
             </div>
            
               <div class="row">
         <div class="col-12">
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

             <br />

                 <asp:LinkButton ID  ="ShortlistLbtn_link" runat="server" ></asp:LinkButton>

           

             <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panel1" TargetControlID="ShortlistLbtn_link"
CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</ajaxToolkit:ModalPopupExtender>



             <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display: none">

                  <div class="header">                 
        Shortlist the Selected Candidates:
    </div>
    <div class="body">
         <div class="card border-info">
                            <div class="card-body">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td><asp:Label ID="appregnolbl1" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="canregno1" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="FinalShortBtn" runat="server" Text="Shortlist" OnClick="FinalShortBtn_Click" />
                </td>
            </tr>
            
        </table>
    </div>
    <div class="footer" align="right">
        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="button" />
    </div>
                 </div>
        </div>
             </asp:Panel>

         </div>

     </div>

     <div class="row">
         <div class="col-12">
             

                 <asp:LinkButton ID ="RejectLinkDummyButton1" runat="server" ></asp:LinkButton>

            
             <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panel2" TargetControlID="RejectLinkDummyButton1"
CancelControlID="btnClose2" BackgroundCssClass="modalBackground">
</ajaxToolkit:ModalPopupExtender>



             <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" Style="display: none">

                  <div class="header">                 
        Shortlist the Selected Candidates:
    </div>
    <div class="body">
         <div class="card border-info">
                            <div class="card-body">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td><asp:Label ID="appregnolbl2" runat="server" Text=""></asp:Label></td>
                <td><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="PopupFinalRejectBtn" runat="server" Text="Reject" OnClick="PopupFinalRejectBtn_Click" />
                </td>
            </tr>
            
        </table>
    </div>
    <div class="footer" align="right">
        <asp:Button ID="btnClose2" runat="server" Text="Cancel R" CssClass="button" />
    </div>
                 </div>
        </div>
             </asp:Panel>

         </div>

     </div>

     <div class="row">
         <div class="col-12">
             

                 <asp:LinkButton ID ="PreviewLinkDummyButton1" runat="server" ></asp:LinkButton>

            
             <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender3" runat="server" PopupControlID="Panel3" TargetControlID="PreviewLinkDummyButton1"
CancelControlID="btnClose3" BackgroundCssClass="modalBackground">
</ajaxToolkit:ModalPopupExtender>

    
    <asp:Panel ID="Panel3" runat="server" CssClass="modalPopup1" Style="display: normal">

               
   <div class="container-fluid">
       <div class="overflow-auto">
   <div class="card border-none btn-rounded">
   <div class="card-body "> 
       <div class="card-header bg-info text-white ">
             <asp:Label runat="server" Text="Application No:  " Font-Bold="True" Font-Size="Medium" ForeColor="#000066" ></asp:Label><asp:Label ID="appregnolbl3" runat="server" ForeColor="#000066" Font-Bold="True" Font-Size="Medium" Text=""></asp:Label> <asp:Label ID="regidlbl" runat="server" ForeColor="#000066" Font-Bold="True" Font-Size="Medium" Text=""></asp:Label>
       </div>
    
   <div class="row">
       <div class="col-1">
           <table border: 15px solid;>
               <caption>
                   <br />
                   <tr>
                       <td>
                           <asp:Image ID="photo" runat="server" Height="176px" Width="134px" />
                       </td>
                   </tr>
               </caption>
              
           </table>
       </div>
       <div class="col-11">
           <asp:Table BackColor="#E2ECEA"  class="table-sm table-info table-bordered table-hover" HorizontalAlign="Center" ID="PersonalDetailtable" runat="server">
               <asp:TableHeaderRow>
                   <asp:TableHeaderCell  ForeColor="#D53543" HorizontalAlign="Center" ColumnSpan="10" class="table-success" >Personal Details</asp:TableHeaderCell>
                   

               </asp:TableHeaderRow>
               <asp:TableRow>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>Full name </strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>Father Name</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>Mother Name</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>DOB</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>GENDER</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>CATEGORY</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>Marital Status</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>Religion</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>Are you a CSIR Employee</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>PWD Catagory</strong></asp:TableCell>
               </asp:TableRow>
               <asp:TableRow>
                   <asp:TableCell><asp:Label ID="fullnamelbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="fathernamelbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="mothernamelbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="doblbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="genderlbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="categorylbl" runat="server" Text="Label"></asp:Label> </asp:TableCell>
                   <asp:TableCell><asp:Label ID="maritallbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="religionlbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="csiremplbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="pwdcatlbl1" runat="server" Text="Label"></asp:Label> <asp:Label ID="pwdcatlbl2" runat="server" Text="Label"></asp:Label> <asp:Label ID="Label1" runat="server" Text=","></asp:Label> <asp:Label ID="pwdcatlbl3" runat="server" Text="Label"></asp:Label></asp:TableCell>
               </asp:TableRow>
               <asp:TableRow >
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>Are you an Ex-Servicemen </strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>Are you an Indian Citizen</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399" ><asp:Label runat="server"></asp:Label><strong>Place or City of Born</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>Aadhaar Number	</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>E-Mail Address</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>Mobile Number</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>Payment Details</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>?</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>Communication Address</strong></asp:TableCell>
                   <asp:TableCell ForeColor="#333399"><asp:Label runat="server"></asp:Label><strong>Permanent Address</strong></asp:TableCell>
               </asp:TableRow>
                  <asp:TableRow>
                   <asp:TableCell><asp:Label ID="armylbl" runat="server" Text="Label"></asp:Label> <asp:Label ID="Label2" runat="server" Text=","></asp:Label> <asp:Label ID="armylblservice" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="citizenlbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="placebornlbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="aadhaarlbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="emaillbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="mobilelbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="bankreflbl" runat="server" Text="Label"></asp:Label> <asp:Label ID="paydatelbl" runat="server" Text="Label"></asp:Label> <asp:Label ID="paymodelbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="permaddlbl1" runat="server" Text="?"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="presentaddlbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="permaddlbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
               </asp:TableRow>

           </asp:Table>
       </div>
        </div>
       <div class="row">
           <label></label>
       </div>
       <div class="row">
           <div class="col-5">
               <asp:Table ID="Table1" BackColor="#E2ECEA" class="table-sm table-info table-bordered table-hover" runat="server"  >
                   <asp:TableHeaderRow>
                       <asp:TableHeaderCell  ForeColor="#D53543" class="table-success" ColumnSpan="7">Educational Details</asp:TableHeaderCell>
                   </asp:TableHeaderRow>
                                                                    <asp:TableHeaderRow class="table table-bordered">
                                                                        <asp:TableHeaderCell BackColor="#E4D5E5" ForeColor="Black" > Qualification</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#E4D5E5" ForeColor="Black" > Group Name</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#E4D5E5" ForeColor="Black" > Main Subject</asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#E4D5E5" ForeColor="Black" > Institute/School Name</asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#E4D5E5" ForeColor="Black" > Marks in Percentage </asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#E4D5E5" ForeColor="Black" > Year of Passing </asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#E4D5E5" ForeColor="Black" > Division/Grade </asp:TableHeaderCell> 
                                                                    </asp:TableHeaderRow>
                                                                    <asp:TableRow  id="sslcRow" class="table table-bordered">
                                                                        <asp:TableCell CssClass="AspCell"> <asp:Label ID="ssl1" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ssl2" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ssl3" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ssl4" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ssl5" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ssl6" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell CssClass="AspCell"> <asp:Label ID="ssl7" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                        
                                                                    </asp:TableRow>

                                                                       <asp:TableRow  id="hscRow" class="table table-bordered">
                                                                         <asp:TableCell> <asp:Label ID="hsc1" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="hsc2" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="hsc3" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="hsc4" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="hsc5" runat="server" Text="Label"></asp:Label>  </asp:TableCell>  
                                                                         <asp:TableCell> <asp:Label ID="hsc6" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="hsc7" runat="server" Text="Label"></asp:Label>  </asp:TableCell>  
                                                                        
                                                                    </asp:TableRow>
                                                                     <asp:TableRow  id="ITIRow" class="table table-bordered">
                                                                         <asp:TableCell> <asp:Label ID="ITI1" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ITI2" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ITI3" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ITI4" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ITI5" runat="server" Text="Label"></asp:Label>  </asp:TableCell>  
                                                                         <asp:TableCell> <asp:Label ID="ITI6" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ITI7" runat="server" Text="Label"></asp:Label>  </asp:TableCell>  
                                                                        
                                                                    </asp:TableRow>
                   <asp:TableRow>    
                       <asp:TableCell ColumnSpan="7"> </asp:TableCell>
    </asp:TableRow>

                                                                      <asp:TableHeaderRow  id="ugpgtitleRow" class="table table-bordered">
                                                                        <asp:TableHeaderCell BackColor="#E4D5E5" ForeColor="Black" > Qualification</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#E4D5E5" ForeColor="Black" > Specialization/Degree Name</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#E4D5E5" ForeColor="Black" > Main Subject</asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#E4D5E5" ForeColor="Black" >Institute/University/College Name</asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#E4D5E5" ForeColor="Black" > Marks in Percentage </asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#E4D5E5" ForeColor="Black" > Year of Passing </asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#E4D5E5" ForeColor="Black" > Division/Grade </asp:TableHeaderCell> 
                                                                    </asp:TableHeaderRow>

                                                                       <asp:TableRow  id="dipRow" class="table table-bordered">
                                                                        <asp:TableCell> <asp:Label ID="dip1" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="dip2" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="dip3" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="dip4" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="dip5" runat="server" Text="Label"></asp:Label>  </asp:TableCell> 
                                                                            <asp:TableCell> <asp:Label ID="dip6" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="dip7" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                        
                                                                    </asp:TableRow>

                                                                       <asp:TableRow  id="ugRow" class="table table-bordered">
                                                                        <asp:TableCell > <asp:Label ID="ug1" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ug2" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ug3" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ug4" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ug5" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                           <asp:TableCell> <asp:Label ID="ug6" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="ug7" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                        
                                                                    </asp:TableRow >
                                                                       <asp:TableRow  id="pgRow" class="table table-bordered">
                                                                        <asp:TableCell> <asp:Label ID="pg1" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="pg2" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="pg3" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="pg4" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="pg5" runat="server" Text="Label"></asp:Label>  </asp:TableCell>  
                                                                           <asp:TableCell> <asp:Label ID="pg6" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="pg7" runat="server" Text="Label"></asp:Label>  </asp:TableCell>  

                                                                        </asp:TableRow>
                                                                  
                                                                </asp:Table>
           </div>
           <div class="col-1">
               <lable></lable>
           </div>
           <div class="col-6">
               <table>
                   <tr align="left"  style="vertical-align:middle;" class="table-success"><td><label><strong><font color="#D53543">Experience Details</font></strong></label></td></tr>
                   <tr>
                       
                       <td>
                             <asp:GridView ID="GridView2" BackColor="#E2ECEA" class="table-sm table-info table-bordered table-hover" runat="server"  GridLines="Horizontal" OnRowDataBound="GridView2_RowDataBound" OnRowCreated="GridView2_RowCreated">
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#E4D5E5" Font-Bold="True" ForeColor="Black" />
         
    </asp:GridView>
                       </td>
                   </tr>

               </table>
               <br />
               <asp:Table BackColor="#E2ECEA" class="table-md table-info table-bordered table-hover" HorizontalAlign="Center" ID="Table2" runat="server">
               <asp:TableHeaderRow>
                   <asp:TableHeaderCell  ForeColor="#D53543" HorizontalAlign="Center" ColumnSpan="10" class="table-success" >Other Mandatory Details</asp:TableHeaderCell>
                   

               </asp:TableHeaderRow>
               
               <asp:TableRow >
                   <asp:TableCell BackColor="#E4D5E5" ><asp:Label runat="server"></asp:Label><strong>Have you been outside india? </strong></asp:TableCell>
                   <asp:TableCell BackColor="#E4D5E5" ><asp:Label runat="server"></asp:Label><strong>Are you under any bond</strong></asp:TableCell>
                   <asp:TableCell BackColor="#E4D5E5" ><asp:Label runat="server"></asp:Label><strong>Minimum joining time required </strong></asp:TableCell>
                   <asp:TableCell BackColor="#E4D5E5" ><asp:Label runat="server"></asp:Label><strong>Any of your Blood relation working in CSIR?	</strong></asp:TableCell>
                   <asp:TableCell BackColor="#E4D5E5" ><asp:Label runat="server"></asp:Label><strong>Are you a Permanent CSIR/Government Servant at Present?:</strong></asp:TableCell>
                   <asp:TableCell BackColor="#E4D5E5" ><asp:Label runat="server"></asp:Label><strong>Are you claiming for age relaxation other than SC/ST/OBC?</strong></asp:TableCell>
                  
               </asp:TableRow>
                  <asp:TableRow>
                   <asp:TableCell ><asp:Label ID="forignvisitlbl" runat="server" Text="Label"></asp:Label> </asp:TableCell>
                   <asp:TableCell><asp:Label ID="bondlbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="joinglbl" runat="server" Text="Label"></asp:Label> <asp:Label ID="Label4" runat="server" Text=" "></asp:Label> <asp:Label ID="Label6" runat="server" Text="Months"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="relativelbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="govtserventlbl" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   <asp:TableCell><asp:Label ID="Agerelxlbl1" runat="server" Text="Label"></asp:Label> <asp:Label ID="Label19" runat="server" Text=","></asp:Label> <asp:Label ID="Agerelxlbl2" runat="server" Text="Label"></asp:Label></asp:TableCell>
                   
               </asp:TableRow>

                   

           </asp:Table>
               <br />

                              <asp:Table BackColor="#E2ECEA" class="table-md table-info table-bordered table-hover" HorizontalAlign="Center" ID="Table5" runat="server">

                   <asp:TableRow>
                       <asp:TableCell BackColor="#E4D5E5" >
                           <asp:Button ID="ViewCert" runat="server" class="btn-info" Text="View Certificates" /></asp:TableCell>
                   </asp:TableRow>
               </asp:Table>

                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender4" runat="server" PopupControlID="Panel4" TargetControlID="ViewCert"
CancelControlID="btnClose4" BackgroundCssClass="modalBackground" OnDataBinding="ModalPopupExtender4_DataBinding">
</ajaxToolkit:ModalPopupExtender>



             <asp:Panel ID="Panel4" runat="server" CssClass=".modalPopup2" Style="display: none">

                  <div class="header">                 
        Shortlist the Selected Candidates:
    </div>
    <div class="body">
         <div class="card border-info">
                            <div class="card-body">
        <div class="container">
        <br />
        <center>
            <asp:Label ID="Label7" runat="server" Text="Educational Certificates Upload" Font-Bold="True" ForeColor="#0000CC"></asp:Label> &nbsp;
        </center>



        <asp:Table ID="Table3" runat="server">


            <asp:TableRow ID="SSLCTableRow" runat="server" class="table table-bordered">
                <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>
                <asp:TableCell>10th or Equivalent Certificate</asp:TableCell>

               
                <asp:TableCell>

                    
                    
                    <asp:ImageButton ID="ssc_pdfview" src="imgs/pdficon.png" runat="server" Height="32px" OnClientClick="openInNewTab();" OnClick="ssc_pdfview_Click" Width="36px" />


                </asp:TableCell>


            </asp:TableRow>




            <asp:TableRow ID="HSCTableRow" runat="server" class="table table-bordered">
                <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>
                <asp:TableCell> 12th or Equivalent Certificate</asp:TableCell>

                <asp:TableCell>



                    <asp:ImageButton ID="hsc_pdfview" src="imgs/pdficon.png" runat="server" Height="32px" Width="36px" OnClick="hsc_pdfview_Click" />


                </asp:TableCell>


            </asp:TableRow>

            <asp:TableRow ID="IITTableRow" runat="server" class="table table-bordered">
                <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>
                <asp:TableCell> ITI or its Equivalent Certificate</asp:TableCell>

                <asp:TableCell>



                    <asp:ImageButton ID="ITI_pdfview" src="imgs/pdficon.png" OnClick="ITI_pdfview_Click" runat="server" Height="32px" Width="36px" />


                </asp:TableCell>


            </asp:TableRow>


            <asp:TableRow ID="DIPTableRow" runat="server" class="table table-bordered">
                <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>
                <asp:TableCell> Diploma or its Equivalent Certificate</asp:TableCell>

                <asp:TableCell>



                    <asp:ImageButton ID="DIP_pdfview" src="imgs/pdficon.png" OnClick="DIP_pdfview_Click" runat="server" Height="32px" Width="36px" />


                </asp:TableCell>


            </asp:TableRow>


            <asp:TableRow ID="UGTableRow" runat="server" class="table table-bordered">
                <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>
                <asp:TableCell> UG or its Equivalent Certificate</asp:TableCell>

                <asp:TableCell>



                    <asp:ImageButton ID="UG_pdfview" src="imgs/pdficon.png" OnClick="UG_pdfview_Click" runat="server" Height="32px" Width="36px" />


                </asp:TableCell>


            </asp:TableRow>


            <asp:TableRow ID="PGTableRow" runat="server" class="table table-bordered">
                <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>
                <asp:TableCell> PG or its Equivalent Certificate</asp:TableCell>

                <asp:TableCell>



                    <asp:ImageButton ID="PG_pdfview" src="imgs/pdficon.png" OnClick="PG_pdfview_Click" runat="server" Height="32px" Width="36px" />


                </asp:TableCell>


            </asp:TableRow>



        </asp:Table>
        <br />

        <center>
            <asp:Label ID="Label10" runat="server" Text="Other Mandatory Documents Upload" Font-Bold="True" ForeColor="#0000CC"></asp:Label> &nbsp;
        </center>

        <asp:Table ID="Table4" runat="server">


            <asp:TableRow ID="CommunityTableRow" runat="server" class="table table-bordered">
                <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>
                <asp:TableCell>Community Certificate</asp:TableCell>

                <asp:TableCell>



                    <asp:ImageButton ID="Community_pdfview" src="imgs/pdficon.png" runat="server" Height="32px" OnClick="Community_pdfview_Click" Width="36px" />


                </asp:TableCell>


            </asp:TableRow>




            <asp:TableRow ID="ExperienceTableRow" runat="server" class="table table-bordered">
                <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>
                <asp:TableCell> Experience Details Documents (Combine Multiple pages)</asp:TableCell>

                <asp:TableCell>



                    <asp:ImageButton ID="Experience_pdfview" src="imgs/pdficon.png" runat="server" Height="32px" Width="36px" OnClick="Experience_pdfview_Click" />


                </asp:TableCell>


            </asp:TableRow>

            <asp:TableRow ID="ExServicemanTableRow" runat="server" class="table table-bordered">
                <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>
                <asp:TableCell> Ex-Serviceman Documents </asp:TableCell>

                <asp:TableCell>



                    <asp:ImageButton ID="ExServiceman_pdfview" src="imgs/pdficon.png" OnClick="ExServiceman_pdfview_Click" runat="server" Height="32px" Width="36px" />


                </asp:TableCell>


            </asp:TableRow>


            <asp:TableRow ID="NOCTableRow" runat="server" class="table table-bordered">
                <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>
                <asp:TableCell> NOC from Current Employer (In case of Permanent CSIR or Government Servant)</asp:TableCell>

                <asp:TableCell>



                    <asp:ImageButton ID="NOC_pdfview" src="imgs/pdficon.png" OnClick="NOC_pdfview_Click" runat="server" Height="32px" Width="36px" />


                </asp:TableCell>


            </asp:TableRow>


            <asp:TableRow ID="PWDTableRow" runat="server" class="table table-bordered">
                <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>
                <asp:TableCell> PWD Certificate ((Upload a certificate as pdf issued by competent authority)</asp:TableCell>

                <asp:TableCell>



                    <asp:ImageButton ID="PWD_pdfview" src="imgs/pdficon.png" OnClick="PWD_pdfview_Click" runat="server" Height="32px" Width="36px" />


                </asp:TableCell>

            </asp:TableRow>

        </asp:Table>
            

    </div>
    </div>
    <div class="footer" align="right">
        <asp:Button ID="btnClose4" runat="server" Text="Close" Class="btn-danger" />
    </div>
                 </div>
        </div>
             </asp:Panel>
             
           </div>
       </div>
       <div class="row">
   
   <div class="col-12">
       <br />
   <div class="footer" align="center">
        <asp:Button ID="btnClose3" runat="server" Text="Close Preview" class="btn btn-primary" />

   </div>
   </div>
           </div>
   </div>
   
   </div>
           </div>
   </div>
   </asp:Panel>
   </div>
   </div>
             
    </div>

</asp:Content>
