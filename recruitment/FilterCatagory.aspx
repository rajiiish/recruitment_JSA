<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="FilterCatagory.aspx.cs" Inherits="recruitment.FilterCatagory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
 

  body
    {
        font-family: Arial;
        font-size: 10pt;
    }

 
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />

        <div class="row">
  <div class="col-sm-3">
    <div class="card">
      <div class="card-body">
        <h6 class="card-title">Filter Post-Wise</h6>
       
        <a href="FilterbyPost.aspx" class="btn btn-info">Open</a>
      </div>
    </div>
  </div>
   <div class="col-sm-3">
    <div class="card">
      <div class="card-body">
        <h6 class="card-title">Filter Cast Catagory-Wise</h6>
       
        <a href="AdminPreview.aspx" class="btn btn-info">Open</a>
      </div>
    </div>
  </div>
                <div class="col-sm-3">
    <div class="card">
      <div class="card-body">
        <h6 class="card-title">Filter Marks-Wise</h6>
       
        <a href="FilterbyMark.aspx" class="btn btn-info">Open</a>
      </div>
    </div>
  </div>
                <div class="col-sm-3">
    <div class="card">
      <div class="card-body">
        <h6 class="card-title">View Single Applicant Profile</h6>
       
        <a href="can_profile.aspx" class="btn btn-info">Open</a>
      </div>
    </div>
  </div>
</div>
    </div>
</asp:Content>
