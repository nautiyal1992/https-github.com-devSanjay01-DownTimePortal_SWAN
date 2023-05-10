<%@ page title="" language="C#" masterpagefile="~/UserMaster.master" autoeventwireup="true" inherits="Admin_AddPop, App_Web_kim2zise" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder8" Runat="Server">
    <link href="../Styles/style.css" rel="stylesheet" type="text/css" />
    <table style="width:100%; font-size: medium;" border="0">
        <caption id="cap">
            POP Detail And Add POP</caption>
        <tr>
            <td align="right">
                POP Name :</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="TextBox1_TextBoxWatermarkExtender" 
                    runat="server" TargetControlID="TextBox1" WatermarkText="POP Name">
                </asp:TextBoxWatermarkExtender>
            </td>
            <td rowspan="9">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" DataSourceID="POPdatasource" AllowPaging="True" 
                    PageSize="20" EmptyDataText="No POP Added">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No">
                       <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="POP">
                            <ItemTemplate>
                                <%#Eval("POP") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DHQ">
                            <ItemTemplate>
                                <%#Eval("DHQ") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="POP Type">
                            <ItemTemplate>
                                <%#Eval("POP_Type") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Link Type">
                            <ItemTemplate>
                                <%#Eval("Link_Type") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Band<br/>width">
                            <ItemTemplate>
                                <%#Eval("Bandwidth") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NOC Open<br/> Time">
                            <ItemTemplate>
                                <%#Eval("NOC_Open_Time") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NOC Close<br/> Time">
                            <ItemTemplate>
                                 <%#Eval("NOC_Close_Time") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <FooterStyle BackColor="White" ForeColor="#000066" />
                    <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                    <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#007DBB" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#00547E" />
                </asp:GridView>
                <asp:SqlDataSource ID="POPdatasource" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:con_str %>" 
                    SelectCommand="SELECT * FROM [POP] ORDER BY DHQ"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td align="right">
                Select POP Type :</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Width="200px">
                    <asp:ListItem>---Select POP Type---</asp:ListItem>
                    <asp:ListItem>SHQ</asp:ListItem>
                    <asp:ListItem>DHQ</asp:ListItem>
                    <asp:ListItem>THQ</asp:ListItem>
                    <asp:ListItem>BHQ</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                Select DHQ :</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                Link Type : </td>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                Bandwidth :</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="200px" AutoPostBack="True" 
                    ontextchanged="TextBox2_TextChanged" TextMode="Phone"></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="TextBox2_TextBoxWatermarkExtender" 
                    runat="server" TargetControlID="TextBox2" WatermarkText="00">
                </asp:TextBoxWatermarkExtender>
            </td>
        </tr>
        <tr>
            <td align="right">
                NOC Open Time :</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Width="200px" AutoPostBack="True" 
                    ontextchanged="TextBox3_TextChanged" ></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="TextBox3_TextBoxWatermarkExtender" 
                    runat="server" TargetControlID="TextBox3" WatermarkText="hh:mm:ss">
                </asp:TextBoxWatermarkExtender>
            </td>
        </tr>
        <tr>
            <td align="right">
                NOC Close Time :</td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" Width="200px" AutoPostBack="True" 
                    ontextchanged="TextBox4_TextChanged" ></asp:TextBox>
                <asp:TextBoxWatermarkExtender ID="TextBox4_TextBoxWatermarkExtender" 
                    runat="server" TargetControlID="TextBox4" WatermarkText="hh:mm:ss">
                </asp:TextBoxWatermarkExtender>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                    Text="Add POP" />
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder10" Runat="Server">
</asp:Content>

