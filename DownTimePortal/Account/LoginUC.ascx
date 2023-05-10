<%@ control language="C#" autoeventwireup="true" inherits="Use_Control_LoginUC, App_Web_oqtrasiw" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="../Styles/style.css" rel="stylesheet" type="text/css" />
<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
</asp:ScriptManagerProxy>
<table style="width: 200px; text-align:right;" >
    <tr>
        <td>
           <asp:LinkButton ID="lnkLogin" runat="server" Text="Login"></asp:LinkButton>
        </td>
        <td>
             <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Account/SignUp.aspx">SignUp</asp:LinkButton>
        </td>
       
    </tr>
</table>


<asp:Panel ID="pnlLogin" runat="server" CssClass="modalPopup" Style="display: none">
    <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td align="right">
                <asp:LinkButton ID="lnkCancel" runat="server" Text="[X]"></asp:LinkButton >
            </td>
        </tr>
        <tr>
            <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
           
<ContentTemplate>

                <asp:Login ID="Login1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99"
                    BorderStyle="Solid" BorderWidth="1px" FailureText="Wrong Username and Password"
                    Font-Names="Verdana" Font-Size="10pt" OnAuthenticate="Login_Authenticate" >
                    <LayoutTemplate>
                        <table cellpadding="1" cellspacing="0" style="border-collapse: collapse;">
                            <tr>
                                <td>
                                    <table cellpadding="0">
                                        <tr>
                                            <td align="center" colspan="3" style="color: #000000; background-color: #C0C0C0;
                                                font-weight: bold; font-size: 25px; font-family: Arial, Helvetica, sans-serif;">
                                                Log In
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                            </td>
                                            <td class="style2">
                                                <asp:TextBox ID="UserName" runat="server" Width="200px" placeholder="Email ID"></asp:TextBox>
                                                &nbsp;
                                            </td>
                                            <td class="style2">
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                    ErrorMessage="User Name is required." Font-Italic="True" ForeColor="Red" ToolTip="User Name is required."
                                                    ValidationGroup="ctl00$Login">User Name is required.</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                            </td>
                                            <td class="style2">
                                                <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="200px" placeholder="Password"></asp:TextBox>
                                            </td>
                                            <td class="style2">
                                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                    ErrorMessage="Password is required." Font-Italic="True" ForeColor="Red" ToolTip="Password is required."
                                                    ValidationGroup="ctl00$Login">Password is required.</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2" style="color: Red;">
                                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                            </td>
                                            <td align="center" style="color: Red;">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" ValidationGroup="ctl00$Login" />
                                            </td>
                                            <td align="right">
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Account/FogotPassword.aspx">Forget Password ?</asp:LinkButton>
                                            </td>
                                            <td align="right">
                                                <asp:LinkButton ID="LinkButton3" runat="server" PostBackUrl="~/Account/ChangePassword.aspx">Change Passowd</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </LayoutTemplate>
                    <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                </asp:Login>
               </ContentTemplate>
</asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:ModalPopupExtender ID="popup" runat="server" DropShadow="false" TargetControlID="lnkLogin"
    PopupControlID="pnlLogin" BackgroundCssClass="modalBackground" CancelControlID="lnkCancel">
</asp:ModalPopupExtender>

