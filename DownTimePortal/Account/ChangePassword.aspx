<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Account_ChangePassword, App_Web_oqtrasiw" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    
    <style type="text/css">
        .style2
        {
            height: 23px;
        }
        .style3
        {
            height: 23px;
            width: 204px;
        }
        .style4
        {
            width: 204px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />
    <table align="center" style="width: 600px;">
        <caption id="cap">
            Change Your Password</caption>
        <tr>
            <td class="style2" align="right">
                Email ID :
            </td>
            <td align="left" class="style3">
                <asp:TextBox ID="TextBox1" runat="server" Width="200px" placeholder="email ID"></asp:TextBox>
            </td>
            <td align="left" class="style2">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBox1" ErrorMessage="RegularExpressionValidator" 
                    Font-Italic="True" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Enter Valid Email ID</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                Old Password :</td>
            <td align="left" class="style4">
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" placeholder="Old Password"></asp:TextBox>
            </td>
            <td align="left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox2" ErrorMessage="RequiredFieldValidator" 
                    Font-Italic="True" ForeColor="Red">Enter Old Password</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                New Password :</td>
            <td align="left" class="style4">
                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" placeholder="New Password"></asp:TextBox>
            </td>
            <td align="left">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBox3" ErrorMessage="RequiredFieldValidator" 
                    Font-Italic="True" ForeColor="Red">Require New Password</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style2" align="right">
                Re-Password :</td>
            <td align="left" class="style3">
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" placeholder="Re_New Password"></asp:TextBox>
            </td>
            <td align="left" class="style2">
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TextBox3" ControlToValidate="TextBox4" 
                    ErrorMessage="CompareValidator" Font-Italic="True" ForeColor="Red">Password not Matched</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left" class="style4">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left" class="style4">
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
            </td>
            <td align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left" class="style4">
                <asp:Label ID="Label1" runat="server" Font-Italic="True" ForeColor="#33CC33" 
                    Text="Label" Visible="False"></asp:Label>
            </td>
            <td align="left">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

