<%@ page title="" language="C#" masterpagefile="~/UserMaster.master" autoeventwireup="true" inherits="DistrictDownDetail, App_Web_xjen1rsy" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
    <style type="text/css">
    #td
    {
        font-weight: bold;
    }
    .row:hover
{
    background-color:#ffcccc;
}
</style>
   
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder8" Runat="Server">
    
    <table style="width: 100%; font-size: small; padding-left:2px">
    <tr>
      <td id="td">
                From Date
            </td>
        <td  id="td">
                To Date
            </td>
        <td  id="td">
                Select A-END
            </td>
        <td  id="td">
                Select B-END
            </td>
        <td  id="td">
                Select Reason
            </td>
        <td  id="td">
                &nbsp;Bandwidth
            </td>
        <td  id="td">
                &nbsp;
            </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" Width="100px"
                    AutoPostBack="True"></asp:TextBox>
            <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" 
                Format="dd/MM/yyyy" TargetControlID="TextBox1">
            </asp:CalendarExtender>
        </td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" Width="100px"
                    AutoPostBack="True"></asp:TextBox>
            <asp:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" 
                Format="dd/MM/yyyy" TargetControlID="TextBox2">
            </asp:CalendarExtender>
        </td>
        <td class="style15">
            <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server" Width="150px">
                <asp:ListItem>Select All</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:DropDownList ID="DropDownList3" runat="server">
                <asp:ListItem Value="R">Select All</asp:ListItem>
                <asp:ListItem>R1</asp:ListItem>
                <asp:ListItem>R2</asp:ListItem>
                <asp:ListItem>R3</asp:ListItem>
                <asp:ListItem>R4</asp:ListItem>
                <asp:ListItem>R5</asp:ListItem>
                <asp:ListItem>R6</asp:ListItem>
                <asp:ListItem>R7</asp:ListItem>
                <asp:ListItem>R8</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="style17">
            <asp:DropDownList ID="DropDownList4" runat="server">
                <asp:ListItem>Select All</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" CommandName="Search" />
        </td>
    </tr>
    <tr>
        <td colspan="7" align="center">
            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                    CellPadding="1" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound"
                    PageSize="2" CellSpacing="1" HorizontalAlign="Center" >
                <%--   <PagerTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" Text="First" 
               CommandArgument="First" CommandName="Page"></asp:LinkButton>
             <asp:LinkButton ID="LinkButton2" runat="server" Text="Previous <<" 
               CommandArgument="Prev" CommandName="Page"></asp:LinkButton>
               <asp:LinkButton ID="LinkButton3" runat="server" Text=">> Next" 
               CommandArgument="Next" CommandName="Page"></asp:LinkButton>
                 <asp:LinkButton ID="LinkButton4" runat="server" Text="Last" 
               CommandArgument="Last" CommandName="Page"></asp:LinkButton>
          
                </PagerTemplate>--%>

                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />

                <Columns>
                    <asp:TemplateField HeaderText="S.No">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="A-END">
                        <ItemTemplate>
                            <%#Eval("A_END") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="B-END">
                        <ItemTemplate>
                            <%#Eval("B_END") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Band<br/>width">
                        <ItemTemplate>
                            <%#Eval("Bandwidth")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NOC<br/> Open">
                        <ItemTemplate>
                            <%#Eval("NOC_Open")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NOC <br/>Close ">
                        <ItemTemplate>
                            <%#Eval("NOC_Close")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LL Down<br/> Date">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("LLDown_Date")).ToShortDateString() %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LL Down<br/> Time">
                        <ItemTemplate>
                            <%#Eval("LLDown_Time")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Report <br> to <br> Agency">
                        <ItemTemplate>
                            <%#Eval("Report_Agency")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LL UP<br/> Date">
                        <ItemTemplate>
                            <%# Convert.ToDateTime(Eval("LLUP_Date")).ToShortDateString() %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LL UP<br/> Time">
                        <ItemTemplate>
                            <%#Eval("LLUP_Time")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Reason">
                        <ItemTemplate>
                            <asp:Label ID="Reasonid" runat="server" Text='<%#Eval("Reason")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Down Time">
                        <ItemTemplate>
                            <%#Eval("TotalDown_Time")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remark">
                        <ItemTemplate>
                            <%#Eval("Remark")%>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Docket<br/> No">
                        <ItemTemplate>
                            <%#Eval("Docket_No")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Min" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="ttmin" runat="server" Text='<%#Eval("Totalmin")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     
                </Columns>
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <FooterStyle BackColor="Maroon" ForeColor="#000066" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerSettings FirstPageText="First" LastPageText="Last" 
                        Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous" />
                <PagerStyle BackColor="#336699" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle ForeColor="#000066" Wrap="True" HorizontalAlign="Center"  CssClass="row" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />

<SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

<SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>

<SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

<SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>

            </asp:GridView>
            <asp:SqlDataSource ID="SearchData" runat="server" ConnectionString="<%$ ConnectionStrings:con_str %>" 
                   SelectCommand="select * from Downdetail where (A_End=@dhq or B_End=@dhq) AND LLUP_Date BETWEEN @dt1 AND @dt2">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBox1" Name="dt1" Type="DateTime" />
                    <asp:ControlParameter ControlID="TextBox2" Name="dt2" Type="DateTime" />
                    <asp:ControlParameter ControlID="Label19" Name="aend" Type="String" />
                    <asp:ControlParameter ControlID="DropDownList2" Name="bnd" Type="String" />
                    <asp:ControlParameter ControlID="DropDownList3" Name="rsn" Type="String" />
                    <asp:ControlParameter ControlID="DropDownList4" Name="bwth" Type="String" />
                    <asp:Parameter Name="sq" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
    </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" runat="server" 
    contentplaceholderid="ContentPlaceHolder10">
     <link href="Styles/style.css" rel="stylesheet" type="text/css" />
    <div class="foter" style="font-size:small;" >
    <table width="100%" id="stable" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="right">
                R1=> </td>
    
    
        <td align="left">
            <asp:Label ID="Label11" runat="server" Text="0"></asp:Label>
            </td>
   
        <td align="right">
                R2=> </td>
   
        <td align="left">
            <asp:Label ID="Label12" runat="server" Text="0"></asp:Label>
            </td>
    
        <td align="right">
                R3=> </td>
   
        <td align="left">
            <asp:Label ID="Label13" runat="server" Text="0"></asp:Label>
    </td>
        <td align="right">
                R4=> </td>
   
        <td align="left">
            <asp:Label ID="Label14" runat="server" Text="0"></asp:Label>
            </td>
     </tr>
    <tr>
        <td align="right">
                R5=> </td>
   
        <td align="left">
            <asp:Label ID="Label15" runat="server" Text="0"></asp:Label></td>
   
        <td align="right">  R6=> </td>
     
        <td align="left">
            <asp:Label ID="Label16" runat="server" Text="0"></asp:Label>
            </td>
    
        <td align="right">
                R7=> </td>
    
        <td align="left">
            <asp:Label ID="Label17" runat="server" Text="0"></asp:Label>
            </td>
    
        <td  align="right">
                R8=></td>
    
        <td align="left">
            <asp:Label ID="Label18" runat="server" Text="0"></asp:Label>
            </td>
    </tr>
</table></div>
</asp:Content>


<asp:Content ID="Content9" runat="server" 
    contentplaceholderid="ContentPlaceHolder9">
    <asp:TreeView ID="TreeView1" runat="server" Font-Size="Small">
                            <Nodes>
                                <asp:TreeNode NavigateUrl="~/DHQHome.aspx" Text="Home" 
                                    Value="Search Reports">
                                </asp:TreeNode>
                                <asp:TreeNode Text="District Downtime" Value="District Downtime" 
                                    NavigateUrl="~/DistrictDownDetail.aspx">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/Report.aspx" Text="Report" Value="Generate">
                                </asp:TreeNode>
                            </Nodes>
                        </asp:TreeView>
                    </asp:Content>



