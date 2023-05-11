<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="admin_synopsis.aspx.cs" Inherits="recruitment.admin1" %>
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
             color: #3333CC;
         }
         .auto-style8 {
             color: #CC3300;
         }
         .auto-style9 {
             color: #000099;
         }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
         <BR />
          <div class="container">
              <div class="card bg-light align-content-center">
            <div class="card-body"> 
                <div class="row">
            <div class="col-12">
              <div class="row">
                   <div class="col-sm-12">
                       <asp:Label ID="droplblname" runat="server" Text="Select Post Code to View"></asp:Label>
                      <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="True" Height="27px" Width="257px">
            
            <asp:ListItem Value="TA-CIVIL">Technical Assistant (Civil)</asp:ListItem>
            <asp:ListItem Value="TA-IT">Technical Assistant (IT)</asp:ListItem>
            <asp:ListItem Value="JSA">Junior Secretariat Assistant</asp:ListItem>
        </asp:DropDownList>

                       </div>
                  </div>
              
              </div>
                    </div>
                </div>
                  </div>
              </div>
       
        
          <div class="container-fluid">
             <div class="row">
                       <div class="col-12">
                        <div class="card border-info">
                            <div class="card-body">

                               
                                    
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineapplicationConnectionString1 %>" SelectCommand="SELECT * FROM [basicdetailsNew] WHERE ([postcode] = @postcode)">
                                        <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="postcode" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>

                                    </asp:SqlDataSource>

                                    
                                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" EmptyDataText="Applications Subitted is Nil !" runat="server" AutoGenerateColumns="False" DataKeyNames="appregno"  >
                                            <Columns>
                                                <asp:BoundField DataField="appregno" HeaderText="Application ID" ReadOnly="True" SortExpression="appregno">
                                                    <ControlStyle Font-Bold="True" />
                                                    <ItemStyle Font-Bold="True" Font-Size="Small"/>
                                                </asp:BoundField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <div class="container-fluid">
                                                            <div class="row">
                                                                
                                                                <div class="col-lg-12">
                                                                    <div class="row">
                                                                        <div class="col-10">
                                                                            <asp:Label ID="regidlbl" runat="server" Text='<%# Eval("can_regno") %>' Font-Bold="True" Font-Color="red" Font-Size="Medium"></asp:Label>
                                                                        
                                                                   
                                                                    <div class="row">
                                                                        <div class="col-12">
                                                                            <span>Postcode - </span>
                                                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("postcode") %>'></asp:Label>
                                                                            &nbsp;| <span><span>&nbsp;</span>Post Name - </span>
                                                                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("postdetails") %>'></asp:Label>
                                                                            &nbsp;|
                                                                            <span>Application No- <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("appregno") %>'></asp:Label>
                                                                            </span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-12">
                                                                            Full Name -
                                                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("fullname") %>'></asp:Label>
                                                                            &nbsp;| Father / Gurdian Name -
                                                                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("fathername") %>'></asp:Label>
                                                                            &nbsp;| DOB -
                                                                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("dateofbirth") %>'></asp:Label>
                                                                            &nbsp;| Gender -
                                                                            <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("sexuality") %>'></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-12">
                                                                            Cast Category -
                                                                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("cast") %>'></asp:Label>
                                                                            &nbsp;|Maritial Status -
                                                                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("marital") %>'></asp:Label>
                                                                            &nbsp;| Religion -
                                                                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("religion") %>'></asp:Label>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-12">
                                                                            Whether CSIR Employee -
                                                                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("csiremp") %>'></asp:Label>
                                                                             Whether Ex-Serviceman Employee -
                                                                            <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("ExArmy") %>'></asp:Label>
                                                                        </div>
                                                                    </div>

                                                                   </div>
                                                                      
                                                                        
                                                                         </div>
                                                                </div>
                                                                
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                        </asp:GridView>
                                    </div>
                                       
                                   
                                </div>
                            </div>
                        </div>
                
       
                     
          </div>
                
        
</asp:Content>
