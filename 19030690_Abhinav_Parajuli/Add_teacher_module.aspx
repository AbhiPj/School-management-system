<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Add_teacher_module.aspx.cs" Inherits="_19030690_Abhinav_Parajuli.Add_teacher_module" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <asp:DropDownList ID="TeacherDropdown" runat="server" DataSourceID="TeacherDatasource" DataTextField="TEACHER_NAME" DataValueField="TEACHER_ID">
    </asp:DropDownList>
    <asp:SqlDataSource ID="TeacherDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;TEACHER_ID&quot;, &quot;TEACHER_NAME&quot; FROM &quot;TEACHER&quot;"></asp:SqlDataSource>
    <asp:DropDownList ID="ModuleDropdown" runat="server" DataSourceID="ModuleDatasource" DataTextField="MODULE_NAME" DataValueField="MODULE_CODE">
    </asp:DropDownList>
    <asp:SqlDataSource ID="ModuleDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;MODULE_NAME&quot;, &quot;MODULE_CODE&quot; FROM &quot;MODULE&quot;"></asp:SqlDataSource>
    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Button" />

    <div>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="TEACHER_ID,TEACHER_NAME,MODULE_CODE,MODULE_NAME,CREDIT_HOUR" OnRowEditing="OnRowEditing" OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="100%" >
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>

    </div>
</asp:Content>
