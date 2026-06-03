<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" EnableEventValidation = "false"  CodeBehind="AdminPreview.aspx.cs" Inherits="recruitment.AdminPreview" %>
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
        max-height:80%;
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
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
 <div class="container-fluid">
     <br />
     <br />
          <div class="row">
                       <div class="col-12">
                        <div class="card border-info">
                            <div class="card-body">
                                
                       <asp:Label ID="droplblname" runat="server" Text="Select Post Code to View"></asp:Label>
                      <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="True" Height="27px" Width="257px">
            
            <asp:ListItem Value="TA-CIVIL">Technical Assistant (Civil)</asp:ListItem>
            <asp:ListItem Value="TA-IT">Technical Assistant (IT)</asp:ListItem>
            <asp:ListItem Value="JSA">Junior Secretariat Assistant</asp:ListItem>
        </asp:DropDownList>
 &nbsp;   <asp:Label ID="Label3" runat="server" Text="Submitted"></asp:Label>
                      <asp:DropDownList ID="SubmitteDrop" runat="server"  AutoPostBack="True" Height="27px" Width="57px">
            
            <asp:ListItem Value="all">All</asp:ListItem>
            <asp:ListItem Value="Yes">Yes</asp:ListItem>
            <asp:ListItem Value="No">No</asp:ListItem>
        </asp:DropDownList>


                                 &nbsp;      &nbsp;   &nbsp;   &nbsp;   &nbsp;   &nbsp; 
                  <asp:RequiredFieldValidator ErrorMessage="Enter Number" ControlToValidate="markstxt"  validationgroup="filtergrp" runat="server" ForeColor="Red" />
               <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  validationgroup="filtergrp" ControlToValidate="markstxt" runat="server" Display="Dynamic" ErrorMessage="Only Numbers" ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>


                                <asp:Label ID="Label1" runat="server" Text="Filter by Marks:"></asp:Label>
                                <asp:TextBox ID="markstxt" runat="server" Height="30px" Width="80px"></asp:TextBox>


                                 <asp:Label ID="Label2" runat="server" Text=">=" Font-Bold="True" ></asp:Label>
                                 <asp:DropDownList ID="DropDownList2" runat="server"  AutoPostBack="True" Height="27px" Width="257px">
              <asp:ListItem Value="0">--SELECT--</asp:ListItem>
            <asp:ListItem Value="sslc">SSLC</asp:ListItem>
            <asp:ListItem Value="hsc">HSC</asp:ListItem>
            <asp:ListItem Value="iti">ITI</asp:ListItem>
            <asp:ListItem Value="dip">DIPLOMA</asp:ListItem>
            <asp:ListItem Value="ug">UG</asp:ListItem>
            <asp:ListItem Value="pg">PG</asp:ListItem>
          
        </asp:DropDownList>
                  <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="DropDownList2" InitialValue="0" validationgroup="filtergrp" runat="server" ForeColor="Red" />

                                <asp:Button ID="Filterbtn" runat="server" Text="Filter" validationgroup="filtergrp"  OnClick="Filterbtn_Click" />

                         

                                
                       </div>
                                
                            </div>
</div>

</div>

     <br />

          <div class="row">
                                      <div class="col-12">
                        <div class="card border-info">
                            <div class="card-body">

                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineapplicationConnectionString1 %>" SelectCommand="SELECT * FROM [basicdetailsNew] WHERE ([postcode] = @postcode)">
                                        <SelectParameters>

                                        <asp:ControlParameter ControlID="DropDownList1" Name="postcode" PropertyName="SelectedValue" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
     <center>   <asp:Button ID="ExportExclBtn" runat="server" Text="Export to Excel" OnClick="ExportExclBtn_Click" /></center>
                                <br /> 
                                   <asp:GridView ID="GridView1" cssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="appregno"  OnRowDataBound="GridView1_RowDataBound" Font-Size="9pt" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" Font-Bold="True" GridLines="Vertical">
                                       <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                
                <asp:BoundField DataField="appregno" HeaderText="appregno" InsertVisible="False" ReadOnly="True" SortExpression="appregno" />
                <asp:BoundField DataField="fullname" HeaderText="FULL NAME " SortExpression="fullname" HeaderStyle-HorizontalAlign="left" ItemStyle-HorizontalAlign="Justify"/>
                <asp:BoundField DataField="fathername" HeaderText="FAHTER / HUSBAND /GURADIAN NAME" ReadOnly="True" SortExpression="fathername" />
                <asp:BoundField DataField="dateofbirth" HeaderText="DOB" SortExpression="dateofbirth" />
                <asp:BoundField DataField="sexuality" HeaderText="GENDER" SortExpression="sexuality" />
                <asp:BoundField DataField="cast" HeaderText="CAST" SortExpression="cast" />
               
                <asp:BoundField DataField="religion" HeaderText="RELIGION" SortExpression="religion" />
                <asp:BoundField DataField="csiremp" HeaderText="IS CSIR EMP?" SortExpression="csiremp" />
                <asp:BoundField DataField="pwd" HeaderText="PWD?" SortExpression="pwd" />
                <asp:BoundField DataField="ExArmy" HeaderText="EX ARMY?" SortExpression="ExArmy" />
                <asp:BoundField DataField="UnderBond" HeaderText="UNDER ANY BOND?" SortExpression="UnderBond" />
                <asp:BoundField DataField="IsRelativeCSIR" HeaderText="IS RELATIVE TO CSIR EMP?" SortExpression="IsRelativeCSIR" />
                <asp:BoundField DataField="SSLCPmarks" HeaderText="SSLC" SortExpression="SSLCPmarks" />
                <asp:BoundField DataField="HSCPmarks" HeaderText="HSC" SortExpression="HSCPmarks" />
                <asp:BoundField DataField="ITIPmarks" HeaderText="ITI" SortExpression="ITIPmarks" />
                <asp:BoundField DataField="DIPLOMAPmarks" HeaderText="DIPLOMA" SortExpression="DIPLOMAPmarks" />
                <asp:BoundField DataField="UGPmarks" HeaderText="UG" SortExpression="UGPmarks" />
                 <asp:BoundField DataField="PGPmarks" HeaderText="PG" SortExpression="PGPmarks" />

                <asp:BoundField DataField="IsCompleted"  HeaderText="IsCompleted" SortExpression="IsCompleted" />
                <asp:BoundField DataField="IsShortlisted" HeaderText="Shortlisted" SortExpression="IsShortlisted" />
           
                 <asp:TemplateField>
                 <ItemTemplate>
                 <asp:LinkButton ID  ="ShortlistLbtn1" class="btn btn-sm btn-success" OnClick="ShortlistLbtn_Click" runat="server" >Shortlist</asp:LinkButton>
                     
                     <asp:ImageButton ID="rigthimgbtn" src="imgs/right.png" width="25" height="25" runat="server" />
                 </ItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField>
                 <ItemTemplate>
                 <asp:LinkButton ID  ="NotEligibleBtn" class="btn btn-sm btn-warning" OnClick="RejecLinkClick_Click"  runat="server" >Reject</asp:LinkButton>
                     <asp:ImageButton ID="wrnimgbtn" src="imgs/wrong.png" width="25" height="25" runat="server" />
                 </ItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField>
                 <ItemTemplate>
                 <asp:LinkButton ID  ="PreviewBtn" class="btn btn-sm btn-info"  OnClick="PreviewClicklinbtn_Click" runat="server" >Preview</asp:LinkButton>
                 </ItemTemplate>
                 </asp:TemplateField>

            </Columns>
                                      
                                       <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                       <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                       <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                       <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                       <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                       <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                       <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                       <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                       <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
                                <asp:Label ID="testlbl" runat="server" Text="Label"></asp:Label>

                                </div>
                            </div>
                        </div>
                   </div>

     <div class="row">
         <div class="col-12">
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

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
        <asp:Button ID="btnClose2" runat="server" Text="Close" CssClass="button" />
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
   <div class="card border-info">
   <div class="card-body ">
   



   <div class="row">

   <asp:Label ID="appregnolbl3" runat="server" Text=""></asp:Label>
   <div class="col-12"></div>
   <div class="footer" align="center">
        <asp:Button ID="btnClose3" runat="server" Text="Close" CssClass="button" />
   </div>
   </div>
   </div>
   
   </div>
   </div>
   </asp:Panel>
   </div>
   </div>
   </div>
        </form>
    </asp:Content>
