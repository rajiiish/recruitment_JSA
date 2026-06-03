<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testbinddb.aspx.cs" Inherits="recruitment.testbinddb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
             <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="True" Height="27px" Width="257px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="Select">-Select-</asp:ListItem>
            <asp:ListItem Value="TA-CIVIL">Technical Assistant (Civil)</asp:ListItem>
            <asp:ListItem Value="TA-IT">Technical Assistant (IT)</asp:ListItem>
            <asp:ListItem Value="JSA">Junior Secretariat Assistant</asp:ListItem>
        </asp:DropDownList>


            <br />


            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="can_regno" HeaderText="can_regno" SortExpression="can_regno" />
                    <asp:BoundField DataField="postcode" HeaderText="postcode" SortExpression="postcode" />
                    <asp:BoundField DataField="postdetails" HeaderText="postdetails" SortExpression="postdetails" />
                    <asp:BoundField DataField="appregno" HeaderText="appregno" SortExpression="appregno" />
                    <asp:BoundField DataField="fullname" HeaderText="fullname" SortExpression="fullname" />
                    <asp:BoundField DataField="fathername" HeaderText="fathername" SortExpression="fathername" />
                    <asp:BoundField DataField="dateofbirth" HeaderText="dateofbirth" SortExpression="dateofbirth" />
                    <asp:BoundField DataField="sexuality" HeaderText="sexuality" SortExpression="sexuality" />
                    <asp:BoundField DataField="cast" HeaderText="cast" SortExpression="cast" />
                    <asp:BoundField DataField="marital" HeaderText="marital" SortExpression="marital" />
                    <asp:BoundField DataField="religion" HeaderText="religion" SortExpression="religion" />
                    <asp:BoundField DataField="csiremp" HeaderText="csiremp" SortExpression="csiremp" />
                    <asp:BoundField DataField="pwd" HeaderText="pwd" SortExpression="pwd" />
                    <asp:BoundField DataField="aadhaar" HeaderText="aadhaar" SortExpression="aadhaar" />
                    <asp:BoundField DataField="citizen" HeaderText="citizen" SortExpression="citizen" />
                    <asp:BoundField DataField="bankname" HeaderText="bankname" SortExpression="bankname" />
                    <asp:BoundField DataField="paydate" HeaderText="paydate" SortExpression="paydate" />
                    <asp:BoundField DataField="paymode" HeaderText="paymode" SortExpression="paymode" />
                    <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                    <asp:BoundField DataField="mobile" HeaderText="mobile" SortExpression="mobile" />
                    <asp:BoundField DataField="presentaddress" HeaderText="presentaddress" SortExpression="presentaddress" />
                    <asp:BoundField DataField="paddresscity" HeaderText="paddresscity" SortExpression="paddresscity" />
                    <asp:BoundField DataField="paddressstate" HeaderText="paddressstate" SortExpression="paddressstate" />
                    <asp:BoundField DataField="paddresspincode" HeaderText="paddresspincode" SortExpression="paddresspincode" />
                    <asp:BoundField DataField="peraddress" HeaderText="peraddress" SortExpression="peraddress" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:onlineapplicationConnectionString1 %>" SelectCommand="SELECT * FROM [basicdetailsNew] WHERE ([postcode] = @postcode)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList1" Name="postcode" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
