<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        <b>Welcome to the optimized web application testing framework. To start testing 
        the website enter the use case statements of your system.</b></p>
    <p>
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
            ForeColor="Red"></asp:Label>
    </p>
<p>
        <asp:TextBox ID="TextBox1" runat="server" Height="97px" TextMode="MultiLine" 
            Width="439px"></asp:TextBox>
    </p>
    <p>
        Enter the names of the levels of users</p>
    <p>
        <asp:TextBox ID="TextBox2" runat="server" Height="97px" TextMode="MultiLine" 
            Width="439px"></asp:TextBox>
    </p>
    <p>
        &nbsp;<asp:CheckBox ID="CheckBox1" runat="server" 
            oncheckedchanged="CheckBox1_CheckedChanged" 
            Text="Maximum number of test cases (100) if not specified" AutoPostBack="True" 
            EnableViewState="False" />

    &nbsp;
        <asp:TextBox ID="TextBox3" runat="server" 
            Width="23px" EnableViewState="False" Visible="False" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3" ErrorMessage="Enter a valid number" ValidationExpression="^((-)?[0-9]+(\.[0-9]+)?)$" Display="Dynamic"></asp:RegularExpressionValidator>
           
 
    &nbsp;</p>
<p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Create the model" />
    </p>
<p>
        &nbsp;</p>
</asp:Content>
