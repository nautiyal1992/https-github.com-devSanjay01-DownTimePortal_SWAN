<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Account_Login, App_Web_g5ttszk5" %>
<%@ Register src="LoginUC.ascx" tagname="LoginUC" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />
  
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    
    <div _designerregion="0"  style="text-align: center">
        <table style="width:100%;">
            <tr>
                <td>
                    SHQ :
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    DHQ :
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                        AutoPostBack="True">
                        <asp:ListItem>Select All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;From :
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    <asp:DropDownList ID="DropDownList2" runat="server" Visible="False">
                    </asp:DropDownList>
                &nbsp;To :
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td id="cap" colspan="4" align="center">
                    Current Month Down Time Till Date</td>
                    
            </tr>
            <tr>
                <td  colspan="4" align="center">
                    <asp:GridView ID="GridView1" runat="server" BackColor="#FF9900" 
                        BorderColor="#336666" BorderStyle="Outset" BorderWidth="3px" 
                        CaptionAlign="Top" CellPadding="5" 
                        CellSpacing="5" EmptyDataText="No record Found" Font-Size="Small" 
                        Width="100%">
                        <FooterStyle BackColor="White" ForeColor="#333333" />
                        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="White" ForeColor="#333333" HorizontalAlign="Center" 
                            VerticalAlign="Middle" />
                        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#487575" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#275353" />
                    </asp:GridView>
                    <asp:Chart ID="Chart1" runat="server" ViewStateContent="All" Visible="False">
                        <Series>
                            <asp:Series Legend="Legend1" Name="Series1">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                        <Legends>
                            <asp:Legend Name="Legend1" Title="R1">
                            </asp:Legend>
                        </Legends>
                    </asp:Chart>
                </td>
            </tr>
        </table>
</div>
</asp:Content>

<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
                                <asp:TreeView ID="TreeView1" runat="server" 
        Visible="False">
                                    <Nodes>
                                        <asp:TreeNode NavigateUrl="~/Account/Login.aspx" Text="Login" Value="Login">
                                        </asp:TreeNode>
                                        <asp:TreeNode NavigateUrl="~/Account/SignUp.aspx" Text="SignUp" Value="Signup">
                                        </asp:TreeNode>
                                        <asp:TreeNode NavigateUrl="~/Account/FogotPassword.aspx" Text="Forgot Password" 
                                            Value="Forgot Password"></asp:TreeNode>
                                        <asp:TreeNode NavigateUrl="~/Account/ChangePassword.aspx" 
                                            Text="Change Password" Value="Change Password"></asp:TreeNode>
                                    </Nodes>
                                </asp:TreeView>
                            </asp:Content>


<asp:Content ID="Content5" runat="server" 
    contentplaceholderid="ContentPlaceHolder3">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
             <uc2:LoginUC ID="LoginUC1" runat="server" />
            </AnonymousTemplate>
        
    </asp:LoginView>
    </asp:Content>



