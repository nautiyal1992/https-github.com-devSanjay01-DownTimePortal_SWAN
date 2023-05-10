<%@ Page Title="" Language="C#" MasterPageFile="~/UserMaster.master" AutoEventWireup="true" CodeFile="MyDetail.aspx.cs" Inherits="DHQ_MyDetail" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder9" Runat="Server">
<asp:TreeView ID="TreeView1" runat="server" Font-Size="Small">
                            <Nodes>
                                <asp:TreeNode NavigateUrl="~/DHQ/DHQHome.aspx" Text="Home" 
                                    Value="Search Reports">
                                </asp:TreeNode>
                                <asp:TreeNode Text="District Downtime" Value="District Downtime" 
                                    NavigateUrl="~/DHQ/DistrictDownDetail.aspx">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/DHQ/Report.aspx" Text="Report" Value="Generate">
                                </asp:TreeNode>
                                <asp:TreeNode NavigateUrl="~/DHQ/MyDetail.aspx" Text="My Detail" 
                                    Value="My Detail"></asp:TreeNode>
                            </Nodes>
                        </asp:TreeView>
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" Runat="Server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        BackColor="White" BorderColor="Black" BorderStyle="Outset" BorderWidth="1px" 
        CellPadding="4" DataKeyNames="Email" DataSourceID="Detaildata" 
        ForeColor="Black" GridLines="Horizontal" Width="600px" 
        HorizontalAlign="Center">
        <CommandRowStyle BackColor="#CCCCCC" HorizontalAlign="Center" ForeColor="Blue" />
        <EditRowStyle BackColor="White" Font-Bold="False" ForeColor="Black" />
        <FieldHeaderStyle BackColor="#CCCCCC" Width="150px" />
        <Fields>
            <asp:TemplateField>
            <HeaderTemplate>Name :</HeaderTemplate>
            <ItemTemplate>
            <%#Eval("Name") %>           
            </ItemTemplate> 
            <EditItemTemplate>
            <asp:TextBox ID="uname" runat="server" Text='<%#Bind("Name") %>' placeholder=" Enter User Name"/>  
            <asp:RequiredFieldValidator ID="requirename" runat="server" 
                    ControlToValidate="uname" Display="Dynamic" ErrorMessage="Enter User Name" 
                    Font-Italic="True" ForeColor="Red"></asp:RequiredFieldValidator>
            </EditItemTemplate>           
            </asp:TemplateField>
             <asp:TemplateField>
            <HeaderTemplate>Email ID :</HeaderTemplate>
             <ItemTemplate>
            <%#Eval("Email") %>           
            </ItemTemplate>         
            </asp:TemplateField>
             <asp:TemplateField>
            <HeaderTemplate>Mobile :</HeaderTemplate>
            <ItemTemplate>
                     <%#Eval("Mobile") %>      
            </ItemTemplate>  
            <EditItemTemplate>
             <asp:TextBox ID="mobile" runat="server" Text='<%#Bind("Mobile") %>' placeholder="Enter Mobile No" MaxLength="10" TextMode="Phone"/>   
             <asp:RegularExpressionValidator ID="numberexpression" runat="server" 
                ErrorMessage="Mobile Number should be only on digit with 10 digit" 
                Font-Italic="True" ForeColor="Red" 
                ValidationExpression="^[0-9]{10}" ControlToValidate="mobile" 
                Display="Dynamic"></asp:RegularExpressionValidator>
            </EditItemTemplate>          
            </asp:TemplateField>
             <asp:TemplateField>
            <HeaderTemplate>Gender :</HeaderTemplate>
            <ItemTemplate>
                <%#Eval("Gender") %>             
            </ItemTemplate>  
            <EditItemTemplate>
                <asp:RadioButtonList ID="Genradio" runat="server" 
                    RepeatDirection="Horizontal">
                     <asp:ListItem Selected="True">Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
               
                </asp:RadioButtonList>
            </EditItemTemplate>          
            </asp:TemplateField>
             <asp:TemplateField>
            <HeaderTemplate>DOB :</HeaderTemplate>
            <ItemTemplate>
                <%#Convert.ToDateTime(Eval("DOB")).ToString("dd/MM/yyyy")%>                 
            </ItemTemplate>  
            <EditItemTemplate>
            <asp:TextBox ID="dob" runat="server" Text='<%#Bind("DOB","{0:dd/MM/yyyy}")%>' placeholder="Enter DOB" />  
                <asp:CalendarExtender ID="dob_CalendarExtender" runat="server" 
                    Format="dd/MM/yyyy" TargetControlID="dob">
                </asp:CalendarExtender>
                <asp:RegularExpressionValidator ID="dobexpresiion" runat="server" 
                ErrorMessage="Enter DOB on dd/MM/yyyy Format" 
                Font-Italic="True" ForeColor="Red" 
                ValidationExpression="(([0-1][1-9])|([1-2][0-9])|([3][0-1]))/([0][1-9]|([1][0-2]))/([0-9][0-9][0-9][0-9])" ControlToValidate="dob" 
                Display="Dynamic"></asp:RegularExpressionValidator>
            </EditItemTemplate>                       
            </asp:TemplateField>
             <asp:TemplateField>
            <HeaderTemplate>SHQ :</HeaderTemplate>
            <ItemTemplate>
                <%#Eval("SHQ") %>             
            </ItemTemplate>                          
            </asp:TemplateField>
             <asp:TemplateField>
            <HeaderTemplate>DHQ :</HeaderTemplate>
            <ItemTemplate>
             <%#Eval("DHQ") %>              
            </ItemTemplate>                    
            </asp:TemplateField>
             <asp:TemplateField>
            <HeaderTemplate>POP :</HeaderTemplate>
            <ItemTemplate>
            <%#Eval("POP") %>                                
            </ItemTemplate>                  
            </asp:TemplateField>
             <asp:TemplateField>
            <HeaderTemplate>Address :</HeaderTemplate>
            <ItemTemplate>
             <%#Eval("Address") %>                              
            </ItemTemplate>     
            <EditItemTemplate>
            <asp:TextBox ID="address" runat="server" Text='<%#Bind("Address") %>'
                  placeholder="Enter Address" Rows="4" TextMode="MultiLine" Height="50px" 
                    Width="250px" /> 
            </EditItemTemplate>       
            </asp:TemplateField>
             <asp:TemplateField>
            <HeaderTemplate>Permission :</HeaderTemplate>
            <ItemTemplate>
               <p style="color:Green;";><%#Eval("Permission") %> </p>       
            </ItemTemplate>            
            </asp:TemplateField>
             <asp:TemplateField>
            <HeaderTemplate>Account Date :</HeaderTemplate>
            <ItemTemplate>
                <p ><%#Eval("AC_Date") %> </p>              
            </ItemTemplate>            
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-BackColor="ActiveCaption" HeaderStyle-BackColor="ActiveCaption" >
            <ItemTemplate>
             <asp:Button ID="Button1" runat="server" Text="Edit" CommandName="Edit" 
                    Width="100px"/> 
            </ItemTemplate>
            <EditItemTemplate>
               <asp:Button ID="Button2" runat="server" Text="Update"  CommandName="Update"  
                    Width="100px" onclick="Button2_Click" />
             <asp:Button ID="Button3" runat="server" Text="Cancel" CommandName="cancel"  Width="100px" /> 
            </EditItemTemplate>

<HeaderStyle BackColor="ActiveCaption"></HeaderStyle>

<ItemStyle BackColor="ActiveCaption"></ItemStyle>
            </asp:TemplateField>
            </Fields>
                    
              <FooterStyle BackColor="#CCCC99" ForeColor="Black" HorizontalAlign="Center" />
        <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="White" 
            VerticalAlign="Middle" Width="150px" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />       
    </asp:DetailsView>
    <asp:SqlDataSource ID="Detaildata" runat="server" ConnectionString="<%$ ConnectionStrings:con_str %>" 
         SelectCommand="SELECT * FROM [AccountDetail] where Email=@eml" >
        <SelectParameters>
        <asp:SessionParameter Name="eml" SessionField="name"  DbType="String" />
        </SelectParameters>
        </asp:SqlDataSource>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder10" Runat="Server">

</asp:Content>

