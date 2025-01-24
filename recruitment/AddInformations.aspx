<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddInformations.aspx.cs" Inherits="recruitment.AddInformations" %>
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
       
            .auto-style4 {
                margin-left: 62;
            }
            .auto-style5 {
                width: 148px;
                height: 21px;
            }
            .auto-style6 {
                width: 148px;
            }

             .table-b
        {
    border:1px solid green;
    margin-top:20px;

  }

        .table-b > thead > tr > th{
    border:1px solid green;
}
.table-b > tbody > tr > td{
    border:1px solid green;
}
       
            .auto-style7 {
                height: 30px;
            }
       
            .auto-style8 {
                left: 0px;
                top: 0px;
            }
       hr.solid {
  border-top: 3px solid #bbb;
}
            .auto-style9 {
                position: relative;
                width: 100%;
                -ms-flex: 0 0 100%;
                flex: 0 0 100%;
                max-width: 100%;
                left: 0px;
                top: 0px;
                padding-left: 15px;
                padding-right: 15px;
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


 <!--   <div class="container ">
            <div class="card bg-light">
               <div class="card-body"> 
            <table class="table titlemenufont">
  
  <tbody>
    <tr>
         <td > <strong><img src="imgs/1.PNG" class="auto-style3" /></strong>PERSONAL DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
         <td> <strong><img src="imgs/2.PNG" class="auto-style3" /></strong>EDUCATION DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 

                 <td > <strong><img src="imgs/3.PNG" class="auto-style3" /></strong>EXPERIENCE DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
                        <td > <strong><img src="imgs/5.PNG" class="auto-style3" /></strong>PROFESSIONAL INFORMATION <img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></td>

                 <td class="stepfont"> <strong><img src="imgs/ticon.PNG" class="auto-style3" /></strong>OTHER INFORMATION<strong><img src="imgs/icons8_forward_48px.PNG" class="auto-style3" /></strong></td> 
                 <td > <strong><img src="imgs/6.PNG" class="auto-style3" /></strong>FILES UPLOAD<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
               
    </tr>
  </tbody>
</table>
                      </div>
         </div>
            </div> -->

     <div class="container ">
      <div class="card bg-light">
               <div class="card-body"> 
                     <!--  Country check start -->
                   <center>    <h6 class="card-header text-white  bg-info ">Any Other Informations Details</h6></center>
                   <div class="row">
            <div class="col-12">
                <br />
                <label>* Have you been outside India? If Yes, Give Details of the visits:</label> &nbsp
                <asp:DropDownList ID="countryvisitdrop"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="countryvisitdrop_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="Yes">Yes</asp:ListItem>
                         <asp:ListItem Value="No">No</asp:ListItem>
                </asp:DropDownList>
                  <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="countryvisitdrop" InitialValue="0" validationgroup="otherinfogroup" runat="server" ForeColor="Red" />

            </div>
            </div>
                     <!--  Country check end-->


                 <!--  Country panel start-->
                   <div class="row">
                       <asp:Panel ID="countrypanel" runat="server">

                           <table class="table table-b">

      
     <thead>
       <tr>
           <th scope="col" class="auto-style3">Name of the Country</th>
          <th scope="col" class="auto-style3">From</th>
         <th scope="col" class="auto-style3">To</th>
         <th scope="col" class="auto-style5">Duration</th>
           <th scope="col" class="auto-style3">Details of the Visit</th>

             </tr>
     </thead>
    <tr>
         <td><asp:TextBox ID="countrytxt" runat="server"  Height="30px" Width="205px"></asp:TextBox></td>
         <td>   <center> <asp:TextBox ID="fromtxt" runat="server" Height="30px" Width="172px" Format="dd/MM/yyyy" class="form-control" AutoPostBack="true" TextMode="Date" placeholder="" value=""  OnTextChanged="fromtxt_TextChanged"></asp:TextBox>            &nbsp;</center> </td>
        
                <td> <center><asp:TextBox ID="totxt" runat="server" Height="30px" Width="161px" Format="dd/MM/yyyy" class="form-control" AutoPostBack="true" TextMode="Date" placeholder="" value=""  OnTextChanged="totxt_TextChanged"></asp:TextBox>            </center> </td>
                <td class="auto-style6"><asp:Label ID="totaldaystxt" runat="server" Text="0" Font-Bold="True" ForeColor="#006600"></asp:Label></td>
         <td>
                                   <asp:TextBox ID="visitdetailstxt" runat="server" Height="30px" MaxLength="350" Width="199px" CssClass="auto-style4"></asp:TextBox>
                               </td>
         <td>
                                      
                                       <asp:Button ID="Addbutton" runat="server" class="btn btn-info" OnClick="Addbutton_Click" Text="Add" Height="36px" Width="50px" />
                                   </td>
                
    </tr>
   
                              
                              
        </table>
                           <div class="text-center">
                               <center>    <h6 class="card-header text-white  bg-primary ">Added Forign Visit Details</h6></center>
                               <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="8" class="table table-bordered " DataKeyNames="id" EmptyDataText="No records has been added." Font-Size="10pt" ForeColor="#333333" GridLines="None" Height="85px" OnDataBound="GridView1_DataBound" OnRowDeleting="GridView1_RowDeleting" Width="1097px">
                                   <AlternatingRowStyle BackColor="White" />
                                   <Columns>
                                       <%--<asp:BoundField DataField="can_regno" HeaderText="can_regno" SortExpression="can_regno" />
        
        <asp:BoundField DataField="appregno" HeaderText="appregno" SortExpression="appregno" />--%>
                                       <asp:BoundField DataField="id" HeaderText="VISIT ID" ReadOnly="false" SortExpression="id" visible="false" />
                                       <asp:BoundField DataField="country" HeaderText="Name of the Country" ReadOnly="True" SortExpression="country" />
                                       <asp:BoundField DataField="fromdate" HeaderText="From" SortExpression="fromdate" />
                                       <asp:BoundField DataField="todate" HeaderText="To" SortExpression="todate" />
                                       <asp:BoundField DataField="totaldays" HeaderText="Total Duration" SortExpression="totaldays" />
                                       <asp:BoundField DataField="visitdetails" HeaderText="Visit Details" SortExpression="visitdetails" />
                                       <asp:TemplateField>
                                           <ItemTemplate>
                                               <asp:LinkButton ID="Deletebtn_forign" runat="server" OnClick="Deletebtn_forign_Click">Delete</asp:LinkButton>
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
                           </div>

                       </asp:Panel>
                   </div>
                     <!--  Country panel End-->
                    <hr class="solid">
                   <br />
                    <!--  bond check start -->
                   <div class="row">
                       <div class="col-12">
                           <label>* Are you under any bond or contract to serve Central/State/Autonomous Bodies / PSU :</label> &nbsp
                <asp:DropDownList ID="bonddrop"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="bonddrop_SelectedIndexChanged" >
                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="Yes">Yes</asp:ListItem>
                         <asp:ListItem Value="No">No</asp:ListItem>
                </asp:DropDownList>
                       <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="bonddrop" InitialValue="0" validationgroup="otherinfogroup" runat="server" ForeColor="Red" />

                       </div>
                   </div>

                    <!--  bond check start -->
                   <hr class="solid">
                      <!--  bond check start -->
                   <div class="row">
                       <div class="auto-style9">
                           <label>* Are you a Permanent CSIR/Government Servant at Present?:</label> &nbsp
                <asp:DropDownList ID="permGovtDrop"  runat="server" AutoPostBack="True">
                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="Yes">Yes</asp:ListItem>
                         <asp:ListItem Value="No">No</asp:ListItem>
                </asp:DropDownList>
                                                  <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="permGovtDrop" InitialValue="0" validationgroup="otherinfogroup" runat="server" ForeColor="Red" />

                       </div>
                   </div>

                    <!--  bond check start -->
                   <hr class="solid d-none">
                    <!--  pwd check start -->
                   <div class="row d-none">
                       <div class="col-12">
                           <label>* Are you a person with disability?* :</label> &nbsp
                <asp:DropDownList ID="pwddrop"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="pwddrop_SelectedIndexChanged"  >
                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="Yes">Yes</asp:ListItem>
                         <asp:ListItem Value="No">No</asp:ListItem>
                </asp:DropDownList>

                       &nbsp;(* If you want to change the option for PWD Catagory, Please update in &quot;Personal Details&quot; .</div>
                        <div class="col-12">
                           <asp:Panel ID="pwdpanel" runat="server">
                               <table class="table table-b">
                                   <thead>
                                       <tr>
                                           <th>Types of Disabilities Catagory</th>
                                           <th>Types of Disabilities</th>
                                                                                      <th>Percentage of disability (%)*  <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="pwdpercttxt" InitialValue="" validationgroup="otherinfogroup" runat="server" ForeColor="Red" /></th>

                                       </tr>
                                   </thead>
                                   <tr>
                                       <td><ul>
                                                        <li>(A). Blindness and Low Vision;</li>
                                                      <li>(B). Deaf and Hard of Hearing;</li>
                                                      <li>(C). Locomotor Disability Including Cerebral Palsy, Leprosy Cured, Dwarfism, Acid Attack Victims and Muscular Dystrophy;</li>
                                           <li>(D). Autism, Intellectual Disability, Specific Learning Disability and Mental Illness;</li>
                                           <li>(E). Multiple Disabilities from Amongst Persons Under Clauses (a) to (d) including Deaf-Blindness</li>
                                                    </ul>                                   </td>
                                       
                                        <td> 
                                             <asp:DropDownList ID="pwdtypedrop"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="pwddrop_SelectedIndexChanged"  >
                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="A">A</asp:ListItem>
                         <asp:ListItem Value="B">B</asp:ListItem>
                         <asp:ListItem Value="C">C</asp:ListItem>
                         <asp:ListItem Value="D">D</asp:ListItem>
                         <asp:ListItem Value="D">E</asp:ListItem>
                </asp:DropDownList>
            <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="pwdtypedrop" InitialValue="0" validationgroup="otherinfogroup" runat="server" ForeColor="Red" />

                                          </td> 
                                         <td> <asp:TextBox ID="pwdpercttxt" runat="server"></asp:TextBox></td>
                                   </tr>
                               </table>

                               

                           </asp:Panel>
                       </div>
                   </div>

                    <!--  pwd check start -->
                    <hr class="solid">

                    <!--   Rleax cat start -->
                   <div class="row">
                       <div class="col-12">
                           <label>*Are you claiming for age relaxation?</label> &nbsp
                <asp:DropDownList ID="AgeRlxClaimDrop"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="AgeRlxClaimDrop_SelectedIndexChanged" >
                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="Yes">Yes</asp:ListItem>
                         <asp:ListItem Value="No">No</asp:ListItem>
                </asp:DropDownList>
              <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="AgeRlxClaimDrop" InitialValue="0" validationgroup="otherinfogroup" runat="server" ForeColor="Red" />

                       </div>
                       <br />
                        <div class="col-12">
                             <asp:Panel ID="RelaxationPanel" runat="server">
                           <label>*Relaxation category (Refer Advertisement):</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="AgeRlxConfDrop"  runat="server">
                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="SC/ST">SC/ST</asp:ListItem>
                         <asp:ListItem Value="Employee of CSIR or Govt">Employee of CSIR or Govt.</asp:ListItem>
                         <asp:ListItem Value="Women / Widow / Divorced Women">Women / Widow / Divorced Women</asp:ListItem>
                    <asp:ListItem Value="Ex-Servicemen">Ex-Servicemen</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="AgeRlxConfDrop" InitialValue="0" validationgroup="otherinfogroup" runat="server" ForeColor="Red" />

                            </asp:Panel>
                       </div>
                   </div>

                    <!--  Rleax cat check start -->

                    <hr class="solid">
                     <!--  Relative check start -->
                   <br />
                   <div class="row">
                       <div class="col-12">
                           <asp:Label ID="JoinTimeLable" runat="server" Text="* Minimum joining time required (in case of selected for the position):"></asp:Label>
                            
                <asp:TextBox ID="JoiningTimetxt" runat="server" MaxLength="2"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  validationgroup="otherinfogroup" ControlToValidate="JoiningTimetxt" runat="server" Display="Dynamic" ErrorMessage="Only Numbers" ValidationExpression="\d+" ForeColor="Red"></asp:RegularExpressionValidator>
                       </div>
                   </div>

                   

                   <br />
                   <div class="row">
                       <div class="col-12">
                          
                           <label>* Any of your Blood relation working in CSIR? </label> &nbsp
                           <asp:DropDownList ID="RelativeDrop"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="RelativeDrop_SelectedIndexChanged" >
                    <asp:ListItem Selected="True" Value="0">--Select--</asp:ListItem>
                         <asp:ListItem Value="Yes">Yes</asp:ListItem>
                         <asp:ListItem Value="No">No</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ErrorMessage="*Required" ControlToValidate="RelativeDrop" InitialValue="0" validationgroup="otherinfogroup" runat="server" ForeColor="Red" />

                       </div>
                       <div class="col-12">
                           <asp:Panel ID="relativepanel" runat="server">
                               <table class="table table-b">
                                   <thead>
                                       <tr>
                                           <th>Relative Name  <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="RelativeNametxt" InitialValue="" validationgroup="otherinfogroup" runat="server" ForeColor="Red" /></th>
                                           <th>Present Designation in CSIR  <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="PresentDesignationtxt" InitialValue="" validationgroup="otherinfogroup" runat="server" ForeColor="Red" /></th>
                                           <th>Details of Relationship <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="RelationTypetxt" InitialValue="" validationgroup="otherinfogroup" runat="server" ForeColor="Red" /></th>
                                           <th>Name of the CSIR Organaization  <asp:RequiredFieldValidator ErrorMessage="*" ControlToValidate="NameCSIRtxt" InitialValue="" validationgroup="otherinfogroup" runat="server" ForeColor="Red" /></th>
                                       </tr>
                                   </thead>
                                   <tr>
                                        <td> <asp:TextBox ID="RelativeNametxt" runat="server"></asp:TextBox></td>
                                        <td> <asp:TextBox ID="PresentDesignationtxt" runat="server"></asp:TextBox> </td>
                                        <td> <asp:TextBox ID="RelationTypetxt" runat="server"></asp:TextBox> </td>
                                        <td> <asp:TextBox ID="NameCSIRtxt" runat="server" Height="25px" Width="314px"></asp:TextBox> </td>
                                   </tr>
                               </table>

                               

                           </asp:Panel>
                       </div>
                   </div>

                    <!--  Relative check end  -->
                   <br />

                    <!--  Reference check start -->
                    <div class="row">
                       <div class="col-12">
                          
                             <center>    <h6 class="card-header text-white  bg-info ">Reference (Optional)</h6></center>
                            <center><label>The referees should be residents in India and holders of responsible position. They should be intimately acquainted with the applicant's character and work but must not be relations. When the candidate has been in employment he should either give his present or most recent employer or immediate superior as a referee or produce a testimonial from him in regard to the candidate's fitness for the post for which he in an applicant:</label></center>
                           <table class="table table-b">

                               <thead>
                                   <th>S.No</th>
                                   <th>Name</th>
                                   <th>Occupation / Position</th>
                                   <th>Address (with phone-no. & email)</th>
                               </thead>
                               <tr>
                                   <td class="auto-style7"><lable>1</lable></td>
                                    <td class="auto-style7"><asp:TextBox ID="NameRef1" runat="server"></asp:TextBox></td>
                                    <td class="auto-style7"><asp:TextBox ID="OccupRef1" runat="server"></asp:TextBox></td>
                                    <td class="auto-style7"><asp:TextBox ID="AddressRef1" runat="server" Width="275px"></asp:TextBox></td>

                               </tr>
                               <tr>
                                   <td><lable>2</lable></td>
                                    <td><asp:TextBox ID="NameRef2" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox ID="OccupRef2" runat="server"></asp:TextBox></td>
                                    <td><asp:TextBox ID="AddressRef2" runat="server" Width="275px"></asp:TextBox></td>

                               </tr>
                              
                               
                           </table>
                   </div>
                        </div>
                    <!--  Reference check end -->

                    <!--  Declaraion start -->
                   <div class="card bg-light">
               <div class="card-body"> 
                    
                   <center>    <h6 class="card-header text-white  bg-info ">Declaration</h6></center>
                   <table class="table table-b">

                                                        
                               <tr>                                 
                                <!--    <td colspan="4" class="text-justify"> <strong>Declaration:</strong> <br /><asp:CheckBox ID="termsandcondtionCheck1" runat="server" Font-Size="Large" /> &nbsp I hereby declare that all the statements made in this application are true and complete to the best of my knowledge and belief and nothing has been concealed or/distorted. I am aware that, if at any time I am found to have concealed/distorted any material/information, my appointment is liable to be summarily terminated without notice</td>-->
                                   <td colspan="4" class="text-justify"> <strong>Declaration:</strong> <br /><asp:CheckBox ID="termsandcondtionCheck" runat="server" Font-Size="Large" /> &nbsp  I hereby declare that all the statements made in the application are true, complete and correct to the best of my knowledge and belief and in the event of any of
 the information being found false or incorrect or any ineligibility being detected before or after the selection, my candidature is liable to be cancelled and action may be initiated against me</td>
                               </tr>
                           </table>
                   </div>
                       </div>

                     <!--  Declaraion start -->

         </div>

         <br />
          <div class="container">
        <div class="row">
            <div class="col-12 align-items-center">
                                 <asp:Button ID="goBackbtn" CssClass="savebtncolor" runat="server" Text="Go Back to Home" OnClick="goBackbtn_Click" />

                 <center>
                <asp:Button ID="SaveEducationbtn" runat="server" CssClass="savebtncolor" Text="Save and Continue" validationgroup="otherinfogroup" OnClick="SaveEducationbtn_Click" />
                </center>
                </div>
            <div class="row">
                <div class="auto-style8">
                    </div>
            </div>
        </div>
    </div>
         <br />
</asp:Content>
