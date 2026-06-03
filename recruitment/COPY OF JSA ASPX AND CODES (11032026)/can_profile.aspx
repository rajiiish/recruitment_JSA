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
             <div class="container fontsize" >
        <div class="bg-light  text-center">

       
        </div>

    </div>


    <div class="container fontsize">
        <div class="card bg-light">
            <div class="card-body">
                <div class="row">
                    <div class="col-12">


                        <center>
                            <!-- ######## This is a comment, visible only in the source editor  ######## -->

                            <!--<p><strong style="color: #000;">Note:</strong> Candidates are requested to take a print out of the application for self-reference.</p>-->
                            <div class="text-center d-print-none">
                            </div>
                        </center>
                        <table class="tablecss">
                            <thead>
                                </thead>
                                <tr style="height: 23px;">
                                    <td colspan="3" class="auto-style7" style="border: thin solid #000000"><strong>Basic Information</strong></td>
                                </tr>
                            

                            <tr style="height: 25px; ">
                                <td style="min-width: 140px; height: 25px; width: 316.812px; border: thin solid #000000" class="auto-style5"><span>Full Name</span></td>
                                <td style="width: 262.688px; height: 25px; border: thin solid #000000"">
                                    <strong>
                                        <asp:Label ID="fullnamelbl" runat="server" Text="Label"></asp:Label>
                                    </strong>
                                </td>
                                <td style="height: 200px; width: 182.5px; border: thin solid #000000" rowspan="8">
   <label><strong>Photo</strong></label> <br /><asp:Image ID="photo" runat="server" Height="144px" Width="123px" /> <br /> <label><strong>Signature</strong></label><asp:Image ID="Signpic" runat="server" Height="43px" Width="164px" />
                                    <br />
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="height: 25px; width: 316.812px; border: thin solid #000000" class="auto-style5"><span>Father Name</span></td>
                                <td style="width: 262.688px; height: 25px;border: thin solid #000000">
                                    <b>
                                        <asp:Label ID="fathernamelbl" runat="server" Text="Label"></asp:Label>
                                    </b>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="height: 25px; width: 316.812px;border: thin solid #000000" class="auto-style5"><span>Mother Name</span></td>
                                <td style="width: 262.688px; height: 25px;border: thin solid #000000">
                                    <b>
                                        <asp:Label ID="mothernamelbl" runat="server" Text="Label"></asp:Label>
                                    </b>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="height: 25px; width: 316.812px;border: thin solid #000000" class="auto-style5"><span>Date of Birth</span></td>
                                <td style="width: 262.688px; height: 25px; border: thin solid #000000">
                                    <b>
                                        <asp:Label ID="doblbl" runat="server" Text="Label"></asp:Label>
                                    </b>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td valign="top" style="height: 25px; width: 316.812px; border: thin solid #000000" class="auto-style5"><span>Gender</span></td>
                                <td style="width: 262.688px; height: 25px; border: thin solid #000000"">
                                    <b>
                                        <asp:Label ID="genderlbl" runat="server" Text="Label"></asp:Label>
                                    </b>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000" class="auto-style5"><span>Category</span></td>
                                <td style="width: 262.688px; height: 25px; border: thin solid #000000">
                                    <b>
                                        <asp:Label ID="categorylbl" runat="server" Text="Label"></asp:Label>
                                    </b>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000" class="auto-style5"><span>Marital Status</span></td>
                                <td style="width: 262.688px; height: 25px; border: thin solid #000000 ">
                                    <b>
                                        <asp:Label ID="maritallbl" runat="server" Text="Label"></asp:Label>
                                    </b>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px;border: thin solid #000000" class="auto-style5"><span>Religion</span></td>
                                <td style="width: 262.688px; height: 25px; border: thin solid #000000">
                                    <b>
                                        <asp:Label ID="religionlbl" runat="server" Text="Label"></asp:Label>
                                    </b>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000" class="auto-style5"><span>Are you a CSIR Employee?</span></td>
                                <td colspan="2" style="border: thin solid #000000" class="auto-style16">
                                    <b>
                                        <asp:Label ID="csiremplbl" runat="server" Text="Label"></asp:Label>
                                    </b>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000" class="auto-style5"><span>PwBD Category?</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="pwdcatlbl1" runat="server" Text="Label"></asp:Label>
                                    <asp:Label ID="pwdpctlbl" runat="server" Text="Percentage of disability : "></asp:Label>
                                    <asp:Label ID="pwdcatlbl2" runat="server" Text="Label"></asp:Label>
                                    <asp:Label ID="pwdtypelbl" runat="server" Text="Type of Disability : ">  </asp:Label>
                                    <asp:Label ID="pwdcatlbl3" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000" class="auto-style5">Are you an Ex<span>-Servicemen?</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="armylbl" runat="server" Text="Label"></asp:Label>
                                    <asp:Label ID="PrdServicelbl" runat="server" Text="Period of Service (in Years) : "></asp:Label>
                                    <asp:Label ID="armylblservice" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000"" class="auto-style5"><span>Are you an Indian Citizen?</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="citizenlbl" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000"" class="auto-style5"><span>Place of Birth</span></td>
                                <td style="border: thin solid #000000"class="auto-style4" colspan="2">
                                    <asp:Label ID="placebornlbl" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000"" class="auto-style5"><span>Aadhaar Number</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="aadhaarlbl" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000"" class="auto-style5"><span>Bank Reference Number</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="bankreflbl" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000"" class="auto-style5"><span>Payment Date</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="paydatelbl" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000" class="auto-style5"><span>Mode of Payment</span></td>
                                <td style="border: thin solid #000000"class="auto-style4" colspan="2">
                                    <asp:Label ID="paymodelbl" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000" class="auto-style5"><span>E-Mail Address</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="emaillbl" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000" class="auto-style5"><span>Mobile Number</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="mobilelbl" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000" class="auto-style5"><span>Present Address / Communication Address</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="presentaddlbl" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 10px;">
                                <td style="width: 316.812px; height: 10px; border: thin solid #000000" class="auto-style5"><span>Permanent Address</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="permaddlbl" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>

                            

                            <tr style="height: 25px; ">
                                <td style="border: thin solid #000000" class="auto-style9" colspan="3">Educational Qualification Details:</td>
                            </tr>

                            <tr style="height: 25px;">
                                <td style="border: thin solid #000000" class="auto-style2" colspan="3">



                                    <asp:Table ID="Table1" Height="317px" Width="869px" BackColor="White" BorderColor="#000000" BorderStyle="solid" BorderWidth="1px" Font-Bold="False" Font-Size="10pt" GridLines="Both" runat="server" ForeColor="Black">
                                            <asp:TableHeaderRow class="table font-weight-bold table-bordered ">
                                            <asp:TableHeaderCell BackColor="White" ForeColor="Black"> Qualification</asp:TableHeaderCell>
                                            <asp:TableHeaderCell BackColor="White" ForeColor="Black"> Group Name</asp:TableHeaderCell>
                                            <asp:TableHeaderCell BackColor="White" ForeColor="Black"> Main Subject</asp:TableHeaderCell>
                                            <asp:TableHeaderCell BackColor="White" ForeColor="Black"> Institute/School Name</asp:TableHeaderCell>
                                            <asp:TableHeaderCell BackColor="White" ForeColor="Black"> Marks in Percentage </asp:TableHeaderCell>
                                            <asp:TableHeaderCell BackColor="White" ForeColor="Black"> Year of Passing </asp:TableHeaderCell>
                                            <asp:TableHeaderCell BackColor="White" ForeColor="Black"> Division/Grade </asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                        <asp:TableRow ID="sslcRow" class="table table-bordered">
                                            <asp:TableCell>
                                                <asp:Label ID="ssl1" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ssl2" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ssl3" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ssl4" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="AspCell">
                                                <asp:Label ID="ssl5" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="AspCell">
                                                <asp:Label ID="ssl6" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell CssClass="AspCell">
                                                <asp:Label ID="ssl7" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>

                                        </asp:TableRow>

                                        <asp:TableRow ID="hscRow" class="table table-bordered">
                                            <asp:TableCell>
                                                <asp:Label ID="hsc1" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="hsc2" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="hsc3" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="hsc4" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="hsc5" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="hsc6" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="hsc7" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>

                                        </asp:TableRow>
                                        <asp:TableRow ID="ITIRow" class="table table-bordered">
                                            <asp:TableCell>
                                                <asp:Label ID="ITI1" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ITI2" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ITI3" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ITI4" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ITI5" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ITI6" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ITI7" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>

                                        </asp:TableRow>
                                        

                                        <asp:TableHeaderRow ID="ugpgtitleRow" class="table table-bordered">
                                            <asp:TableHeaderCell BackColor="White" ForeColor="Black"> Qualification</asp:TableHeaderCell>
                                            <asp:TableHeaderCell BackColor="White" ForeColor="Black"> Specialization/Degree Name</asp:TableHeaderCell>
                                            <asp:TableHeaderCell BackColor="White" ForeColor="Black"> Main Subject</asp:TableHeaderCell>
                                            <asp:TableHeaderCell BackColor="White" ForeColor="Black">Institute/University/College Name</asp:TableHeaderCell>
                                            <asp:TableHeaderCell BackColor="White" ForeColor="Black"> Marks in Percentage </asp:TableHeaderCell>
                                            <asp:TableHeaderCell BackColor="White" ForeColor="Black"> Year of Passing </asp:TableHeaderCell>
                                            <asp:TableHeaderCell BackColor="White" ForeColor="Black"> Division/Grade </asp:TableHeaderCell>
                                        </asp:TableHeaderRow>

                                        <asp:TableRow ID="dipRow" class="table table-bordered">
                                            <asp:TableCell>
                                                <asp:Label ID="dip1" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="dip2" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="dip3" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="dip4" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="dip5" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="dip6" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="dip7" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>

                                        </asp:TableRow>

                                        <asp:TableRow ID="ugRow" class="table table-bordered">
                                            <asp:TableCell>
                                                <asp:Label ID="ug1" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ug2" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ug3" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ug4" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ug5" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ug6" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="ug7" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>

                                        </asp:TableRow>
                                        <asp:TableRow ID="pgRow" class="table table-bordered">
                                            <asp:TableCell>
                                                <asp:Label ID="pg1" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="pg2" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="pg3" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="pg4" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="pg5" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="pg6" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell>
                                                <asp:Label ID="pg7" runat="server" Text="Label"></asp:Label>
                                            </asp:TableCell>

                                        </asp:TableRow>

                                    </asp:Table>


                                </td>
                            </tr>





                            <!--<tr style="height: 25px;">
<td style="width: 762px; height: 25px;" colspan="3" class="auto-style5"><span>&nbsp;<asp:GridView ID="GridView1"  class="table table-bordered" runat="server" Height="126px" Width="757px" BackColor="White" BorderColor="White" BorderStyle="Double" BorderWidth="3px" CellPadding="4" Font-Bold="False" Font-Size="10pt" GridLines="Horizontal">
    <FooterStyle BackColor="White" ForeColor="#333333" />
    <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
    <RowStyle BackColor="White" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="Black" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#487575" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
    </span></td>
</tr>-->

                            <tr style="height: 25px;">
                                <td style="border: thin solid #000000" class="auto-style11" colspan="3"><span class="auto-style10"><strong>Experience Details:</strong></span><span class="auto-style5"> </span>
                                    <asp:Label ID="Explable" runat="server" Text="No Record Added"></asp:Label>
                                </td>

                            </tr>

                            <tr style="height: 25px;">
                                <td style="border: thin solid #000000" class="auto-style2" colspan="3">
                                    <asp:GridView ID="GridView2" class="table table-bordered" runat="server" Height="126px" Width="870px" BackColor="White" BorderColor="White" BorderStyle="Double" BorderWidth="3px" CellPadding="4" Font-Bold="False" Font-Size="10pt" GridLines="Horizontal" OnRowDataBound="GridView2_RowDataBound">
                                        <FooterStyle BackColor="White" ForeColor="#333333" />
                                        <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                                        <AlternatingRowStyle BackColor="White" />

                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                        <RowStyle BackColor="White" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="Black" />
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#487575" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#275353" />
                                    </asp:GridView>
                                </td>
                            </tr>

                            <tr style="height: 25px;">
                                <td style="border: thin solid #000000" colspan="3" class="text-center"><span class="auto-style10"><strong>Any Other Information</strong></span><span class="auto-style5"> </span></td>

                            </tr>
                            <tr style="height: 10px;">
                                <td style="width: 316.812px; height: 10px; border: thin solid #000000 " class="auto-style5"><span>Have you been outside india?</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="forignvisitlbl" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 10px;">
                                <td style="width: 316.812px; height: 10px; border: thin solid #000000" class="auto-style5"><span>Are you under any bond or contract to serve Central/State/Autonomous Bodies / PSU?</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="bondlbl" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            
     <tr style="height: 10px;">
         <td style="width: 316.812px; height: 10px; border: thin solid #000000" class="auto-style5"><span>Any of your blood relation working in CSIR? </span></td>
         <td style="border: thin solid #000000"class="auto-style4" colspan="2">
             <asp:Label ID="relativelbl" runat="server" Text="Label"></asp:Label>
             <br />
             <asp:Label ID="relativdetaillbl" runat="server" Text=""></asp:Label>
         </td>
     </tr>
                            <tr style="height: 10px;">
                                <td style="width: 316.812px; height: 10px; border: thin solid #000000" class="auto-style5"><span>Are you a Permanent CSIR/Government Servant at Present?</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="govtserventlbl" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr style="height: 10px;">
                                <td style="width: 316.812px; height: 10px; border: thin solid #000000" class="auto-style5"><span>Are you claiming for age relaxation?</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="Agerelxlbl1" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Agerelxlbl2" runat="server" Text="Label"></asp:Label>

                                </td>
                            </tr>
                            <tr style="height: 10px;">
                                <td style="width: 316.812px; height: 10px; border: thin solid #000000" class="auto-style5"><span>Reference</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="Referencelbl1" runat="server" Text="Label"></asp:Label><br />
                                    <asp:Label ID="Referencelbl2" runat="server" Text="Label"></asp:Label><br />


                                </td>
                            </tr>
                           <tr style="height: 10px;">
                                <td style="width: 316.812px; height: 10px; border: thin solid #000000" class="auto-style5"><span>Medium for Computer Proficiency Test</span></td>
                                <td style="border: thin solid #000000" class="auto-style4" colspan="2">
                                    <asp:Label ID="TypingMediumLbl" runat="server" Text="Label"></asp:Label><br />
                                    


                                </td>
                            </tr>

                            <tr style="height: 25px;">
                                <td style="border: thin solid #000000" colspan="3" class="text-center"><span class="auto-style10"><strong>Declaration</strong></span></td>

                            </tr>
                            <tr style="height: 25px;">
                                <td style="border: thin solid #000000" class="auto-style6" colspan="3"><span class="auto-style14"><strong></strong></span>
                                    <br />
                                    <img alt="" class="auto-style15" src="imgs/right.png" />I hereby declare that all the statements made in the application are true, complete and correct to the best of my knowledge and belief and in the event of any of the information being found false or incorrect or any ineligibility being detected before or after the selection, my candidature is liable to be cancelled and action may be initiated against me</td>
                            </tr>

                            <tr style="height: 25px;">
                                <td style="width: 316.812px; height: 25px; border: thin solid #000000" > <strong>Date&nbsp;&nbsp;:</strong><br />
                                   <strong>Place&nbsp;:</strong> </td>
                                <td style="border: thin solid #000000" class="auto-style3" colspan="2">
                                    <asp:Image ID="Signpic_empty" runat="server" Height="74px" Width="283px" /> <BR /><strong>Signature of the Candidate</strong>
                                </td>
                            </tr>

                           

                            <tr class="d-print-none" style="height: 25px;">
                                <td style="border: thin solid #000000" class="auto-style6" colspan="3">

                                    <center>
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                    </center>
                                </td>

                            </tr>

                            <tr class="d-print-none">
                                <td style="border: thin solid #000000" colspan="3">
                                    <center>
                                        <asp:Button ID="printButton" class="btn btn-success d-print-none" runat="server" Text="Print" OnClientClick="javascript:window.print();"  />
                                    </center>
                                </td>
                            </tr>

                        </table>
                        <br />
                        <br />
                        <hr />
                        <p class="text-center"><span style="font-family: Times New Roman; font-size: medium; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;" class="auto-style13"><strong>Candidate already employed in Govt. Departments should apply &quot;Through Proper Channel&quot; endorsement signed by present employer</strong></span></p>
                        <div class="text-center">
                            <strong>Important: </strong><span class="auto-style12">After submitting the application, take a printout of the filled-in application form. The duly signed application form should be sent to  <strong> "The Controller of Administration, CSIR Madras Complex, CSIR Road, Taramani, Chennai-600113" </strong>enclosing copies of the requisite documents (certificates, etc.).</span> <br /> 
                               <h6 class="alert-danger"><strong> Incomplete application / unsigned application will not be processed.</strong></h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </div>
   

         </asp:Panel>

       
</asp:Content>
