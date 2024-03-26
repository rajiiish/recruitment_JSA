<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="can_profile.aspx.cs" Inherits="recruitment.can_profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 25px;
        }
        .auto-style3 {
            height: 25px;
            text-align: center;
        }


        
        .tablemain {
  border: 1px solid black;
  border-radius: 10px;
}

        .tablecss {
  border-collapse: collapse;
  width: 100%;
  height: 608px; 
  vertical-align: top; 
  width: 763px; 
  margin-left: auto; 
  margin-right: auto;
}


th, td {
  padding: 8px;
  text-align: left;
  border-bottom: 1px solid #ddd;
}
        .auto-style4 {
            height: 25px;
            font-weight: bold;
        }
        .auto-style5 {
            font-weight: bold;
            color: #003366;
        }
        .auto-style6 {
            height: 25px;
            font-weight: bold;
            color: #003366;
        }
        .auto-style7 {
            font-weight: normal;
            color: #006600;
            height: 23px;
            width: 762px;
            text-align: center;
        }
        .auto-style9 {
            font-weight: bold;
            color: #006600;
            height: 25px;
            text-align: center;
        }
        .auto-style10 {
            font-weight: normal;
            color: #006600;
        }
        .auto-style11 {
            height: 25px;
            font-weight: bold;
            color: #003366;
            text-align: center;
        }
        .auto-style12 {
            color: #CC3300;
        }
        .auto-style13 {
            color: rgb(0, 102, 0);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="container">
        c<br />
        <div class="card bg-light align-content-center">
            <div class="card-body"> 
                <div class="row">
            <div class="col-12">
                </div>
               <center> <asp:Label ID="Label1" runat="server" Text="Search by Recruitment Application ID:" CssClass="auto-style12"></asp:Label>   &nbsp <asp:TextBox ID="searchtxt" runat="server"></asp:TextBox> &nbsp <asp:Button ID="searchbyid" runat="server" Text="Search" OnClick="searchbyid_Click" /></center>
                    </div>
                </div>
            </div>
        
    </div>
       
    <asp:Panel ID="Panel1" runat="server">
        <div class="container">
        <div class="bg-light  text-center">
             
       <p >Candidate Registration Number:
              <asp:Label ID="regidlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="Blue"></asp:Label>
       Application ID: <asp:Label ID="appidnolbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label>
            
            Post Applying For: <asp:Label ID="applyhpostlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label>  </p>
      </div>

    </div>    
        </asp:Panel>

         <asp:Panel ID="PrePanel" runat="server">
               <div class="container">
        <div class="bg-light  text-center">
        
        
      </div>

    </div>


    <div class="container">
         <div class="card bg-light">
               <div class="card-body"> 
        <div class="row">
            <div class="col-12">
            
            
  <center>  <!-- ######## This is a comment, visible only in the source editor  ######## -->

<p><strong style="color: #000;">Note:</strong> Candidates are requested to take print out of the application for self reference.</p>
</center>
<table class="tablecss" >
<thead>
<tr style="height: 23px;">
<td colspan="3" class="auto-style7"> <strong>Basic Informations</strong></td>
</tr>
</thead>
<tbody>
<tr style="height: 25px;">
<td style="min-width: 140px; height: 25px; width: 316.812px;" class="auto-style5"><span>Full name</span></td>
<td style="width: 262.688px; height: 25px;">
    <strong>
    <asp:Label ID="fullnamelbl" runat="server" Text="Label"></asp:Label>
    </strong>
    </td>
<td style="height: 200px; width: 182.5px;" rowspan="8">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Image ID="photo" runat="server" Height="176px" Width="134px" />
    <br/>
    </td>
</tr>
<tr style="height: 25px;">
<td style="height: 25px; width: 316.812px;" class="auto-style5"><span>Father Name</span></td>
<td style="width: 262.688px; height: 25px;">
    <b>
    <asp:Label ID="fathernamelbl" runat="server" Text="Label"></asp:Label>
    </b>
    </td>
</tr>
    <tr style="height: 25px;">
<td style="height: 25px; width: 316.812px;" class="auto-style5"><span>Mother Name</span></td>
<td style="width: 262.688px; height: 25px;">
    <b>
    <asp:Label ID="mothernamelbl" runat="server" Text="Label"></asp:Label>
    </b>
    </td>
</tr>
<tr style="height: 25px;">
<td style="height: 25px; width: 316.812px;" class="auto-style5"><span>DOB</span></td>
<td style="width: 262.688px; height: 25px;">
    <b>
    <asp:Label ID="doblbl" runat="server" Text="Label"></asp:Label>
    </b>
    </td>
</tr>
<tr style="height: 25px;">
<td valign="top" style="height: 25px; width: 316.812px;" class="auto-style5"><span>GENDER</span></td>
<td style="width: 262.688px; height: 25px;">
    <b>
    <asp:Label ID="genderlbl" runat="server" Text="Label"></asp:Label>
    </b>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>CATEGORY</span></td>
<td style="width: 262.688px; height: 25px;">
    <b>
    <asp:Label ID="categorylbl" runat="server" Text="Label"></asp:Label>
    </b>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>Marital Status</span></td>
<td style="width: 262.688px; height: 25px;">
    <b>
    <asp:Label ID="maritallbl" runat="server" Text="Label"></asp:Label>
    </b>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>Religion<br /></span></td>
<td style="width: 262.688px; height: 25px;">
    <b>
    <asp:Label ID="religionlbl" runat="server" Text="Label"></asp:Label>
    </b>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>Are you a CSIR Employee</span></td>
<td style="width: 262.688px; height: 25px;">
    <b>
    <asp:Label ID="csiremplbl" runat="server" Text="Label"></asp:Label>
    </b>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>PWD Catagory</span></td>
<td class="auto-style4" colspan="2">
    <asp:Label ID="pwdcatlbl1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="pwdcatlbl2" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="pwdcatlbl3" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>Are you an Ex-Servicemen</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="armylbl" runat="server" Text="Label"></asp:Label>  <asp:Label ID="armylblservice" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>Are you an Indian Citizen</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="citizenlbl" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
    <tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>Place or City of Born</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="placebornlbl" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>Aadhaar Number</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="aadhaarlbl" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>Bank Reference Number</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="bankreflbl" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>Payment Date</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="paydatelbl" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>Mode of Payment</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="paymodelbl" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>E-Mail Address</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="emaillbl" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>Mobile Number</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="mobilelbl" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5"><span>Present Address / Communication Address</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="presentaddlbl" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr style="height: 10px;">
<td style="width: 316.812px; height: 10px;" class="auto-style5"><span>Permanent Address</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="permaddlbl" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 762px; height: 25px;" colspan="3" class="auto-style5"><span>&nbsp;</span></td>
</tr>

<tr style="height: 25px;">
<td class="auto-style9" colspan="3">Educational Qualification Details:</td>
</tr>

    <tr style="height: 25px;">
<td class="auto-style2" colspan="3">
   
      
                                                        
                                                                <asp:Table ID="Table1"  Height="317px" Width="757px" BackColor="White" BorderColor="#336666"  BorderStyle="Double" BorderWidth="3px"  Font-Bold="False" Font-Size="10pt" GridLines="Horizontal" runat="server" CssClass="AspCell" >
                                                                    <asp:TableHeaderRow class="table table-bordered">
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Qualification</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Group Name</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Main Subject</asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Institute/School Name</asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Marks in Percentage </asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Year of Passing </asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Division/Grade </asp:TableHeaderCell> 
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
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Qualification</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Specialization/Degree Name</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Main Subject</asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" >Institute/University/College Name</asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Marks in Percentage </asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Year of Passing </asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Division/Grade </asp:TableHeaderCell> 
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
                                                                
                                                        
                       </td>                             
    </tr>
    <tr style="height: 25px;">
<td class="auto-style11" colspan="3"> <span class="auto-style10"><strong>Phd Details:</strong></span><span class="auto-style5">
    <asp:Label ID="phdlabl" runat="server" Text="No Record Added"></asp:Label>
    </span> </td>
</tr>
    <tr style="height: 25px;">
<td class="auto-style6" colspan="3">
    <asp:Table ID="phdtable" Height="126px" Width="870px" BackColor="White" BorderColor="#336666"  BorderStyle="Double" BorderWidth="3px"  Font-Bold="False" Font-Size="10pt" GridLines="Horizontal" runat="server" CssClass="AspCell" >
                                                                    <asp:TableHeaderRow  id="phdTitleRow" class="table table-bordered">
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Phd Title</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Month & Year of Completion</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Area of Study</asp:TableHeaderCell>
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Breif the Title</asp:TableHeaderCell>
                                                                       
                                                                    </asp:TableHeaderRow>
      

                                                                       <asp:TableRow id="phdRow" class="table table-bordered">
                                                                        <asp:TableCell > <asp:Label ID="phd1" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="phd2" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="phd3" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="phd4" runat="server" Text="Label"></asp:Label>  </asp:TableCell>   
                                                                        
                                                                    </asp:TableRow>
        </asp:Table>
       
    </td>
 </tr>

    <tr style="height: 25px;">
<td class="auto-style11" colspan="3"> <span class="auto-style10"><strong>Gate Details:</strong></span><span class="auto-style5">
    <asp:Label ID="GATElabl" runat="server" Text="No Record Added"></asp:Label>
    </span> </td>
</tr>
    <tr style="height: 25px;">
<td class="auto-style6" colspan="3">
    <asp:Table ID="GATEtable" Height="126px" Width="870px" BackColor="White" BorderColor="#336666"  BorderStyle="Double" BorderWidth="3px"  Font-Bold="False" Font-Size="10pt" GridLines="Horizontal" runat="server" CssClass="AspCell" >
                                                                    <asp:TableHeaderRow  id="GATETitleRow" class="table table-bordered">
                                                                        <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Gate Marks in Percentage</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Month & Year of Completion</asp:TableHeaderCell>
                                                                         <asp:TableHeaderCell BackColor="#336666" ForeColor="White" > Branch</asp:TableHeaderCell>
                                                                       
                                                                    </asp:TableHeaderRow>
      

                                                                       <asp:TableRow id="GATERow" class="table table-bordered">
                                                                        <asp:TableCell > <asp:Label ID="gate1" runat="server" Text="gate1"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="gate2" runat="server" Text="gate2"></asp:Label>  </asp:TableCell>   
                                                                         <asp:TableCell> <asp:Label ID="gate3" runat="server" Text="gate3"></asp:Label>  </asp:TableCell>   
                                                                        
                                                                    </asp:TableRow>
        </asp:Table>
       
    </td>
 </tr>

<!--<tr style="height: 25px;">
<td style="width: 762px; height: 25px;" colspan="3" class="auto-style5"><span>&nbsp;<asp:GridView ID="GridView1"  class="table table-bordered" runat="server" Height="126px" Width="757px" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" Font-Bold="False" Font-Size="10pt" GridLines="Horizontal">
    <FooterStyle BackColor="White" ForeColor="#333333" />
    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="White" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#487575" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
    </span></td>
</tr>-->
  
<tr style="height: 25px;">
<td class="auto-style11" colspan="3"> <span class="auto-style10"><strong>Experience Details:</strong></span><span class="auto-style5"> </span> </td>
</tr>

<tr style="height: 25px;">
<td class="auto-style2" colspan="3">
    <asp:GridView ID="GridView2"  class="table table-bordered" runat="server" Height="126px" Width="870px" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" Font-Bold="False" Font-Size="10pt" GridLines="Horizontal" OnRowDataBound="GridView2_RowDataBound">
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
         <AlternatingRowStyle BackColor="PaleGoldenrod" />
            
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
    </td>
</tr>
<tr style="height: 25px;">
<td  colspan="3" class="text-center"><span class="auto-style10"><strong>Any Other Informations</strong></span><span class="auto-style5"> </span></td>

</tr>
    <tr style="height: 10px;">
<td style="width: 316.812px; height: 10px;" class="auto-style5"><span>Have you been outside india?</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="forignvisitlbl" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
     <tr style="height: 10px;">
<td style="width: 316.812px; height: 10px;" class="auto-style5"><span>Are you under any bond or contract to serve Central/State/Autonomous Bodies / PSU?</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="bondlbl" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
     <tr style="height: 10px;">
<td style="width: 316.812px; height: 10px;" class="auto-style5"><span>Minimum joining time required (months)</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="joinglbl" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
     <tr style="height: 10px;">
<td style="width: 316.812px; height: 10px;" class="auto-style5"><span>Any of your Blood relation working in CSIR? </span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="relativelbl" runat="server" Text="Label"></asp:Label> <br />
    <asp:Label ID="relativdetaillbl" runat="server" Text=""></asp:Label> 
    </td>
</tr>
        <tr style="height: 10px;">
<td style="width: 316.812px; height: 10px;" class="auto-style5"><span> Are you a Permanent CSIR/Government Servant at Present?:</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="govtserventlbl" runat="server" Text="Label"></asp:Label>
    </td>
</tr>
       <tr style="height: 10px;">
<td style="width: 316.812px; height: 10px;" class="auto-style5"><span>Are you claiming for age relaxation other than SC/ST/OBC?</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="Agerelxlbl1" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Agerelxlbl2" runat="server" Text="Label"></asp:Label>

    </td>
</tr>
        <tr style="height: 10px;">
<td style="width: 316.812px; height: 10px;" class="auto-style5"><span>Reference</span></td>
<td class="auto-style4" colspan="2" >
    <asp:Label ID="Referencelbl1" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="Referencelbl2" runat="server" Text="Label"></asp:Label><br />
    

    </td>
</tr>
<tr style="height: 25px;">
<td class="auto-style6" colspan="3"><span class="auto-style14"><strong>Declaration:</strong></span> <br /> 
    <img alt="" class="auto-style15" src="imgs/right.png" />I hereby declare that all the statements made in this application are true and complete to the best of my knowledge and belief and nothing has been concealed or/distorted. I am aware that, if at any time I am found to have concealed/distorted any material/information, my appointment is liable to be summarily terminated without notice.</td>
</tr>

<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5">&nbsp;</td>
<td class="auto-style3" colspan="2">
    <asp:Image ID="Signpic" runat="server" Height="74px" Width="283px" />
    </td>
</tr>
<tr style="height: 25px;">
<td style="width: 316.812px; height: 25px;" class="auto-style5">&nbsp;</td>
<td class="auto-style3" colspan="2">Signature of the Candidate</td>
</tr>
    
    <tr style="height: 25px;">
    <td class="auto-style6" colspan="3">
        <center>
            <br />
            <br />
            <br />
            <br />
        </center>
    </td>

    </tr>
</tbody>
</table>
                <br />
                <br />
<hr />
<p class="text-center"><span style="font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: -webkit-center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;" class="auto-style13"><strong>Candidate already employed in Govt. Departments should apply &quot;Through Proper Channel&quot; endorsement signed by his/her present employer</strong></span></p>
                <div class="text-center">
            ------------------------For others: <span class="auto-style12"><strong>No Hardcopy of application is required to be sent</strong></span> --------------------------</div>
<hr />
            </div>
         </div>
                   </div>
             </div>
        </div>
         </asp:Panel>

       
</asp:Content>
