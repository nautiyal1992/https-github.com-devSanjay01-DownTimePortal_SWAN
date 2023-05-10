<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Account_SignUp, App_Web_oqtrasiw" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../Styles/layout.css" rel="stylesheet" type="text/css" />
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder3">
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />
    <table align="center" width="700px">
    <caption id="cap">
        SignUp for New Account
        </caption>
    <tr>
        <td  align="right" width="85px">
                Name :</td>
        <td align="left">
            <asp:TextBox ID="TextBox1" runat="server" Width="200px" placeholder="User Name"></asp:TextBox>
        </td>
        <td align="left" >
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Enter User Name" 
                    Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td  align="right" width="85px">
                Email-ID :</td>
        <td align="left" >
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Email" ToolTip="Email ID" 
                    Width="200px" placeholder="Email ID"></asp:TextBox>
        </td>
        <td align="left" >
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBox2" Display="Dynamic" 
                    ErrorMessage="Enter Valid Email ID" Font-Italic="True" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td  align="right" width="85px">
                Mobile :</td>
        <td align="left" >
            <asp:TextBox ID="TextBox3" runat="server" Width="200px" MaxLength="10" 
                    TextMode="Phone" placeholder="Mobile"></asp:TextBox>
        </td>
        <td align="left" >
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ErrorMessage="Mobile Number should be only on digit with 10 digit" 
                Font-Italic="True" ForeColor="Red" 
                ValidationExpression="^[0-9]{10}" ControlToValidate="TextBox3" 
                Display="Dynamic"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td  align="right" width="85px">
                DOB :</td>
        <td align="left" >
            <asp:TextBox ID="TextBox4" runat="server" Width="200px" placeholder="dd/mm/yyyy"></asp:TextBox>
            <asp:CalendarExtender ID="TextBox4_CalendarExtender" runat="server" 
                Format="dd/MM/yyyy" TargetControlID="TextBox4">
            </asp:CalendarExtender>
        </td>
        <td align="left" class="style3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="Enter Date Birth" 
                    Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style4" align="right" width="85px">
                Gender :</td>
        <td align="left" class="style1">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td align="left" class="style4">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="RadioButtonList1" Display="Dynamic" 
                    ErrorMessage="Select Gender" Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style3" align="right" width="85px">
                SHQ :</td>
        <td align="left" class="style1">
            <asp:Label ID="Label1" runat="server" Text="Dehradun SHQ"></asp:Label>
        </td>
        <td align="left" class="style3">
        </td>
    </tr>
    <tr>
        <td class="style3" align="right" width="85px">
                DHQ :</td>
        <td align="left" class="style1">
            <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" placeholder="Select DHQ"
                    AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
        <td align="left" class="style3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="DropDownList1" Display="Dynamic" ErrorMessage="Select DHQ" 
                    Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style2" align="right" width="85px">
                POP :</td>
        <td align="left" class="style1">
            <asp:DropDownList ID="DropDownList2" runat="server" Width="200px" placeholder="Select POP"
                    AutoPostBack="True">
            </asp:DropDownList>
        </td>
        <td align="left" class="style2">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="DropDownList2" Display="Dynamic" ErrorMessage="Select POP" 
                    Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style3" align="right" width="85px">
                Password :</td>
        <td align="left" class="style1">
            <asp:TextBox ID="TextBox5" runat="server" TextMode="Password" Width="200px" placeholder="Password"></asp:TextBox>
        </td>
        <td align="left" class="style3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="EnterPassword" 
                    Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style2" align="right" width="85px">
                Re-Password :</td>
        <td align="left" class="style1">
            <asp:TextBox ID="TextBox6" runat="server" TextMode="Password" Width="200px" placeholder="Re_Password"></asp:TextBox>
        </td>
        <td align="left" class="style2">
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TextBox6" ControlToValidate="TextBox5" Display="Dynamic" 
                    ErrorMessage="Password Not Matched" Font-Italic="True" ForeColor="Red"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td align="right" width="85px">
                Address :</td>
        <td align="left" class="style1">
            <asp:TextBox ID="TextBox7" runat="server" TextMode="MultiLine" Width="300px" 
                    Height="72px" placeholder="Offie Address"></asp:TextBox>
        </td>
        <td align="left">
                &nbsp;</td>
    </tr>
    <tr>
        <td align="right" width="85px">
        </td>
        <td class="style1" align="left">
            <asp:Button ID="Button1" runat="server" Text="SignUp" onclick="Button1_Click" />
        </td>
        <td align="left">
                &nbsp;</td>
    </tr>
    <tr>
        <td align="right" width="85px">
                &nbsp;</td>
        <td align="left" class="style1">
            <asp:Label ID="Label2" runat="server" Font-Italic="True" ForeColor="#33CC33" 
                    Text="Label" Visible="False"></asp:Label>
        </td>
        <td align="left">
                &nbsp;</td>
    </tr>
</table>
</asp:Content>


