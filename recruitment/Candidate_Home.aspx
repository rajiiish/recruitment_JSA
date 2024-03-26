<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Candidate_Home.aspx.cs" Inherits="recruitment.Candidate_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 28px;
            height: 26px;
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
         R<%-- title start--%><div class="container">
        <div class="bg-light shadow text-center">
        <p >Note: Don't input any special characters or punctuation marks. Input only alphanumeric characters.<br/>
         (fields marked with * are mandatory)</p>
        <p >Candidate Registration Number:
              <asp:Label ID="regidlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="Blue"></asp:Label>
   &nbsp;  &nbsp;    Application ID: <asp:Label ID="appidnolbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label> 
        &nbsp;  &nbsp;      Post Applying For: <asp:Label ID="applyhpostlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label>  </p>
            
      </div>

    </div> 
        <%-- title ends--%>
    <div class="container">
        <div class="card alert-info">
            <div class="card-header bg-dark text-light border">
              <center>  <label >Please fill out the forms below one by one</label></center>
                </div>
            <div class="row-10">
                <div class="col-12">
        <div class="row">
            <div class="col-md-11 mx-auto mx-auto">

                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <br />

                <div class="card">
                    <div class="card-header">
                        <asp:LinkButton ID="Previewbutton1" runat="server" OnClick="PersonalDetailsLinkBtn_Click">PERSONAL DETAILS</asp:LinkButton>
                        <img src="imgs/right.png" ID="tickimg1" runat="server" class="auto-style5" />
                    </div>
                </div>

                <div class="card">

                    <asp:Panel ID="PreviewPanel1" runat="server">
                        <div class="card-body">
                      <center>    <asp:Button ID="pbtn1" runat="server" CssClass="btn-success" Text="Add / Edit - PERSONAL DETAILS" OnClick="pbtn1_Click" Font-Bold="True" ForeColor="White" /> </center>  
                        </div>
                    </asp:Panel>

                </div>
               
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" CollapseControlID="Previewbutton1" Collapsed="True" CollapsedText="Hello frinnd how " ExpandControlID="Previewbutton1" ExpandedText="Its my rajesh" TextLabelID="Panel1lbl" TargetControlID="PreviewPanel1" />
            </div>

            <div class="col-md-11 mx-auto">              
               
                <div class="card">
                    <div class="card-header">
                        <asp:LinkButton ID="Previewbutton2" runat="server" OnClick="EducationDetailsLinkBtn_Click">EDUCATION DETAILS</asp:LinkButton>
                                                <img src="imgs/right.png" ID="tickimg2" runat="server" class="auto-style5" />

                    </div>
                </div>

                <div class="card">
                    <asp:Panel ID="PreviewPanel2" runat="server">
                        <div class="card-body">
                                               <center>    <asp:Button ID="pbtn2" runat="server" CssClass="btn-success" Text="Add / Edit - EDUCATION DETAILS" OnClick="pbtn2_Click" ForeColor="White" Font-Bold="True" /> </center>  
   
                        </div>
                    </asp:Panel>
                </div>
               
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" CollapseControlID="Previewbutton2" Collapsed="True" CollapsedText="Hello frinnd how " ExpandControlID="Previewbutton2" ExpandedText="Its my rajesh" TextLabelID="Panel1lbl" TargetControlID="PreviewPanel2" />
            </div>

            

            <div class="col-md-11 mx-auto">              
               
                <div class="card">
                    <div class="card-header">
                        <asp:LinkButton ID="Previewbutton3" runat="server" OnClick="ExperienceDetailsLinkBtn_Click">EXPERIENCE DETAILS</asp:LinkButton>
                                                <img src="imgs/right.png" ID="tickimg3" runat="server" class="auto-style5" />

                    </div>
                </div>

                <div class="card">
                    <asp:Panel ID="PreviewPanel3" runat="server">
                        <div class="card-body">
                                                                   <center>    <asp:Button ID="pbtn3" runat="server" CssClass="btn-success" Text="Add / Edit - EXPERIENCE DETAILS" OnClick="pbtn3_Click" ForeColor="White" Font-Bold="True" /> </center>  
        
                        </div>
                    </asp:Panel>
                </div>
               
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender4" runat="server" CollapseControlID="Previewbutton3" Collapsed="True" CollapsedText="Hello frinnd how " ExpandControlID="Previewbutton3" ExpandedText="Its my rajesh" TextLabelID="Panel1lbl" TargetControlID="PreviewPanel3" />
            </div>

        

            <div class="col-md-11 mx-auto">              
               
                <div class="card">
                    <div class="card-header">
                        <asp:LinkButton ID="Previewbutton5" runat="server" OnClick="OtherInfoDetailsLinkBtn_Click">OTHER INFORMATION</asp:LinkButton>
                        <img src="imgs/right.png" ID="tickimg5" runat="server" class="auto-style5" />

                    </div>
                </div>

                <div class="card">
                    <asp:Panel ID="PreviewPanel5" runat="server">
                        <div class="card-body">
                                                                                                       <center>    <asp:Button ID="pbtn5" runat="server" CssClass="btn-success" Text="Add / Edit - OTHER INFORMATION" OnClick="pbtn5_Click" ForeColor="White" Font-Bold="True" /> </center>  
        
                        </div>
                    </asp:Panel>
                </div>
               
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender6" runat="server" CollapseControlID="Previewbutton5" Collapsed="True" CollapsedText="Hello frinnd how " ExpandControlID="Previewbutton5" ExpandedText="Its my rajesh" TextLabelID="Panel1lbl" TargetControlID="PreviewPanel5" />
            </div>

            <div class="col-md-11 mx-auto">              
               
                <div class="card">
                    <div class="card-header">
                        <asp:LinkButton ID="Previewbutton6" runat="server" OnClick="FilesUploadDetailsLinkBtn_Click">FILES UPLOAD</asp:LinkButton>
                        <img src="imgs/right.png" ID="tickimg6" runat="server" class="auto-style5" />

                    </div>
                </div>

                <div class="card">
                    <asp:Panel ID="PreviewPanel6" runat="server">
                        <div class="card-body">
                            <center>    <asp:Button ID="pbtn6" runat="server" CssClass="btn-success" Text="Add / Edit -  FILES UPLOAD" OnClick="pbtn6_Click" ForeColor="White" Font-Bold="True" /> </center>  
              
                        </div>
                    </asp:Panel>
                </div>
               
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender3" runat="server" CollapseControlID="Previewbutton6" Collapsed="True" CollapsedText="Hello frinnd how " ExpandControlID="Previewbutton6" ExpandedText="Its my rajesh" TextLabelID="Panel1lbl" TargetControlID="PreviewPanel6" />
            </div>

            <div class="col-md-11 mx-auto">              
               
                <div class="card">
                    <div class="card-header">
                        <asp:LinkButton ID="Previewbutton7" runat="server"  OnClick="PaymentDetailsLinkBtn_Click">APPLICATION FEE PAYMENT</asp:LinkButton>
                        <img src="imgs/right.png" ID="tickimg7" runat="server" class="auto-style5" />

                    </div>
                </div>

                <div class="card">
                    <asp:Panel ID="PreviewPanel7" runat="server">
                        <div class="card-body">
                            <center>    <asp:Button ID="pbtn7" runat="server" OnClick="pbtn7_Click" CssClass="btn-success" Text="Add / Edit -  APPLICATION FEE PAYMENT "  ForeColor="White" Font-Bold="True" /> </center>  
              
                        </div>
                    </asp:Panel>
                </div>
               
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender7" runat="server" CollapseControlID="Previewbutton7" Collapsed="True" CollapsedText="Hello frinnd how " ExpandControlID="Previewbutton7" ExpandedText="" TextLabelID="Panel1lbl" TargetControlID="PreviewPanel7" />
            </div>
            
           
        </div>
                   
            </div>
    </div>
            <div class="row-10">            
                <br />
            <div class="col-md-12">

            <center>  <asp:Button ID="PreviewApplication" class="btn-primary" runat="server" Text="Preview & Submit"  Font-Bold="True" Font-Italic="False" Font-Size="Large" OnClick="PreviewApplication_Click1" /> 
                
                </center>  
            </div>
                   </div>

            <br />
            <br />
            <br />
         </div>

        </div>
</asp:Content>
