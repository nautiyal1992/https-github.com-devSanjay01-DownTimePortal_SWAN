<%@ page title="" language="C#" masterpagefile="~/UserMaster.master" autoeventwireup="true" inherits="Admin_Majorreport, App_Web_kim2zise" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            text-align: right;
        }
        .style2
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder13" Runat="Server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder10" Runat="Server">

</asp:Content>

<asp:Content ID="Content10" runat="server" 
    contentplaceholderid="ContentPlaceHolder8">
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />
    <table style="width:100%; background-color:White;">
        <caption id="cap">
            Select Your Report Genration Type</caption>
    <tr>
        <td align="center" colspan="5">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">Major Issue</asp:ListItem>
                <asp:ListItem>Detailed</asp:ListItem>
                <asp:ListItem>Detailed Summary</asp:ListItem>
                <asp:ListItem>Reason Summary</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label11" runat="server" Text="Enter Days:"></asp:Label>
        </td>
        <td align="center" class="style2">
            <asp:TextBox ID="TextBox1" runat="server" ontextchanged="TextBox1_TextChanged" 
                TextMode="Number" AutoPostBack="True">0</asp:TextBox>
        </td>
        <td class="style1">
            <asp:Label ID="Label12" runat="server" Text="Select Date :"></asp:Label>
        </td>
        <td align="center" class="style2">
            <asp:TextBox ID="TextBox2" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
            <asp:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
                Format="dd/MM/yyyy" TargetControlID="TextBox2">
            </asp:CalendarExtender>
        </td>
        <td align="center">
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                Text="Show Report" />
        </td>
    </tr>
    <tr>
        <td colspan="5">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" 
                Font-Names="Verdana" Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
                WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="600px" 
                style="text-align: center">
              </rsweb:ReportViewer>
           
        </td>
    </tr>
</table>
</asp:Content>


