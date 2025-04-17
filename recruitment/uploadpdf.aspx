<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="uploadpdf.aspx.cs" Inherits="recruitment.uploadpdf" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
           .titlemenufont
    {
        font-family: Arial;
        font-size: 10pt;
    }
        .auto-style4 {
            width: 257px;
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
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">  
        var message = "Function Disabled!";
        function clickIE4() {
            if (event.button == 2) {
                alert(message);
                return false;
            }
        }
        function clickNS4(e) {
            if (document.layers || document.getElementById && !document.all) {
                if (e.which == 2 || e.which == 3) {
                    alert(message);
                    return false;
                }
            }
        }
        if (document.layers) {
            document.captureEvents(Event.MOUSEDOWN);
            document.onmousedown = clickNS4;
        }
        else if (document.all && !document.getElementById) {
            document.onmousedown = clickIE4;
        }
        document.oncontextmenu = new Function("return false")
    </script>             
     <section>
    <div class="container">
        <div class="bg-light  text-center">
        
        <p >Candidate Registration Number:
              <asp:Label ID="regidlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="Blue"></asp:Label>
       Application ID: <asp:Label ID="appidnolbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label> 
            Post Applying For: <asp:Label ID="applyhpostlbl" runat="server" Text="Label" Font-Bold="True" ForeColor="#006600"></asp:Label>  </p>
      </div>

    </div>
        </section>

     <%-- title ends--%>

    

 <!--   <div class="container ">
        <div class="card bg-light">
               <div class="card-body"> 
                   <div class="row">
            <table class="table titlemenufont">
  
  <tbody>
     <tr>
         <td > <strong><img src="imgs/1.PNG" class="auto-style3" /></strong>PERSONAL DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
         <td> <strong><img src="imgs/2.PNG" class="auto-style3" /></strong>EDUCATION DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 

                 <td  > <strong><img src="imgs/3.PNG" class="auto-style3" /></strong>EXPERIENCE DETAILS<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
                          <td > <strong><img src="imgs/4.PNG" class="auto-style3" /></strong>PROFESSIONAL INFORMATION <strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 

                 <td > <strong><img src="imgs/5.PNG" class="auto-style3" /></strong>OTHER INFORMATION<strong><img src="imgs/icons8_forward_32px.PNG" class="auto-style3" /></strong></td> 
                 <td class="stepfont"> <strong><img src="imgs/ticon.PNG" class="auto-style3" /></strong>FILES UPLOAD<strong><img src="imgs/icons8_forward_48px.PNG" class="auto-style3" /></strong></td> 
               
    </tr>
  </tbody>
</table>
                       </div>
                   </div>
            </div>
            </div>-->
 <div class="container ">
<div class="card bg-light">
               <div class="card-body"> 
                   <div class="row">
  
    <div class="container">
         <center> <asp:Label ID="photouploadtitlelbl" runat="server" Text="Photo and Signature Upload" Font-Bold="True" ForeColor="#0000CC"></asp:Label> </center>
<asp:Table ID="Table2" runat="server">
  
  
      
     <asp:TableRow ID="TableRow1" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
       <asp:TableCell>  Upload Photo <strong>*</strong></asp:TableCell>  
        
       <asp:TableCell>   <asp:FileUpload ID="PhotoUpload" accept=".jpg" runat="server" /></asp:TableCell>  
         <asp:TableCell> <asp:Button class="btn btn-success" ID="photobtn" runat="server" Text="Upload" OnClick="photobtn_Click"    />
           
            <asp:Label ID="phottimelbl" runat="server" Text="Label"></asp:Label>
       </asp:TableCell>  
        <asp:TableCell> <asp:Label ID="photosucesslbl" runat="server" Font-Size="Small" Text="Upload Only .jpg Photo upto 1MB" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
        <asp:TableCell>
            <asp:Image ID="photo" runat="server" Height="150px" Width="120px" /></asp:TableCell>  
        <asp:TableCell>            
              

            

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="photo_deletebtn" src="imgs/pdfdelete.png" runat="server" Height="32px" Width="29px" OnClick="photo_deletebtn_Click" /> 
                  
                  </asp:TableCell>  
                   
        
    </asp:TableRow>
         
     
     <asp:TableRow ID="TableRow2" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
         <asp:TableCell>  <label>Upload Signature <strong>*</strong></label></asp:TableCell>  
        
        <asp:TableCell>   <asp:FileUpload ID="SignUpload" accept=".jpg" runat="server" /></asp:TableCell>  
         <asp:TableCell>  <asp:Button class="btn btn-success" ID="signaturebtn" runat="server" Text="Upload" OnClick="signatureupload_Click" />
            
            <asp:Label ID="signtimelbl" runat="server" Text="Label"></asp:Label>
       </asp:TableCell>  
         <asp:TableCell> <asp:Label ID="signsucesslbl" runat="server" Font-Size="Small" Text="Upload Only .jpg Photo upto 1MB" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
        <asp:TableCell>
            <asp:Image ID="signature" runat="server" Height="60px" Width="250px" /></asp:TableCell>  
        <asp:TableCell>              
              

             <!--  <asp:ImageButton ID="photo_view" src="imgs/pdficon.png" runat="server" Height="32px"  Width="36px" />-->

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="sign_deletebtn" src="imgs/pdfdelete.png" runat="server" Height="32px" Width="29px" OnClick="sign_deletebtn_Click"  /> 
                  
                  </asp:TableCell>  
                   
        
    </asp:TableRow>
</asp:Table>

    </div>
    


    <div class="container">
        <br />
        <center> <asp:Label ID="Label3" runat="server" Text="Educational Certificates Upload" Font-Bold="True" ForeColor="#0000CC"></asp:Label> &nbsp;
        </center>
 
        

     <asp:Table ID="Table1" runat="server">
  
  
     <asp:TableRow ID="SSLCTableRow" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
       <asp:TableCell>10th or Equivalent Certificate</asp:TableCell>  
        
       <asp:TableCell>  <asp:FileUpload ID="FileUpload1" accept=".pdf" runat="server" /></asp:TableCell>  
        <asp:TableCell> <asp:Button class="btn btn-success" ID="SSLC_btn" runat="server" Text="Upload" OnClick="SSLC_btn_Click"   /></asp:TableCell>  
        <asp:TableCell><asp:Label ID="Label1" runat="server" Font-Size="small" Text="Upload PDF File upto 1MB" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
       <asp:TableCell>
               
              

               <asp:ImageButton ID="ssc_pdfview" src="imgs/pdficon.png" runat="server" Height="32px" OnClick="ssc_pdfview_Click" Width="36px" />

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="ssc_deletebtn" src="imgs/pdfdelete.png" runat="server" Height="32px" OnClick="ssc_delete_Click" Width="29px" /> 
                  
                  </asp:TableCell>  
                   
        
    </asp:TableRow>
         

  
 
     <asp:TableRow ID="HSCTableRow" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
       <asp:TableCell> 12th or Equivalent Certificate</asp:TableCell>  
        
       <asp:TableCell>  <asp:FileUpload ID="FileUpload2" accept=".pdf" runat="server" /></asp:TableCell>  
        <asp:TableCell> <asp:Button class="btn btn-success" ID="HSC_btn" runat="server" Text="Upload" OnClick="HSC_btn_Click"/></asp:TableCell>  
        <asp:TableCell><asp:Label ID="Label2" runat="server" Font-Size="small" Text="Upload PDF File less then 1MB (1000 KB)" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
        <asp:TableCell>
               
              

               <asp:ImageButton ID="hsc_pdfview" src="imgs/pdficon.png" runat="server" Height="32px"  Width="36px" OnClick="hsc_pdfview_Click" />

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="hsc_deletebtn" src="imgs/pdfdelete.png" runat="server" Height="32px"  Width="29px" OnClick="hsc_deletebtn_Click" /> 
                  
                  </asp:TableCell>  
                   
        
    </asp:TableRow>
      
          <asp:TableRow ID="IITTableRow" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
       <asp:TableCell> ITI or its Equivalent Certificate</asp:TableCell>  
        
       <asp:TableCell>  <asp:FileUpload ID="ITIFileUpload" accept=".pdf" runat="server" /></asp:TableCell>  
        <asp:TableCell> <asp:Button class="btn btn-success" ID="ITI_btn" runat="server" Text="Upload" OnClick="ITI_btn_Click" /></asp:TableCell>  
        <asp:TableCell><asp:Label ID="ITIlbl" runat="server" Font-Size="small" Text="Upload PDF File less then 1MB (1000 KB)" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
        <asp:TableCell>
               
              

               <asp:ImageButton ID="ITI_pdfview" src="imgs/pdficon.png" OnClick="ITI_pdfview_Click" runat="server" Height="32px"  Width="36px"/>

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="ITI_deletebtn" src="imgs/pdfdelete.png" OnClick="ITI_deletebtn_Click" runat="server" Height="32px"  Width="29px"/> 
                  
                  </asp:TableCell>  
                   
        
    </asp:TableRow>

   
          <asp:TableRow ID="DIPTableRow" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
       <asp:TableCell> Diploma or its Equivalent Certificate</asp:TableCell>  
        
       <asp:TableCell>  <asp:FileUpload ID="DIPFileUpload" accept=".pdf" runat="server" /></asp:TableCell>  
        <asp:TableCell> <asp:Button class="btn btn-success" ID="DIP_btn" OnClick="DIP_btn_Click" runat="server" Text="Upload" /></asp:TableCell>  
        <asp:TableCell><asp:Label ID="DIPlbl" runat="server" Font-Size="small" Text="Upload PDF File less then 1MB (1000 KB)" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
        <asp:TableCell>
               
              

               <asp:ImageButton ID="DIP_pdfview" src="imgs/pdficon.png" OnClick="DIP_pdfview_Click" runat="server" Height="32px"  Width="36px"/>

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="DIP_deletebtn" src="imgs/pdfdelete.png" OnClick="DIP_deletebtn_Click" runat="server" Height="32px"  Width="29px"/> 
                  
                  </asp:TableCell>  
                   
        
    </asp:TableRow>

       
          <asp:TableRow ID="UGTableRow" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
       <asp:TableCell> UG or its Equivalent Certificate</asp:TableCell>  
        
       <asp:TableCell>  <asp:FileUpload ID="UGFileUpload" accept=".pdf" runat="server" /></asp:TableCell>  
        <asp:TableCell> <asp:Button class="btn btn-success" ID="UG_btn" OnClick="UG_btn_Click" runat="server" Text="Upload" /></asp:TableCell>  
        <asp:TableCell><asp:Label ID="UGlbl" runat="server" Font-Size="small" Text="Upload PDF File less then 1MB (1000 KB)" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
        <asp:TableCell>
               
              

               <asp:ImageButton ID="UG_pdfview" src="imgs/pdficon.png" OnClick="UG_pdfview_Click" runat="server" Height="32px"  Width="36px"/>

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="UG_deletebtn" src="imgs/pdfdelete.png" OnClick="UG_deletebtn_Click" runat="server" Height="32px"  Width="29px"/> 
                  
                  </asp:TableCell>  
                   
        
    </asp:TableRow>

      
          <asp:TableRow ID="PGTableRow" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
       <asp:TableCell> PG or its Equivalent Certificate</asp:TableCell>  
        
       <asp:TableCell>  <asp:FileUpload ID="PGFileUpload" accept=".pdf" runat="server" /></asp:TableCell>  
        <asp:TableCell> <asp:Button class="btn btn-success" ID="PG_btn" OnClick="PG_btn_Click" runat="server" Text="Upload" /></asp:TableCell>  
        <asp:TableCell><asp:Label ID="PGlbl" runat="server" Font-Size="small" Text="Upload PDF File less then 1MB (1000 KB)" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
        <asp:TableCell>
               
              

               <asp:ImageButton ID="PG_pdfview" src="imgs/pdficon.png" OnClick="PG_pdfview_Click" runat="server" Height="32px"  Width="36px"/>

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="PG_deletebtn" src="imgs/pdfdelete.png" OnClick="PG_deletebtn_Click" runat="server" Height="32px"  Width="29px"/> 
                  
                  </asp:TableCell>  
                   
        
    </asp:TableRow>

      

</asp:Table>
        <br />
        
          <center> <asp:Label ID="OtherMandLbl" runat="server" Text="Other Mandatory Documents Upload" Font-Bold="True" ForeColor="#0000CC"></asp:Label> &nbsp;
        </center>

        <asp:Table ID="Table3" runat="server">
  
  
     <asp:TableRow ID="CommunityTableRow" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
       <asp:TableCell>Community Certificate</asp:TableCell>  
        
       <asp:TableCell>  <asp:FileUpload ID="CommunityFileUpload" accept=".pdf" runat="server" /></asp:TableCell>  
        <asp:TableCell> <asp:Button class="btn btn-success" ID="Community_btn" runat="server" Text="Upload" OnClick="Community_btn_Click"  /></asp:TableCell>  
        <asp:TableCell><asp:Label ID="Communitylbl" runat="server" Font-Size="small" Text="Upload PDF File upto 1MB" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
       <asp:TableCell>
               
              

               <asp:ImageButton ID="Community_pdfview" src="imgs/pdficon.png" runat="server" Height="32px" OnClick="Community_pdfview_Click" Width="36px" />

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="Community_deletebtn" src="imgs/pdfdelete.png" runat="server" Height="32px" OnClick="Community_deletebtn_Click" Width="29px" /> 
                  
                  </asp:TableCell>  
                   
        
    </asp:TableRow>
         

  <asp:TableRow ID="ExServicemanTableRow" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
       <asp:TableCell>Add Ex-Servicemen Document</asp:TableCell>  
        
       <asp:TableCell>  <asp:FileUpload ID="ExServicemanFileUpload" accept=".pdf" runat="server" /></asp:TableCell>  
        <asp:TableCell> <asp:Button class="btn btn-success" ID="ExServiceman_btn" runat="server" Text="Upload" OnClick="ExServiceman_btn_Click" /></asp:TableCell>  
        <asp:TableCell><asp:Label ID="ExServicemanlbl" runat="server" Font-Size="small" Text="Upload PDF File less then 1MB (1000 KB)" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
        <asp:TableCell>
               
              

               <asp:ImageButton ID="ExServiceman_pdfview" src="imgs/pdficon.png" OnClick="ExServiceman_pdfview_Click" runat="server" Height="32px"  Width="36px"/>

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="ExServiceman_deletebtn" src="imgs/pdfdelete.png" OnClick="ExServiceman_deletebtn_Click" runat="server" Height="32px"  Width="29px"/> 
                  
                  </asp:TableCell>  
                   
        
    </asp:TableRow>
 
     <asp:TableRow ID="ExperienceTableRow" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
       <asp:TableCell> Experience Details Documents (Combine Multiple pages)</asp:TableCell>  
        
       <asp:TableCell>  <asp:FileUpload ID="ExperienceFileUpload" accept=".pdf" runat="server" /></asp:TableCell>  
        <asp:TableCell> <asp:Button class="btn btn-success" ID="Experience_btn" runat="server" Text="Upload" OnClick="Experience_btn_Click"/></asp:TableCell>  
        <asp:TableCell><asp:Label ID="Experiencelbl" runat="server" Font-Size="small" Text="Upload PDF File less then 1MB (1000 KB)" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
        <asp:TableCell>
               
              

               <asp:ImageButton ID="Experience_pdfview" src="imgs/pdficon.png" runat="server" Height="32px"  Width="36px" OnClick="Experience_pdfview_Click" />

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="Experience_deletebtn" src="imgs/pdfdelete.png" runat="server" Height="32px"  Width="29px" OnClick="Experience_deletebtn_Click" /> 
                  
                  </asp:TableCell>  
                   
        
    </asp:TableRow>
      
          

   
          <asp:TableRow ID="NOCTableRow" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
       <asp:TableCell> NOC from Current Employer (In case of Permanent CSIR or Government Servant)</asp:TableCell>  
        
       <asp:TableCell>  <asp:FileUpload ID="NOCFileUpload" accept=".pdf" runat="server" /></asp:TableCell>  
        <asp:TableCell> <asp:Button class="btn btn-success" ID="NOC_btn" OnClick="NOC_btn_Click" runat="server" Text="Upload" /></asp:TableCell>  
        <asp:TableCell><asp:Label ID="NOClbl" runat="server" Font-Size="small" Text="Upload PDF File less then 1MB (1000 KB)" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
        <asp:TableCell>
               
              

               <asp:ImageButton ID="NOC_pdfview" src="imgs/pdficon.png" OnClick="NOC_pdfview_Click" runat="server" Height="32px"  Width="36px"/>

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="NOC_deletebtn" src="imgs/pdfdelete.png" OnClick="NOC_deletebtn_Click" runat="server" Height="32px"  Width="29px"/> 
                  
                  </asp:TableCell>  
                   
        
    </asp:TableRow>

       
          <asp:TableRow ID="PWDTableRow" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
       <asp:TableCell> PWD Certificate ((Upload a certificate as pdf issued by competent authority)</asp:TableCell>  
        
       <asp:TableCell>  <asp:FileUpload ID="PWDFileUpload" accept=".pdf" runat="server" /></asp:TableCell>  
        <asp:TableCell> <asp:Button class="btn btn-success" ID="PWD_btn" OnClick="PWD_btn_Click" runat="server" Text="Upload" /></asp:TableCell>  
        <asp:TableCell><asp:Label ID="PWDlbl" runat="server" Font-Size="small" Text="Upload PDF File less then 1MB (1000 KB)" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
        <asp:TableCell>
               
              

               <asp:ImageButton ID="PWD_pdfview" src="imgs/pdficon.png" OnClick="PWD_pdfview_Click" runat="server" Height="32px"  Width="36px"/>

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="PWD_deletebtn" src="imgs/pdfdelete.png" OnClick="PWD_deletebtn_Click" runat="server" Height="32px"  Width="29px"/> 
                  
                  </asp:TableCell>                    
        
    </asp:TableRow>   
            
          <asp:TableRow ID="WidowDoc1Rwo" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
       <asp:TableCell>Death Certificate for Widow or Court Judgment/Decree in case of divource</asp:TableCell>  
        
       <asp:TableCell>  <asp:FileUpload ID="WidowFileUpload1" accept=".pdf" runat="server" /></asp:TableCell>  
              
        <asp:TableCell> <asp:Button class="btn btn-success" ID="WidowBtn1" OnClick="WidowBtn1_Click" runat="server" Text="Upload" />
 </asp:TableCell>  
        <asp:TableCell><asp:Label ID="WidowLbl1" runat="server" Font-Size="small" Text="Upload PDF File less then 1MB (1000 KB)" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
        <asp:TableCell>
               
               <asp:ImageButton ID="WidowPdfView1" src="imgs/pdficon.png" OnClick="WidowPdfView1_pdfview_Click" runat="server" Height="32px"  Width="36px"/>

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="WidowPdfDelete1" src="imgs/pdfdelete.png" OnClick="WidowPdfDelete1_Click" runat="server" Height="32px"  Width="29px"/> 

               
                  
                  </asp:TableCell>                    
        
    </asp:TableRow>

              <asp:TableRow ID="WidowDoc2Rwo" runat="server" class="table table-bordered">
         <asp:TableCell><img src="imgs/ticon.png" height="15" width="15" /></asp:TableCell>  
       <asp:TableCell> Affidavit for non-remarriage.</asp:TableCell>  
        
       <asp:TableCell>  <asp:FileUpload ID="WidowFileUpload2" accept=".pdf" runat="server" /></asp:TableCell>  
        <asp:TableCell> <asp:Button class="btn btn-success" ID="WidowBtn2" OnClick="WidowBtn2_Click" runat="server" Text="Upload" /></asp:TableCell>  
        <asp:TableCell><asp:Label ID="WidowLbl2" runat="server" Font-Size="small" Text="Upload PDF File less then 1MB (1000 KB)" Font-Italic="True" ForeColor="Blue"></asp:Label>&nbsp; </asp:TableCell>  
        <asp:TableCell>
                <asp:ImageButton ID="WidowPdfView2" src="imgs/pdficon.png" OnClick="WidowPdfView2_pdfview_Click" runat="server" Height="32px"  Width="36px"/>

           &nbsp;&nbsp;&nbsp;&nbsp;  <asp:ImageButton ID="WidowPdfDelete2" src="imgs/pdfdelete.png" OnClick="WidowPdfDelete2_Click" runat="server" Height="32px"  Width="29px"/>
              

              
                  
                  </asp:TableCell>                    
        
    </asp:TableRow>
          

         

</asp:Table>

 
</div>

                       </div>
                   </div>
    </div>
    </div>
    <br />
     <%-- Submit button start.--%>
    <div class="container">
    <div class="row">
    <div class="col-12">
                         <asp:Button ID="goBackbtn" CssClass="savebtncolor" runat="server" Text="Go Back to Home" OnClick="goBackbtn_Click" />

    <center> 
        <asp:Button ID="uploadcontinue" runat="server" CssClass="savebtncolor" Text="Save and Continue" OnClick="uploadcontinue_Click"  />

         
        

        
    </center>
    </div>
    </div>
        <br />
        <br />
    </div>
       <%-- Submit Section ends.--%>      

   
</asp:Content>