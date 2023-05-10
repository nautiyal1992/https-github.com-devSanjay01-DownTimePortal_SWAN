<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Account_FogotPassword, App_Web_oqtrasiw" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
    .style1
    {
        width: 226px;
    }
        .style2
        {
            height: 26px;
        }
        .style3
        {
            width: 226px;
            height: 26px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="Server">
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />
        <table style="width: 600px;" align="center">
            <caption id="cap">
                Forgot Password</caption>
            <tr>
                <td align="right">
                    User Name :
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="TextBox1_TextBoxWatermarkExtender" runat="server"
                        Enabled="True" TargetControlID="TextBox1" WatermarkText="Your Name">
                    </asp:TextBoxWatermarkExtender>
                </td>
                <td align="left">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="RequiredFieldValidator" Font-Italic="True" ForeColor="#FF3300">Enter Your Name</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Email ID :
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="TextBox2_TextBoxWatermarkExtender" runat="server"
                        Enabled="True" TargetControlID="TextBox2" WatermarkText="Email">
                    </asp:TextBoxWatermarkExtender>
                </td>
                <td align="left">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2"
                        ErrorMessage="RegularExpressionValidator" Font-Italic="True" ForeColor="#FF3300"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">Enter Correct Email ID Format</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Mobile No. :
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="TextBox3" runat="server" MaxLength="10"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="TextBox3_TextBoxWatermarkExtender" runat="server"
                        Enabled="True" TargetControlID="TextBox3" WatermarkText="1234567890">
                    </asp:TextBoxWatermarkExtender>
                </td>
                <td align="left">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox3"
                        ErrorMessage="RegularExpressionValidator" Font-Italic="True" ForeColor="#FF3300"
                        ValidationExpression="^[0-9]{10}">Mobile no is only on digit </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    DOB :
                </td>
                <td align="left" class="style3">
                    <asp:TextBox ID="TextBox4" runat="server" placeholder="dd/mm/yyyy"></asp:TextBox>
                    <asp:CalendarExtender ID="TextBox4_CalendarExtender" runat="server" TargetControlID="TextBox4">
                    </asp:CalendarExtender>
                </td>
                <td align="left" class="style2">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox4"
                        ErrorMessage="RequiredFieldValidator" Font-Italic="True" ForeColor="#FF3300">Select Your Date of Birth</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;
                </td>
                <td align="left" class="style1">
                    &nbsp;
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;
                </td>
                <td align="left" class="style1">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Password" />
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right">
                    &nbsp;
                </td>
                <td align="left" class="style1">
                    <asp:Label ID="Label1" runat="server" Text="Password" ForeColor="#33CC33" Visible="False"></asp:Label>
                </td>
                <td align="left">
                    &nbsp;
                </td>
            </tr>
        </table>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
