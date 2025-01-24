<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="recruitment.homepage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        
        e<!-- Page header with logo and tagline
        <header class="py-5 bg-light border-bottom mb-4">
            <div class="container">
                <div class="text-center my-5">
                    <h1 class="fw-bolder">Welcome to Blog Home!</h1>
                    <p class="lead mb-0">A Bootstrap 5 starter layout for your next blog homepage</p>
                </div>
            </div>
        </header>--><!-- Page content--><div class="container">
            <div class="row">
                <!-- Blog entries-->
                <div class="col-lg-8">
                    <!-- Featured blog post-->
                    <div class="card mb-4">
                        <a href="#!"><img class="card-img-top" src="imgs/homebanner.jpg" alt="..." /></a>
                        <div class="card-body">
                            <div class="small text-muted">January 20, 2025</div>
                            <h5 class="card-title">Applications are invited from Indian Nationals for the following posts in CSIR Madras Complex (CMC), Chennai.</h5>
                        <!--     <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>-->
                            <table class="table">
  <thead>
    <tr>
      <th scope="col">S.No</th>
      <th scope="col">Post Name</th>
      <th scope="col">No of Positions</th>
      <th scope="col">Max Age Limit</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <th scope="row">1</th>
      <td>Security Assistant (SA)</td>
      <td>1 No. (UR)</td>
      <td>28 years</td>
    </tr>
 
  </tbody>
</table>
                          <br /> <br>  
                            <a class="btn btn-primary" href="#!">View Full Notification →</a>

                        </div>
                    </div>
                    <!-- Nested row for non-featured blog posts-->
                    
                    <!-- Pagination-->

                </div>
                <!-- Side widgets-->
                <div class="col-lg-4">
                    <!-- Search widget-->
                    <div class="card mb-4">
                        <div class="card-header"> <asp:Label ID="loginlbl" runat="server" Text="Already Registered Applicants"></asp:Label></div>
                        <div class="card-body">
                            <div class="input-group">
                               <asp:Button ID="loginclick" class="btn btn-primary btn-block btn-md" runat="server" Text="Login" OnClick="loginclick_Click" />
                                 <asp:Button ID="logoutclick" class="btn btn-warning btn-block btn-md" runat="server" Text="Logout" OnClick="logoutclick_Click" />
                            </div>
                        </div>
                    </div>
                    <!-- Categories widget-->
                    <div class="card mb-4">
                        <div class="card-header"><asp:Label ID="registlbl" runat="server" Text="New Applicants"></asp:Label></div>
                        <div class="card-body">
                            <div class="row">
                                <div class="input-group">
                               <asp:Button ID="registerbtn" class="btn btn-info btn-block btn-md" runat="server" Text="Register" OnClick="registerbtn_Click" />
                               <asp:Button ID="viewpostbtn" class="btn btn-warning btn-block btn-md" runat="server" Text="View Applied Posts" OnClick="viewpostbtn_Click"  />
                            </div>
                            </div>
                        </div>
                    </div>
                    <!-- Side widget-->
                     <div class="card mb-4">
                       <!--   <div class="card-header">SBI Collect Payment</div> -->
                        <div class="card-header"></div> 

                        <div class="card-body">
                            <div class="row">
                                <div class="input-group">
                                    <div class="col-12">
                                <!--      <p>Applicants are required to remit/pay application fee (Non-refundable) of Rs. 500/- (wherever applicable) through SBI COLLECT to the following account and fill up the transaction details in the prescribed columns of online application.No other mode of payment will be accepted.</p>
                             <asp:Button ID="Button1" class="btn btn-info btn-block btn-sm" runat="server" href="#!" Text="SBI Collect Link"  /> -->
                                  <strong>  <p>Application fee is exempted in respect of SC/ST/PWD/ EX-Serviceman, Women & Departmental Applicants.</p></strong>
                                        </div>
                            </div>
                            </div>
                        </div>
                    </div>

                
                </div>
            </div>
        </div>
        
    </div>


</asp:Content>