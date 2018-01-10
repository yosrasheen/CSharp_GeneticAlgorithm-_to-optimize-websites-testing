<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="testingParam.aspx.cs" Inherits="testingParam" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        Please Choose the features that you need to test.</p>
    <p>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem Value="Browser">Browser</asp:ListItem>
            <asp:ListItem Value="Javascript">Javascript</asp:ListItem>
            <asp:ListItem Value="Screen_Resolution">Screen Resolution</asp:ListItem>
            <asp:ListItem Value="Cookies">Cookies</asp:ListItem>
            <asp:ListItem Value="Accessibility">Accessibility</asp:ListItem>
            <asp:ListItem Value="Right_to_left_support">Right-to-left support</asp:ListItem>
            <asp:ListItem Value="Using_CSS">Using CSS</asp:ListItem>
            <asp:ListItem Value="Dynamic_Navigation">Dynamic Navigation (a link leads to multiple pages)</asp:ListItem>
            <asp:ListItem Value="Server_Side_Scripting">Server Side Scripting</asp:ListItem>
        </asp:CheckBoxList>
    </p>
    <p>
        <asp:Button ID="btnDone" runat="server" onclick="btnDone_Click" Text="Done" />
    </p>
    <p>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </p>
</asp:Content>

