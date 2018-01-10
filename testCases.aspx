<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="testCases.aspx.cs" Inherits="TestCases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 810px;
        }
        .style3
        {
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


<h1>Generated Test Cases</h1>
    <table class="style1">
        <tr>
            <td class="style2" rowspan="2">
    <asp:TextBox ID="TextBox1" runat="server" Columns="100" Font-Bold="True" 
        ForeColor="Blue" TextMode="MultiLine" 
        ReadOnly="True" Rows="50"></asp:TextBox>

            </td>
            <td class="style3" >
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Print" />
               

            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    <br />

</asp:Content>

