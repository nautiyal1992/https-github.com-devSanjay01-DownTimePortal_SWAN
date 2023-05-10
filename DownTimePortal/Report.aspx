<%@ page title="" language="C#" masterpagefile="~/UserMaster.master" autoeventwireup="true" inherits="Report, App_Web_xjen1rsy" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder8" runat="Server">
    <table style="width: 100%; text-align: center;">
        <tr>
            <td>
                &nbsp;</td>
            <td style="color: #009900; text-align: center">
                     <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">Daily Down Time Report</asp:ListItem>
                    <asp:ListItem>Monthly Panelty Report</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                Your District :
                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Visible="False">
                </asp:DropDownList>
                <asp:Label ID="Label12" runat="server" Text="Select From Date :"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                    TargetControlID="TextBox1">
                </asp:CalendarExtender>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label13" runat="server" Text="Select To Date :"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                    TargetControlID="TextBox2">
                </asp:CalendarExtender>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Generate" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:GridView ID="GridView1" runat="server" 
                    Width="100%" Visible="False">
                    <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    
                </asp:GridView>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                    Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
                    WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" 
                    Height="600px">
                    
                </rsweb:ReportViewer>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
                    OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
                    TypeName="MajorissuesetTableAdapters.DowndetailTableAdapter">
                </asp:ObjectDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder10" runat="Server">
</asp:Content>
<asp:Content ID="Content9" runat="server" ContentPlaceHolderID="ContentPlaceHolder9">
    <asp:TreeView ID="TreeView1" runat="server" Font-Size="Small">
        <Nodes>
            <asp:TreeNode Text="Home" Value="Search Reports" NavigateUrl="~/DHQHome.aspx"></asp:TreeNode>
            <asp:TreeNode NavigateUrl="~/DistrictDownDetail.aspx" Text="District Downtime" Value="District Downtime">
            </asp:TreeNode>
            <asp:TreeNode Text="Report" Value="Report" NavigateUrl="~/Report.aspx"></asp:TreeNode>
        </Nodes>
    </asp:TreeView>
</asp:Content>
