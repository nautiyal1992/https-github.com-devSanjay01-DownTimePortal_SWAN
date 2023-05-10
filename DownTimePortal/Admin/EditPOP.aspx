<%@ page title="" language="C#" masterpagefile="~/UserMaster.master" autoeventwireup="true" inherits="Admin_EditPOP, App_Web_kim2zise" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style13
        {
            height: 26px;
        }
        .style14
        {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder8" Runat="Server">
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />
    <table style="width: 100%;">
        <caption id="cap">
            Update POP and Delete</caption>
    <tr>
        <td align="right">
            Select DHQ Name :</td>
        <td colspan="2">
            <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style13" align="right">
            Select POP Type :</td>
        <td colspan="2" class="style13">
            <asp:DropDownList ID="DropDownList2" runat="server" Width="150px" 
                AutoPostBack="True" onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                <asp:ListItem>---Selecte POP Type---</asp:ListItem>
                <asp:ListItem>SHQ</asp:ListItem>
                <asp:ListItem>DHQ</asp:ListItem>
                <asp:ListItem>THQ</asp:ListItem>
                <asp:ListItem>BHQ</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">
            Select POP Name :</td>
        <td colspan="2">
            <asp:DropDownList ID="DropDownList3" runat="server" 
                onselectedindexchanged="DropDownList3_SelectedIndexChanged" Width="150px" 
                AutoPostBack="True">
                <asp:ListItem>---Select POP---</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style13" align="right">
            Select Link Type :</td>
        <td class="style13">
            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="style13">
            <asp:DropDownList ID="DropDownList4" runat="server" 
                onselectedindexchanged="DropDownList3_SelectedIndexChanged" Width="150px" 
                Visible="False">
                <asp:ListItem>---Select Link Type---</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style14" align="right">
            Bandwidth :</td>
        <td class="style14">
            <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="style14">
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" Height="22px" 
                ontextchanged="TextBox1_TextChanged" Visible="False"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="TextBox1_TextBoxWatermarkExtender" 
                runat="server" TargetControlID="TextBox1" WatermarkText="00">
            </asp:TextBoxWatermarkExtender>
        </td>
    </tr>
    <tr>
        <td class="style13" align="right">
            NOC Open Time :</td>
        <td class="style13">
            <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="style13">
            <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" 
                ontextchanged="TextBox2_TextChanged" Visible="False"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="TextBox2_TextBoxWatermarkExtender" 
                runat="server" TargetControlID="TextBox2" WatermarkText="00:00:00">
            </asp:TextBoxWatermarkExtender>
        </td>
    </tr>
    <tr>
        <td align="right">
            NOC Close Time :</td>
        <td>
            <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server" AutoPostBack="True" 
                ontextchanged="TextBox3_TextChanged" Visible="False"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="TextBox3_TextBoxWatermarkExtender" 
                runat="server" TargetControlID="TextBox3" WatermarkText="00:00:00">
            </asp:TextBoxWatermarkExtender>
        </td>
    </tr>
    <tr>
        <td align="right">
            &nbsp;</td>
        <td colspan="2">
            <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Do You Want Update Values ?</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td align="right">
            &nbsp;</td>
        <td>
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Update" 
                Visible="False" />
        </td>
        <td>
            <asp:Button ID="Button2" runat="server" Text="Delete" onclick="Button2_Click" 
                OnClientClick="return confirm('Do you want to Delete this ?')" 
                Visible="False" />
        </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder10" Runat="Server">
</asp:Content>

