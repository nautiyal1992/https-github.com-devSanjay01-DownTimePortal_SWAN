<%@ page title="" language="C#" masterpagefile="~/UserMaster.master" autoeventwireup="true" inherits="Admin_Linktype, App_Web_kim2zise" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style13
    {
        font-size: x-large;
    }
</style>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder8" Runat="Server">
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />

    <table align="center" style="width: 100%; text-align: center;">
        <caption id="cap">
            <strong>Link Type Entery Form</strong></caption>
        <tr>
            <td class="style5">
            </td>
            <td class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5" style="text-align: right">
                Link Type :
            </td>
            <td align="left" class="style5">
                <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="TextBox1_TextBoxWatermarkExtender" 
                    runat="server" TargetControlID="TextBox1" WatermarkText="Link Name">
                </asp:TextBoxWatermarkExtender>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td align="left">
                <asp:Button ID="Button1" runat="server" Text="Entry" onclick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" DataSourceID="Linktypeds" ForeColor="#333333" 
                    AllowPaging="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                       <asp:TemplateField HeaderText="S.No">
                       <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Link Type">
                            <ItemTemplate>
                                <%#Eval("Link_Type") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <asp:SqlDataSource ID="Linktypeds" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:con_str %>" 
                    SelectCommand="SELECT * FROM [LinkType] ORDER BY [Link_Type]">
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder10" Runat="Server">
</asp:Content>

