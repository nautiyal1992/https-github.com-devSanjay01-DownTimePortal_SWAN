<%@ page title="" language="C#" masterpagefile="~/UserMaster.master" autoeventwireup="true" inherits="Admin_AccountRequest, App_Web_kim2zise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder8" runat="Server">
<style type="text/css">
.row:hover
{
    background-color:#ffcccc;
}
</style>
    <link href="../Styles/Grid.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/Deletecomfirm.js" type="text/javascript"></script>
    <table style="width: 100%;" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    DataKeyNames="Email" AllowPaging="True" AllowSorting="True" 
                    CellPadding="4" PageSize="30" HorizontalAlign="Center" Width="100%" OnRowDataBound="GridView1_RowDataBound"
                    OnRowUpdating="GridView1_RowUpdating" 
                    OnRowDeleting="GridView1_RowDeleting" 
                    DataSourceID="Accountdetail" ForeColor="#333333">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <p class="leftagn">
                                    <%#Eval("Name") %></p>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email ID">
                            <ItemTemplate>
                                <p class="leftagn">
                                    <%#Eval("Email") %></p>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mobile No.">
                            <ItemTemplate>
                                <%#Eval("Mobile") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <%#Eval("Gender") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DOB">
                            <ItemTemplate>
                                <%# Convert.ToDateTime(Eval("DOB")).ToShortDateString() %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SHQ">
                            <ItemTemplate>
                                <p class="leftagn">
                                    <%#Eval("SHQ") %>
                                </p>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="DHQ">
                            <ItemTemplate>
                                <p class="leftagn">
                                    <%#Eval("DHQ") %>
                                </p>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="POP">
                            <ItemTemplate>
                                <p class="leftagn">
                                    <%#Eval("POP") %></p>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Permi-<br/>ssion">
                            <ItemTemplate>
                                <asp:Label ID="Status" runat="server" Text='<%#Eval("Permission") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="DropDownList1" runat="server" SelectedValue='<%# Bind("Permission") %>' >
                                    <asp:ListItem>Admin</asp:ListItem>
                                    <asp:ListItem>Allow</asp:ListItem>
                                    <asp:ListItem>Cancel</asp:ListItem>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Account Create<br/> Date" ItemStyle-CssClass="leftagn">
                            <ItemTemplate>
                                <p class="leftagn">
                                    <%#Eval("AC_Date") %></p>
                            </ItemTemplate>
                            <ItemStyle CssClass="leftagn"></ItemStyle>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="true" ButtonType="Button" EditText="Permissions"
                            ControlStyle-ForeColor="#006600">
                            <ControlStyle ForeColor="#006600" ></ControlStyle>
                        </asp:CommandField>
                         <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" Text="Delete" CommandName="Delete" ForeColor="Red"  OnClientClick="return confirm('Do you want to Delete this ?')" />
                            </ItemTemplate>
                            <ItemStyle CssClass="leftagn"></ItemStyle>
                        </asp:TemplateField>
                       
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerSettings FirstPageText="First" LastPageText="Last"
                        NextPageText="Next" PreviousPageText="Previous" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" HorizontalAlign="Center" Font-Size="Medium" 
                        CssClass="row" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <asp:SqlDataSource ID="Accountdetail" runat="server" ConnectionString="<%$ ConnectionStrings:con_str %>"
                    SelectCommand="SELECT [Name], [Email], [Mobile], [Gender], [DOB], [SHQ], [DHQ], [POP], [Permission], [AC_Date] FROM [AccountDetail] Order by DHQ"
                    UpdateCommand="Update AccountDetail SET Permission=@pr where Email=@eml" 
                    DeleteCommand="Delete from AccountDetail where Email=@eml" >
                    <UpdateParameters>
                        <asp:Parameter Name="eml" Type="String" />
                        <asp:Parameter Name="pr" Type="String" />
                    </UpdateParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="eml" Type="String" />
                    </DeleteParameters>
                </asp:SqlDataSource>
            </td>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder10" runat="Server">
</asp:Content>
