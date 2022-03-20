<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Assignment.aspx.cs" Inherits="_19030690_Abhinav_Parajuli.Assignment" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:TextBox ID="AssignmentType" placeholder="Assignment Type" runat="server"></asp:TextBox>
    <asp:TextBox ID="txtID" runat="server" visible="false"></asp:TextBox>

    <asp:DropDownList ID="DepartmentDropdown" runat="server" DataSourceID="DepartmentDatasource" DataTextField="DEPARTMENT_NAME" DataValueField="DEPARTMENT_ID">
    </asp:DropDownList>
    <asp:GridView ID="assignmentGridview" runat="server" DataKeyNames="ASSIGNMENT_ID,ASSIGNMENT_TYPE,DEPARTMENT_ID,DEPARTMENT_NAME" OnRowEditing="OnRowEditing"  OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="100%" >
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
            <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Edit" />
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
    <asp:SqlDataSource ID="DepartmentDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;DEPARTMENT_ID&quot;, &quot;DEPARTMENT_NAME&quot; FROM &quot;DEPARTMENT&quot;"></asp:SqlDataSource>
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Button" Width="78px" />

</asp:Content>
